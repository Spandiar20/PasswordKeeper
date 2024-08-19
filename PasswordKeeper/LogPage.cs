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

namespace PasswordKeeper
{
    public partial class LogPage : Form
    {
        public string UserId;
        SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename='W:\Work\Projects\Personal Password Manager\PasswordKeeper\PasswordKeeper\Passwords.mdf';Integrated Security=True");

        public LogPage()
        {
            InitializeComponent();

            connection.Open();

            SqlDataAdapter adapt = new SqlDataAdapter("SELECT * FROM AccountLogs INNER JOIN Accounts ON AccountLogs.AccountId = Accounts.aId WHERE UserId = '" + UserId + "'", connection);
            DataTable dtb1 = new DataTable();
            adapt.Fill(dtb1);

            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = dtb1;

            connection.Close();
        }

        private void LogPage_Load(object sender, EventArgs e)
        {
            connection.Open();

            SqlDataAdapter adapt = new SqlDataAdapter("SELECT * FROM AccountLogs INNER JOIN Accounts ON AccountLogs.AccountId = Accounts.aId WHERE UserId = '" + UserId + "'", connection);
            DataTable dtb1 = new DataTable();
            adapt.Fill(dtb1);

            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = dtb1;

            connection.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            connection.Open();

            SqlDataAdapter adapt = new SqlDataAdapter("SELECT * FROM AccountLogs INNER JOIN Accounts ON AccountLogs.AccountId = Accounts.aId WHERE UserId = '" + UserId + "'", connection);
            DataTable dtb1 = new DataTable();
            adapt.Fill(dtb1);

            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = dtb1;

            connection.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string searchContent = textBox1.Text;

            connection.Open();

            SqlDataAdapter adapt = new SqlDataAdapter("SELECT * FROM AccountLogs AS al INNER JOIN Accounts AS a ON al.AccountId = a.aId INNER JOIN users AS u ON u.uId = a.UserId WHERE a.UserId = '" + UserId + "' AND a.AccountName LIKE '%" + searchContent + "%'", connection);
            DataTable dtb1 = new DataTable();
            adapt.Fill(dtb1);

            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = dtb1;

            connection.Close();
        }
    }
}
