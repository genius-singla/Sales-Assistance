using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using System;
using Android.Database;
using Android.Text;
using Android.Content;

namespace App7
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
    public class MainActivity : Activity
    {
        ICursor cursor;
        DBHelper myDB;
        EditText login_username;
        EditText login_passowrd;
        RadioButton login_admin;
        RadioButton login_sales_person;
        Button login_button;
        Android.App.AlertDialog.Builder alert;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
          
            SetContentView(Resource.Layout.activity_main);
            login_username = FindViewById<EditText>(Resource.Id.login_edit_username);
            login_passowrd = FindViewById<EditText>(Resource.Id.login_edit_password);
            login_admin = FindViewById<RadioButton>(Resource.Id.login_radio_admin);
            login_sales_person = FindViewById<RadioButton>(Resource.Id.login_radio_sales_person);
            login_button = FindViewById<Button>(Resource.Id.login_btn);
            alert = new Android.App.AlertDialog.Builder(this);
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
                login_button.Enabled = true;
            }
            else
            {
                login_username.Error = "Invalid Email";
                login_button.Enabled = false;
            }
        }

        private void alertOKButton(object sender, DialogClickEventArgs e)
        {
            login_username.Text = "";
            login_passowrd.Text = "";
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
                    Intent newscreen = new Intent(this, typeof(Activity));
                    StartActivity(newscreen);
                }
                else
                {
                    alert.SetTitle("Error!");
                    alert.SetMessage("Wrong Username or Password...");
                    alert.SetPositiveButton("Ok", alertOKButton);
                    Android.App.AlertDialog myDialog = alert.Create();
                    myDialog.Show();
                }
            }
            else
            {
                cursor = myDB.SelectSalesPersonData(login_username.Text);
                cursor.MoveToFirst();
                if(cursor==null)
                {
                    alert.SetTitle("Error!");
                    alert.SetMessage("This email id is not registered..");
                    alert.SetPositiveButton("Ok", alertOKButton);
                    Android.App.AlertDialog myDialog = alert.Create();
                    myDialog.Show();
                }
                else
                {
                    var un = cursor.GetString(cursor.GetColumnIndexOrThrow("sp_email"));
                    var pswd = cursor.GetString(cursor.GetColumnIndexOrThrow("sp_password"));
                    var fname = cursor.GetString(cursor.GetColumnIndexOrThrow("first_name"));
                    var lname = cursor.GetString(cursor.GetColumnIndexOrThrow("last_name"));
                    if (login_username.Text == un && login_passowrd.Text == pswd)
                    {
                        System.Console.WriteLine("Successfully logged in!!");
                        Intent newscreen = new Intent(this, typeof(sales_person_dashboard));
                        newscreen.PutExtra("email", login_username.Text);
                        newscreen.PutExtra("salesPersonName", fname + " " + lname);
                        StartActivity(newscreen);
                    }
                    else
                    {
                        alert.SetTitle("Error!");
                        alert.SetMessage("Wrong Username or Password...");
                        alert.SetPositiveButton("Ok", alertOKButton);
                        Android.App.AlertDialog myDialog = alert.Create();
                        myDialog.Show();
                    }
                }
                
            }
        }
    }
}