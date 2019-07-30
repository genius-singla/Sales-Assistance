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
        }
    }
}