using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ATMTuto
{
    public partial class Deposit : Form
    {
        public Deposit()
        {
            InitializeComponent();
        }
        SqlConnection sqlConnection = new SqlConnection("Data Source=DESKTOP-77LQJ4S;Initial Catalog=ATMdbo;Integrated Security=True");
        string Acc = Login.AccNumber;
        private void addTranstation()
        {
            string TrType = "Deposit";
            try
            {
                sqlConnection.Open();
                string query = "insert into TransactionTbl values('" + Acc + "', '" + TrType + "',  '" + DepoAmtTb.Text + "', '" + DateTime.Today.Date.ToString() + "')";
                SqlCommand sqlcmd = new SqlCommand(query, sqlConnection);
                sqlcmd.ExecuteNonQuery();
                //MessageBox.Show("Create successfully!!");
                sqlConnection.Close();
                Login log = new Login();
                log.Show();
                this.Hide();
            }
            catch (Exception Ex)
            {
                MessageBox.Show($"Error: {Ex}");
                throw;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (DepoAmtTb.Text == "" || Convert.ToInt32(DepoAmtTb.Text) <= 0)
            {
                MessageBox.Show("Enter your amount to Deposit");
            }
            else
            {
                newBalance = oldBalance + Convert.ToInt32(DepoAmtTb.Text);
                try
                {
                    sqlConnection.Open();
                    string query = "update AccountTbl set Balance='" + newBalance + "' where AccNum='"+Acc+"'";
                    SqlCommand sqlCommand= new SqlCommand(query,sqlConnection);
                    sqlCommand.ExecuteNonQuery();
                    MessageBox.Show("Success Deposit");
                    sqlConnection.Close();
                    addTranstation();
                    HOME h = new HOME();
                    h.Show();
                    this.Hide();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            HOME h = new HOME();
            h.Show();
            this.Hide();
        }
        int oldBalance, newBalance;
        private void GetBalance()
        {
            sqlConnection.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select Balance from AccountTbl where AccNum='" + Acc + "'", sqlConnection);
            DataTable data = new DataTable();
            sda.Fill(data);
            oldBalance = Convert.ToInt32(data.Rows[0][0].ToString());
            sqlConnection.Close();
        }

        private void Deposit_Load(object sender, EventArgs e)
        {
            GetBalance();
        }
    }
}
