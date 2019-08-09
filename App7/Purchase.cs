using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using System.Collections.Generic;
using Android.Database;
using System;
using Android.Support.V7.Widget;
using Android.Text;

namespace App7
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar")]
    public class Purchase :Activity
    {
        DBHelper myDB;
        ICursor ic;
        int ven_id;
        int cat = 0;
        int ind;
        int total_amt = 0;
        Purchase_CustomAdapter searchAdapter;
        Android.Widget.SearchView sv;
        
        EditText date;
        Spinner spinner_purchase1;
        Spinner spinner_purchase2;
        ListView listView1;
        Button purchase_button;
        ImageView logo_pur;
        List<string> vendor = new List<string>();

        Dictionary<string, int> vendor_dict = new Dictionary<string, int>();
        
        List<string> myUnit1 = new List<string>();
        Dictionary<string, int> category_dict = new Dictionary<string, int>();
        Purchase_CustomAdapter myCAdapter;

        List<UserObject_purchase> myUsersList = new List<UserObject_purchase>();
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.purchase_activity);
            spinner_purchase1 = FindViewById<Spinner>(Resource.Id.spinner_pur1);
            spinner_purchase2 = FindViewById<Spinner>(Resource.Id.spinner_pur2);
            logo_pur = FindViewById<ImageView>(Resource.Id.image_logo_pur);
            purchase_button = FindViewById<Button>(Resource.Id.purchase_btn);
            listView1 = FindViewById<ListView>(Resource.Id.listView1);
            date = FindViewById<EditText>(Resource.Id.edt_txt_date);
            myDB = new DBHelper(this);
            ic = myDB.vendor_list();
            
            int j = 1;
            while (ic.MoveToNext())
            {
                var a = ic.GetString(ic.GetColumnIndex("v_company_name"));
                var b = ic.GetInt(ic.GetColumnIndex("vendor_id"));
                vendor_dict.Add(a, b);
                vendor.Add(a);
                j++;
            }
            
            ic = myDB.category_list();
            myUnit1.Add("All Categories");
            int k = 0;
            while (ic.MoveToNext())
            {
                var a = ic.GetString(ic.GetColumnIndex("cat_name"));
                var b = ic.GetInt(ic.GetColumnIndex("cat_id"));
                myUnit1.Add(a);
                category_dict.Add(a, b);
                k++;
            }

            purchase_button.Click += delegate
            {
                myDB.insertPurchase(ven_id, date.Text, total_amt);
            };
            listView1.ItemClick += listView_ItemClick1;

            date.Text = System.DateTime.Now.ToShortDateString();
            //myDB = new DBHelper(this);
            showProductList();
            
            spinner_purchase1.Adapter = new ArrayAdapter
              (this, Android.Resource.Layout.SimpleListItem1, vendor);

            spinner_purchase1.ItemSelected += MyItemSelectedMethod2;

            spinner_purchase2.Adapter = new ArrayAdapter
             (this, Android.Resource.Layout.SimpleListItem1, myUnit1);

            spinner_purchase2.ItemSelected += MyItemSelectedMethod3;
            
            sv = FindViewById<Android.Widget.SearchView>(Resource.Id.searchID_pro);
            sv.QueryTextChange += Sv_QueryTextChange;
        }

        public void showProductList()
        {
            ic = myDB.product_list();

            int i = 0;
            myUsersList = new List<UserObject_purchase>();
            while (ic.MoveToNext())
            {
                var a = ic.GetString(ic.GetColumnIndex("pro_name"));
                var b = ic.GetInt(ic.GetColumnIndex("purchase_price"));
                Console.WriteLine(a);
                Console.WriteLine(b);
                myUsersList.Add(new UserObject_purchase(a, b));
                i++;
            }
            myCAdapter = new Purchase_CustomAdapter(this, myUsersList);
            listView1.Adapter = myCAdapter;
        }

        private void MyItemSelectedMethod3(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            var index = e.Position;

            var value = myUnit1[index];
            if (value == "All Categories")
            {
                showProductList();
                
            }
            else
            {
                category_dict.TryGetValue(value, out cat);
                ic = myDB.product_list1(cat);
                myUsersList = new List<UserObject_purchase>();
                int i = 0;
                while (ic.MoveToNext())
                {
                    var a = ic.GetString(ic.GetColumnIndex("pro_name"));
                    var b = ic.GetInt(ic.GetColumnIndex("purchase_price"));
                    Console.WriteLine(a);
                    Console.WriteLine(b);
                    
                    myUsersList.Add(new UserObject_purchase(a, b));
                    i++;
                }
                myCAdapter = new Purchase_CustomAdapter(this, myUsersList);
                listView1.Adapter = myCAdapter;
            }
        }

        private void MyItemSelectedMethod2(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            var index = e.Position;

            var value = myUnit1[index];
            System.Console.WriteLine("value is " + value);
            
            vendor_dict.TryGetValue(value, out ven_id);
           
        }

        private void Sv_QueryTextChange(object sender, Android.Widget.SearchView.QueryTextChangeEventArgs e)
        {
            UserObject_purchase myObj;
            List<UserObject_purchase> mylist = new List<UserObject_purchase>();
            //throw new System.NotImplementedException();
            var mySearchValue = e.NewText;
            System.Console.WriteLine("Search Text is :  is \n\n " + mySearchValue);

            for (int i = 0; i < myUsersList.Count; i++)
            {
                myObj = myUsersList[i];
                if (myObj.name.ToLower().Contains(mySearchValue))
                {
                    mylist.Add(myUsersList[i]);
                }
            }

            searchAdapter = new Purchase_CustomAdapter(this, mylist);
            listView1.Adapter = searchAdapter;
        }

        private void listView_ItemClick1(object sender, AdapterView.ItemClickEventArgs e)
        {
            var index = e.Position;
            ind = index;
            System.Console.WriteLine(myUsersList[index]);
            //EditText qty = FindViewById<EditText>(Resource.Id.p_qty);
            //Console.WriteLine(myUsersList[index].);
            ((EditText)index).TextChanged += getQty;
            //Console.WriteLine(qt);
        }

        private void getQty(object sender, TextChangedEventArgs e)
        {
            Console.WriteLine(((EditText)ind).Text);
        }
    }
    
}
