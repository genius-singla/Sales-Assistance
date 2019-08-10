using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace App7
{
    class Order_CustomAdapter : BaseAdapter<UserObject_Order>
    {
        List<UserObject_Order> userList;
        Activity mycontext;
        public Order_CustomAdapter(Activity contex, List<UserObject_Order> userArray)
        {
            userList = userArray;
            mycontext = contex;
        }
        public override UserObject_Order this[int position]
        {

            get { return userList[position]; }
        }

        public override int Count
        {
            get { return userList.Count; }
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            View myView = convertView;
            UserObject_Order myObj = userList[position];

            if (myView == null)
            {
                myView = mycontext.LayoutInflater.Inflate(Resource.Layout.order_cellLayout, null);
            }
            myView.FindViewById<TextView>(Resource.Id.o_pro_name).Text = myObj.name;
            myView.FindViewById<TextView>(Resource.Id.o_price).Text = (myObj.pr).ToString();

            //myView.FindViewById<TextView>(Resource.Id.o_qty).Text = (myObj.or_id).ToString();
            return myView;
        }
    }
}
