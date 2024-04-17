using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Windows.Forms;
using System.Data;

namespace SimpleProjectAD.Connection
{
    

    internal class ConnectionDB
    {
        //Connection string
        public static OleDbConnection conn;
        public static string dbconnect = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Application.StartupPath + "\\ADProjDB.accdb";

        public static void DB()
        {
            try
            {
                conn = new OleDbConnection(dbconnect);
                conn.Open();
            }
            catch (Exception ex)
            {
                conn.Close();
                MessageBox.Show(ex.Message);    
            }
        }
    }
}
