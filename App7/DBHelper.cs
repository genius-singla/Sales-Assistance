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
using Android.Database;
using Android.Database.Sqlite;

namespace App7
{
    class DBHelper : SQLiteOpenHelper
    {
        Context myContex;
        SQLiteDatabase connectionObj;

        public static string DBName = "myDatabse.db";

        /*      ***Admin Table***       */
        public static string admin_tablename = "admin_login";
        public static string admin_name = "adm_name";
        public static string admin_password = "adm_password";
        //create database
        public string admin_creatTable = "Create Table " + admin_tablename + "(" + admin_name + " Text, " + admin_password + " Text);";

        

        /*      ***Sales Person Table***      */
        public static string sales_person_tablename = "sales_person";
        public static string sales_person_id = "sales_person_id";
        public static string sales_person_fname = "first_name";
        public static string sales_person_lname = "last_name";
        public static string sales_person_email = "sp_email";
        public static string sales_person_contact = "sp_contact";
        public static string sales_person_address = "sp_address";
        public static string sales_person_password = "sp_password";

        /*      Create table for sales person       */
        public string sales_person_creatTable = "Create Table " + sales_person_tablename + "(" 
            + sales_person_id + " int, "
            + sales_person_fname + " Text, "
            + sales_person_lname + " Text, "
            + sales_person_email + " Text, "
            + sales_person_contact + " Text, "
            + sales_person_address + " Text, "
            + sales_person_password + " Text);";

        


        //      Inserting New Vendor
        public void InsertVendor(string c_name, string v_address, string v_city, string v_province, string v_contact_name, string v_contact_number)
        {
            String selectStm = "Select ifnull(max(" + vendor_id + "),0) as max_id from " + vendor_tablename;
            ICursor myresult = connectionObj.RawQuery(selectStm, null);
            myresult.MoveToFirst();
            var id = myresult.GetInt(myresult.GetColumnIndexOrThrow("max_id"));

            string insertStatement = "Insert into " + vendor_tablename + " values(" + (id + 1) + ", '" + c_name + "', '"
                + v_address + "', '" + v_city + "', '" + v_province + "', '" + v_contact_name + "', '" + v_contact_number + "');";
            connectionObj.ExecSQL(insertStatement);
            Console.WriteLine(insertStatement);
        }


        /*      ***Product Table***      */
        public static string product_tablename = "product";
        public static string product_id = "pro_id";
        public static string cat_id = "cat_id";
        public static string product_name = "pro_name";
        public static string unit = "unit";
        public static string purchase_price = "purchase_price";
        public static string selling_price = "selling_price";
        public static string product_image = "pro_image";

        //      Create Product Table
        public string product_creatTable = "Create Table " + product_tablename + "("
            + product_id + " int, "
            + cat_id + " int, "
            + product_name + " Text, "
            + unit + " Text, "
            + purchase_price + " int, "
            + selling_price + " int, "
            + product_image + " image);";



        /*      Category Table      */
        public static string category = "category";
        public static string category_id = "cat_id";
        public static string category_name = "cat_name";
        public static string category_image = "cat_img";

        

        //      Create Category Table
        public string category_creatTable = "Create Table " + category + "("
            + category_id + " int, "
            + category_name + " Text, "
            + category_image + " image);";


        /*      ***Vendor Table***      */
        public static string vendor_tablename = "vendor";
        public static string vendor_id = "vendor_id";
        public static string vendor_Company_name = "v_company_name";
        public static string vendor_address = "v_address";
        public static string vendor_city = "v_city";
        public static string vendor_province = "v_province";
        public static string vendor_contact_person = "v_contact_person";
        public static string vendor_contact_number = "v_contact_number";

        //      Create Vendor Table
        public string vendor_creatTable = "Create Table " + vendor_tablename + "("
            + vendor_id + " int, "
            + vendor_Company_name + " Text, "
            + vendor_address + " Text, "
            + vendor_city + " Text, "
            + vendor_province + " Text, "
            + vendor_contact_person + " Text, "
            + vendor_contact_number + " Text);";



        // Inserting new Category
        public void insertCategory(string cat, string img_path)
        {
            String selectStm = "Select ifnull(max(" + category_id + "),0) as max_id from " + category;
            ICursor myresult = connectionObj.RawQuery(selectStm, null);
            myresult.MoveToFirst();
            var id = myresult.GetInt(myresult.GetColumnIndexOrThrow("max_id"));

            string insertStatement = "Insert into " + category + " values(" + (id + 1) + ", '" + cat + "', '"
                + img_path + "');";
            connectionObj.ExecSQL(insertStatement);
            Console.WriteLine(insertStatement);

        }


        //Inserting New Product
        public void InsertProduct(int cat_id, string product_name, string unit_val, int product_purchase_price, int product_sell_price, string product_image)
        {
            String selectStm = "Select ifnull(max(" + product_id + "),0) as max_id from " + product_tablename;
            ICursor myresult = connectionObj.RawQuery(selectStm, null);
            myresult.MoveToFirst();
            var id = myresult.GetInt(myresult.GetColumnIndexOrThrow("max_id"));

            string insertStatement = "Insert into " + product_tablename + " values(" + (id + 1) + ", " + cat_id + ", '" 
                + product_name + "', '"
                + unit_val+"', "
                + product_purchase_price + ", "
                + product_sell_price + ", '"
                + product_image + "');";
            connectionObj.ExecSQL(insertStatement);
            Console.WriteLine(insertStatement);
        }


        //Getting Category list
        public ICursor category_list()
        {
            String selectStm = "Select * from " + category + ";";
            ICursor myresut = connectionObj.RawQuery(selectStm, null);
            return myresut;
        }

        //Getting Vendor list
        internal ICursor vendor_list()
        {
            String selectStm = "Select * from " + vendor_tablename + ";";
            ICursor myresut = connectionObj.RawQuery(selectStm, null);
            return myresut;
        }

        //Getting Product List
        public ICursor product_list()
        {
            String selectStm = "Select * from " + product_tablename + ";";
            ICursor myresut = connectionObj.RawQuery(selectStm, null);
            return myresut;
        }

        //Inserting entry of new sales person
        public void insertSalesPerson(string fname, string lname, string sp_email, string sp_contact, string sp_address, string sp_password)
        {
            String selectStm = "Select ifnull(max(" + sales_person_id + "),0) as max_id from " + sales_person_tablename;

            ICursor myresult = connectionObj.RawQuery(selectStm, null);
            myresult.MoveToFirst();
            var id = myresult.GetInt(myresult.GetColumnIndexOrThrow("max_id"));

            string insertStatement = "Insert into " + sales_person_tablename + " values(" + (id+1) + ", '" + fname + "', '"
                + lname + "', '"
                + sp_email + "', '"
                + sp_contact + "', '"
                + sp_address + "', '"
                + sp_password + "');";
            connectionObj.ExecSQL(insertStatement);
            Console.WriteLine(insertStatement);
        }
        

        //Updating Sales Person Password
        public void update_sales_person_password(string uname,string pswd)
        {
            String updateStm = "update " + sales_person_tablename + " set " + sales_person_password + " = '" 
                + pswd + "' where " + sales_person_email + " = '" + uname + "';";
            connectionObj.ExecSQL(updateStm);
            Console.WriteLine(updateStm);
        }

        //checking the password of sales person
        public ICursor chk_sales_person_Password(string uname)
        {
            String selectStm = "Select * from " + sales_person_tablename + " where " + sales_person_email + "= '" + uname + "';";

            ICursor myresut = connectionObj.RawQuery(selectStm, null);
            return myresut;
        }

        //Fetching particular sales person data
        public ICursor SelectSalesPersonData(string uname)
        {
            String selectStm = "Select * from " + sales_person_tablename + " where " + sales_person_email + "= '" + uname + "';";

            ICursor myresut = connectionObj.RawQuery(selectStm, null);
            return myresut;
        }

        public DBHelper(Context context) : base(context, name: DBName, factory: null, version: 1)
        {
            myContex = context;
            connectionObj = WritableDatabase;
        }

        public override void OnCreate(SQLiteDatabase db)
        {
            System.Console.WriteLine("My Create Table STM \n \n" + admin_creatTable);
            db.ExecSQL(admin_creatTable);
            db.ExecSQL(sales_person_creatTable);
            db.ExecSQL(category_creatTable);
            db.ExecSQL(product_creatTable);
            db.ExecSQL(vendor_creatTable);
            //insertAdmin("admin","abc");
            string insertStm = "Insert into " + admin_tablename + " values('admin', 'abc');";
            Console.WriteLine(insertStm);
            db.ExecSQL(insertStm);
        }

        //Insert data into admin table
        public void insertAdmin(string uname, string upass)
        {
            
            //connectionObj.ExecSQL(insertStm);
        }

        public ICursor chk_admin_passwod()
        {
            String selectStm = "Select * from " + admin_tablename;

            ICursor myresut = connectionObj.RawQuery(selectStm, null);
            return myresut;
        }

        public void update_admin_password(string pswd)
        {
            String updateStm = "update " + admin_tablename + " set " + admin_password + " = '" + pswd + "';";
            connectionObj.ExecSQL(updateStm);
            Console.WriteLine(updateStm);
        }

        //Select data from admin table
        public ICursor SelectMyAdmindata()
        {
            String selectStm = "Select * from " + admin_tablename;

            ICursor myresut = connectionObj.RawQuery(selectStm, null);
            return myresut;
        }
        public override void OnUpgrade(SQLiteDatabase db, int oldVersion, int newVersion)
        {
            throw new NotImplementedException();
        }
    }
}