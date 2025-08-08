namespace Exceptional_handling
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            Employee emp = new Employee(1, "Anushree");
            emp.Display(out int eid, out string ename);
            MessageBox.Show(eid.ToString());
            MessageBox.Show(ename);
        }

    }
}