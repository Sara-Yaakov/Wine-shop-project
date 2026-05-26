using System;
using System.Linq;
using System.Windows.Forms;
using BlApi;
using BO;
using System.Collections.Generic;

namespace WinFormsUI
{
    public partial class OrderForm : Form
    {
        private readonly IBl _bl = BlApi.Factory.Get();
        private BO.Order _order;

        public OrderForm()
        {
            InitializeComponent();
            StartNewOrder();
            UpdateBackButtonState();
        }

        private void StartNewOrder()
        {
            _order = new BO.Order { IsClubMember = false, Products = new List<ProductInOrder>(), TotalPrice = 0 };
            RefreshOrderGrid();
            UpdateBackButtonState();
        }

        private void RefreshOrderGrid()
        {
            dgvOrderItems.DataSource = null;
            // compute projection with fresh calculation to avoid stale FinalPrice
            var rows = _order.Products.Select(p => new
            {
                p.ProductId,
                p.ProductName,
                Quantity = p.Amount,
                UnitPrice = p.BasicPrice,
                LineTotal = Math.Round(p.BasicPrice * p.Amount, 2)
            }).ToList();
            dgvOrderItems.DataSource = rows;
            lblTotal.Text = $"Total: {_order.TotalPrice:F2}";
            UpdateBackButtonState();
        }

        private void UpdateBackButtonState()
        {
            // enable back button only when order is empty
            if (btnBack == null) return;
            btnBack.Enabled = _order == null || !_order.Products.Any();
        }

        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            var f = new AddProductForm();
            if (f.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    _bl.Order.AddProductToOrder(_order, f.SelectedProductId, (int)f.Quantity);
                    _bl.Order.CalcTotalPrice(_order);
                    RefreshOrderGrid();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private int? GetSelectedProductId()
        {
            if (dgvOrderItems.CurrentRow == null) return null;
            var val = dgvOrderItems.CurrentRow.Cells[0].Value;
            if (val == null) return null;
            return Convert.ToInt32(val);
        }

        private void btnIncrease_Click(object sender, EventArgs e)
        {
            var id = GetSelectedProductId();
            if (!id.HasValue) return;
            try
            {
                _bl.Order.AddProductToOrder(_order, id.Value, 1);
                _bl.Order.CalcTotalPrice(_order);
                RefreshOrderGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDecrease_Click(object sender, EventArgs e)
        {
            var id = GetSelectedProductId();
            if (!id.HasValue) return;
            try
            {
                // get current amount
                var pio = _order.Products.FirstOrDefault(p => p.ProductId == id.Value);
                if (pio == null) return;
                if (pio.Amount <= 1)
                {
                    // remove item
                    _bl.Order.AddProductToOrder(_order, id.Value, -pio.Amount);
                }
                else
                {
                    _bl.Order.AddProductToOrder(_order, id.Value, -1);
                }

                _bl.Order.CalcTotalPrice(_order);
                RefreshOrderGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            var id = GetSelectedProductId();
            if (!id.HasValue) return;
            try
            {
                // find product and remove by setting amount to 0
                var pio = _order.Products.FirstOrDefault(p => p.ProductId == id.Value);
                if (pio != null)
                {
                    _bl.Order.AddProductToOrder(_order, id.Value, -pio.Amount);
                    _bl.Order.CalcTotalPrice(_order);
                    RefreshOrderGrid();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnPurchase_Click(object sender, EventArgs e)
        {
            try
            {
                _bl.Order.DoOrder(_order);
                MessageBox.Show("Purchase completed", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                StartNewOrder();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void chkMember_CheckedChanged(object sender, EventArgs e)
        {
            _order.IsClubMember = chkMember.Checked;
            // let BL recalc
            foreach (var p in _order.Products) SearchAndRefreshLine(p);
            _bl.Order.CalcTotalPrice(_order);
            RefreshOrderGrid();
        }

        private void SearchAndRefreshLine(ProductInOrder pio)
        {
            _bl.Order.SearchSaleForProduct(pio, _order.IsClubMember);
            _bl.Order.CalcTotalPriceForProduct(pio);
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            if (_order != null && _order.Products.Any())
            {
                MessageBox.Show("Cannot go back while order has items. Remove items first.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var f = new CustomerSelectionForm();
            f.Show();
            this.Close();
        }
    }
}