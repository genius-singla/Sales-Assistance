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
    class Orderlist_CustomAdapter : BaseAdapter<UserObject_orderList>
    {
        List<UserObject_orderList> orderList;
    Activity myContext;

    public Orderlist_CustomAdapter(Activity context, List<UserObject_orderList> catArray)
    {
        orderList = catArray;
        myContext = context;
    }


    public override UserObject_orderList this[int position]
    {
        get { return orderList[position]; }
    }

    public override int Count
    {
        get { return orderList.Count; }
    }

    public override long GetItemId(int position)
    {
        return position;
    }

    public override View GetView(int position, View convertView, ViewGroup parent)
    {
        View myView = convertView;
        UserObject_orderList myObj = orderList[position];

        if (myView == null)
        {
            myView = myContext.LayoutInflater.Inflate(Resource.Layout.view_order_celllayout, null);
        }
        myView.FindViewById<TextView>(Resource.Id.order_id_orderList_cell).Text = myObj.order_id;
        myView.FindViewById<TextView>(Resource.Id.customer_name_list_cell).Text = myObj.customer_nm;
        myView.FindViewById<TextView>(Resource.Id.totalAmount_orderList_cell).Text = myObj.totalamount;
        myView.FindViewById<TextView>(Resource.Id.date_orderList_cell).Text = myObj.date;
        return myView;
    }
}
}


    
    