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

        /*      ***Favourite Table***       */
        public static string favourite_tablename = "fav";
        public static string fav_vendor_id = "ven_id";
        public static string fav_vendor_name = "v_company_name";
        public static string fav_vendor_contact = "v_contact_number";
        //create database
        public string fav_creatTable = "Create Table " + favourite_tablename + "(" + fav_vendor_id + " int," 
            + fav_vendor_name + " Text, "
            + fav_vendor_contact + " Text);";


        /*      ***Admin Table***       */
        public static string admin_tablename = "admin_login";
        public static string admin_name = "adm_name";
        public static string admin_password = "adm_password";
        //create database
        public string admin_creatTable = "Create Table " + admin_tablename + "(" + admin_name + " Text, " + admin_password + " Text);";


        //View Purchase
        public ICursor view_purchase()
        {
            String selectStm = "Select * from " + purchase_tablename;
            ICursor myresut = connectionObj.RawQuery(selectStm, null);
            return myresut;
        }

        /*      ***Purchase Table***       */
        public static string purchase_tablename = "purchase";

        // Favourite List
        public ICursor favList()
        {
           String selectStm = "Select * from fav;";
            ICursor myresult = connectionObj.RawQuery(selectStm, null);
            return myresult;
        }

        
        public ICursor pendingOrder()
        {
            String selectStm = "Select * from " + order_tablename + " where " + order_status + " = 'pending'";
            ICursor myresult = connectionObj.RawQuery(selectStm, null);
            return myresult;
        }

        public ICursor completeOrder()
        {
            String selectStm = "Select * from " + order_tablename + " where " + order_status + " = 'complete'";
            ICursor myresult = connectionObj.RawQuery(selectStm, null);
            return myresult;
        }
        public static string purchase_id = "pur_id";
        public static string ven_id = "vendor_id";
        public static string purchase_date = "pur_date";
        public static string purchase_amount = "pur_amt";


        /*      ***Order Table***       */
        public static string order_tablename = "order_table";
        public static string order_id = "order_id";
        public static string cust_id = "cust_id";
        public static string order_date = "or_date";
        public static string order_amount = "or_amt";
        public static string order_status = "or_status";


        //create order database
        public string order_creatTable = "Create Table " + order_tablename + "(" + order_id + " int, "
            + cust_id + " int, "
            + order_date + " Text, "
            + order_amount + " int, " 
            +order_status + " Text);";

        public void updateOrderStatus(string o_id)
        {
            String updateStm = "update " + order_tablename + " set " + order_status + " = 'complete' where " + order_id + " = " + o_id + ";";
            connectionObj.ExecSQL(updateStm);
            Console.WriteLine(updateStm);
        }



        //create database
        public string purchase_creatTable = "Create Table " + purchase_tablename + "(" + purchase_id + " int, "
            + ven_id + " int, "
            + purchase_date + " Text, "
            + purchase_amount + " int);";


        //Getting Category Detail
        public ICursor getCategory(int id)
        {
            String selectStm = "Select * from " + category + " where " + category_id + " = " + id +";";
            ICursor myresut = connectionObj.RawQuery(selectStm, null);
            return myresut;
        }


        /*      ***Sales Person Table***      */
        public static string sales_person_tablename = "sales_person";
        public static string sales_person_id = "sales_person_id";
        public static string sales_person_fname = "first_name";
        public static string sales_person_lname = "last_name";
        public static string sales_person_email = "sp_email";
        public static string sales_person_contact = "sp_contact";
        public static string sales_person_address = "sp_address";
        public static string sales_person_password = "sp_password";


        //update category
        public void updateCategory(string id, string name, int img_path)
        {
            String updateStm = "update " + category + " set " + category_name + " = '"
                + name + "', " + category_image + " = " + img_path + " where " + category_id + " = " + id + ";";
            connectionObj.ExecSQL(updateStm);
            Console.WriteLine(updateStm);
        }

        /*      Create table for sales person       */
        public string sales_person_creatTable = "Create Table " + sales_person_tablename + "(" 
            + sales_person_id + " int, "
            + sales_person_fname + " Text, "
            + sales_person_lname + " Text, "
            + sales_person_email + " Text, "
            + sales_person_contact + " Text, "
            + sales_person_address + " Text, "
            + sales_person_password + " Text);";


        // Delete category
        internal void deleteCategoryItem(int catid)
        {
            string dltStm = "Delete from " + category + " where " + category_id + "=" + catid + ";";
            Console.WriteLine(dltStm);
            System.Console.WriteLine("My SQL  delete STM \n  \n" + dltStm);
            connectionObj.ExecSQL(dltStm);
        }


        /*      ***Customer Table***      */
        public static string customer_tablename = "customer";
        public static string customer_id = "customer_id";
        public static string customer_Company_name = "c_company_name";
        public static string customer_address = "c_address";
        public static string customer_city = "c_city";
        public static string customer_province = "c_province";
        public static string customer_contact_person = "c_contact_person";
        public static string customer_contact_number = "c_contact_number";
        public static string customer_email = "c_email";

        //      Create Customer Table
        public string customer_creatTable = "Create Table " + customer_tablename + "("
            + customer_id + " int, "
            + customer_Company_name + " Text, "
            + customer_address + " Text, "
            + customer_city + " Text, "
            + customer_province + " Text, "
            + customer_contact_person + " Text, "
            + customer_contact_number + " Text, "
            + customer_email + " Text);";


        //      Inserting New Customer
        public void InsertCustomer(string cust_cmpny_name, string cust_address, string cust_city, string cust_province, string cust_contact_nme, string cust_contact_no, string cust_email)
        {
            String selectStm = "Select ifnull(max(" + customer_id + "),0) as max_id from " + customer_tablename;
            ICursor myresult = connectionObj.RawQuery(selectStm, null);
            myresult.MoveToFirst();
            var id = myresult.GetInt(myresult.GetColumnIndexOrThrow("max_id"));

            string insertStatement = "Insert into " + customer_tablename + " values(" + (id + 1) + ", '" + cust_cmpny_name + "', '"
                + cust_address + "', '" + cust_city + "', '" + cust_province + "', '" + cust_contact_nme + "', '" + cust_contact_no + "', '" + cust_email + "');";
            connectionObj.ExecSQL(insertStatement);
            Console.WriteLine(insertStatement);
        }

        //      Inserting New Vendor
        public void InsertVendor(string c_name, string v_address, string v_city, string v_province, string v_contact_name, string v_contact_number, bool fav)
        {
            String selectStm = "Select ifnull(max(" + vendor_id + "),0) as max_id from " + vendor_tablename;
            ICursor myresult = connectionObj.RawQuery(selectStm, null);
            myresult.MoveToFirst();
            var id = myresult.GetInt(myresult.GetColumnIndexOrThrow("max_id"));
            if(fav==true)
            {
                InsertFavVendor(id, c_name, v_contact_number);
            }
            string insertStatement = "Insert into " + vendor_tablename + " values(" + (id + 1) + ", '" + c_name + "', '"
                + v_address + "', '" + v_city + "', '" + v_province + "', '" + v_contact_name + "', '" + v_contact_number + "');";
            connectionObj.ExecSQL(insertStatement);
            Console.WriteLine(insertStatement);
        }

        //Creating Favourite Vendor
        public void InsertFavVendor(int id, string name, string contact)
        {
            string insertStatement = "Insert into " + favourite_tablename + " values(" + (id+1) + ", '" + name + "', '" + contact + "');";
            connectionObj.ExecSQL(insertStatement);
            Console.WriteLine(insertStatement);
        }

        //Getting Order Max Id
        public ICursor OrderID()
        {
            String selectStm = "Select ifnull(max(" + order_id + "),0) as max_id from " + order_tablename;
            ICursor myresult = connectionObj.RawQuery(selectStm, null);
            return myresult;

        }


        //Getting Purchase Max Id
        public ICursor PurchaseID()
        {
            String selectStm = "Select ifnull(max(" + purchase_id + "),0) as max_id from " + purchase_tablename;
            ICursor myresult = connectionObj.RawQuery(selectStm, null);
            return myresult;

        }

        //      Inserting Order data
        public void insertOrder(int or_id, int cust_id, string date, int total_amt)
        {
            string insertStatement = "Insert into " + order_tablename + " values(" + or_id + ", " + cust_id + ", '"
                + date + "', " + total_amt + ", 'pending');";
            connectionObj.ExecSQL(insertStatement);
            Console.WriteLine(insertStatement);

        }

        //      Inserting Purchase data
        public void insertPurchase(int pur_id, int ven_id, string date, int total_amt)
        {
            string insertStatement = "Insert into " + purchase_tablename + " values(" + pur_id + ", " + ven_id + ", '"
                + date + "', " + total_amt + ");";
            connectionObj.ExecSQL(insertStatement);
            Console.WriteLine(insertStatement);

        }
        //Inserting Product order
        public void insertOrderProduct(int or_id, int add_id, int qty)
        {
            string insertStatement = "Insert into " + order_product_tablename + " values(" + or_id + ", " + add_id + ", "
                + qty + ");";
            connectionObj.ExecSQL(insertStatement);
            Console.WriteLine(insertStatement);
        }

        //Inserting Product purchase
        public void insertPurchasedProduct(int pur_id, int add_id, int qty)
        {
            string insertStatement = "Insert into " + purchase_product_tablename + " values(" + pur_id + ", " + add_id + ", "
                + qty + ");";
            connectionObj.ExecSQL(insertStatement);
            Console.WriteLine(insertStatement);
        }

        /*      Purchase Product        */
        public static string purchase_product_tablename = "purchase_product";
        public static string product_purchase_id = "pur_id";
        public static string pro_id = "pro_id";
        public static string pro_qty = "pro_qty";

        //      Create Product Purchase Table
        public string product_purchase_creatTable = "Create Table " + purchase_product_tablename + "("
            + product_purchase_id + " int, "
            + pro_id + " int, "
            + pro_qty + " int);";


        /*      Order Product        */
        public static string order_product_tablename = "order_product";
        public static string product_order_id = "or_id";
        public static string o_pro_id = "pro_id";
        public static string o_pro_qty = "pro_qty";

        //      Create Product Order Table
        public string product_order_creatTable = "Create Table " + order_product_tablename + "("
            + product_order_id + " int, "
            + o_pro_id + " int, "
            + o_pro_qty + " int);";


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
            + product_image + " int);";



        /*      Category Table      */
        public static string category = "category";
        public static string category_id = "cat_id";
        public static string category_name = "cat_name";
        public static string category_image = "cat_img";

        

        //      Create Category Table
        public string category_creatTable = "Create Table " + category + "("
            + category_id + " int, "
            + category_name + " Text, "
            + category_image + " int);";


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
        public void insertCategory(string cat, int img_path)
        {
            String selectStm = "Select ifnull(max(" + category_id + "),0) as max_id from " + category;
            ICursor myresult = connectionObj.RawQuery(selectStm, null);
            myresult.MoveToFirst();
            var id = myresult.GetInt(myresult.GetColumnIndexOrThrow("max_id"));

            string insertStatement = "Insert into " + category + " values(" + (id + 1) + ", '" + cat + "', "
                + img_path + ");";
            connectionObj.ExecSQL(insertStatement);
            Console.WriteLine(insertStatement);

        }


        //Inserting New Product
        public void InsertProduct(int cat_id, string product_name, string unit_val, int product_purchase_price, int product_sell_price, int product_image)
        {
            String selectStm = "Select ifnull(max(" + product_id + "),0) as max_id from " + product_tablename;
            ICursor myresult = connectionObj.RawQuery(selectStm, null);
            myresult.MoveToFirst();
            var id = myresult.GetInt(myresult.GetColumnIndexOrThrow("max_id"));

            string insertStatement = "Insert into " + product_tablename + " values(" + (id + 1) + ", " + cat_id + ", '" 
                + product_name + "', '"
                + unit_val+"', "
                + product_purchase_price + ", "
                + product_sell_price + ", "
                + product_image + ");";
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
        public ICursor customer_list()
        {
            String selectStm = "Select * from " + customer_tablename + ";";
            ICursor myresut = connectionObj.RawQuery(selectStm, null);
            return myresut;
        }

        //Getting Vendor list
        public ICursor vendor_list()
        {
            String selectStm = "Select * from " + vendor_tablename + ";";
            ICursor myresut = connectionObj.RawQuery(selectStm, null);
            return myresut;
        }
        //Getting Product List for particular category
        public ICursor product_list1(int cat)
        {
            String selectStm = "Select * from " + product_tablename + " where " + cat_id + "= '" + cat + "';";
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
            db.ExecSQL(purchase_creatTable);
            db.ExecSQL(customer_creatTable);
            db.ExecSQL(fav_creatTable);
            db.ExecSQL(product_purchase_creatTable);
            db.ExecSQL(order_creatTable);
            db.ExecSQL(product_order_creatTable);
            //insertAdmin("admin","abc");
            string insertStm = "Insert into " + admin_tablename + " values('admin', 'abc');";
            Console.WriteLine(insertStm);
            db.ExecSQL(insertStm);
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