﻿using Android.Support.V4.App;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;

namespace App7
{
    public class Fragment1 : Android.Support.V4.App.Fragment
    {
        public String user1;
        Android.Database.ICursor i;
        ArrayAdapter myAdapterarray;
        List<string> rsname = new List<string>();

        DBHelper myDB;

        public String myName;
        public Activity myContext;
        public WelcomeScreen welcomeScreen;

        public Fragment1(Activity context)
        {

            myContext = context;
        }

        public Fragment1(WelcomeScreen welcomeScreen)
        {
            this.welcomeScreen = welcomeScreen;
        }

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            DBHelper myDB = new DBHelper(this.Context);
            //myDB.pendingOrder();
            i = myDB.pendingOrder();
            while (i.MoveToNext())
            {
                string a = i.GetString(i.GetColumnIndexOrThrow("order_id"));
                Console.WriteLine(a);
                rsname.Add(a);
            }
            View myView = inflater.Inflate(Resource.Layout.FFragmentLayout, container, false);
            ListView myList = myView.FindViewById<ListView>(Resource.Id.listID);
           // myView.FindViewById<TextView>(Resource.Id.myNameIdl).Text = myName;

            myList.Adapter = new ArrayAdapter(this.Activity, Android.Resource.Layout.SimpleListItem1, rsname);

            myList.ItemClick += OnItemClick;
            return myView;
            
        }

        private void OnItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {

            //rsname = new List<string>();
            myDB = new DBHelper(this.Context);
            int index = e.Position;
            var value = rsname[index];
            myDB.updateOrderStatus(value);
        }
    }
    public class Fragment2 : Android.Support.V4.App.Fragment
    {
        public String user1;
        Android.Database.ICursor i;
        ArrayAdapter myAdapterarray;
        List<string> rsname = new List<string>();

        DBHelper myDB;

        public String myName;
        public Activity myContext;
        public WelcomeScreen welcomeScreen;

        public Fragment2(Activity context)
        {

            myContext = context;
        }

        public Fragment2(WelcomeScreen welcomeScreen)
        {
            this.welcomeScreen = welcomeScreen;
        }

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {

            DBHelper myDB = new DBHelper(this.Context);
            myDB.completeOrder();
            i = myDB.completeOrder();
            while (i.MoveToNext())
            {
                string a = i.GetString(i.GetColumnIndexOrThrow("order_id"));
                Console.WriteLine(a);
                rsname.Add(a);
            }
            View myView = inflater.Inflate(Resource.Layout.SFragmentLayout, container, false);
            ListView myList = myView.FindViewById<ListView>(Resource.Id.listID1);
            // myView.FindViewById<TextView>(Resource.Id.myNameIdl).Text = myName;

            myList.Adapter = new ArrayAdapter(this.Activity, Android.Resource.Layout.SimpleListItem1, rsname);
            return myView;


        }
    }
}
