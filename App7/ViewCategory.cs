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
        int id;
        ImageView add_cat;
        ImageView dlt_btn;
        CatCustomAdapter myCAdapter;
        List<CatObject> myCatList = new List<CatObject>();
        Android.App.AlertDialog.Builder alert;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.view_category);
            add_cat = FindViewById<ImageView>(Resource.Id.img_id_cat);
            
            listView = FindViewById<ListView>(Resource.Id.cat_list);
            show_category();
            alert = new Android.App.AlertDialog.Builder(this);
            add_cat.Click += delegate 
            {
                Intent newscreen = new Intent(this, typeof(Category));
                StartActivity(newscreen);
            };

            
            //myAdapter = new ArrayAdapter(this, Android.Resource.Layout.SimpleListItem1, myUsersList);
            
        }

        

        private void show_category()
        {
            myDB = new DBHelper(this);
            myDB.category_list();
            ic = myDB.category_list();
            //myArray = new string[ic.Count];
            int i = 0;
            while (ic.MoveToNext())
            {
                var a = ic.GetString(ic.GetColumnIndex("cat_name"));
                var b = ic.GetInt(ic.GetColumnIndex("cat_img"));
                var c = ic.GetInt(ic.GetColumnIndex("cat_id"));
                myCatList.Add(new CatObject(a, b, c));
                i++;
            }

            myCAdapter = new CatCustomAdapter(this, myCatList);
            listView.Adapter = myCAdapter;

            listView.ItemClick += listView_ItemClick;
            
        }

        
        private void listView_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            CatObject mycat;
            var index = e.Position;
            mycat = myCatList[index];
            /*ImageView edt_btn = FindViewById<ImageView>(Resource.Id.cat_edit);
            ImageView dlt_btn = FindViewById<ImageView>(Resource.Id.cat_trash);*/
            id = mycat.cat_id;
            alert.SetTitle("Edit/Delete");
            alert.SetMessage("Click on Delete or Edit");
            alert.SetPositiveButton("Edit", alertEditButton);

            alert.SetNegativeButton("Delete", alertOKButton);
            //Dialog myDialog = alert.Create();
            Android.App.AlertDialog myDialog = alert.Create();
            myDialog.Show();


        }

        public void alertEditButton(object sender, DialogClickEventArgs e)
        {
            Intent ns = new Intent(this, typeof(edit_category));
            
            GlobalVariables.SetCategoryID(id);
            StartActivity(ns);
        }

        

        public void alertOKButton(object sender, DialogClickEventArgs e)
        {
            myDB.deleteCategoryItem(id);
            Intent ns = new Intent(this, typeof(ViewCategory));
            StartActivity(ns);
            //show_category();
        }
 
    }
}