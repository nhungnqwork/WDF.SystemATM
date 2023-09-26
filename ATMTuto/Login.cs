using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ATMTuto
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        public static String AccNumber;
        SqlConnection sqlConnection = new SqlConnection("Data Source=DESKTOP-77LQJ4S;Initial Catalog=ATMdbo;Integrated Security=True");

        //login
        private void button1_Click(object sender, EventArgs e)
        {
            sqlConnection.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select count(*) from AccountTbl where AccNum='"+AccNumTb.Text+"' and PIN= '" + PinTb.Text + "'", sqlConnection);
            DataTable data = new DataTable();
            sda.Fill(data);
            if (data.Rows[0][0].ToString() == "1")
            {
                AccNumber = AccNumTb.Text;
                HOME h = new HOME();
                h.ShowDialog();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Wrong input");
            }
            sqlConnection.Close();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            account a = new account();
            a.ShowDialog();
            this.Hide();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
