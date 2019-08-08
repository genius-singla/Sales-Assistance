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
    [Activity(Label = "View_order", Theme = "@style/AppTheme.NoActionBar")]
    public class View_order : Activity
    {
        ListView listView;
        ICursor ic;
        TextView id;
        TextView customer_name_order;
        TextView totalam;
        TextView date;


        Orderlist_CustomAdapter myorderAdapter;
        List<UserObject_orderList> orderList = new List<UserObject_orderList>();
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.Vieworder_main);
            id = FindViewById<TextView>(Resource.Id.order_id_orderList);
            customer_name_order = FindViewById<TextView>(Resource.Id.customer_name_list);
            totalam = FindViewById<TextView>(Resource.Id.totalAmount_OrderList);
            date = FindViewById<TextView>(Resource.Id.date_purList);

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

            listView = FindViewById<ListView>(Resource.Id.order_list);
            //myAdapter = new ArrayAdapter(this, Android.Resource.Layout.SimpleListItem1, myUsersList);
            myorderAdapter = new Orderlist_CustomAdapter(this, orderList);
            listView.Adapter = myorderAdapter;
            /*add.Click += delegate
            {
                Intent newscreen = new Intent(this, typeof(Purchase));
                StartActivity(newscreen);
            };*/
        }
    }
}