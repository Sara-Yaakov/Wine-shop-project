namespace WinFormsUI
{
    partial class ProductForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblAmount;
        private System.Windows.Forms.NumericUpDown numAmount;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.NumericUpDown numPrice;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblWinery;
        private System.Windows.Forms.TextBox txtWinery;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblName = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblAmount = new System.Windows.Forms.Label();
            this.numAmount = new System.Windows.Forms.NumericUpDown();
            this.lblPrice = new System.Windows.Forms.Label();
            this.numPrice = new System.Windows.Forms.NumericUpDown();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblWinery = new System.Windows.Forms.Label();
            this.txtWinery = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.numAmount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPrice)).BeginInit();
            this.SuspendLayout();
            // 
            // lblName
            // 
            this.lblName.Location = new System.Drawing.Point(12, 9);
            this.lblName.Size = new System.Drawing.Size(100, 23);
            this.lblName.Text = "Name";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(12, 35);
            this.txtName.Size = new System.Drawing.Size(260, 23);
            // 
            // lblWinery
            // 
            this.lblWinery.Location = new System.Drawing.Point(12, 65);
            this.lblWinery.Size = new System.Drawing.Size(100, 23);
            this.lblWinery.Text = "Winery";
            // 
            // txtWinery
            // 
            this.txtWinery.Location = new System.Drawing.Point(12, 90);
            this.txtWinery.Size = new System.Drawing.Size(260, 23);
            // 
            // lblAmount
            // 
            this.lblAmount.Location = new System.Drawing.Point(12, 120);
            this.lblAmount.Size = new System.Drawing.Size(100, 23);
            this.lblAmount.Text = "Amount";
            // 
            // numAmount
            // 
            this.numAmount.Location = new System.Drawing.Point(12, 145);
            this.numAmount.Maximum = 100000;
            this.numAmount.Minimum = 0;
            this.numAmount.Size = new System.Drawing.Size(120, 23);
            // 
            // lblPrice
            // 
            this.lblPrice.Location = new System.Drawing.Point(150, 120);
            this.lblPrice.Size = new System.Drawing.Size(100, 23);
            this.lblPrice.Text = "Price";
            // 
            // numPrice
            // 
            this.numPrice.DecimalPlaces = 2;
            this.numPrice.Location = new System.Drawing.Point(150, 145);
            this.numPrice.Maximum = 1000000;
            this.numPrice.Size = new System.Drawing.Size(120, 23);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(12, 185);
            this.btnSave.Size = new System.Drawing.Size(100, 30);
            this.btnSave.Text = "Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(172, 185);
            this.btnCancel.Size = new System.Drawing.Size(100, 30);
            this.btnCancel.Text = "Cancel";
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            // 
            // ProductForm
            // 
            this.ClientSize = new System.Drawing.Size(284, 230);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblWinery);
            this.Controls.Add(this.txtWinery);
            this.Controls.Add(this.lblAmount);
            this.Controls.Add(this.numAmount);
            this.Controls.Add(this.lblPrice);
            this.Controls.Add(this.numPrice);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Product";
            ((System.ComponentModel.ISupportInitialize)(this.numAmount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPrice)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}