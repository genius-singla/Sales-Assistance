using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V4.View;
using Android.Support.V4.Widget;
using Android.Support.V7.App;

using Android.Views;

using Android.App;
using Android.Content;

using Android.Widget;

namespace App7
{
    [Activity(Label = "Registration", Theme = "@style/AppTheme.NoActionBar")]
    public class Registration : AppCompatActivity, NavigationView.IOnNavigationItemSelectedListener
    {
        EditText first_name;
        EditText last_name;
        EditText e_mail;
        EditText c_num;
        EditText addrs;
        EditText temppwd;
        Button registration;

        DBHelper myDB;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.register_activity);
            Android.Support.V7.Widget.Toolbar toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
            // SetSupportActionBar(toolbar);
            // SupportActionBar.Title = "Welcome Admin ";


            DrawerLayout drawer = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);
            ActionBarDrawerToggle toggle = new ActionBarDrawerToggle(this, drawer, toolbar, Resource.String.navigation_drawer_open, Resource.String.navigation_drawer_close);

            drawer.AddDrawerListener(toggle);
            toggle.SyncState();


            NavigationView navigationView = FindViewById<NavigationView>(Resource.Id.nav_view);
            navigationView.SetNavigationItemSelectedListener(this);

            // Create your application here
            first_name = FindViewById<EditText>(Resource.Id.fname);
            last_name = FindViewById<EditText>(Resource.Id.lname);
            e_mail = FindViewById<EditText>(Resource.Id.email);
            c_num = FindViewById<EditText>(Resource.Id.contact);
            addrs = FindViewById<EditText>(Resource.Id.address);
            temppwd = FindViewById<EditText>(Resource.Id.temporarypwd);
            registration = FindViewById<Button>(Resource.Id.register);

            myDB = new DBHelper(this);

            registration.Click += delegate
              {
                  myDB.insertSalesPerson(first_name.Text, last_name.Text, e_mail.Text, c_num.Text, addrs.Text, temppwd.Text);
              };
        }


             public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.menu_main, menu);
            return true;
        }


        public bool OnNavigationItemSelected(IMenuItem item)
        {
            int id = item.ItemId;

            if (id == Resource.Id.nav_sales)
            {

            }
            else if (id == Resource.Id.nav_product)
            {

            }
            else if (id == Resource.Id.nav_purchase)
            {

            }
            else if (id == Resource.Id.nav_customer)
            {

            }
            else if (id == Resource.Id.nav_category)
            {

            }
            else if (id == Resource.Id.nav_salesperson)
            {

            }
            else if (id == Resource.Id.nav_password)
            {

            }

            DrawerLayout drawer = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);
            drawer.CloseDrawer(GravityCompat.Start);
            return true;
        }
    }
}