using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Windows.Forms;
using System.Data;


namespace SimpleProjectAD.DBHelper
{
    internal class Helper
    {
        //Use for transacting in database
        public static string gen = "";
        public static OleDbCommand command;
        public static OleDbConnection conn;
        public static OleDbDataReader reader;

        public static void FillDb(string q, DataGridView dgv)
        {
            try
            {
                Connection.ConnectionDB.DB();
                DataTable dt = new DataTable();
                OleDbDataAdapter data = null;
                OleDbCommand cmd = new OleDbCommand(q, Connection.ConnectionDB.conn);
                data = new OleDbDataAdapter(cmd);
                data.Fill(dt);
                dgv.DataSource = dt;
                Connection.ConnectionDB.conn.Close();
            }
            catch(Exception ex)
            {
                Connection.ConnectionDB.conn.Close();
                MessageBox.Show(ex.Message, "Error FillDataGridView", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        public static void ModifyRecords(string updates)
        {
            try
            {
                Connection.ConnectionDB.DB();
                OleDbCommand cmd = new OleDbCommand(updates, Connection.ConnectionDB.conn);
                command.ExecuteNonQuery();
                Connection.ConnectionDB.conn.Open();
            }
            catch (Exception ex)
            {
                Connection.ConnectionDB.conn.Close();
                MessageBox.Show(ex.Message);
            }
        }
    }
}
