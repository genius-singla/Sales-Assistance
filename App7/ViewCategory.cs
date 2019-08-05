using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Database;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace App7
{
    [Activity(Label = "ViewCategory", Theme = "@style/AppTheme.NoActionBar")]
    public class ViewCategory : Activity
    {
        DBHelper myDB;
        ListView listView;
        ICursor ic;
        ImageView add_cat;
        CatCustomAdapter myCAdapter;
        List<CatObject> myCatList = new List<CatObject>();
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.view_category);
            add_cat = FindViewById<ImageView>(Resource.Id.img_id_cat);
            myDB = new DBHelper(this);
            myDB.category_list();
            ic = myDB.category_list();
            //myArray = new string[ic.Count];
            int i = 0;
            while (ic.MoveToNext())
            {
                var a = ic.GetString(ic.GetColumnIndex("cat_name"));
                var b = ic.GetInt(ic.GetColumnIndex("cat_img"));
                Console.WriteLine(a);
                Console.WriteLine(b);
                myCatList.Add(new CatObject(a, b));
                i++;
            }
            add_cat.Click += delegate 
            {
                Intent newscreen = new Intent(this, typeof(Category));
                StartActivity(newscreen);
            };
            listView = FindViewById<ListView>(Resource.Id.cat_list);
            //myAdapter = new ArrayAdapter(this, Android.Resource.Layout.SimpleListItem1, myUsersList);
            myCAdapter = new CatCustomAdapter(this, myCatList);
            listView.Adapter = myCAdapter;
        }
    }
}