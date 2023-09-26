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
    public partial class ministatement : Form
    {
        public ministatement()
        {
            InitializeComponent();
        }
        SqlConnection sqlConnection = new SqlConnection("Data Source=DESKTOP-77LQJ4S;Initial Catalog=ATMdbo;Integrated Security=True");
        string Acc = Login.AccNumber;
        private void populate()
        {
            sqlConnection.Open();
            string query = "select * from TransactionTbl where AccNum='"+Acc+"'";
            SqlCommand cmd = new SqlCommand(query, sqlConnection);
            SqlDataAdapter data = new SqlDataAdapter(cmd);
            DataTable tb = new DataTable();
            data.Fill(tb);
            ministatementDGV.DataSource = tb;
            sqlConnection.Close();
        }
        private void ministatement_Load(object sender, EventArgs e)
        {
            populate();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            HOME h = new HOME();
            h.Show();
            this.Hide();
        }
    }
}
