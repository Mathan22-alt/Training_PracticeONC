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

namespace DatabaseConnectivityDemo
{
    public partial class FrmCategories : Form
    {
        CategoryBAL categoryBAL = null;
        public FrmCategories()
        {
            InitializeComponent();
            categoryBAL = new CategoryBAL();
        }

        private void FrmCategories_Load(object sender, EventArgs e)
        {
            List<CategoryBAL> categories = categoryBAL.CategoryList();
            dataGridView1.DataSource = categories;

        }

        private void InitializeComponent()
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            categoryBAL.CategoryName = txtcatname.Text;
            categoryBAL.CategoryDescription = txtcatdesc.Text;
            categoryBAL.AddProduct(categoryBAL);
            FrmCategories_Load(sender, e);

        }
    }
}