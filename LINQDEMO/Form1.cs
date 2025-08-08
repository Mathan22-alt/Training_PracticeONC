using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace LINQDEMO
{
    public partial class Form1 : Form
    {
        private List<Student> students;
        private LINQDemo linqDemo;

        public Form1()
        {
            InitializeComponent();

            students = new List<Student>
            {
                new Student { Id = 1, Name = "Alice", Age = 20, Department = "CS", Marks = new List<int>{ 90, 85, 92 } },
                new Student { Id = 2, Name = "Bob", Age = 22, Department = "IT", Marks = new List<int>{ 70, 75, 72 } },
                new Student { Id = 3, Name = "Charlie", Age = 21, Department = "CS", Marks = new List<int>{ 60, 65, 58 } },
                new Student { Id = 4, Name = "David", Age = 23, Department = "EC", Marks = new List<int>{ 88, 90, 84 } },
                new Student { Id = 5, Name = "Eve", Age = 20, Department = "IT", Marks = new List<int>{ 95, 92, 96 } }
            };

            linqDemo = new LINQDemo();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Optional logic here
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();

            var topCSStudents = linqDemo.GetTopCSStudents(students);

            foreach (var student in topCSStudents)
            {
                listBox1.Items.Add($"{student.Name} - Avg: {student.Marks.Average():F2}");
            }

            if (topCSStudents.Count == 0)
            {
                listBox1.Items.Add("No CS students found with average > 80.");
            }
        }
    }
}
