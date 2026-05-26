namespace WinFormsUI
{
    partial class ManagerDashboardForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabProducts;
        private System.Windows.Forms.TabPage tabCustomers;
        private System.Windows.Forms.TabPage tabSales;
        private System.Windows.Forms.DataGridView dgvProducts;
        private System.Windows.Forms.DataGridView dgvCustomers;
        private System.Windows.Forms.DataGridView dgvSales;
        private System.Windows.Forms.Button btnProductsAdd;
        private System.Windows.Forms.Button btnProductsUpdate;
        private System.Windows.Forms.Button btnProductsDelete;
        private System.Windows.Forms.Button btnProductsRefresh;
        private System.Windows.Forms.Button btnCustomersAdd;
        private System.Windows.Forms.Button btnCustomersUpdate;
        private System.Windows.Forms.Button btnCustomersDelete;
        private System.Windows.Forms.Button btnCustomersRefresh;
        private System.Windows.Forms.Button btnSalesAdd;
        private System.Windows.Forms.Button btnSalesUpdate;
        private System.Windows.Forms.Button btnSalesDelete;
        private System.Windows.Forms.Button btnSalesRefresh;
        private System.Windows.Forms.Button btnBackToRoleSelection; // back button to return to role selection

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabProducts = new System.Windows.Forms.TabPage();
            this.tabCustomers = new System.Windows.Forms.TabPage();
            this.tabSales = new System.Windows.Forms.TabPage();
            this.dgvProducts = new System.Windows.Forms.DataGridView();
            this.dgvCustomers = new System.Windows.Forms.DataGridView();
            this.dgvSales = new System.Windows.Forms.DataGridView();
            this.btnProductsAdd = new System.Windows.Forms.Button();
            this.btnProductsUpdate = new System.Windows.Forms.Button();
            this.btnProductsDelete = new System.Windows.Forms.Button();
            this.btnProductsRefresh = new System.Windows.Forms.Button();
            this.btnCustomersAdd = new System.Windows.Forms.Button();
            this.btnCustomersUpdate = new System.Windows.Forms.Button();
            this.btnCustomersDelete = new System.Windows.Forms.Button();
            this.btnCustomersRefresh = new System.Windows.Forms.Button();
            this.btnSalesAdd = new System.Windows.Forms.Button();
            this.btnSalesUpdate = new System.Windows.Forms.Button();
            this.btnSalesDelete = new System.Windows.Forms.Button();
            this.btnSalesRefresh = new System.Windows.Forms.Button();
            this.btnBackToRoleSelection = new System.Windows.Forms.Button();
            this.tabControl.SuspendLayout();
            this.tabProducts.SuspendLayout();
            this.tabCustomers.SuspendLayout();
            this.tabSales.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSales)).BeginInit();
            this.SuspendLayout();
            // 
            // btnBackToRoleSelection
            // 
            this.btnBackToRoleSelection.Location = new System.Drawing.Point(700, 8);
            this.btnBackToRoleSelection.Name = "btnBackToRoleSelection";
            this.btnBackToRoleSelection.Size = new System.Drawing.Size(90, 30);
            this.btnBackToRoleSelection.Text = "Back";
            this.btnBackToRoleSelection.Click += new System.EventHandler(this.btnBackToRoleSelection_Click);
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabProducts);
            this.tabControl.Controls.Add(this.tabCustomers);
            this.tabControl.Controls.Add(this.tabSales);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.None;
            this.tabControl.Location = new System.Drawing.Point(0, 48);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(800, 402);
            this.tabControl.TabIndex = 0;
            // 
            // tabProducts
            // 
            this.tabProducts.Controls.Add(this.dgvProducts);
            this.tabProducts.Controls.Add(this.btnProductsAdd);
            this.tabProducts.Controls.Add(this.btnProductsUpdate);
            this.tabProducts.Controls.Add(this.btnProductsDelete);
            this.tabProducts.Controls.Add(this.btnProductsRefresh);
            this.tabProducts.Location = new System.Drawing.Point(4, 24);
            this.tabProducts.Name = "tabProducts";
            this.tabProducts.Padding = new System.Windows.Forms.Padding(3);
            this.tabProducts.Size = new System.Drawing.Size(792, 374);
            this.tabProducts.TabIndex = 0;
            this.tabProducts.Text = "Products";
            this.tabProducts.UseVisualStyleBackColor = true;
            // 
            // tabCustomers
            // 
            this.tabCustomers.Controls.Add(this.dgvCustomers);
            this.tabCustomers.Controls.Add(this.btnCustomersAdd);
            this.tabCustomers.Controls.Add(this.btnCustomersUpdate);
            this.tabCustomers.Controls.Add(this.btnCustomersDelete);
            this.tabCustomers.Controls.Add(this.btnCustomersRefresh);
            this.tabCustomers.Location = new System.Drawing.Point(4, 24);
            this.tabCustomers.Name = "tabCustomers";
            this.tabCustomers.Padding = new System.Windows.Forms.Padding(3);
            this.tabCustomers.Size = new System.Drawing.Size(792, 374);
            this.tabCustomers.TabIndex = 1;
            this.tabCustomers.Text = "Customers";
            this.tabCustomers.UseVisualStyleBackColor = true;
            // 
            // tabSales
            // 
            this.tabSales.Controls.Add(this.dgvSales);
            this.tabSales.Controls.Add(this.btnSalesAdd);
            this.tabSales.Controls.Add(this.btnSalesUpdate);
            this.tabSales.Controls.Add(this.btnSalesDelete);
            this.tabSales.Controls.Add(this.btnSalesRefresh);
            this.tabSales.Location = new System.Drawing.Point(4, 24);
            this.tabSales.Name = "tabSales";
            this.tabSales.Padding = new System.Windows.Forms.Padding(3);
            this.tabSales.Size = new System.Drawing.Size(792, 374);
            this.tabSales.TabIndex = 2;
            this.tabSales.Text = "Sales";
            this.tabSales.UseVisualStyleBackColor = true;
            // 
            // dgvProducts
            // 
            this.dgvProducts.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvProducts.Location = new System.Drawing.Point(8, 8);
            this.dgvProducts.Name = "dgvProducts";
            this.dgvProducts.Size = new System.Drawing.Size(776, 332);
            this.dgvProducts.TabIndex = 0;
            this.dgvProducts.ReadOnly = true;
            this.dgvProducts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            // 
            // dgvCustomers
            // 
            this.dgvCustomers.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvCustomers.Location = new System.Drawing.Point(8, 8);
            this.dgvCustomers.Name = "dgvCustomers";
            this.dgvCustomers.Size = new System.Drawing.Size(776, 332);
            this.dgvCustomers.TabIndex = 0;
            this.dgvCustomers.ReadOnly = true;
            this.dgvCustomers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            // 
            // dgvSales
            // 
            this.dgvSales.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvSales.Location = new System.Drawing.Point(8, 8);
            this.dgvSales.Name = "dgvSales";
            this.dgvSales.Size = new System.Drawing.Size(776, 332);
            this.dgvSales.TabIndex = 0;
            this.dgvSales.ReadOnly = true;
            this.dgvSales.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            // 
            // btnProductsAdd
            // 
            this.btnProductsAdd.Location = new System.Drawing.Point(8, 348);
            this.btnProductsAdd.Name = "btnProductsAdd";
            this.btnProductsAdd.Size = new System.Drawing.Size(90, 30);
            this.btnProductsAdd.Text = "Add";
            this.btnProductsAdd.Click += new System.EventHandler(this.btnProductsAdd_Click);
            // 
            // btnProductsUpdate
            // 
            this.btnProductsUpdate.Location = new System.Drawing.Point(108, 348);
            this.btnProductsUpdate.Name = "btnProductsUpdate";
            this.btnProductsUpdate.Size = new System.Drawing.Size(90, 30);
            this.btnProductsUpdate.Text = "Update";
            this.btnProductsUpdate.Click += new System.EventHandler(this.btnProductsUpdate_Click);
            // 
            // btnProductsDelete
            // 
            this.btnProductsDelete.Location = new System.Drawing.Point(208, 348);
            this.btnProductsDelete.Name = "btnProductsDelete";
            this.btnProductsDelete.Size = new System.Drawing.Size(90, 30);
            this.btnProductsDelete.Text = "Delete";
            this.btnProductsDelete.Click += new System.EventHandler(this.btnProductsDelete_Click);
            // 
            // btnProductsRefresh
            // 
            this.btnProductsRefresh.Location = new System.Drawing.Point(308, 348);
            this.btnProductsRefresh.Name = "btnProductsRefresh";
            this.btnProductsRefresh.Size = new System.Drawing.Size(90, 30);
            this.btnProductsRefresh.Text = "Refresh";
            this.btnProductsRefresh.Click += new System.EventHandler(this.btnProductsRefresh_Click);
            // 
            // btnCustomersAdd
            // 
            this.btnCustomersAdd.Location = new System.Drawing.Point(8, 348);
            this.btnCustomersAdd.Name = "btnCustomersAdd";
            this.btnCustomersAdd.Size = new System.Drawing.Size(90, 30);
            this.btnCustomersAdd.Text = "Add";
            this.btnCustomersAdd.Click += new System.EventHandler(this.btnCustomersAdd_Click);
            // 
            // btnCustomersUpdate
            // 
            this.btnCustomersUpdate.Location = new System.Drawing.Point(108, 348);
            this.btnCustomersUpdate.Name = "btnCustomersUpdate";
            this.btnCustomersUpdate.Size = new System.Drawing.Size(90, 30);
            this.btnCustomersUpdate.Text = "Update";
            this.btnCustomersUpdate.Click += new System.EventHandler(this.btnCustomersUpdate_Click);
            // 
            // btnCustomersDelete
            // 
            this.btnCustomersDelete.Location = new System.Drawing.Point(208, 348);
            this.btnCustomersDelete.Name = "btnCustomersDelete";
            this.btnCustomersDelete.Size = new System.Drawing.Size(90, 30);
            this.btnCustomersDelete.Text = "Delete";
            this.btnCustomersDelete.Click += new System.EventHandler(this.btnCustomersDelete_Click);
            // 
            // btnCustomersRefresh
            // 
            this.btnCustomersRefresh.Location = new System.Drawing.Point(308, 348);
            this.btnCustomersRefresh.Name = "btnCustomersRefresh";
            this.btnCustomersRefresh.Size = new System.Drawing.Size(90, 30);
            this.btnCustomersRefresh.Text = "Refresh";
            this.btnCustomersRefresh.Click += new System.EventHandler(this.btnCustomersRefresh_Click);
            // 
            // btnSalesAdd
            // 
            this.btnSalesAdd.Location = new System.Drawing.Point(8, 348);
            this.btnSalesAdd.Name = "btnSalesAdd";
            this.btnSalesAdd.Size = new System.Drawing.Size(90, 30);
            this.btnSalesAdd.Text = "Add";
            this.btnSalesAdd.Click += new System.EventHandler(this.btnSalesAdd_Click);
            // 
            // btnSalesUpdate
            // 
            this.btnSalesUpdate.Location = new System.Drawing.Point(108, 348);
            this.btnSalesUpdate.Name = "btnSalesUpdate";
            this.btnSalesUpdate.Size = new System.Drawing.Size(90, 30);
            this.btnSalesUpdate.Text = "Update";
            this.btnSalesUpdate.Click += new System.EventHandler(this.btnSalesUpdate_Click);
            // 
            // btnSalesDelete
            // 
            this.btnSalesDelete.Location = new System.Drawing.Point(208, 348);
            this.btnSalesDelete.Name = "btnSalesDelete";
            this.btnSalesDelete.Size = new System.Drawing.Size(90, 30);
            this.btnSalesDelete.Text = "Delete";
            this.btnSalesDelete.Click += new System.EventHandler(this.btnSalesDelete_Click);
            // 
            // btnSalesRefresh
            // 
            this.btnSalesRefresh.Location = new System.Drawing.Point(308, 348);
            this.btnSalesRefresh.Name = "btnSalesRefresh";
            this.btnSalesRefresh.Size = new System.Drawing.Size(90, 30);
            this.btnSalesRefresh.Text = "Refresh";
            this.btnSalesRefresh.Click += new System.EventHandler(this.btnSalesRefresh_Click);
            // 
            // ManagerDashboardForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.btnBackToRoleSelection);
            this.Name = "ManagerDashboardForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Manager Dashboard";
            this.Load += new System.EventHandler(this.ManagerDashboardForm_Load);
            this.tabControl.ResumeLayout(false);
            this.tabProducts.ResumeLayout(false);
            this.tabCustomers.ResumeLayout(false);
            this.tabSales.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSales)).EndInit();
            this.ResumeLayout(false);
        }
    }
}