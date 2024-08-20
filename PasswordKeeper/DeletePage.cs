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
    public partial class DeletePage : Form
    {

        SqlConnection sc = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename='W:\Work\Projects\Personal Password Manager\PasswordKeeper\PasswordKeeper\Passwords.mdf';Integrated Security=True");
        public string UserId;
        public DeletePage()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string AccountName = textBox1.Text;

            sc.Open();

            string query = "DELETE AccountLogs FROM AccountLogs INNER JOIN Accounts ON AccountLogs.AccountId = Accounts.aId WHERE AccountName = '" + AccountName + "' AND Accounts.UserId = '" + UserId + "'";
            SqlCommand command = new SqlCommand(query, sc);
            command.ExecuteNonQuery();

            textBox1.Clear();

            sc.Close();

            MessageBox.Show("Account Deleted!");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string Username = textBox6.Text;
            string Password = textBox5.Text;

            sc.Open();

            string query = "DELETE FROM users WHERE Username = '" + Username + "' AND Password = '" + Password + "'";
            SqlCommand command = new SqlCommand(query, sc);
            command.ExecuteNonQuery();

            textBox5.Text = textBox6.Text = "";

            sc.Close();

            MessageBox.Show("User Deleted!");

        }
    }
}
