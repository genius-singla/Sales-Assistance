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
    [Activity(Label = "Activity", Theme = "@style/AppTheme.NoActionBar")]
    public class Activity : AppCompatActivity, NavigationView.IOnNavigationItemSelectedListener
    {
        LinearLayout reg_layout;
        LinearLayout chg_pswd_layout;
        LinearLayout add_category_link_layout;
        LinearLayout vendor_layout;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.activity);





            Android.Support.V7.Widget.Toolbar toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);
            SupportActionBar.Title = "Welcome Admin ";


            DrawerLayout drawer = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);
            ActionBarDrawerToggle toggle = new ActionBarDrawerToggle(this, drawer, toolbar, Resource.String.navigation_drawer_open, Resource.String.navigation_drawer_close);

            drawer.AddDrawerListener(toggle);
            toggle.SyncState();


            NavigationView navigationView = FindViewById<NavigationView>(Resource.Id.nav_view);
            navigationView.SetNavigationItemSelectedListener(this);

           //this.Title = " welcome Admin";
            reg_layout = FindViewById<LinearLayout>(Resource.Id.reg_go);
            chg_pswd_layout = FindViewById<LinearLayout>(Resource.Id.chg_pswd_go);
            add_category_link_layout = FindViewById<LinearLayout>(Resource.Id.add_category_link);
            vendor_layout = FindViewById<LinearLayout>(Resource.Id.vendor_go);
            reg_layout.Click += delegate
            {
                //Console.WriteLine("Welcome to Registration Page");
                Intent newscreen = new Intent(this, typeof(Registration));
                StartActivity(newscreen);
            };

            chg_pswd_layout.Click += delegate
            {
                //Console.WriteLine("Welcome to Registration Page");
                Intent newscreen = new Intent(this, typeof(Changepassword));
                newscreen.PutExtra("userName", "admin");
                StartActivity(newscreen);
            };
            add_category_link_layout.Click += delegate
            {
                Intent newscreen = new Intent(this, typeof(Category));
                StartActivity(newscreen);
            };
            vendor_layout.Click += delegate
            {
                Intent newscreen = new Intent(this, typeof(Vendor));
                StartActivity(newscreen);
            };
        }
        


        /*public override void OnBackPressed()
        {
            DrawerLayout drawer = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);
            /*if (drawer.IsDrawerOpen(GravityCompat.Start))
            {
                drawer.CloseDrawer(GravityCompat.Start);
            }
            else
            {
                base.OnBackPressed();
            }//
            Intent newscreen = new Intent(this, typeof(Activity));
            StartActivity(newscreen);
        }*/

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

