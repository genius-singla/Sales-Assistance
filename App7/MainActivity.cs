﻿using Android.App;
using Android.OS;
//using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using System;
using Android.Database;
using Android.Text;

namespace App7
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : Activity
    {
        ICursor cursor;
        DBHelper myDB;
        EditText login_username;
        EditText login_passowrd;
        RadioButton login_admin;
        RadioButton login_sales_person;
        Button login_button;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
          
            SetContentView(Resource.Layout.activity_main);
            login_username = FindViewById<EditText>(Resource.Id.login_edit_username);
            login_passowrd = FindViewById<EditText>(Resource.Id.login_edit_password);
            login_admin = FindViewById<RadioButton>(Resource.Id.login_radio_admin);
            login_sales_person = FindViewById<RadioButton>(Resource.Id.login_radio_sales_person);
            login_button = FindViewById<Button>(Resource.Id.login_btn);
            myDB = new DBHelper(this);
            login_button.Click += delegate {
                login();
            };
            login_username.TextChanged += login_user_textChanged;

            
        }

        private void login_user_textChanged(object sender, TextChangedEventArgs e)
        {
            if((login_username.Text.Contains("@") && login_username.Text.Contains(".")) || login_username.Text=="admin")
            {
                Console.WriteLine("Valid Email");
            }
            else
            {
                login_username.Error = "Invalid Email";
            }
        }

        private void login()
        {
            if(login_admin.Checked)
            {
                cursor = myDB.SelectMyAdmindata();
                cursor.MoveToFirst();
                var un = cursor.GetString(cursor.GetColumnIndexOrThrow("adm_name"));
                var pswd = cursor.GetString(cursor.GetColumnIndexOrThrow("adm_password"));
                if(login_username.Text == un && login_passowrd.Text == pswd)
                {
                    System.Console.WriteLine("Successfully logged in!!");
                }
                else
                {
                    System.Console.WriteLine("Wrong username and password");
                }
            }
            else
            {

            }
        }
    }
}