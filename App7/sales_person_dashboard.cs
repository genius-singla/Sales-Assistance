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
    [Activity(Label = "sales_person_dashboard", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
    public class sales_person_dashboard : AppCompatActivity, NavigationView.IOnNavigationItemSelectedListener
    {
        string user_email;
        string user_name;
        LinearLayout sales_chg_pswd;
       
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.sales_person_activity);
            

            user_email = Intent.GetStringExtra("email");
            user_name = Intent.GetStringExtra("salesPersonName");
            sales_chg_pswd = FindViewById<LinearLayout>(Resource.Id.sales_layout_chg_pswd);
            

            //Title Bar
            Android.Support.V7.Widget.Toolbar toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);
            SupportActionBar.Title = "Welcome! " + user_name;

            sales_chg_pswd.Click += delegate
            {
                Intent newscreen = new Intent(this, typeof(Changepassword));
                newscreen.PutExtra("userName", user_email);
                StartActivity(newscreen);
            };

            DrawerLayout drawer = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);
            ActionBarDrawerToggle toggle = new ActionBarDrawerToggle(this, drawer, toolbar, Resource.String.navigation_drawer_open, Resource.String.navigation_drawer_close);
            drawer.AddDrawerListener(toggle);
            toggle.SyncState();

            NavigationView navigationView = FindViewById<NavigationView>(Resource.Id.nav_view);
            navigationView.SetNavigationItemSelectedListener(this);
            //this.Title = "Welcome Sales Person";

            // Create your application here
        }
        /*public override void OnBackPressed()
        {
            DrawerLayout drawer = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);
            if (drawer.IsDrawerOpen(GravityCompat.Start))
            {
                drawer.CloseDrawer(GravityCompat.Start);
            }
            else
            {
                base.OnBackPressed();
            }
        }*/

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.menu_main, menu);
            return true;
        }



        public bool OnNavigationItemSelected(IMenuItem item)
        {
            int id = item.ItemId;

            if (id == Resource.Id.vieworder)
            {
                // Handle the camera action
            }
            else if (id == Resource.Id.viewproduct)
            {

            }
            else if (id == Resource.Id.addorder)
            {

            }
            else if (id == Resource.Id.changepassword)
            {

            }


            DrawerLayout drawer = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);
            drawer.CloseDrawer(GravityCompat.Start);
            return true;
        }
    }
}