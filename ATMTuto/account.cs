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
    public partial class account : Form
    {
        public account()
        {
            InitializeComponent();
        }

        SqlConnection sqlConnection = new SqlConnection("Data Source=DESKTOP-77LQJ4S;Initial Catalog=ATMdbo;Integrated Security=True");

        private void button1_Click(object sender, EventArgs e)
        {
            if (AccNameTb.Text == "" || AccNumTb.Text == "" || FnameTb.Text == "" || AddressTb.Text == "" || PinTb.Text == "" || educationcb.SelectedIndex == -1 || occupationTb.Text == "" || PhoneTb.Text == "" || PinTb.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    int bal = 0;
                    sqlConnection.Open();
                    string query = "insert into AccountTbl values('"+ AccNumTb.Text + "', '"+ AccNameTb.Text + "',  '" + FnameTb.Text + "', '"+ dobdate.Value.Date + "', '"+ PhoneTb.Text + "' ,'" + AddressTb.Text + "', '"+ educationcb.SelectedIndex.ToString() + "', '"+ occupationTb.Text + "', "+bal+", '" + PinTb.Text +"')";
                    SqlCommand sqlcmd = new SqlCommand(query, sqlConnection);
                    sqlcmd.ExecuteNonQuery();
                    MessageBox.Show("Create successfully!!");
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
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DialogResult h = MessageBox.Show("Bạn có thực sự muốn thoát?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (h == DialogResult.OK) 
            {
                Application.Exit();
            }
        }



        #region Chặn k cho ghi chữ hoặc ký tự đặc biệt
        private void AccNumTb_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }
        private void PinTb_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void PhoneTb_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }
        #endregion



    }
}
