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
    class CatObject
    {
        public String cat_name;
        public int cat_img;

        public CatObject(string name, int img)
        {
            cat_name = name;
            cat_img = img;
        }
    }
}