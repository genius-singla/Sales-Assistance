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
    class Favourite_CustomAdapter : BaseAdapter<UserObject_favourite>
    {
        List<UserObject_favourite> FavouriteList;
        Activity myContext;

        public Favourite_CustomAdapter(Activity context, List<UserObject_favourite> catArray)
        {
            FavouriteList = catArray;
            myContext = context;
        }


        public override UserObject_favourite this[int position]
        {
            get { return FavouriteList[position]; }
        }

        public override int Count
        {
            get { return FavouriteList.Count; }
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            View myView = convertView;
            UserObject_favourite myObj = FavouriteList[position];

            if (myView == null)
            {
                myView = myContext.LayoutInflater.Inflate(Resource.Layout.favourite_celllayout, null);
            }
            myView.FindViewById<TextView>(Resource.Id.vendor_id_favourite_cell).Text = (myObj.vendor_id).ToString();
            myView.FindViewById<TextView>(Resource.Id.vendor_name_list_cell).Text = myObj.vendor_nm;
            myView.FindViewById<TextView>(Resource.Id.contact_FavouriteList_cell).Text = myObj.vendor_contact;

            return myView;
        }
    }
}


