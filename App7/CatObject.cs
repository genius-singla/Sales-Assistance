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
        public int cat_id;

        public CatObject(string name, int img, int id)
        {
            cat_name = name;
            cat_img = img;
            cat_id = id;
        }
    }
}