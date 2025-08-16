using BusinessLogicLibrary;

namespace DataBaseConnectivityDemo
{
    public partial class Form1 : Form
    {

        CategoryBAL categoryBAL = null;

        public Form1()
        {
            InitializeComponent();
            categoryBAL = new CategoryBAL();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            List<CategoryBAL> categories = categoryBAL.CategoryList();
            dataGridView1.DataSource = categories;

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
