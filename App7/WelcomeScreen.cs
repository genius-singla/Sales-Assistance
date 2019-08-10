using Android.OS;
using Android.Support.Design.Widget;
using Android.Support.Design.Internal;
using Android.Support.V4.View;
using System.Collections.Generic;
using Android.Support.V4.App;
using Android.Views;
using Android.Support.V7.App;
using Android.Support.V7.Widget;
using System;
using Android.Widget;

using Android.Content;
using Android.Database;

namespace App7
{

    [Android.App.Activity(Theme = "@style/AppTheme")]

    public class WelcomeScreen : AppCompatActivity
    {
        ViewPager _viewPager;
        BottomNavigationView _navigationView;
        Fragment[] _fragments;
        // DBHelperClass myDB;
        ICursor cursor;
        //Spinner spinnerView;
        // Toolbar toolb;


        private Fragment mycontext;

        // List<UserObject> myusersList = new List<UserObject>();
        protected override void OnCreate(Bundle savedInstanceState)
        {

            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.WelcomeScreen);
            /*myDB = new DBHelperClass(this);
            myDB.SelectComplaintList();
            cursor = myDB.SelectComplaintList();
            cursor.MoveToFirst();
            while(cursor.MoveToNext())
            {


            }*/
            //toolb = FindViewById<Toolbar>(Resource.Id.my_toolbar);

            //SetSupportActionBar(toolb);
            // spinnerView = FindViewById<Spinner>(Resource.Id.spinner1);

            // spinnerView.Adapter = new ArrayAdapter
            //  (this, Android.Resource.Layout.SimpleListItem1, myCategory);

            //  valueFromLoginUser = Intent.GetStringExtra("userName");
            //   myUser = FindViewById<TextView>(Resource.Id.welcomeuser);
            //   myUser.Text = "Welcome," + valueFromLoginUser;
            // this.Title = "welcome admin";
            //  spinnerView.ItemSelected += MyItemSelectedMethod;

            InitializeTabs();

            _viewPager = FindViewById<ViewPager>(Resource.Id.viewpager);
            _viewPager.PageSelected += ViewPager_PageSelected;
            _viewPager.Adapter = new ViewPagerAdapter(SupportFragmentManager, _fragments);

            _navigationView = FindViewById<BottomNavigationView>(Resource.Id.bottom_navigation);
            RemoveShiftMode(_navigationView);
            _navigationView.NavigationItemSelected += NavigationView_NavigationItemSelected;

        }


        void InitializeTabs()
        {

            _fragments = new Fragment[] {
                new Fragment1(this),
                new Fragment2(this),
                //new Fragment1("Sandy","21",myusersList),
               // new Fragment2(this)
            };
        }

        private void ViewPager_PageSelected(object sender, ViewPager.PageSelectedEventArgs e)
        {
            var item = _navigationView.Menu.GetItem(e.Position);
            _navigationView.SelectedItemId = item.ItemId;
        }

        void NavigationView_NavigationItemSelected(object sender, BottomNavigationView.NavigationItemSelectedEventArgs e)
        {
            _viewPager.SetCurrentItem(e.Item.Order, true);
        }

        void RemoveShiftMode(BottomNavigationView view)
        {

            var menuView = (BottomNavigationMenuView)view.GetChildAt(0);

            try
            {
                var shiftingMode = menuView.Class.GetDeclaredField("mShiftingMode");
                shiftingMode.Accessible = true;
                shiftingMode.SetBoolean(menuView, false);
                shiftingMode.Accessible = false;


                for (int i = 0; i < menuView.ChildCount; i++)
                {
                    var item = (BottomNavigationItemView)menuView.GetChildAt(i);
                    // item.SetShiftingMode(false);
                    // set once again checked value, so view will be updated
                    item.SetChecked(item.ItemData.IsChecked);
                }
            }
            catch (System.Exception ex)
            {
                System.Diagnostics.Debug.WriteLine((ex.InnerException ?? ex).Message);
            }
        }

        protected override void OnDestroy()
        {
            _viewPager.PageSelected -= ViewPager_PageSelected;
            _navigationView.NavigationItemSelected -= NavigationView_NavigationItemSelected;
            base.OnDestroy();
        }



    }
}

