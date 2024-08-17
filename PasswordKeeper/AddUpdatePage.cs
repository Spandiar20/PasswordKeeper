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
    public partial class AddAccount : Form
    {
        public string UserId;
        public AddAccount()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string AccountName = textBox1.Text;
            string Password = textBox2.Text;
            DateTime time = DateTime.Now;

            SqlConnection sc = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename='W:\Work\Projects\Personal Password Manager\PasswordKeeper\PasswordKeeper\Passwords.mdf';Integrated Security=True");
            sc.Open();
            string query = "INSERT INTO Accounts (AccountName,Password,UserId,Date) VALUES ('" + AccountName + "','" + Password + "','" + UserId + "','" +  time + "')";
            SqlCommand command = new SqlCommand(query, sc);
            command.ExecuteNonQuery();
            sc.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string AccountName = textBox4.Text;
            string Password = textBox3.Text;
            DateTime time = DateTime.Now;

            SqlConnection sc = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename='W:\Work\Projects\Personal Password Manager\PasswordKeeper\PasswordKeeper\Passwords.mdf';Integrated Security=True");
            sc.Open();
            string query = "UPDATE Accounts SET Password='" + Password + "' WHERE AccountName='" + AccountName + "'";
            SqlCommand command = new SqlCommand(query, sc);
            command.ExecuteNonQuery();
            sc.Close();
        }
    }
}
