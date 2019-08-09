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
    [Activity(Label = "Vendor", Theme = "@style/AppTheme.NoActionBar")]
    public class Vendor : Activity
    {
        EditText cmpny_name;
        EditText ven_address;
        EditText ven_city;
        EditText ven_province;
        EditText ven_contact_nme;
        EditText ven_contact_no;
        Button ad_ven;
        DBHelper myDB;
        bool fav = false;
        Android.App.AlertDialog.Builder alert;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.add_vendor);
            cmpny_name = FindViewById<EditText>(Resource.Id.company_name_id);
            ven_address = FindViewById<EditText>(Resource.Id.vendor_address);
            ven_city = FindViewById<EditText>(Resource.Id.city_text);
            ven_province = FindViewById<EditText>(Resource.Id.vendor_street_id);
            ven_contact_nme = FindViewById<EditText>(Resource.Id.vendor_contact_name_id);
            ven_contact_no = FindViewById<EditText>(Resource.Id.vendor_contact_id);
            ad_ven = FindViewById<Button>(Resource.Id.vendor_btn);
            alert = new Android.App.AlertDialog.Builder(this);
            ad_ven.Click += AddVendor;
        }

        private void AddVendor(object sender, EventArgs e)
        {
            alert.SetTitle("Favourite");
            alert.SetMessage("Do you want to save this Vendor as Favourite?");
            alert.SetPositiveButton("Yes", alertOKButton);

            alert.SetNegativeButton("Cancel", alertCancelButton);
            //Dialog myDialog = alert.Create();
            Android.App.AlertDialog myDialog = alert.Create();
            myDialog.Show();
            
        }

        public void insert()
        {
            myDB = new DBHelper(this);
            myDB.InsertVendor(cmpny_name.Text, ven_address.Text,
                ven_city.Text, ven_province.Text, ven_contact_nme.Text, ven_contact_no.Text, fav);
            string toast = string.Format("Vendor Added Successfully!");
            Toast.MakeText(this, toast, ToastLength.Long).Show();
            Intent newscreen = new Intent(this, typeof(Activity));
            StartActivity(newscreen);
        }

        private void alertCancelButton(object sender, DialogClickEventArgs e)
        {
            insert();
            //throw new NotImplementedException();
        }

        private void alertOKButton(object sender, DialogClickEventArgs e)
        {
            fav = true;
            insert();
        }
    }
}