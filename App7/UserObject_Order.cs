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
    class UserObject_Order
    {
        public String name;
        public int pr;
        public int or_id;

        public UserObject_Order(string product_name, int price, int id)
        {
            name = product_name;
            pr = price;
            or_id = id;
        }
    }
}