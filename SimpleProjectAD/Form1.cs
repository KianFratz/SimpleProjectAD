using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleProjectAD
{
    public partial class Form1 : Form
    {
        public string sendtext = ""; 
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void loginBtn_Click(object sender, EventArgs e)
        {
            // Confirming if the account is in the database
            try
            {
                Connection.ConnectionDB.DB();
                DBHelper.Helper.gen = "Select * from users where[username] = '" + txtusername.Text + "' and [password] = '" + txtpassword.Text + "'";
                DBHelper.Helper.command = new OleDbCommand(DBHelper.Helper.gen, Connection.ConnectionDB.conn);
                DBHelper.Helper.reader = DBHelper.Helper.command.ExecuteReader();

                if(DBHelper.Helper.reader.HasRows)
                {
                    DBHelper.Helper.reader.Read();
                    txtusername.Text = (DBHelper.Helper.reader["username"].ToString());
                    txtpassword.Text = (DBHelper.Helper.reader["password"].ToString());

                    timer1.Enabled = true;
                    timer1.Start();
                    timer1.Interval = 1000;
                    progressBar1.Maximum = 200;
                    timer1.Tick += new EventHandler(timer1_Tick);
                }

            }
            catch(Exception ex)
            {
                Connection.ConnectionDB.conn.Close();
                MessageBox.Show(ex.Message);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if(progressBar1.Value != 200)
            {
                progressBar1.Value++;
            }
            else
            {
                timer1.Stop();
                this.Hide();

                progressBar1.Value = 0;
                sendtext = txtusername.Text;
                Stocks stocks = new Stocks();
                stocks.Show();
            }
        }
    }
}
