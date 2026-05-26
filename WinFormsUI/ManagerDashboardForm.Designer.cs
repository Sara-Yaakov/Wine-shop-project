namespace WinFormsUI
{
    partial class ManagerDashboardForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabProducts;
        private System.Windows.Forms.TabPage tabCustomers;
        private System.Windows.Forms.TabPage tabPromotions;
        private System.Windows.Forms.DataGridView dgvProducts;
        private System.Windows.Forms.DataGridView dgvCustomers;
        private System.Windows.Forms.DataGridView dgvPromotions;
        private System.Windows.Forms.Button btnProductsAdd;
        private System.Windows.Forms.Button btnProductsUpdate;
        private System.Windows.Forms.Button btnProductsDelete;
        private System.Windows.Forms.Button btnProductsRefresh;
        private System.Windows.Forms.Button btnCustomersAdd;
        private System.Windows.Forms.Button btnCustomersUpdate;
        private System.Windows.Forms.Button btnCustomersDelete;
        private System.Windows.Forms.Button btnCustomersRefresh;
        private System.Windows.Forms.Button btnPromotionsAdd;
        private System.Windows.Forms.Button btnPromotionsUpdate;
        private System.Windows.Forms.Button btnPromotionsDelete;
        private System.Windows.Forms.Button btnPromotionsRefresh;
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
            this.tabPromotions = new System.Windows.Forms.TabPage();
            this.dgvProducts = new System.Windows.Forms.DataGridView();
            this.dgvCustomers = new System.Windows.Forms.DataGridView();
            this.dgvPromotions = new System.Windows.Forms.DataGridView();
            this.btnProductsAdd = new System.Windows.Forms.Button();
            this.btnProductsUpdate = new System.Windows.Forms.Button();
            this.btnProductsDelete = new System.Windows.Forms.Button();
            this.btnProductsRefresh = new System.Windows.Forms.Button();
            this.btnCustomersAdd = new System.Windows.Forms.Button();
            this.btnCustomersUpdate = new System.Windows.Forms.Button();
            this.btnCustomersDelete = new System.Windows.Forms.Button();
            this.btnCustomersRefresh = new System.Windows.Forms.Button();
            this.btnPromotionsAdd = new System.Windows.Forms.Button();
            this.btnPromotionsUpdate = new System.Windows.Forms.Button();
            this.btnPromotionsDelete = new System.Windows.Forms.Button();
            this.btnPromotionsRefresh = new System.Windows.Forms.Button();
            this.btnBackToRoleSelection = new System.Windows.Forms.Button();
            this.tabControl.SuspendLayout();
            this.tabProducts.SuspendLayout();
            this.tabCustomers.SuspendLayout();
            this.tabPromotions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPromotions)).BeginInit();
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
            this.tabControl.Controls.Add(this.tabPromotions);
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
            // tabPromotions
            // 
            this.tabPromotions.Controls.Add(this.dgvPromotions);
            this.tabPromotions.Controls.Add(this.btnPromotionsAdd);
            this.tabPromotions.Controls.Add(this.btnPromotionsUpdate);
            this.tabPromotions.Controls.Add(this.btnPromotionsDelete);
            this.tabPromotions.Controls.Add(this.btnPromotionsRefresh);
            this.tabPromotions.Location = new System.Drawing.Point(4, 24);
            this.tabPromotions.Name = "tabPromotions";
            this.tabPromotions.Padding = new System.Windows.Forms.Padding(3);
            this.tabPromotions.Size = new System.Drawing.Size(792, 374);
            this.tabPromotions.TabIndex = 2;
            this.tabPromotions.Text = "Promotions";
            this.tabPromotions.UseVisualStyleBackColor = true;
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
            // dgvPromotions
            // 
            this.dgvPromotions.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvPromotions.Location = new System.Drawing.Point(8, 8);
            this.dgvPromotions.Name = "dgvPromotions";
            this.dgvPromotions.Size = new System.Drawing.Size(776, 332);
            this.dgvPromotions.TabIndex = 0;
            this.dgvPromotions.ReadOnly = true;
            this.dgvPromotions.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
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
            // btnPromotionsAdd
            // 
            this.btnPromotionsAdd.Location = new System.Drawing.Point(8, 348);
            this.btnPromotionsAdd.Name = "btnPromotionsAdd";
            this.btnPromotionsAdd.Size = new System.Drawing.Size(90, 30);
            this.btnPromotionsAdd.Text = "Add";
            this.btnPromotionsAdd.Click += new System.EventHandler(this.btnPromotionsAdd_Click);
            // 
            // btnPromotionsUpdate
            // 
            this.btnPromotionsUpdate.Location = new System.Drawing.Point(108, 348);
            this.btnPromotionsUpdate.Name = "btnPromotionsUpdate";
            this.btnPromotionsUpdate.Size = new System.Drawing.Size(90, 30);
            this.btnPromotionsUpdate.Text = "Update";
            this.btnPromotionsUpdate.Click += new System.EventHandler(this.btnPromotionsUpdate_Click);
            // 
            // btnPromotionsDelete
            // 
            this.btnPromotionsDelete.Location = new System.Drawing.Point(208, 348);
            this.btnPromotionsDelete.Name = "btnPromotionsDelete";
            this.btnPromotionsDelete.Size = new System.Drawing.Size(90, 30);
            this.btnPromotionsDelete.Text = "Delete";
            this.btnPromotionsDelete.Click += new System.EventHandler(this.btnPromotionsDelete_Click);
            // 
            // btnPromotionsRefresh
            // 
            this.btnPromotionsRefresh.Location = new System.Drawing.Point(308, 348);
            this.btnPromotionsRefresh.Name = "btnPromotionsRefresh";
            this.btnPromotionsRefresh.Size = new System.Drawing.Size(90, 30);
            this.btnPromotionsRefresh.Text = "Refresh";
            this.btnPromotionsRefresh.Click += new System.EventHandler(this.btnPromotionsRefresh_Click);
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
            this.tabPromotions.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPromotions)).EndInit();
            this.ResumeLayout(false);
        }
    }
}