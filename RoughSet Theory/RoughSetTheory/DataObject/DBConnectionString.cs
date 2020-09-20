using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Security.Cryptography;
using System.IO;
using System.Configuration;
using System.Xml.XPath;
using System.Data.SqlClient;
using System.Linq;
namespace DataObject
{
    public static class DBConnectionString
    {

        #region ConnectionString

        public static string ConnectionString
        {
            get
            {
                //var serverName = "(LocalDB)\v11.0";
                //var database = @"C:\Users\Zaw Lin Htay\Desktop\Kyaw Zin Thant\RoughSetTheory\RoughSetTheory\DecisionSystem.mdf";
                ////AttachDbFilename=
                ////var username = "sa";
                ////var password = "123123";
                //return string.Format("Data Source={0};AttachDbFilename={1};Integrated Security=True;Connect Timeout=30;", serverName, database);              
                return @"Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\DecisionSystem.mdf;Integrated Security=True;Connect Timeout=30";
            }
        }  

        #endregion

        #region Events
        public static void TableClear(object sender, DataTableClearEventArgs e)
        {

            e.Table.Columns["no"].AutoIncrementSeed = e.Table.Columns["no"].AutoIncrementStep = -1;
            e.Table.Columns["no"].AutoIncrementSeed = e.Table.Columns["no"].AutoIncrementStep = 1;
        }
        #endregion

    }
}
