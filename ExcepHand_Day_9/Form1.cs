using System;
using System.Windows.Forms;

namespace ExcepHand_Day_9
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                // Input validation for numeric fields
                if (!int.TryParse(txtSupplierID.Text.Trim(), out int supplierID))
                    throw new Exception("Supplier ID must be a valid number.");

                if (!int.TryParse(txtCategoryID.Text.Trim(), out int categoryID))
                    throw new Exception("Category ID must be a valid number.");

                if (!long.TryParse(txtMobile.Text.Trim(), out long mobile))
                    throw new Exception("Mobile number must be a valid 10-digit number.");

                // Create Supplier object
                Supplier supplier = new Supplier
                {
                    supplier_id = supplierID,
                    supplier_name = txtSupplierName.Text.Trim(),
                    category_id = categoryID,
                    city_name = txtCity.Text.Trim(),
                    mbl_num = mobile
                };

                // Validate supplier data
                supplier.Validate();

                // Show success message
                MessageBox.Show("Supplier details are valid!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
