using System;
using System.Drawing;
using System.Windows.Forms;
using ExceptionHandlingDemo; // Use the namespace from Employee.cs

namespace ExceptionalHandling_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Optional startup logic
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Employee emp = new Employee(1, "Anushree");
            emp.Display(out int eid, out string ename);

            MessageBox.Show(eid.ToString(), "Employee ID");
            MessageBox.Show(ename, "Employee Name");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            EmployeeDesignations emp = new EmployeeDesignations();
            emp.Designation = EmployeeType.Lead;

            MessageBox.Show("You entered designation = " + emp.Designation.ToString(), "Designation");

            // Optional: Change button color as a demo
            button1.BackColor = Color.Red;
        }
    }
}
