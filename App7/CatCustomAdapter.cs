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
    class CatCustomAdapter : BaseAdapter<CatObject>
    {
        List<CatObject> catList;
        Activity myContext;

        public CatCustomAdapter(Activity context, List<CatObject> catArray)
        {
            catList = catArray;
            myContext = context;
        }

        public override CatObject this[int position]
        {
            get { return catList[position]; }
        }

        public override int Count
        {
            get { return catList.Count; }
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            View myView = convertView;
            CatObject myObj = catList[position];

            if (myView == null)
            {
                myView = myContext.LayoutInflater.Inflate(Resource.Layout.category_cell_layout, null);
            }
            myView.FindViewById<TextView>(Resource.Id.cat_name).Text = myObj.cat_name;

            myView.FindViewById<ImageView>(Resource.Id.mycat_pic).SetImageResource((myObj.cat_img));
            //myView.FindViewById<ImageView>(Resource.Id.mycat_pic).SetImageResource(Resource.Drawable.g);
            return myView;
        }
    }
}