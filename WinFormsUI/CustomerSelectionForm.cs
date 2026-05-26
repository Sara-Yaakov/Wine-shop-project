using System;
using System.Windows.Forms;

namespace WinFormsUI
{
    public partial class CustomerSelectionForm : Form
    {
        public CustomerSelectionForm()
        {
            InitializeComponent();
        }

        private void btnStartOrder_Click(object sender, EventArgs e)
        {
            var f = new OrderForm();
            f.Show();
            this.Hide();
        }

        private void btnBackToRoleSelection_Click(object sender, EventArgs e)
        {
            var f = new RoleSelectionForm();
            f.Show();
            this.Close();
        }
    }
}