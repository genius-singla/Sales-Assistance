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
    [Activity(Label = "View_purchase", Theme = "@style/AppTheme.NoActionBar")]
    public class View_purchase : Activity
    {

        ListView listView;
        ICursor ic;
        TextView id;
        TextView vendor_name_pur;
        TextView totalam;
        TextView date;
        ImageView add;

        PurchaseList_CustomAdapter myPAdapter;
        List<UserObject_purchaseList> purchaseList = new List<UserObject_purchaseList>();
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.view_purchase);
            id = FindViewById<TextView>(Resource.Id.order_id_purList);
            vendor_name_pur = FindViewById<TextView>(Resource.Id.vendor_name_list);
            totalam = FindViewById<TextView>(Resource.Id.totalAmount_purList);
            date = FindViewById<TextView>(Resource.Id.date_purList);
            add = FindViewById<ImageView>(Resource.Id.img_id_pur);
            // myDB = new DBHelper(this);
            // myDB.category_list();
            //ic = myDB.category_list();
            //myArray = new string[ic.Count];
            /* int i = 0;
             while (ic.MoveToNext())
             {
                 var a = ic.GetString(ic.GetColumnIndex("cat_name"));
                 var b = ic.GetInt(ic.GetColumnIndex("cat_img"));
                 Console.WriteLine(a);
                 Console.WriteLine(b);
                 purchaseList.Add(new UserObject_PurchaseList(a, b));
                 i++;
             }*/

            listView = FindViewById<ListView>(Resource.Id.purchase_list);
            //myAdapter = new ArrayAdapter(this, Android.Resource.Layout.SimpleListItem1, myUsersList);
            myPAdapter = new PurchaseList_CustomAdapter(this, purchaseList);
            listView.Adapter = myPAdapter;
            add.Click += delegate
            {
                Intent newscreen = new Intent(this, typeof(Purchase));
                StartActivity(newscreen);
            };
        }
    }
}