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
    [Activity(Label = "sales_person_dashboard")]
    public class sales_person_dashboard : Activity
    {
        string user_email;
        LinearLayout sales_chg_pswd;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.sales_person_dashboard);
            user_email = Intent.GetStringExtra("email");
            sales_chg_pswd = FindViewById<LinearLayout>(Resource.Id.sales_layout_chg_pswd);
            sales_chg_pswd.Click += delegate
              {
                  Intent newscreen = new Intent(this, typeof(Changepassword));
                  newscreen.PutExtra("userName", user_email);
                  StartActivity(newscreen);
              };
        }
    }
}