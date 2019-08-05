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
    class Purchase_CustomAdapter : BaseAdapter<UserObject_purchase>
    {

        List<UserObject_purchase> userList;
        Activity mycontext;
        public Purchase_CustomAdapter(Activity contex, List<UserObject_purchase> userArray)
        {
            userList = userArray;
            mycontext = contex;
        }
        public override UserObject_purchase this[int position]
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
            UserObject_purchase myObj = userList[position];

            if (myView == null)
            {
                myView = mycontext.LayoutInflater.Inflate(Resource.Layout.purchase_cellLayout, null);
            }
            myView.FindViewById<TextView>(Resource.Id.product_name).Text = myObj.name;
            myView.FindViewById<TextView>(Resource.Id.price).Text = myObj.pr;

            myView.FindViewById<TextView>(Resource.Id.qty).Text = (myObj.qt).ToString();
            return myView;
        }
    }
}