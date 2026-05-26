using System;
using System.Windows.Forms;
using BlApi;
using BO;

namespace WinFormsUI
{
    public partial class CustomerForm : Form
    {
        private readonly IBl _bl = BlApi.Factory.Get();
        private readonly Customer _existing;
        public CustomerForm(Customer existing = null)
        {
            InitializeComponent();
            _existing = existing;
            if (existing != null) LoadExisting(existing);
        }

        private void LoadExisting(Customer c)
        {
            txtCustomerId.Text = c.Id.ToString();
            txtCustomerId.Enabled = false; // prevent changing primary id on update
            txtName.Text = c.Name;
            txtAddress.Text = c.Address;
            txtPhone.Text = c.PhoneNumber;
            chkMember.Checked = c.IsClubMember;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCustomerId.Text))
            {
                MessageBox.Show("Customer ID is required", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!int.TryParse(txtCustomerId.Text, out var id))
            {
                MessageBox.Show("Customer ID must be a numeric value", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Name is required", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                var cust = new Customer
                {
                    Id = id,
                    Name = txtName.Text,
                    Address = txtAddress.Text,
                    PhoneNumber = txtPhone.Text,
                    IsClubMember = chkMember.Checked
                };

                if (_existing == null)
                    _bl.Customer.AddCustomer(cust);
                else
                    _bl.Customer.UpdateCustomer(cust);

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