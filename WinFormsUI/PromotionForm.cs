using System;
using System.Windows.Forms;
using BO;

namespace WinFormsUI
{
    // Simple promotion form stub so ManagerDashboardForm can compile and run.
    public class PromotionForm : Form
    {
        private readonly Sale? _existing;

        public PromotionForm()
        {
            InitializeComponent();
        }

        public PromotionForm(Sale existing) : this()
        {
            _existing = existing;
            LoadExisting(existing);
        }

        private void LoadExisting(Sale s)
        {
            // minimal loading; UI is a stub
            Text = $"Promotion - {s.Id}";
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            //
            // PromotionForm
            //
            this.ClientSize = new System.Drawing.Size(400, 300);
            this.Name = "PromotionForm";
            this.Text = "Promotion";

            var btnOk = new Button();
            btnOk.Text = "OK";
            btnOk.DialogResult = DialogResult.OK;
            btnOk.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnOk.Size = new System.Drawing.Size(75, 23);
            btnOk.Location = new System.Drawing.Point(310, 260);
            this.Controls.Add(btnOk);
            this.AcceptButton = btnOk;

            this.ResumeLayout(false);
        }
    }
}
