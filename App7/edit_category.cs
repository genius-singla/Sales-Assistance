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
    [Activity(Label = "edit_category")]
    public class edit_category : Activity
 {
        ImageView gallery;
        EditText editcat;
        EditText edit_id;
        Button update_btn;
            protected override void OnCreate(Bundle savedInstanceState)
            {
                base.OnCreate(savedInstanceState);
                // Set our view from the "main" layout resource
                SetContentView(Resource.Layout.edit_cat);
            gallery = FindViewById<ImageView>(Resource.Id.catedit_img);
            editcat = FindViewById<EditText>(Resource.Id.catedit_id);
            edit_id = FindViewById<EditText>(Resource.Id.category_edit_id);
            update_btn = FindViewById<Button>(Resource.Id.editcat_btn);
           
            }
        }
    }