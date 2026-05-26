namespace WinFormsUI
{
    partial class CustomerSelectionForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Button btnStartOrder;
        private System.Windows.Forms.Button btnBackToRoleSelection;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.btnStartOrder = new System.Windows.Forms.Button();
            this.btnBackToRoleSelection = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnStartOrder
            // 
            this.btnStartOrder.Location = new System.Drawing.Point(30, 30);
            this.btnStartOrder.Name = "btnStartOrder";
            this.btnStartOrder.Size = new System.Drawing.Size(200, 60);
            this.btnStartOrder.Text = "Start Order";
            this.btnStartOrder.Click += new System.EventHandler(this.btnStartOrder_Click);
            // 
            // btnBackToRoleSelection
            // 
            this.btnBackToRoleSelection.Location = new System.Drawing.Point(30, 100);
            this.btnBackToRoleSelection.Name = "btnBackToRoleSelection";
            this.btnBackToRoleSelection.Size = new System.Drawing.Size(200, 30);
            this.btnBackToRoleSelection.Text = "Back";
            this.btnBackToRoleSelection.Click += new System.EventHandler(this.btnBackToRoleSelection_Click);
            // 
            // CustomerSelectionForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(260, 140);
            this.Controls.Add(this.btnStartOrder);
            this.Controls.Add(this.btnBackToRoleSelection);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "CustomerSelectionForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Customer";
            this.ResumeLayout(false);
        }
    }
}