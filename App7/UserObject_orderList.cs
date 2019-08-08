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
    class UserObject_orderList
    {
        public String order_id;
        public String customer_nm;
        public String totalamount;
        public String date;
        public UserObject_orderList(string order, string customer, string total, string date_list)
        {
            order_id = order;
            customer_nm = customer;
            totalamount = total;
            date = date_list;
        }
    }
}