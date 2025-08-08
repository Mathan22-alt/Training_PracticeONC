using RetailLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace QuerySyntaxDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int[] numbers = new int[] { 1, 23, 42, 563, 2566, 6777, 4444, 22446688 };

            var eveNos = (from n in numbers
                          where n % 2 == 0
                          select n).ToList();

            listBox1.Items.Clear(); // Clear old output
            foreach (var item in eveNos)
            {
                listBox1.Items.Add(item);
            }
        }

        List<Employee> employees = new List<Employee>();

        private void button2_Click(object sender, EventArgs e)
        {
            employees.Clear(); // Avoid duplicate entries

            employees.Add(new Employee { Empid = 10, EmpName = "Sara", City = "Pune", Salary = 22000, Deptno = 10 });
            employees.Add(new Employee { Empid = 11, EmpName = "Raj", City = "Thane", Salary = 33000, Deptno = 23 });
            employees.Add(new Employee { Empid = 12, EmpName = "Veera", City = "Chennai", Salary = 24000, Deptno = 10 });
            employees.Add(new Employee { Empid = 13, EmpName = "Kia", City = "Pune", Salary = 18000, Deptno = 23 });
            employees.Add(new Employee { Empid = 14, EmpName = "Ravi", City = "Delhi", Salary = 27000, Deptno = 10 });

            var grouped = from emp in employees
                          group emp by emp.Deptno into g
                          select new { Department = g.Key, EmpCount = g.Count() };

            listBox1.Items.Clear(); // Clear old output
            foreach (var item in grouped)
            {
                listBox1.Items.Add($"Deptno = {item.Department} and Employees = {item.EmpCount}");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
    }
}
