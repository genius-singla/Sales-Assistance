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
    [Activity(Label = "Favourite", Theme = "@style/AppTheme.NoActionBar")]
    public class Favourite : Activity
    {
        ListView listView;
        ICursor ic;
        TextView vendor_id;
        TextView vendor_name;
        TextView contact;



        Favourite_CustomAdapter myorderAdapter;
        List<UserObject_favourite> favouriteList = new List<UserObject_favourite>();
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.favourite_mainactivity);
            vendor_id = FindViewById<TextView>(Resource.Id.vendor_id_vendorList);
            vendor_name = FindViewById<TextView>(Resource.Id.vendor_name_list);
            contact = FindViewById<TextView>(Resource.Id.contact);


            // myDB = new DBHelper(this);
            // myDB.category_list();
            //ic = myDB.category_list();
            //myArray = new string[ic.Count];
            /* int i = 0;
             while (ic.MoveToNext())
             {
                 var a = ic.GetString(ic.GetColumnIndex("cat_name"));
                 var b = ic.GetInt(ic.GetColumnIndex("cat_img"));
                 Console.WriteLine(a);
                 Console.WriteLine(b);
                 purchaseList.Add(new UserObject_PurchaseList(a, b));
                 i++;
             }*/

            listView = FindViewById<ListView>(Resource.Id.favourite_list);
            //myAdapter = new ArrayAdapter(this, Android.Resource.Layout.SimpleListItem1, myUsersList);
            myorderAdapter = new Favourite_CustomAdapter(this, favouriteList);
            listView.Adapter = myorderAdapter;
            /*add.Click += delegate
            {
                Intent newscreen = new Intent(this, typeof(Purchase));
                StartActivity(newscreen);
            };*/
        }
    }
}