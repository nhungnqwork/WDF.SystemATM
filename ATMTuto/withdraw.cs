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
    public partial class withdraw : Form
    {
        public withdraw()
        {
            InitializeComponent();
        }
        string Acc = Login.AccNumber;
        int bal;
        int newBalance;
        SqlConnection sqlConnection = new SqlConnection("Data Source=DESKTOP-77LQJ4S;Initial Catalog=ATMdbo;Integrated Security=True");
        private void GetBalance()
        {
            sqlConnection.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select Balance from AccountTbl where AccNum='" + Acc + "'", sqlConnection);
            DataTable data = new DataTable();
            sda.Fill(data);
            balancelbl.Text = "Balance Rs " + data.Rows[0][0].ToString();
            bal = Convert.ToInt32(data.Rows[0][0].ToString());  
            sqlConnection.Close();
        }
        private void addTranstation()
        {
            string TrType = "Withdraw";
            try
            {
                sqlConnection.Open();
                string query = "insert into TransactionTbl values('" + Acc + "', '" + TrType + "',  '" + wdrawTb.Text + "', '" + DateTime.Today.Date.ToString() + "')";
                SqlCommand sqlcmd = new SqlCommand(query, sqlConnection);
                sqlcmd.ExecuteNonQuery();
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
        private void withdraw_Load(object sender, EventArgs e)
        {
            GetBalance();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            HOME h = new HOME();
            h.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (wdrawTb.Text == "")
            {
                MessageBox.Show("Missing Information");  
            }
            else if (Convert.ToInt32(wdrawTb.Text) <= 0)
            {
                MessageBox.Show("Enter a Valid Amount");
            }
            else if (Convert.ToInt32(wdrawTb.Text) > bal)
            {
                MessageBox.Show("Balance can not be negative");
            }
            else
            {
                try
                {
                    newBalance = bal - Convert.ToInt32(wdrawTb.Text);
                    try
                    {
                        sqlConnection.Open();
                        string query = "update AccountTbl set Balance='" + newBalance + "' where AccNum='" + Acc + "'";
                        SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                        sqlCommand.ExecuteNonQuery();
                        MessageBox.Show("Success Withdraw");
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
                catch (Exception)
                {

                    throw;
                }
            }
        }
    }
}
