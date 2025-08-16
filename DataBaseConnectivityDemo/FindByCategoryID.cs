using BusinessLogicLayerLibrary;
using BusinessLogicLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DatabaseConnectivityDemo
{
    public partial class FindByCategoryID : Form
    {
        CategoryBAL bal = null;
        public FindByCategoryID()
        {
            InitializeComponent();
            bal = new CategoryBAL();
        }

        private void FindByCategoryID_Load(object sender, EventArgs e)
        {



        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            int id = Convert.ToInt32(textBox1.Text);
            List<ProductsBAL> products = bal.FindProductByCategoryIDAndOrderByProductName(id);

            dataGridView1.DataSource = products;


        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            int id = Convert.ToInt32(textBox1.Text);
            List<ProductsBAL> products = bal.FindProductByCategoryIDAndOrderBySupplierid(id);

            dataGridView1.DataSource = products;

        }
    }
}