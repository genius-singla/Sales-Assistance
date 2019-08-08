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
        string name;
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
            dlt_btn = FindViewById<ImageView>(Resource.Id.cat_trash);
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
                myCatList.Add(new CatObject(a, b));
                i++;
            }

            myCAdapter = new CatCustomAdapter(this, myCatList);
            listView.Adapter = myCAdapter;

            listView.ItemClick += listView_ItemClick;
            
        }

        private void delete_item(object sender, AdapterView.ItemClickEventArgs e)
        {
            CatObject mycat;
            var index = e.Position;
            mycat = (myCatList[index]);
            myDB.deleteCategoryItem(mycat.cat_name);
        }

        private void listView_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            CatObject mycat;
            var index = e.Position;
            mycat = myCatList[index];
            /*ImageView edt_btn = FindViewById<ImageView>(Resource.Id.cat_edit);
            ImageView dlt_btn = FindViewById<ImageView>(Resource.Id.cat_trash);*/
            name = mycat.cat_name;
            alert.SetTitle("Edit/Delete");
            alert.SetMessage("Click on Delete or Edit");
            alert.SetPositiveButton("Edit", alertOKButton);

            alert.SetNegativeButton("Delete", alertOKButton);
            //Dialog myDialog = alert.Create();
            Android.App.AlertDialog myDialog = alert.Create();
            myDialog.Show();


        }
        public void alertOKButton(object sender, Android.Content.DialogClickEventArgs e)
        {
            myDB.deleteCategoryItem(name);
            show_category();
            
        }
 
    }
}