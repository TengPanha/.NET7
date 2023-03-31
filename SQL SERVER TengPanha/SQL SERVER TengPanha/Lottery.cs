using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SQL_SERVER_TengPanha
{
    public partial class Lottery : Form
    {
        public Lottery()
        {
            InitializeComponent();
        }
        List<Employee> employees;
        private void Lottery_Load(object sender, EventArgs e)
        {
            try
            {
                employees = Employee.GetAllEmployee();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                DialogResult = DialogResult.Abort;
            }
        }
        int index;
        private void btn_Click(object sender, EventArgs e)
        {
            string text = btn.Text;
            if (text == "Start")
            {
                btn.Text = "Stop";
                btn.Image = Properties.Resources.IconAsk;
                timer.Start();
            }
            else
            {
                btn.Text = "Start";
                btn.Image = Properties.Resources.iconPuse;
                timer.Stop();
                Employee employee = employees[index];
                list.Items.Add(employee);


                employees.RemoveAt(index);

            }
        }

        private void list_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (list.SelectedItems.Count > 0)
            {
                Employee employee = list.SelectedItem as Employee;
                txtId.Text = employee.Id.ToString();
                txtFullname.Text = employee.FirstName + employee.LastName;
                txtGender.Text = employee.Gender;
                txtDateOfBirth.Text = employee.DateOfBirth.ToString("yyyyy-MM-dd");
                txtEmail.Text = employee.Email;
                txtSalary.Text = employee.Salary.ToString(":c2");
                txtAddress.Text = employee.Address;
                picture.Image = employee.Photo;
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            Random random = new Random();
            index = random.Next(employees.Count);
            Employee employee = employees[index];
            txtRandomEmail.Text = employee.Email;
            /*picture.Image = employee.Photo;*/
        }
    }
}
