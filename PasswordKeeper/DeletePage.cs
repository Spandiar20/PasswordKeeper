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
            sc.Open();
            string query = "";
            SqlCommand command = new SqlCommand(query, sc);
            command.ExecuteNonQuery();

            sc.Close();
        }
    }
}
