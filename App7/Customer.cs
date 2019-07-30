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
    [Activity(Label = "Customer", Theme = "@style/AppTheme.NoActionBar")]
    public class Customer : Activity
    {
        EditText cust_cmpny_name;
        EditText cust_address;
        EditText cust_city;
        EditText cust_province;
        EditText cust_contact_nme;
        EditText cust_contact_no;
        EditText cust_email;
        Button ad_cust;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.add_customer);
            cust_cmpny_name = FindViewById<EditText>(Resource.Id.cust_company_name_id);
            cust_address = FindViewById<EditText>(Resource.Id.customer_address);
            cust_city = FindViewById<EditText>(Resource.Id.cust_city_text);
            cust_province = FindViewById<EditText>(Resource.Id.cust_street_id);
            cust_contact_nme = FindViewById<EditText>(Resource.Id.cust_contact_name_id);
            cust_contact_no = FindViewById<EditText>(Resource.Id.cust_contact_id);
            ad_cust = FindViewById<Button>(Resource.Id.cust_btn);
            cust_email = FindViewById<EditText>(Resource.Id.cust_email);

            // Create your application here
        }
    }
}