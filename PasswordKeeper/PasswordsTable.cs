using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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

        public PasswordsTable()
        {
            InitializeComponent();
        }

        private void PasswordsTable_Load(object sender, EventArgs e)
        {
            label2.Text = UserName;
        }
    }
}
