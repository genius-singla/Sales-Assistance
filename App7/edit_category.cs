using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Database;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Views;
using Android.Widget;

namespace App7
{
    [Activity(Label = "edit_category", Theme = "@style/AppTheme.NoActionBar")]
    public class edit_category : Activity
    {
        ImageView gallery;
        EditText editcat;
        EditText edit_id;
        Button update_btn;
        int cid;
        DBHelper myDB;
        ICursor ic;
        Spinner spinner_cat_img1;
        int img_path;
        private static int[] cat_img_list = { Resource.Drawable.veg, Resource.Drawable.cat };
        protected override void OnCreate(Bundle savedInstanceState)
            {
                base.OnCreate(savedInstanceState);
                // Set our view from the "main" layout resource

                
                SetContentView(Resource.Layout.edit_cat);
                
                gallery = FindViewById<ImageView>(Resource.Id.catedit_img);
                editcat = FindViewById<EditText>(Resource.Id.catedit_id);
                edit_id = FindViewById<EditText>(Resource.Id.category_name);
                update_btn = FindViewById<Button>(Resource.Id.editcat_btn);
            cid = GlobalVariables.GetCategoryID();
            editcat.Enabled = false;
            spinner_cat_img1 = FindViewById<Spinner>(Resource.Id.spinner_cat1);
            //menu_gallery.Click += ButtonOnClick;
            spinner_cat_img1.Adapter = new ArrayAdapter
              (this, Android.Resource.Layout.SimpleListItem1, cat_img_list);

            spinner_cat_img1.ItemSelected += MyImgSelectedMethod1;
            showCategory();
            update_btn.Click +=delegate
            {
                if (img_path == null)
                {
                    Snackbar snackBar = Snackbar.Make(update_btn, "Please Choose Image first...", Snackbar.LengthIndefinite);
                    //Show the snackbar
                    snackBar.SetDuration(1000);
                    snackBar.Show();
                }
                else if (edit_id.Text == "")
                {
                    Snackbar snackBar = Snackbar.Make(update_btn, "Please enter category first...", Snackbar.LengthIndefinite);
                    //Show the snackbar
                    snackBar.SetDuration(1000);
                    snackBar.Show();
                }
                else
                {
                    myDB = new DBHelper(this);
                    myDB.updateCategory(editcat.Text ,edit_id.Text, img_path);
                    string toast = string.Format("Category Updated Successfully!");
                    Toast.MakeText(this, toast, ToastLength.Long).Show();
                    Intent newscreen = new Intent(this, typeof(ViewCategory));
                    StartActivity(newscreen);

                }
            };
            }

        private void MyImgSelectedMethod1(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            int index = e.Position;
            img_path = cat_img_list[index];
            gallery.SetImageResource(img_path);
        }

        private void showCategory()
        {
            myDB = new DBHelper(this);
            ic = myDB.getCategory(cid);
            ic.MoveToFirst();
            editcat.Text = cid.ToString();
            editcat.Text = ic.GetString(ic.GetColumnIndexOrThrow("cat_id"));
            edit_id.Text = ic.GetString(ic.GetColumnIndexOrThrow("cat_name"));
            //gallery.SetImageResource(Convert.ToInt32(ic.GetString(ic.GetColumnIndexOrThrow("cat_img"))));

        }
    }
    }