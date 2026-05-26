using System;
using System.Windows.Forms;
using BlApi;
using BO;

namespace WinFormsUI
{
    public partial class ProductForm : Form
    {
        private readonly IBl _bl = BlApi.Factory.Get();
        private readonly Product _existing;
        public ProductForm(Product existing = null)
        {
            InitializeComponent();
            _existing = existing;
            if (existing != null) LoadExisting(existing);
        }

        private void LoadExisting(Product p)
        {
            txtName.Text = p.Name;
            numAmount.Value = p.Amount;
            txtWinery.Text = p.Winery;
            numPrice.Value = (decimal)p.Price;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Name is required", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (numAmount.Value <= 0)
            {
                MessageBox.Show("Amount must be > 0", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                var p = new Product
                {
                    Id = _existing?.Id ?? 0,
                    Name = txtName.Text,
                    Amount = (int)numAmount.Value,
                    Price = (double)numPrice.Value,
                    Winery = txtWinery.Text
                };

                if (_existing == null)
                    _bl.Product.AddProduct(p);
                else
                    _bl.Product.UpdateProduct(p);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}