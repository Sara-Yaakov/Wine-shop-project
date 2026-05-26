using System;
using System.Linq;
using System.Windows.Forms;
using BO;
using BlApi;

namespace WinFormsUI
{
    public partial class PromotionForm : Form
    {
        private readonly ISale _saleBl;
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
            // select product in combobox
            if (cmbProducts != null)
            {
                cmbProducts.SelectedValue = s.ProductId;
            }

            numRequiredAmount.Value = s.RequiredAmount;
            numPriceAfterDiscount.Value = s.PriceAfterDiscount;
            chkClubOnly.Checked = s.IsForClubMembersOnly;
            dtpStart.Value = s.StartDate;
            dtpEnd.Value = s.EndDate;
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.ClientSize = new System.Drawing.Size(420, 320);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "Promotion";

            // controls
            var lblProduct = new Label() { Text = "Product", Location = new System.Drawing.Point(12, 9), Size = new System.Drawing.Size(100, 23) };
            cmbProducts = new ComboBox() { Location = new System.Drawing.Point(12, 35), Size = new System.Drawing.Size(300, 23), DropDownStyle = ComboBoxStyle.DropDownList }; 

            var lblRequired = new Label() { Text = "Required Amount", Location = new System.Drawing.Point(12, 65), Size = new System.Drawing.Size(120, 23) };
            numRequiredAmount = new NumericUpDown() { Location = new System.Drawing.Point(12, 90), Size = new System.Drawing.Size(120, 23), Minimum = 1, Maximum = 100000, Value = 1 };

            var lblPrice = new Label() { Text = "Price After Discount", Location = new System.Drawing.Point(150, 65), Size = new System.Drawing.Size(140, 23) };
            numPriceAfterDiscount = new NumericUpDown() { Location = new System.Drawing.Point(150, 90), Size = new System.Drawing.Size(120, 23), Minimum = 0, Maximum = 1000000 }; 

            chkClubOnly = new CheckBox() { Text = "Club Members Only", Location = new System.Drawing.Point(12, 120), Size = new System.Drawing.Size(160, 23) };

            var lblStart = new Label() { Text = "Start Date", Location = new System.Drawing.Point(12, 150), Size = new System.Drawing.Size(100, 23) };
            dtpStart = new DateTimePicker() { Location = new System.Drawing.Point(12, 175), Size = new System.Drawing.Size(200, 23) };

            var lblEnd = new Label() { Text = "End Date", Location = new System.Drawing.Point(220, 150), Size = new System.Drawing.Size(100, 23) };
            dtpEnd = new DateTimePicker() { Location = new System.Drawing.Point(220, 175), Size = new System.Drawing.Size(180, 23) };

            btnSave = new Button() { Text = "Save", Location = new System.Drawing.Point(220, 260), Size = new System.Drawing.Size(80, 25) };
            btnSave.Click += BtnSave_Click;
            btnCancel = new Button() { Text = "Cancel", Location = new System.Drawing.Point(310, 260), Size = new System.Drawing.Size(80, 25), DialogResult = DialogResult.Cancel };

            this.Controls.Add(lblProduct);
            this.Controls.Add(cmbProducts);
            this.Controls.Add(lblRequired);
            this.Controls.Add(numRequiredAmount);
            this.Controls.Add(lblPrice);
            this.Controls.Add(numPriceAfterDiscount);
            this.Controls.Add(chkClubOnly);
            this.Controls.Add(lblStart);
            this.Controls.Add(dtpStart);
            this.Controls.Add(lblEnd);
            this.Controls.Add(dtpEnd);
            this.Controls.Add(btnSave);
            this.Controls.Add(btnCancel);

            this.AcceptButton = btnSave;

            // load products into combobox
            try
            {
                var bl = BlApi.Factory.Get();
                var products = bl.Product.GetAllProducts();
                cmbProducts.DataSource = products;
                cmbProducts.DisplayMember = "Name";
                cmbProducts.ValueMember = "Id";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private void BtnSave_Click(object? sender, EventArgs e)
        {
            // product selection required
            if (cmbProducts.SelectedItem == null)
            {
                MessageBox.Show("Please select a product", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (numRequiredAmount.Value <= 0)
            {
                MessageBox.Show("Required amount must be > 0", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (numPriceAfterDiscount.Value < 0)
            {
                MessageBox.Show("Price must be >= 0", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                var sale = new Sale
                {
                    // Id left default when creating; BL will generate it
                    ProductId = Convert.ToInt32(((dynamic)cmbProducts.SelectedItem).Id),
                    RequiredAmount = (int)numRequiredAmount.Value,
                    PriceAfterDiscount = (int)numPriceAfterDiscount.Value,
                    IsForClubMembersOnly = chkClubOnly.Checked,
                    StartDate = dtpStart.Value,
                    EndDate = dtpEnd.Value
                };

                var bl = BlApi.Factory.Get();
                if (_existing == null)
                {
                    bl.Sale.AddSale(sale);
                }
                else
                {
                    sale.Id = _existing.Id; // keep id
                    bl.Sale.UpdateSale(sale);
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // designer fields
        private System.Windows.Forms.ComboBox cmbProducts;
        private System.Windows.Forms.NumericUpDown numRequiredAmount;
        private System.Windows.Forms.NumericUpDown numPriceAfterDiscount;
        private System.Windows.Forms.CheckBox chkClubOnly;
        private System.Windows.Forms.DateTimePicker dtpStart;
        private System.Windows.Forms.DateTimePicker dtpEnd;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
    }
}
