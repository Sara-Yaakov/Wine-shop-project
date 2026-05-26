using System;
using System.Windows.Forms;

namespace WinFormsUI
{
    public partial class RoleSelectionForm : Form
    {
        public RoleSelectionForm()
        {
            InitializeComponent();
        }

        private void btnManager_Click(object sender, EventArgs e)
        {
            var f = new ManagerDashboardForm();
            f.Show();
            this.Hide();
        }

        private void btnCashier_Click(object sender, EventArgs e)
        {
            var f = new CustomerSelectionForm();
            f.Show();
            this.Hide();
        }
    }
}