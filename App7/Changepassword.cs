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
    [Activity(Label = "Changepassword")]
    public class Changepassword : Activity
    {
        EditText old_pwd;
        EditText new_pwd;
        EditText confirm_pwd;
        Button change_pwd;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Changepassword);
            old_pwd = FindViewById<EditText>(Resource.Id.oldassword);
            new_pwd = FindViewById<EditText>(Resource.Id.newpwd);
            confirm_pwd = FindViewById<EditText>(Resource.Id.confirmpwd);
            change_pwd = FindViewById<Button>(Resource.Id.changepassword);
            // Create your application here
        }
    }
}