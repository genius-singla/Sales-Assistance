﻿using System;
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
    [Activity(Label = "Registration")]
    public class Registration : Activity
    {
        EditText first_name;
        EditText last_name;
        EditText e_mail;
        EditText c_num;
        EditText addrs;
        EditText temppwd;
        Button registration;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Registration);

            // Create your application here
            first_name = FindViewById<EditText>(Resource.Id.fname);
            last_name = FindViewById<EditText>(Resource.Id.lname);
            e_mail = FindViewById<EditText>(Resource.Id.email);
             c_num= FindViewById<EditText>(Resource.Id.contact);
            addrs = FindViewById<EditText>(Resource.Id.address);
            temppwd = FindViewById<EditText>(Resource.Id.temporarypwd);
            registration = FindViewById<Button>(Resource.Id.register);

        }
    }
}