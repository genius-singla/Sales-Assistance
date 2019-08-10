using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Database;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace App7
{
    [Activity(Label = "Order", Theme = "@style/AppTheme.NoActionBar")]
    public class Order : Activity
    {
        DBHelper myDB;
        ICursor ic;
        int cust_id;
        int cat = 0;
        int or_id;
        int ind;
        int total_amt = 0;
        string add_product;
        int add_id;
        int add_price;
        Order_CustomAdapter searchAdapter;
        Android.Widget.SearchView sv;
        Android.App.AlertDialog.Builder alert;
        EditText date;
        Spinner spinner_order1;
        Spinner spinner_order2;
        ListView listView1;
        Button order_button;
        EditText et;
        ImageView logo_or;
        List<string> customer = new List<string>();

        Dictionary<string, int> customer_dict = new Dictionary<string, int>();

        List<string> myUnit1 = new List<string>();
        Dictionary<string, int> category_dict = new Dictionary<string, int>();
        Order_CustomAdapter myCAdapter;

        List<UserObject_Order> myUsersList = new List<UserObject_Order>();
        List<UserObject_Order> myPurchaseList = new List<UserObject_Order>();
        
        

        //string[] myArray;
       
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.order_activity);
            spinner_order1 = FindViewById<Spinner>(Resource.Id.spinner_order);
            spinner_order2 = FindViewById<Spinner>(Resource.Id.spinner_order2);
            logo_or = FindViewById<ImageView>(Resource.Id.image_logo_pur);
            listView1 = FindViewById<ListView>(Resource.Id.order_listView1);
            date = FindViewById<EditText>(Resource.Id.date_order);
            order_button = FindViewById<Button>(Resource.Id.order_btn);
            //sv = FindViewById<SearchView>(Resource.Id.searchID_order);
            alert = new Android.App.AlertDialog.Builder(this);
            myDB = new DBHelper(this);

            ic = myDB.OrderID();
            ic.MoveToFirst();

            or_id = ic.GetInt(ic.GetColumnIndexOrThrow("max_id")) + 1;


            ic = myDB.customer_list();

            int j = 1;
            while (ic.MoveToNext())
            {
                var a = ic.GetString(ic.GetColumnIndex("c_company_name"));
                var b = ic.GetInt(ic.GetColumnIndex("customer_id"));
                customer_dict.Add(a, b);
                customer.Add(a);
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

            order_button.Click += delegate
            {
                myDB.insertOrder(or_id, cust_id, date.Text, total_amt);
            };
            listView1.ItemClick += listView1_ItemClick1;

            date.Text = System.DateTime.Now.ToShortDateString();
            //myDB = new DBHelper(this);
            showProductList();

            spinner_order1.Adapter = new ArrayAdapter
              (this, Android.Resource.Layout.SimpleListItem1, customer);

            spinner_order1.ItemSelected += MyItemSelectedMethod2;

            spinner_order2.Adapter = new ArrayAdapter
             (this, Android.Resource.Layout.SimpleListItem1, myUnit1);

            spinner_order2.ItemSelected += MyItemSelectedMethod3;

            sv = FindViewById<SearchView>(Resource.Id.searchID_order);
            sv.QueryTextChange += Sv_QueryTextChange;
        }

        private void MyItemSelectedMethod2(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            var index = e.Position;

            var value = customer[index];
            System.Console.WriteLine("value is " + value);

            customer_dict.TryGetValue(value, out cust_id);
            Console.WriteLine(cust_id);

        }

    

    public void showProductList()
        {
            ic = myDB.product_list();

            int i = 0;
            myUsersList = new List<UserObject_Order>();
            while (ic.MoveToNext())
            {
                var a = ic.GetString(ic.GetColumnIndex("pro_name"));
                var b = ic.GetInt(ic.GetColumnIndex("purchase_price"));
                var c = ic.GetInt(ic.GetColumnIndex("pro_id"));
                Console.WriteLine(a);
                Console.WriteLine(b);
                myUsersList.Add(new UserObject_Order(a, b, c));
                i++;
            }
            myCAdapter = new Order_CustomAdapter(this, myUsersList);
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
                myUsersList = new List<UserObject_Order>();
                int i = 0;
                while (ic.MoveToNext())
                {
                    var a = ic.GetString(ic.GetColumnIndex("pro_name"));
                    var b = ic.GetInt(ic.GetColumnIndex("purchase_price"));
                    var c = ic.GetInt(ic.GetColumnIndex("pro_id"));
                    Console.WriteLine(a);
                    Console.WriteLine(b);

                    myUsersList.Add(new UserObject_Order(a, b, c));
                    i++;
                }
                myCAdapter = new Order_CustomAdapter(this, myUsersList);
                listView1.Adapter = myCAdapter;
            }
        }


        private void Sv_QueryTextChange(object sender, Android.Widget.SearchView.QueryTextChangeEventArgs e)
        {
            UserObject_Order myObj;
            List<UserObject_Order> mylist = new List<UserObject_Order>();
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

            searchAdapter = new Order_CustomAdapter(this, mylist);
            listView1.Adapter = searchAdapter;
        }
        private void listView1_ItemClick1(object sender, AdapterView.ItemClickEventArgs e)
        {
            var index = e.Position;
            ind = index;
            System.Console.WriteLine(myUsersList[index]);
            UserObject_Order up;
            up = myUsersList[index];
            add_id = up.or_id;
            add_price = up.pr;
            et = new EditText(this);
            alert.SetTitle("Insert");
            alert.SetMessage("Please Insert the Quantity");
            alert.SetView(et);
            alert.SetPositiveButton("OK", alertOKButton);

            alert.SetNegativeButton("Cancel", alertCancelButton);
            //Dialog myDialog = alert.Create();
            Android.App.AlertDialog myDialog = alert.Create();
            myDialog.Show();
        }

        private void alertCancelButton(object sender, DialogClickEventArgs e)
        {
           
        }

        private void alertOKButton(object sender, DialogClickEventArgs e)
        {
            int a = Convert.ToInt32(et.Text);
            if (a != null || a != 0)
            {
                myDB.insertOrderProduct(or_id, add_id, a);
                total_amt = total_amt + (a * add_price);
            }
        }
    }
}