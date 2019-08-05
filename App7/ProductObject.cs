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
    class ProductObject
    {
        public String pro_name;
        public int pro_img;


        public ProductObject(string name)
        {
            pro_name = name;
            //pro_img = img;
        }
    }
}
