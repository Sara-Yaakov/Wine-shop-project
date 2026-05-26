namespace WinFormsUI
{
    partial class OrderForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblCustomerStatus;
        private System.Windows.Forms.CheckBox chkMember;
        private System.Windows.Forms.DataGridView dgvOrderItems;
        private System.Windows.Forms.Button btnAddProduct;
        private System.Windows.Forms.Button btnIncrease;
        private System.Windows.Forms.Button btnDecrease;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnPurchase;
        private System.Windows.Forms.Label lblTotal;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblCustomerStatus = new System.Windows.Forms.Label();
            this.chkMember = new System.Windows.Forms.CheckBox();
            this.dgvOrderItems = new System.Windows.Forms.DataGridView();
            this.btnAddProduct = new System.Windows.Forms.Button();
            this.btnIncrease = new System.Windows.Forms.Button();
            this.btnDecrease = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnPurchase = new System.Windows.Forms.Button();
            this.lblTotal = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrderItems)).BeginInit();
            this.SuspendLayout();
            // 
            // lblCustomerStatus
            // 
            this.lblCustomerStatus.Location = new System.Drawing.Point(12, 9);
            this.lblCustomerStatus.Size = new System.Drawing.Size(200, 23);
            this.lblCustomerStatus.Text = "Customer: Non-member";
            // 
            // chkMember
            // 
            this.chkMember.Location = new System.Drawing.Point(220, 9);
            this.chkMember.Size = new System.Drawing.Size(120, 23);
            this.chkMember.Text = "Is Member";
            this.chkMember.CheckedChanged += new System.EventHandler(this.chkMember_CheckedChanged);
            // 
            // dgvOrderItems
            // 
            this.dgvOrderItems.Location = new System.Drawing.Point(12, 40);
            this.dgvOrderItems.Size = new System.Drawing.Size(600, 300);
            this.dgvOrderItems.ReadOnly = true;
            this.dgvOrderItems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            // 
            // btnAddProduct
            // 
            this.btnAddProduct.Location = new System.Drawing.Point(630, 40);
            this.btnAddProduct.Size = new System.Drawing.Size(120, 30);
            this.btnAddProduct.Text = "Add Product";
            this.btnAddProduct.Click += new System.EventHandler(this.btnAddProduct_Click);
            // 
            // btnIncrease
            // 
            this.btnIncrease.Location = new System.Drawing.Point(630, 80);
            this.btnIncrease.Size = new System.Drawing.Size(120, 30);
            this.btnIncrease.Text = "Increase";
            this.btnIncrease.Click += new System.EventHandler(this.btnIncrease_Click);
            // 
            // btnDecrease
            // 
            this.btnDecrease.Location = new System.Drawing.Point(630, 120);
            this.btnDecrease.Size = new System.Drawing.Size(120, 30);
            this.btnDecrease.Text = "Decrease";
            this.btnDecrease.Click += new System.EventHandler(this.btnDecrease_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(630, 160);
            this.btnRemove.Size = new System.Drawing.Size(120, 30);
            this.btnRemove.Text = "Remove";
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnPurchase
            // 
            this.btnPurchase.Location = new System.Drawing.Point(630, 340);
            this.btnPurchase.Size = new System.Drawing.Size(120, 30);
            this.btnPurchase.Text = "Purchase";
            this.btnPurchase.Click += new System.EventHandler(this.btnPurchase_Click);
            // 
            // lblTotal
            // 
            this.lblTotal.Location = new System.Drawing.Point(12, 350);
            this.lblTotal.Size = new System.Drawing.Size(300, 23);
            this.lblTotal.Text = "Total: 0.00";
            // 
            // OrderForm
            // 
            this.ClientSize = new System.Drawing.Size(760, 400);
            this.Controls.Add(this.lblCustomerStatus);
            this.Controls.Add(this.chkMember);
            this.Controls.Add(this.dgvOrderItems);
            this.Controls.Add(this.btnAddProduct);
            this.Controls.Add(this.btnIncrease);
            this.Controls.Add(this.btnDecrease);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.btnPurchase);
            this.Controls.Add(this.lblTotal);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Order";
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrderItems)).EndInit();
            this.ResumeLayout(false);
        }
    }
}