using System;
using System.Windows.Forms;
using BlApi;

namespace WinFormsUI
{
    public partial class ManagerDashboardForm : Form
    {
        private readonly IBl _bl = BlApi.Factory.Get();
        public ManagerDashboardForm()
        {
            InitializeComponent();
        }

        private void ManagerDashboardForm_Load(object sender, EventArgs e)
        {
            RefreshProducts();
            RefreshCustomers();
            RefreshSales();
        }

        private void RefreshProducts()
        {
            try
            {
                dgvProducts.DataSource = _bl.Product.GetAllProducts();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RefreshCustomers()
        {
            try
            {
                dgvCustomers.DataSource = _bl.Customer.GetAllCustomers();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RefreshSales()
        {
            try
            {
                dgvSales.DataSource = _bl.Sale.GetAllSales();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnProductsAdd_Click(object sender, EventArgs e)
        {
            var f = new ProductForm();
            if (f.ShowDialog() == DialogResult.OK)
                RefreshProducts();
        }

        private void btnProductsUpdate_Click(object sender, EventArgs e)
        {
            if (dgvProducts.CurrentRow == null) return;
            var item = (dynamic)dgvProducts.CurrentRow.DataBoundItem;
            var f = new ProductForm(item);
            if (f.ShowDialog() == DialogResult.OK)
                RefreshProducts();
        }

        private void btnProductsDelete_Click(object sender, EventArgs e)
        {
            if (dgvProducts.CurrentRow == null) return;
            var item = (dynamic)dgvProducts.CurrentRow.DataBoundItem;
            try
            {
                _bl.Product.DeleteProduct(item.Id);
                RefreshProducts();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnProductsRefresh_Click(object sender, EventArgs e) => RefreshProducts();

        private void btnCustomersAdd_Click(object sender, EventArgs e)
        {
            var f = new CustomerForm();
            if (f.ShowDialog() == DialogResult.OK)
                RefreshCustomers();
        }

        private void btnCustomersUpdate_Click(object sender, EventArgs e)
        {
            if (dgvCustomers.CurrentRow == null) return;
            var item = (dynamic)dgvCustomers.CurrentRow.DataBoundItem;
            var f = new CustomerForm(item);
            if (f.ShowDialog() == DialogResult.OK)
                RefreshCustomers();
        }

        private void btnCustomersDelete_Click(object sender, EventArgs e)
        {
            if (dgvCustomers.CurrentRow == null) return;
            var item = (dynamic)dgvCustomers.CurrentRow.DataBoundItem;
            try
            {
                _bl.Customer.DeleteCustomer(item.Id);
                RefreshCustomers();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCustomersRefresh_Click(object sender, EventArgs e) => RefreshCustomers();

        private void btnSalesAdd_Click(object sender, EventArgs e)
        {
            var f = new SaleForm();
            if (f.ShowDialog() == DialogResult.OK)
                RefreshSales();
        }

        private void btnSalesUpdate_Click(object sender, EventArgs e)
        {
            if (dgvSales.CurrentRow == null) return;
            var item = (dynamic)dgvSales.CurrentRow.DataBoundItem;
            var f = new SaleForm(item);
            if (f.ShowDialog() == DialogResult.OK)
                RefreshSales();
        }

        private void btnSalesDelete_Click(object sender, EventArgs e)
        {
            if (dgvSales.CurrentRow == null) return;
            var item = (dynamic)dgvSales.CurrentRow.DataBoundItem;
            try
            {
                _bl.Sale.DeleteSale(item.Id);
                RefreshSales();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSalesRefresh_Click(object sender, EventArgs e) => RefreshSales();

        private void btnBackToRoleSelection_Click(object sender, EventArgs e)
        {
            var f = new RoleSelectionForm();
            f.Show();
            this.Close();
        }
    }
}