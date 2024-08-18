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

        static string AccountName;
        static string Password;
        private void button1_Click(object sender, EventArgs e)
        {
            AccountName = textBox1.Text;
            Password = textBox2.Text;
            textBox1.Clear();
            textBox2.Clear();
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
            string AccId = null;
            string PrevPassword = null;
            textBox4.Clear();
            textBox3.Clear();
            DateTime time = DateTime.Now;

            //Getting previous account infos

            SqlConnection sc = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename='W:\Work\Projects\Personal Password Manager\PasswordKeeper\PasswordKeeper\Passwords.mdf';Integrated Security=True");
            string query = "SELECT * FROM Accounts WHERE AccountName = '" + AccountName + "'";
            sc.Open();
            SqlCommand command = new SqlCommand(query, sc);

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                AccId = reader["aId"].ToString();
                PrevPassword = reader["Password"].ToString();
            }

            sc.Close();

            //Updating the account infos

            sc.Open();
            query = "UPDATE Accounts SET Password='" + Password + "' WHERE AccountName='" + AccountName + "'";
            command = new SqlCommand(query, sc);
            command.ExecuteNonQuery();

            query = "UPDATE Accounts SET Date='" + time + "' WHERE AccountName='" + AccountName + "'";
            command = new SqlCommand(query, sc);
            command.ExecuteNonQuery();

            //Updating accounts log table

            Console.WriteLine(AccId);
            query = "INSERT INTO AccountLogs (Date,Password,AccountId,PrevPassword) VALUES ('" + time + "','" + Password + "','" + AccId + "','" + PrevPassword + "')";
            command = new SqlCommand(query, sc);
            command.ExecuteNonQuery();

            sc.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string AccountName = textBox6.Text;
            string Password = textBox5.Text;
            textBox6.Clear();
            textBox5.Clear();

            SqlConnection sc = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename='W:\Work\Projects\Personal Password Manager\PasswordKeeper\PasswordKeeper\Passwords.mdf';Integrated Security=True");
            sc.Open();
            string query = "INSERT INTO users (Username,Password) VALUES ('" + AccountName + "','" + Password + "')";
            SqlCommand command = new SqlCommand(query, sc);
            command.ExecuteNonQuery();
            sc.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string AccountName = textBox8.Text;
            string Password = textBox7.Text;
            textBox7.Clear();
            textBox8.Clear();

            SqlConnection sc = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename='W:\Work\Projects\Personal Password Manager\PasswordKeeper\PasswordKeeper\Passwords.mdf';Integrated Security=True");
            sc.Open();
            string query = "UPDATE users SET Password='" + Password + "' WHERE Username='" + AccountName + "'";
            SqlCommand command = new SqlCommand(query, sc);
            command.ExecuteNonQuery();
        }
    }
}
