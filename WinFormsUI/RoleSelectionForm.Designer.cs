namespace WinFormsUI
{
    partial class RoleSelectionForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Button btnManager;
        private System.Windows.Forms.Button btnCashier;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.btnManager = new System.Windows.Forms.Button();
            this.btnCashier = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnManager
            // 
            this.btnManager.Location = new System.Drawing.Point(30, 30);
            this.btnManager.Name = "btnManager";
            this.btnManager.Size = new System.Drawing.Size(200, 60);
            this.btnManager.TabIndex = 0;
            this.btnManager.Text = "Manager";
            this.btnManager.UseVisualStyleBackColor = true;
            this.btnManager.Click += new System.EventHandler(this.btnManager_Click);
            // 
            // btnCashier
            // 
            this.btnCashier.Location = new System.Drawing.Point(30, 110);
            this.btnCashier.Name = "btnCashier";
            this.btnCashier.Size = new System.Drawing.Size(200, 60);
            this.btnCashier.TabIndex = 1;
            this.btnCashier.Text = "Cashier";
            this.btnCashier.UseVisualStyleBackColor = true;
            this.btnCashier.Click += new System.EventHandler(this.btnCashier_Click);
            // 
            // RoleSelectionForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(260, 200);
            this.Controls.Add(this.btnCashier);
            this.Controls.Add(this.btnManager);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "RoleSelectionForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Role Selection";
            this.ResumeLayout(false);
        }
    }
}