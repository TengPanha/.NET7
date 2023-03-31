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
    public partial class ShowEmployee : Form
    {
        public ShowEmployee()
        {
            InitializeComponent();
        }

        private void ShowEmployee_Load(object sender, EventArgs e)
        {
            try
            {
                List<Employee> list = Employee.GetAllEmployee();
                foreach (Employee emp in list)
                {
                    data.Rows.Add(emp.Record());
                }
                Console.WriteLine("der hz");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                MessageBox.Show(ex.Message);
                DialogResult = DialogResult.OK;
            }
        }
    }
}
