using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.App;
using Android.Content;
using Android.Database;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.App;
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
        DBHelper myDB;


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


           
            listView = FindViewById<ListView>(Resource.Id.favourite_list);
            myDB = new DBHelper(this);
            ic = myDB.favList();
            while(ic.MoveToNext())
            {
                var id = ic.GetInt(ic.GetColumnIndexOrThrow("ven_id"));
                var name = ic.GetString(ic.GetColumnIndexOrThrow("v_company_name"));
                var contact = ic.GetString(ic.GetColumnIndexOrThrow("v_contact_number"));
                favouriteList.Add(new UserObject_favourite(id, name, contact));
            }

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