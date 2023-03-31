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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Login login = new Login();
            login.ShowDialog(this);
            
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            DataConnection.DataCon = null;
            new Login().ShowDialog(this);
        }

        private void btnShow_employee_Click(object sender, EventArgs e)
        {
            new ShowEmployee().ShowDialog(this);
        }

        private void btnLottery_Click(object sender, EventArgs e)
        {
            new Lottery().ShowDialog(this);
        }

        private void People_Enter(object sender, EventArgs e)
        {

        }
    }
}
