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