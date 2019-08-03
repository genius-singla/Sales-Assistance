using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
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
        Spinner spinnerView;
        Spinner spinnerView1;
        string[] myProduct = { "Action", "Kids", "Others" };
        string[] myUnit = { "Kg", "lb" };
        EditText product_text;
        ImageView logo;
        TextView text_pro_logo;
        EditText product_text2;
        EditText product_text3;
        ImageView product_image;
        Button product_add;

        protected override void OnCreate(Bundle savedInstanceState)
        {

            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.product_activity);
            spinnerView = FindViewById<Spinner>(Resource.Id.pro_spinner);
            spinnerView1 = FindViewById<Spinner>(Resource.Id.pro_spinner1);
            product_text = FindViewById<EditText>(Resource.Id.product_text_id1);
            product_text2 = FindViewById<EditText>(Resource.Id.product_text_id2);
           product_text3 = FindViewById<EditText>(Resource.Id.product_text_id3);
           product_image = FindViewById<ImageView>(Resource.Id.product_img_view);
           product_add = FindViewById<Button>(Resource.Id.product_btn);

            logo = FindViewById<ImageView>(Resource.Id.image_pro);
            text_pro_logo = FindViewById<TextView>(Resource.Id.product_logo);
            spinnerView.Adapter = new ArrayAdapter
                (this, Android.Resource.Layout.SimpleListItem1, myProduct);

            spinnerView.ItemSelected += MyItemSelectedMethod;
         spinnerView1.Adapter = new ArrayAdapter
             (this, Android.Resource.Layout.SimpleListItem1, myUnit);

           spinnerView1.ItemSelected += MyItemSelectedMethod2;

        }

       
        void MyItemSelectedMethod(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            var index = e.Position;

            var value = myProduct[index];
            System.Console.WriteLine("value is " + value);


            if (value.ToLower().Equals("Action"))
            {
                //create a veg array and create as a new adater 

            }
        }

      public void MyItemSelectedMethod2(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            var index = e.Position;

            var value1 = myUnit[index];
            System.Console.WriteLine("value is " + value1);


            if (value1.ToLower().Equals("Action"))
            {
                //create a veg array and create as a new adater 

            }


        }
    }
}