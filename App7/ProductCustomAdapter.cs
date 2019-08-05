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
    class ProductCustomAdapter : BaseAdapter<ProductObject>
    {
        List<ProductObject> proList;
    Activity myContext;

    public ProductCustomAdapter(Activity context, List<ProductObject> catArray)
    {
        proList = catArray;
        myContext = context;
    }

    public override ProductObject this[int position]
    {
        get { return proList[position]; }
    }

    public override int Count
    {
        get { return proList.Count; }
    }

    public override long GetItemId(int position)
    {
        return position;
    }

    public override View GetView(int position, View convertView, ViewGroup parent)
    {
        View myView = convertView;
        ProductObject myObj = proList[position];

        if (myView == null)
        {
            myView = myContext.LayoutInflater.Inflate(Resource.Layout.product_cell_layout, null);
        }
        myView.FindViewById<TextView>(Resource.Id.product_name).Text = myObj.pro_name;

        //myView.FindViewById<ImageView>(Resource.Id.mypro_pic).SetImageResource((myObj.pro_img));
        //myView.FindViewById<ImageView>(Resource.Id.mycat_pic).SetImageResource(Resource.Drawable.g);
        return myView;
    }
}
}

    