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
    public partial class HOME : Form
    {
        public HOME()
        {
            InitializeComponent();
        }
        SqlConnection sqlConnection = new SqlConnection("Data Source=DESKTOP-77LQJ4S;Initial Catalog=ATMdbo;Integrated Security=True");
        string Acc = Login.AccNumber;
        private void GetBalance()
        {
            sqlConnection.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select Balance from AccountTbl where AccNum='" + Acc + "'", sqlConnection);
            DataTable data = new DataTable();
            sda.Fill(data);
            balancelbl.Text = " - Rs " + data.Rows[0][0].ToString();
            sqlConnection.Close();
        }
        private void label2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Balance bal = new Balance();
            this.Hide();
            bal.ShowDialog();
        }

        private void HOME_Load(object sender, EventArgs e)
        {
            AccNumlbl.Text = $"Account Number: {Login.AccNumber}";
            GetBalance();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Deposit depo = new Deposit();
            depo.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ChangePin Pin = new ChangePin();
            Pin.ShowDialog();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            withdraw wd = new withdraw();
            wd.ShowDialog();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            fastcash fcash = new fastcash();
            fcash.ShowDialog(); this.Hide();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Login l = new Login();
            l.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            ministatement m = new ministatement();
            m.Show();
            this.Hide();
        }
    }
}
