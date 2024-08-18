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
    public partial class PasswordsTable : Form
    {
        public string UserName;
        public string UserId;
        SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename='W:\Work\Projects\Personal Password Manager\PasswordKeeper\PasswordKeeper\Passwords.mdf';Integrated Security=True");


        public PasswordsTable()
        {
            InitializeComponent();
        }

        private void PasswordsTable_Load(object sender, EventArgs e)
        {
            label2.Text = UserName;

            connection.Open();

            SqlDataAdapter adapt = new SqlDataAdapter("SELECT * FROM Accounts WHERE UserId = " + UserId + "" , connection);
            DataTable dtb1 = new DataTable();
            adapt.Fill(dtb1);

            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = dtb1;

            connection.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string searchText = textBox1.Text;

            connection.Open();

            SqlDataAdapter adapt = new SqlDataAdapter("SELECT * FROM Accounts WHERE UserId = " + UserId + " AND AccountName LIKE '%" + searchText + "%'", connection);
            DataTable dtb1 = new DataTable();
            adapt.Fill(dtb1);

            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = dtb1;

            connection.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            connection.Open();

            SqlDataAdapter adapt = new SqlDataAdapter("SELECT * FROM Accounts WHERE UserId = " + UserId + "", connection);
            DataTable dtb1 = new DataTable();
            adapt.Fill(dtb1);

            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = dtb1;

            connection.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AddAccount add = new AddAccount();
            add.Show();
            add.UserId = UserId;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            LogPage log = new LogPage();
            log.Show();
            log.UserId = UserId;
        }
    }
}
