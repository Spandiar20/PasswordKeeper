﻿using System;
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
    public partial class loginPage : Form
    {
        public loginPage()
        {
            InitializeComponent();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string userName = textBox1.Text;
            string password = textBox2.Text;

            SqlConnection sc = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename='W:\Work\Projects\Personal Password Manager\PasswordKeeper\PasswordKeeper\Passwords.mdf';Integrated Security=True");
            sc.Open();
            string query = "SELECT * FROM users WHERE Username = '" + userName + "'" + "AND Password = '" + password + "'";
            SqlCommand command = new SqlCommand(query, sc);

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                string name = reader["Username"].ToString();
                PasswordsTable pt = new PasswordsTable();
                pt.UserName = userName;
                pt.UserId = reader["uId"].ToString();
                pt.Show();
                this.Hide();
            }

            sc.Close();
        }
    }
}
