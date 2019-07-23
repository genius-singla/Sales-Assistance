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



        public DBHelper(Context context) : base(context, name: DBName, factory: null, version: 1)
        {
            myContex = context;
            connectionObj = WritableDatabase;
        }

        public override void OnCreate(SQLiteDatabase db)
        {
            System.Console.WriteLine("My Create Table STM \n \n" + admin_creatTable);

            db.ExecSQL(admin_creatTable);
            insertAdmin("admin","123");
        }

        //Insert data into admin table
        public void insertAdmin(string uname, string upass)
        {
            string insertStm = "Insert into " + admin_tablename + " values('" + uname + "', '" + upass + "');";
            Console.WriteLine(insertStm);
            connectionObj.ExecSQL(insertStm);
        }

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