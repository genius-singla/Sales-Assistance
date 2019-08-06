using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using System.Collections.Generic;
using Android.Database;
using System;
using Android.Support.V7.Widget;


namespace App7
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar")]
    public class Purchase :Activity
    {
        DBHelper myDB;
        ListView PoductlistView;
        ICursor ic;
        List<PurchaseList_CustomAdapter> myProList = new List<PurchaseList_CustomAdapter>();

        Purchase_CustomAdapter searchAdapter;
        Android.Widget.SearchView sv;

        //string[] myArray;
        EditText date;
        Spinner spinner_purchase1;
        Spinner spinner_purchase2;
        ListView listView;
        Button purchase_button;
        ImageView logo_pur;
        string[] vendor = { "gill saab", "sandy", "genius" };
        string[] myUnit1 = { "Kg", "lb" };
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
            listView = FindViewById<ListView>(Resource.Id.listView1);
            date = FindViewById<EditText>(Resource.Id.edt_txt_date);

            date.Text = System.DateTime.Now.ToShortDateString();
            myDB = new DBHelper(this);
            myDB.product_list();
            ic = myDB.product_list();

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


            spinner_purchase1.Adapter = new ArrayAdapter
              (this, Android.Resource.Layout.SimpleListItem1, vendor);

            spinner_purchase1.ItemSelected += MyItemSelectedMethod2;
            spinner_purchase2.Adapter = new ArrayAdapter
             (this, Android.Resource.Layout.SimpleListItem1, myUnit1);


            spinner_purchase2.ItemSelected += MyItemSelectedMethod3;

            //myAdapter = new ArrayAdapter(this, Android.Resource.Layout.SimpleListItem1, myUsersList);
            myCAdapter = new Purchase_CustomAdapter(this, myUsersList);
            listView.Adapter = myCAdapter;
            listView.ItemClick += listView_ItemClick;
            sv = FindViewById<Android.Widget.SearchView>(Resource.Id.searchID_pro);
            sv.QueryTextChange += Sv_QueryTextChange;
        }

        private void MyItemSelectedMethod3(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            var index = e.Position;

            var value = vendor[index];
            System.Console.WriteLine("value is " + value);


            if (value.ToLower().Equals("Action"))
            {
                //create a veg array and create as a new adater 

            }

        }

        private void MyItemSelectedMethod2(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            var index = e.Position;

            var value = myUnit1[index];
            System.Console.WriteLine("value is " + value);


            if (value.ToLower().Equals("Action"))
            {
                //create a veg array and create as a new adater 

            }

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
                    System.Console.WriteLine("You did it");
                    mylist.Add(myUsersList[i]);
                }
            }

            searchAdapter = new Purchase_CustomAdapter(this, mylist);
            listView.Adapter = searchAdapter;
        }

        private void listView_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            var index = e.Position;
            System.Console.WriteLine(myUsersList[index]);

        }

    }


}
