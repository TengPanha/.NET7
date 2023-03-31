using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQL_SERVER_TengPanha
{
    internal class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string Email { get; set; }

        public double Salary { get; set; }

        public string Address { get; set; }

        public Image Photo { get; set; }
        public Employee()
        {

        }

        public Employee(int id, string firstName, string lastName, string gender, DateTime dateOfBirth, string email, double salary, string address, Image photo)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Gender = gender;
            DateOfBirth = dateOfBirth;
            Email = email;
            Salary = salary;
            Address = address;
            Photo = photo;
        }
        public object[] Record()
        {
            return new object[] { Id,
                FirstName,
                LastName,
                Gender,
                $"{DateOfBirth:dd-mm-yy}",
                Email,
               $"{Salary:c2}",
                Address,
                Photo };
        }
        public static List<Employee> GetAllEmployee()
        {
            List<Employee> employees = new List<Employee>();
            string sql = "SELECT * FROM ss20.dbo.tblEmployee;";
            SqlCommand s = new SqlCommand(sql, DataConnection.DataCon);
            SqlDataReader r = s.ExecuteReader();
            while (r.Read())
            {
                int id = int.Parse(r[0].ToString());
                string firstname = r[1].ToString();
                string lastName = r[2].ToString();
                string gender = r[3].ToString();
                DateTime dateOfBirth = ((DateTime)(r[4]));
                string email = r[5].ToString();
                double salary = double.Parse(r[6].ToString());
                string address = r[7].ToString();
                byte[] bytes = (byte[])(r[8]);
                MemoryStream memoryStream = new MemoryStream(bytes);
                Image photo = Image.FromStream(memoryStream);
                employees.Add(new Employee(id, firstname, lastName, gender, dateOfBirth, email, salary, address, photo));


            }
            s.Dispose();
            r.Close();
            return employees;
        }
        public override string ToString()
        {
            return $"{Id:0000}, {Email} ,{FirstName + LastName}";
        }
    }
}
