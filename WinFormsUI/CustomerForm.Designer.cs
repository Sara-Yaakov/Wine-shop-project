namespace WinFormsUI
{
    partial class CustomerForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Label lblPhone;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.CheckBox chkMember;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblCustomerId;
        private System.Windows.Forms.TextBox txtCustomerId;

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
            this.lblAddress = new System.Windows.Forms.Label();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.lblPhone = new System.Windows.Forms.Label();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.chkMember = new System.Windows.Forms.CheckBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblCustomerId = new System.Windows.Forms.Label();
            this.txtCustomerId = new System.Windows.Forms.TextBox();
            // 
            // lblCustomerId
            // 
            this.lblCustomerId.Location = new System.Drawing.Point(12, 9);
            this.lblCustomerId.Size = new System.Drawing.Size(100, 23);
            this.lblCustomerId.Text = "Customer ID";
            // 
            // txtCustomerId
            // 
            this.txtCustomerId.Location = new System.Drawing.Point(12, 35);
            this.txtCustomerId.Size = new System.Drawing.Size(260, 23);
            // 
            // lblName
            // 
            this.lblName.Location = new System.Drawing.Point(12, 65);
            this.lblName.Size = new System.Drawing.Size(100, 23);
            this.lblName.Text = "Name";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(12, 90);
            this.txtName.Size = new System.Drawing.Size(260, 23);
            // 
            // lblAddress
            // 
            this.lblAddress.Location = new System.Drawing.Point(12, 120);
            this.lblAddress.Size = new System.Drawing.Size(100, 23);
            this.lblAddress.Text = "Address";
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(12, 145);
            this.txtAddress.Size = new System.Drawing.Size(260, 23);
            // 
            // lblPhone
            // 
            this.lblPhone.Location = new System.Drawing.Point(12, 175);
            this.lblPhone.Size = new System.Drawing.Size(100, 23);
            this.lblPhone.Text = "Phone";
            // 
            // txtPhone
            // 
            this.txtPhone.Location = new System.Drawing.Point(12, 200);
            this.txtPhone.Size = new System.Drawing.Size(260, 23);
            // 
            // chkMember
            // 
            this.chkMember.Location = new System.Drawing.Point(12, 230);
            this.chkMember.Size = new System.Drawing.Size(120, 23);
            this.chkMember.Text = "Club Member";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(12, 260);
            this.btnSave.Size = new System.Drawing.Size(100, 30);
            this.btnSave.Text = "Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(172, 260);
            this.btnCancel.Size = new System.Drawing.Size(100, 30);
            this.btnCancel.Text = "Cancel";
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            // 
            // CustomerForm
            // 
            this.ClientSize = new System.Drawing.Size(284, 305);
            this.Controls.Add(this.lblCustomerId);
            this.Controls.Add(this.txtCustomerId);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblAddress);
            this.Controls.Add(this.txtAddress);
            this.Controls.Add(this.lblPhone);
            this.Controls.Add(this.txtPhone);
            this.Controls.Add(this.chkMember);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Customer";
        }
    }
}