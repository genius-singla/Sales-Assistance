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
    [Activity(Label = "ViewProduct" , Theme = "@style/AppTheme.NoActionBar")]
    public class ViewProduct : Activity
    {
        DBHelper myDB;
        ListView listView;
        ICursor ic;
        ImageView add_pro;
        ProductCustomAdapter myProdapter;
        List<ProductObject> myProList = new List<ProductObject>();
       
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.view_product);
            add_pro = FindViewById<ImageView>(Resource.Id.img_id_product);
            myDB = new DBHelper(this);
            myDB.product_list();
            ic = myDB.product_list();
            //myArray = new string[ic.Count];
            int i = 0;
            while (ic.MoveToNext())
            {
                var a = ic.GetString(ic.GetColumnIndex("pro_name"));
                int b = ic.GetInt(ic.GetColumnIndex("pro_image"));
                Console.WriteLine(a);
                //Console.WriteLine(a);
                myProList.Add(new ProductObject(a, b));
                i++;
            }
            add_pro.Click += delegate
            {
                Intent newscreen = new Intent(this, typeof(Product));
                StartActivity(newscreen);
            };
            listView = FindViewById<ListView>(Resource.Id.pro_list);
            //myAdapter = new ArrayAdapter(this, Android.Resource.Layout.SimpleListItem1, myUsersList);
            myProdapter = new ProductCustomAdapter(this, myProList);
            listView.Adapter = myProdapter;
        }
    }
}