using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Views;
using Android.Widget;

namespace App7
{
    [Activity(Label = "Category", Theme = "@style/AppTheme.NoActionBar")]
    public class Category : Activity
    {
        DBHelper myDB;
        public static int PickImageId = 1001;
        EditText enter_category;
        ImageView logo;
        TextView category_txt;
        ImageView menu_gallery;
        Button cate_btn;
        string img_path;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.add_category);
            enter_category = FindViewById<EditText>(Resource.Id.enter_category_id);
            logo = FindViewById<ImageView>(Resource.Id.category_page_logo);
            category_txt = FindViewById<TextView>(Resource.Id.category_text_id);
            menu_gallery = FindViewById<ImageView>(Resource.Id.category_img_view);
            cate_btn = FindViewById<Button>(Resource.Id.category_btn);

            menu_gallery.Click += ButtonOnClick;

            cate_btn.Click += delegate
            {
                if(img_path == null || img_path == "")
                {
                    Snackbar snackBar = Snackbar.Make(cate_btn, "Please Choose Image first...", Snackbar.LengthIndefinite);
                    //Show the snackbar
                    snackBar.SetDuration(1000);
                    snackBar.Show();
                }
                else if(enter_category.Text=="")
                {
                    Snackbar snackBar = Snackbar.Make(cate_btn, "Please enter category first...", Snackbar.LengthIndefinite);
                    //Show the snackbar
                    snackBar.SetDuration(1000);
                    snackBar.Show();
                }
                else
                {
                    myDB = new DBHelper(this);
                    myDB.insertCategory(enter_category.Text, img_path);
                    string toast = string.Format("Product Added Successfully!");
                    Toast.MakeText(this, toast, ToastLength.Long).Show();
                    Intent newscreen = new Intent(this, typeof(ViewCategory));
                    StartActivity(newscreen);

                }
            };
        }


        private void ButtonOnClick(object sender, EventArgs e)
        {
            Intent = new Intent();
            Intent.SetType("image/*");
            Intent.SetAction(Intent.ActionGetContent);
            StartActivityForResult(Intent.CreateChooser(Intent, "Select Picture"), PickImageId);
        }

        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            if ((requestCode == PickImageId) && (resultCode == Result.Ok) && (data != null))
            {
                Android.Net.Uri uri = data.Data;
                menu_gallery.SetImageURI(uri);
                img_path = uri.ToString();
            }
        }
    }
}