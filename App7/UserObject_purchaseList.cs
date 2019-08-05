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
    class UserObject_purchaseList
    {
        public String order_id;
        public String vendor_nm;
        public String totalamount;
        public String date;
        public UserObject_purchaseList(string order, string vendor, string total, string date_list)
        {
            order_id = order;
            vendor_nm = vendor;
            totalamount = total;
            date = date_list;
        }
    }
}