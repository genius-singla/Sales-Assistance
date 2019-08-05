using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace App7
{
    [Activity(Label = "Order", Theme = "@style/AppTheme.NoActionBar")]
    public class Order : Activity
    {
        Order_CustomAdapter searchAdapter;
        Android.Widget.SearchView sv;

        //string[] myArray;
        DatePicker date;
        Spinner spinner_purchase1;
        Spinner spinner_purchase2;
        ListView listView;
        ImageView logo_pur;
        string[] customer = { "Aujla", "Parveer", "Suman" };
        string[] myUnit1 = { "Kg", "lb" };
        Order_CustomAdapter myCAdapter;

        List<UserObject_Order> myUsersList = new List<UserObject_Order>();
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.order_activity);
            spinner_purchase1 = FindViewById<Spinner>(Resource.Id.spinner_order);
            spinner_purchase2 = FindViewById<Spinner>(Resource.Id.spinner_order2);
            logo_pur = FindViewById<ImageView>(Resource.Id.image_logo_pur);
            listView = FindViewById<ListView>(Resource.Id.order_listView1);
            date = FindViewById<DatePicker>(Resource.Id.datepick_order);
            spinner_purchase1.Adapter = new ArrayAdapter
              (this, Android.Resource.Layout.SimpleListItem1, customer);

            spinner_purchase1.ItemSelected += MyItemSelectedMethod2;
            spinner_purchase2.Adapter = new ArrayAdapter
             (this, Android.Resource.Layout.SimpleListItem1, myUnit1);


            spinner_purchase2.ItemSelected += MyItemSelectedMethod3;

            //myAdapter = new ArrayAdapter(this, Android.Resource.Layout.SimpleListItem1, myUsersList);
            myCAdapter = new Order_CustomAdapter(this, myUsersList);
            listView.Adapter = myCAdapter;
            listView.ItemClick += listView_ItemClick;
            sv = FindViewById<Android.Widget.SearchView>(Resource.Id.searchID_order);
            sv.QueryTextChange += Sv_QueryTextChange;
        }

        private void MyItemSelectedMethod2(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            var index = e.Position;

            var value = customer[index];
            System.Console.WriteLine("value is " + value);


            if (value.ToLower().Equals("All Category"))
            {
                //create a veg array and create as a new adater 

            }

        }

        private void MyItemSelectedMethod3(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            var index = e.Position;

            var value = myUnit1[index];
            System.Console.WriteLine("value is " + value);


            if (value.ToLower().Equals("Customer Name 1"))
            {
                //create a veg array and create as a new adater 

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
                    System.Console.WriteLine("You did it");
                    mylist.Add(myUsersList[i]);
                }
            }

            searchAdapter = new Order_CustomAdapter(this, mylist);
            listView.Adapter = searchAdapter;
        }

        private void listView_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            var index = e.Position;
            System.Console.WriteLine(myUsersList[index]);

        }
    }
}