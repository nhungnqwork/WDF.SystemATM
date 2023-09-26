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
    public partial class fastcash : Form
    {
        public fastcash()
        {
            InitializeComponent();
        }
        SqlConnection sqlConnection = new SqlConnection("Data Source=DESKTOP-77LQJ4S;Initial Catalog=ATMdbo;Integrated Security=True");
        string Acc = Login.AccNumber;
        int bal;
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
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            HOME h = new HOME();
            h.Show();
            this.Hide();
        }
        private void fastcash_Load(object sender, EventArgs e)
        {
            GetBalance();

        }
        private void addTranstation1()
        {
            string TrType = "Fastcash";
            try
            {
                sqlConnection.Open();
                string query = "insert into TransactionTbl values('" + Acc + "', '" + TrType + "',  '" + 100 + "', '" + DateTime.Today.Date.ToString() + "')";
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
        } //100
        private void button1_Click(object sender, EventArgs e)
        {
            if (bal < 100)
            {
                MessageBox.Show("Balance can not be negative");
            }
            else
            {
                int newBalance = bal - 100;
                try
                {
                    sqlConnection.Open();
                    string query = "update AccountTbl set Balance='" + newBalance + "' where AccNum='" + Acc + "'";
                    SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                    sqlCommand.ExecuteNonQuery();
                    MessageBox.Show("Success Withdraw");
                    sqlConnection.Close();
                    addTranstation1();
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

        private void addTranstation2()
        {
            string TrType = "Fastcash";
            try
            {
                sqlConnection.Open();
                string query = "insert into TransactionTbl values('" + Acc + "', '" + TrType + "',  '" + 500 + "', '" + DateTime.Today.Date.ToString() + "')";
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
        } //500
        private void button5_Click(object sender, EventArgs e)
        {
            if (bal < 500)
            {
                MessageBox.Show("Balance can not be negative");
            }
            else
            {
                int newBalance = bal - 500;
                try
                {
                    sqlConnection.Open();
                    string query = "update AccountTbl set Balance='" + newBalance + "' where AccNum='" + Acc + "'";
                    SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                    sqlCommand.ExecuteNonQuery();
                    MessageBox.Show("Success Withdraw");
                    sqlConnection.Close();
                    addTranstation2();
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

        private void addTranstation3()
        {
            string TrType = "Fastcash";
            try
            {
                sqlConnection.Open();
                string query = "insert into TransactionTbl values('" + Acc + "', '" + TrType + "',  '" + 1000 + "', '" + DateTime.Today.Date.ToString() + "')";
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
        } //1000
        private void button2_Click(object sender, EventArgs e)
        {
            if (bal < 1000)
            {
                MessageBox.Show("Balance can not be negative");
            }
            else
            {
                int newBalance = bal - 1000;
                try
                {
                    sqlConnection.Open();
                    string query = "update AccountTbl set Balance='" + newBalance + "' where AccNum='" + Acc + "'";
                    SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                    sqlCommand.ExecuteNonQuery();
                    MessageBox.Show("Success Withdraw");
                    sqlConnection.Close();
                    addTranstation3();
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

        private void addTranstation4()
        {
            string TrType = "Fastcash";
            try
            {
                sqlConnection.Open();
                string query = "insert into TransactionTbl values('" + Acc + "', '" + TrType + "',  '" + 2000 + "', '" + DateTime.Today.Date.ToString() + "')";
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
        } //2000
        private void button6_Click(object sender, EventArgs e)
        {
            if (bal < 2000)
            {
                MessageBox.Show("Balance can not be negative");
            }
            else
            {
                int newBalance = bal - 52000;
                try
                {
                    sqlConnection.Open();
                    string query = "update AccountTbl set Balance='" + newBalance + "' where AccNum='" + Acc + "'";
                    SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                    sqlCommand.ExecuteNonQuery();
                    MessageBox.Show("Success Withdraw");
                    sqlConnection.Close();
                    addTranstation4();
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

        private void addTranstation5()
        {
            string TrType = "Fastcash";
            try
            {
                sqlConnection.Open();
                string query = "insert into TransactionTbl values('" + Acc + "', '" + TrType + "',  '" + 5000 + "', '" + DateTime.Today.Date.ToString() + "')";
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
        } //5000
        private void button3_Click(object sender, EventArgs e)
        {
            if (bal < 5000)
            {
                MessageBox.Show("Balance can not be negative");
            }
            else
            {
                int newBalance = bal - 5000;
                try
                {
                    sqlConnection.Open();
                    string query = "update AccountTbl set Balance='" + newBalance + "' where AccNum='" + Acc + "'";
                    SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                    sqlCommand.ExecuteNonQuery();
                    MessageBox.Show("Success Withdraw");
                    sqlConnection.Close();
                    addTranstation5();
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

        private void addTranstation6()
        {
            string TrType = "Fastcash";
            try
            {
                sqlConnection.Open();
                string query = "insert into TransactionTbl values('" + Acc + "', '" + TrType + "',  '" + 10000 + "', '" + DateTime.Today.Date.ToString() + "')";
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
        } //10000
        private void button4_Click(object sender, EventArgs e)
        {
            if (bal < 1000)
            {
                MessageBox.Show("Balance can not be negative");
            }
            else
            {
                int newBalance = bal - 1000;
                try
                {
                    sqlConnection.Open();
                    string query = "update AccountTbl set Balance='" + newBalance + "' where AccNum='" + Acc + "'";
                    SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                    sqlCommand.ExecuteNonQuery();
                    MessageBox.Show("Success Withdraw");
                    sqlConnection.Close();
                    addTranstation6();
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
    }
}
