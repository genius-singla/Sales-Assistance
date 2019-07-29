using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Database;
using Android.OS;
using Android.Runtime;
using Android.Text;
using Android.Views;
using Android.Widget;

namespace App7
{
    [Activity(Label = "Changepassword",Theme = "@style/AppTheme.NoActionBar")]
    public class Changepassword : Activity
    {
        string userName;
        EditText old_pwd;
        EditText new_pwd;
        EditText confirm_pwd;
        Button change_pwd;
        DBHelper myDB;
        ICursor cursor;
        AlertDialog alert;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Changepassword);
            userName = Intent.GetStringExtra("userName");
            old_pwd = FindViewById<EditText>(Resource.Id.oldassword);
            new_pwd = FindViewById<EditText>(Resource.Id.newpwd);
            confirm_pwd = FindViewById<EditText>(Resource.Id.confirmpwd);
            change_pwd = FindViewById<Button>(Resource.Id.changepassword_btn);
            myDB = new DBHelper(this);
            confirm_pwd.TextChanged += match_password;

            change_pwd.Click += chk_paswd;
            // Create your application here
        }

        private void match_password(object sender, TextChangedEventArgs e)
        {
            if(confirm_pwd.Text!=new_pwd.Text)
            {
                confirm_pwd.Error = "Password Mismatch!";
                change_pwd.Enabled = false;
            }
            else
            {
                change_pwd.Enabled = true;
            }
        }

        private void chk_paswd(object sender, EventArgs e)
        {
            if(userName=="admin")
            {
                cursor = myDB.chk_admin_passwod();
                cursor.MoveToFirst();
                string pswd = cursor.GetString(cursor.GetColumnIndexOrThrow("adm_password"));
                if (pswd == old_pwd.Text)
                {
                    myDB.update_admin_password(new_pwd.Text);
                }
                else
                {
                    Console.WriteLine("Wrong Password!");
                }
            }
            else
            {
                cursor = myDB.chk_sales_person_Password(userName);
                cursor.MoveToFirst();
                string pswd = cursor.GetString(cursor.GetColumnIndexOrThrow("sp_password"));
                if (pswd == old_pwd.Text)
                {
                    myDB.update_sales_person_password(userName ,new_pwd.Text);
                }
                else
                {
                    Console.WriteLine("Wrong Password!");
                }
            }
            
        }
    }
}