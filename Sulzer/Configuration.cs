using Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sulzer {
    public partial class Configuration : Form {
        public Configuration() {
            InitializeComponent();
        }

        private void Configuration_Load(object sender, EventArgs e) {

        }

        private void button1_Click(object sender, EventArgs e) {
            DatabaseContext context = new DatabaseContext();
            //Console.WriteLine("Enter Employee name");
            //string name = Console.ReadLine();
            //Console.WriteLine("Enter Salary");
            //double salary = Convert.ToDouble(Console.ReadLine());
            //Console.WriteLine("Enter Designation");
            //string designation = Console.ReadLine();
            EmployeeMaster employee = new EmployeeMaster() {
                EmpName = "wqwqw",
                Designation = "wedwds",
                Salary = 13234
            };
            context.EmployeeMaster.Add(employee);
            context.SaveChanges();

            var data = context.EmployeeMaster.ToList();
            foreach (var item in data) {
                Console.Write(string.Format("ID : {0}  Name : {1}  Salary : {2}   Designation : {3}{4}", item.ID, item.EmpName, item.Salary, item.Designation, Environment.NewLine));
            }
        }
    }
}
