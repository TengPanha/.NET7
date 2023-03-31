using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SQL_SERVER_TengPanha
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                int index = comboAuthentication.SelectedIndex;
                string ip = txtIp.Text.Trim();
                string dbname = "ss20";
                string username = txtUserName.Text.Trim();
                string password = txtPassword.Text.Trim();
                if (index == 0)
                {
                    DataConnection.ConnectionDB(ip, dbname);
                }
                else
                {
                    DataConnection.ConnectionDB(ip, dbname, username, password);
                }
                DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Connection ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void comboAuthentication_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = comboAuthentication.SelectedIndex;
            if (index == 0)
            {
                txtUserName.Enabled = false;
                txtPassword.Enabled = false;
            }
            else
            {
                txtPassword.Enabled = true;
                txtUserName.Enabled = true;
            }
        }
        private void Login_Load(object sender, EventArgs e)
        {
            comboAuthentication.SelectedIndex = 1;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
