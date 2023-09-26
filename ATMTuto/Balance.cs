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
    public partial class Balance : Form
    {
        public Balance()
        {
            InitializeComponent();
        }
        SqlConnection sqlConnection = new SqlConnection("Data Source=DESKTOP-77LQJ4S;Initial Catalog=ATMdbo;Integrated Security=True");
        private void GetBalance()
        {
            sqlConnection.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select Balance from AccountTbl where AccNum='" + AccNumberlbl.Text + "'", sqlConnection);
            DataTable data = new DataTable();
            sda.Fill(data);
            balancelbl.Text = "Rs " + data.Rows[0][0].ToString();
            sqlConnection.Close();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            HOME h = new HOME();
            h.ShowDialog();
            this.Hide();    
        }

        private void Balance_Load(object sender, EventArgs e)
        {
            AccNumberlbl.Text = $"{Login.AccNumber}";
            GetBalance();
        }
    }
}
