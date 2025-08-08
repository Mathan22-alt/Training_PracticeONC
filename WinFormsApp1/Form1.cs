using System;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            button1.Click += button1_Click;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Userlogic logic = new Userlogic
            {
                Username = textBox1.Text.Trim(),
                Password = textBox2.Text
            };

            if (logic.ValidateUser())
            {
                MessageBox.Show(logic.Greet(), "Login Success");
            }
            else
            {
                MessageBox.Show("Invalid username or password.", "Login Failed");
            }
        }

        private void Form1_Load(object sender, EventArgs e) { }
        private void label1_Click(object sender, EventArgs e) { }
        private void textBox1_TextChanged(object sender, EventArgs e) { }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
