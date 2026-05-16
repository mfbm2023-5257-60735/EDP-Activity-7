using System;
using System.Drawing;
using System.Windows.Forms;

namespace PetShopInventory
{
    public class ProductForm : Form
    {
        public TextBox txtName = new TextBox();
        public TextBox txtCategory = new TextBox();
        public NumericUpDown numPrice = new NumericUpDown();
        public NumericUpDown numStock = new NumericUpDown();
        private Button btnSave = new Button();
        private Button btnCancel = new Button();

        public string ProductName { get { return txtName.Text.Trim(); } }
        public string Category { get { return txtCategory.Text.Trim(); } }
        public decimal Price { get { return numPrice.Value; } }
        public int StockQty { get { return Convert.ToInt32(numStock.Value); } }

        public ProductForm(string title, string name = "", string category = "", decimal price = 0, int stock = 0)
        {
            this.Text = title;
            this.Size = new Size(420, 330);
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.BackColor = Color.FromArgb(248, 245, 252);

            Label header = new Label();
            header.Text = title;
            header.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            header.ForeColor = Color.FromArgb(74, 20, 140);
            header.Location = new Point(25, 20);
            header.Size = new Size(350, 35);
            this.Controls.Add(header);

            AddLabel("Product Name", 70);
            txtName.Location = new Point(150, 68);
            txtName.Size = new Size(220, 25);
            txtName.Font = new Font("Segoe UI", 10F);
            txtName.Text = name;
            this.Controls.Add(txtName);

            AddLabel("Category", 110);
            txtCategory.Location = new Point(150, 108);
            txtCategory.Size = new Size(220, 25);
            txtCategory.Font = new Font("Segoe UI", 10F);
            txtCategory.Text = category;
            this.Controls.Add(txtCategory);

            AddLabel("Price", 150);
            numPrice.Location = new Point(150, 148);
            numPrice.Size = new Size(220, 25);
            numPrice.Font = new Font("Segoe UI", 10F);
            numPrice.Maximum = 1000000;
            numPrice.DecimalPlaces = 2;
            numPrice.Value = Math.Max(0, price);
            this.Controls.Add(numPrice);

            AddLabel("Stock Qty", 190);
            numStock.Location = new Point(150, 188);
            numStock.Size = new Size(220, 25);
            numStock.Font = new Font("Segoe UI", 10F);
            numStock.Maximum = 1000000;
            numStock.Value = Math.Max(0, stock);
            this.Controls.Add(numStock);

            btnSave.Text = "Save";
            btnSave.BackColor = Color.FromArgb(74, 20, 140);
            btnSave.ForeColor = Color.White;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.Location = new Point(190, 235);
            btnSave.Size = new Size(85, 35);
            btnSave.DialogResult = DialogResult.OK;
            btnSave.Click += (s, e) =>
            {
                if (ProductName == "" || Category == "")
                {
                    MessageBox.Show("Please complete product name and category.");
                    this.DialogResult = DialogResult.None;
                }
            };
            this.Controls.Add(btnSave);

            btnCancel.Text = "Cancel";
            btnCancel.BackColor = Color.White;
            btnCancel.ForeColor = Color.DimGray;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Location = new Point(285, 235);
            btnCancel.Size = new Size(85, 35);
            btnCancel.DialogResult = DialogResult.Cancel;
            this.Controls.Add(btnCancel);

            this.AcceptButton = btnSave;
            this.CancelButton = btnCancel;
        }

        private void AddLabel(string text, int y)
        {
            Label label = new Label();
            label.Text = text;
            label.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            label.ForeColor = Color.FromArgb(55, 42, 79);
            label.Location = new Point(30, y);
            label.Size = new Size(110, 25);
            this.Controls.Add(label);
        }
    }
}
