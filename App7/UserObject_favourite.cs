﻿using System;
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
    class UserObject_favourite
    {
        public int vendor_id;
        public String vendor_nm;
        public String vendor_contact;

        public UserObject_favourite(int id, string vendor, string contact)
        {
            vendor_id = id;
            vendor_nm = vendor;
            vendor_contact = contact;

        }
    }
}