using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Database;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.App;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;

namespace App7
{
    [Activity(Label = "Product", Theme = "@style/AppTheme.NoActionBar")]
    public class Product : AppCompatActivity
    {
        Spinner spinner_category;
        Spinner spinner_unit;
        Spinner pro_img;
        public static int PickImageId = 1001;
        //string[] myProduct = { "Action", "Kids", "Others" };
        List<string> myCategory = new List<string>();
        //List<KeyValuePair<string, int>> category = new List<KeyValuePair<string, int>>();
        Dictionary<string, int> dist = new Dictionary<string, int>();
        string[] myUnit = { "Kg", "lb", "Pc" };
        EditText product_name;
        ImageView logo;
        TextView text_pro_logo;
        EditText product_purchase_price;
        EditText product_sell_price;
        ImageView product_image;
        Button product_add;
        ICursor ic;
        DBHelper myDB;
        int cat_id;
        string unit_val;
        int img_path;
        private static int[] cat_img_list = { Resource.Drawable.p3, Resource.Drawable.p4, Resource.Drawable.p5, Resource.Drawable.p6, Resource.Drawable.p7,
            Resource.Drawable.p8, Resource.Drawable.p9, Resource.Drawable.p10, Resource.Drawable.p11, Resource.Drawable.p12, Resource.Drawable.p13, Resource.Drawable.p14
        , Resource.Drawable.p15, Resource.Drawable.p16, Resource.Drawable.p17, Resource.Drawable.p18, Resource.Drawable.p19};
        protected override void OnCreate(Bundle savedInstanceState)
        {

            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.product_activity);
            spinner_category = FindViewById<Spinner>(Resource.Id.pro_spinner);
            pro_img = FindViewById<Spinner>(Resource.Id.spinner_pro);
            spinner_unit = FindViewById<Spinner>(Resource.Id.pro_unit);
            product_name = FindViewById<EditText>(Resource.Id.product_name);
            product_purchase_price = FindViewById<EditText>(Resource.Id.product_purchase);
            product_sell_price = FindViewById<EditText>(Resource.Id.product_sell);
            product_image = FindViewById<ImageView>(Resource.Id.product_img_view);
            product_add = FindViewById<Button>(Resource.Id.product_btn);
            logo = FindViewById<ImageView>(Resource.Id.image_pro);
            text_pro_logo = FindViewById<TextView>(Resource.Id.product_logo);
            pro_img.Adapter = new ArrayAdapter
              (this, Android.Resource.Layout.SimpleListItem1, cat_img_list);

            pro_img.ItemSelected += MyProImgSelectedMethod;
            product_add.Click += AddProduct;
            spinner_category.ItemSelected += MyItemSelectedMethod;
            spinner_unit.Adapter = new ArrayAdapter
                (this, Android.Resource.Layout.SimpleListItem1, myUnit);

            spinner_unit.ItemSelected += MyItemSelectedMethod2;
            myDB = new DBHelper(this);
            myDB.category_list();
            ic = myDB.category_list();
            
            int i = 0;
            while (ic.MoveToNext())
            {
                var a = ic.GetString(ic.GetColumnIndex("cat_name"));
                var b = ic.GetInt(ic.GetColumnIndex("cat_id"));
                dist.Add(a, b);
                myCategory.Add(a);
                i++;
            }
            //product_image.Click += ImageOnClick;
            spinner_category.Adapter = new ArrayAdapter
                (this, Android.Resource.Layout.SimpleListItem1, myCategory);
        }

        private void MyProImgSelectedMethod(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            int index = e.Position;
            img_path = cat_img_list[index];
            product_image.SetImageResource(img_path);
        }

        /*private void ImageOnClick(object sender, EventArgs e)
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
                product_image.SetImageURI(uri);
                img_path = uri.ToString();
            }
        }*/

        private void AddProduct(object sender, EventArgs e)
        {
            myDB.InsertProduct(cat_id, product_name.Text, unit_val, Convert.ToInt32(product_purchase_price.Text), Convert.ToInt32(product_sell_price.Text), img_path);
            string toast = string.Format("Product Added Successfully!");
            Toast.MakeText(this, toast, ToastLength.Long).Show();
        }

        void MyItemSelectedMethod(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            var index = e.Position;
            var value = myCategory[index];
            System.Console.WriteLine("value is " + value);

            dist.TryGetValue(value, out cat_id);

        }

      public void MyItemSelectedMethod2(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            var index = e.Position;

            unit_val = myUnit[index];
        }
    }
}