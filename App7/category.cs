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
    [Activity(Label = "Category", Theme = "@style/AppTheme.NoActionBar")]
    public class Category : Activity
    {
        EditText enter_category;
        ImageView logo;
        TextView category_txt;
        ImageView menu_gallery;
        Button cate_btn;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.add_category);
            enter_category = FindViewById<EditText>(Resource.Id.enter_category_id);
            logo = FindViewById<ImageView>(Resource.Id.category_page_logo);
            category_txt = FindViewById<TextView>(Resource.Id.category_text_id);
            menu_gallery = FindViewById<ImageView>(Resource.Id.category_img_view);
            cate_btn = FindViewById<Button>(Resource.Id.category_btn);

        }
    }
}