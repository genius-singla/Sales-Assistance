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
    class GlobalVariables
    {
        private static int Category_ID;

        public static void SetCategoryID(int cat_id)
        {
            Category_ID = cat_id;
        }

        public static int GetCategoryID()
        {
            return Category_ID;
        }
    }
}