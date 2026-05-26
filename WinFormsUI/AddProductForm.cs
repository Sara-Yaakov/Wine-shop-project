using System;
using System.Linq;
using System.Windows.Forms;
using BlApi;

namespace WinFormsUI
{
    public partial class AddProductForm : Form
    {
        private readonly IBl _bl = BlApi.Factory.Get();
        public int SelectedProductId { get; private set; }
        public decimal Quantity => numQuantity.Value;

        public AddProductForm()
        {
            InitializeComponent();
            LoadProducts();
        }

        private void LoadProducts()
        {
            try
            {
                var list = _bl.Product.GetAllProducts();
                cmbProducts.DataSource = list;
                cmbProducts.DisplayMember = "Name";
                cmbProducts.ValueMember = "Id";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (cmbProducts.SelectedItem == null)
            {
                MessageBox.Show("Please select a product", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (numQuantity.Value <= 0)
            {
                MessageBox.Show("Quantity must be > 0", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            SelectedProductId = (int)cmbProducts.SelectedValue;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}