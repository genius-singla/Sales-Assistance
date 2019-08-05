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
    class PurchaseList_CustomAdapter : BaseAdapter<UserObject_purchaseList>
    {
        List<UserObject_purchaseList> purchaseList;
        Activity myContext;

        public PurchaseList_CustomAdapter(Activity context, List<UserObject_purchaseList> catArray)
        {
            purchaseList = catArray;
            myContext = context;
        }


        public override UserObject_purchaseList this[int position]
        {
            get { return purchaseList[position]; }
        }

        public override int Count
        {
            get { return purchaseList.Count; }
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            View myView = convertView;
            UserObject_purchaseList myObj = purchaseList[position];

            if (myView == null)
            {
                myView = myContext.LayoutInflater.Inflate(Resource.Layout.purchase_list_cellLayout, null);
            }
            myView.FindViewById<TextView>(Resource.Id.order_id_purList_cell).Text = myObj.order_id;
            myView.FindViewById<TextView>(Resource.Id.vendor_name_list_cell).Text = myObj.vendor_nm;
            myView.FindViewById<TextView>(Resource.Id.totalAmount_purList_cell).Text = myObj.totalamount;
            myView.FindViewById<TextView>(Resource.Id.date_purList_cell).Text = myObj.date;
            return myView;
        }
    }
}