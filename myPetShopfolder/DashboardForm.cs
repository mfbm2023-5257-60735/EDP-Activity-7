using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace PetShopInventory
{
    public partial class DashboardForm : Form
    {
        private DataTable inventoryTable = new DataTable();

        public DashboardForm()
        {
            InitializeComponent();
            this.Load += DashboardForm_Load;
            this.btnReport.Click += btnReport_Click;
            this.btnAbout.Click += btnAbout_Click;
            this.btnLogout.Click += btnLogout_Click;
            this.btnAdd.Click += btnAdd_Click;
            this.btnEdit.Click += btnEdit_Click;
            this.btnDelete.Click += btnDelete_Click;
            this.btnUserManagement.Click += btnUserManagement_Click;
        }

        private void DashboardForm_Load(object sender, EventArgs e)
        {
            SetupInventoryGrid();
            LoadInventoryFromDatabase();
        }

        private void SetupInventoryGrid()
        {
            dgvInventory.AllowUserToAddRows = false;
            dgvInventory.ReadOnly = true;
            dgvInventory.RowHeadersVisible = false;
            dgvInventory.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvInventory.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvInventory.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            dgvInventory.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            dgvInventory.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(186, 104, 200);
            dgvInventory.EnableHeadersVisualStyles = false;
            dgvInventory.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(74, 20, 140);
            dgvInventory.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
        }

        private void LoadInventoryFromDatabase()
        {
            try
            {
                DatabaseConnection db = new DatabaseConnection();
                using (MySqlConnection conn = db.GetConnection())
                using (MySqlCommand cmd = new MySqlCommand(@"SELECT product_id AS `Item ID`, product_name AS `Product Name`, category AS `Category`, price AS `Price`, stock_qty AS `Stock Level` FROM products ORDER BY product_name", conn))
                using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                {
                    inventoryTable = new DataTable();
                    adapter.Fill(inventoryTable);
                    dgvInventory.DataSource = inventoryTable;
                    if (dgvInventory.Columns.Contains("Price"))
                    {
                        dgvInventory.Columns["Price"].DefaultCellStyle.Format = "₱#,##0.00";
                        dgvInventory.Columns["Price"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    }
                    CalculateSummaries();
                    HighlightLowStockRows();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not load inventory from database. Please run XAMPP/MySQL and import petshop_db.sql.\n\n" + ex.Message,
                    "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CalculateSummaries()
        {
            int totalProducts = inventoryTable.Rows.Count;
            int totalStock = 0;
            int lowStockAlerts = 0;

            foreach (DataRow row in inventoryTable.Rows)
            {
                int stock = Convert.ToInt32(row["Stock Level"]);
                totalStock += stock;
                if (stock < 15) lowStockAlerts++;
            }

            lblCardValue1.Text = totalProducts.ToString();
            lblCardValue2.Text = totalStock.ToString();
            lblCardValue3.Text = lowStockAlerts.ToString();
        }

        private void HighlightLowStockRows()
        {
            foreach (DataGridViewRow row in dgvInventory.Rows)
            {
                int stock = Convert.ToInt32(row.Cells["Stock Level"].Value);
                if (stock < 15)
                {
                    row.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(255, 235, 238);
                    row.DefaultCellStyle.ForeColor = System.Drawing.Color.DarkRed;
                }
            }
        }

        private void btnUserManagement_Click(object sender, EventArgs e)
        {
            UserManagementForm usersForm = new UserManagementForm();
            usersForm.ShowDialog();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            using (ProductForm form = new ProductForm("Add Product"))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    ExecuteProductCommand("INSERT INTO products (product_name, category, price, stock_qty) VALUES (@name, @category, @price, @stock)", form, 0);
                    LoadInventoryFromDatabase();
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvInventory.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a product row first.");
                return;
            }

            DataGridViewRow row = dgvInventory.SelectedRows[0];
            int productId = Convert.ToInt32(row.Cells["Item ID"].Value);
            string name = row.Cells["Product Name"].Value.ToString();
            string category = row.Cells["Category"].Value.ToString();
            decimal price = Convert.ToDecimal(row.Cells["Price"].Value);
            int stock = Convert.ToInt32(row.Cells["Stock Level"].Value);

            using (ProductForm form = new ProductForm("Edit Product", name, category, price, stock))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    ExecuteProductCommand("UPDATE products SET product_name=@name, category=@category, price=@price, stock_qty=@stock WHERE product_id=@id", form, productId);
                    LoadInventoryFromDatabase();
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvInventory.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a product row first.");
                return;
            }

            int productId = Convert.ToInt32(dgvInventory.SelectedRows[0].Cells["Item ID"].Value);
            string productName = dgvInventory.SelectedRows[0].Cells["Product Name"].Value.ToString();
            if (MessageBox.Show("Delete " + productName + "?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {
                    DatabaseConnection db = new DatabaseConnection();
                    using (MySqlConnection conn = db.GetConnection())
                    using (MySqlCommand cmd = new MySqlCommand("DELETE FROM products WHERE product_id=@id", conn))
                    {
                        cmd.Parameters.AddWithValue("@id", productId);
                        conn.Open();
                        cmd.ExecuteNonQuery();
                    }
                    LoadInventoryFromDatabase();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Delete failed. Products already used in order items cannot be deleted unless those order items are removed first.\n\n" + ex.Message);
                }
            }
        }

        private void ExecuteProductCommand(string sql, ProductForm form, int productId)
        {
            try
            {
                DatabaseConnection db = new DatabaseConnection();
                using (MySqlConnection conn = db.GetConnection())
                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@name", form.ProductName);
                    cmd.Parameters.AddWithValue("@category", form.Category);
                    cmd.Parameters.AddWithValue("@price", form.Price);
                    cmd.Parameters.AddWithValue("@stock", form.StockQty);
                    if (productId > 0) cmd.Parameters.AddWithValue("@id", productId);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Product saved successfully.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Save failed: " + ex.Message);
            }
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            ReportGeneratorForm reportForm = new ReportGeneratorForm();
            reportForm.ShowDialog();
            LoadInventoryFromDatabase();
        }

        private void btnAbout_Click(object sender, EventArgs e)
        {
            AboutProgramForm aboutForm = new AboutProgramForm();
            aboutForm.ShowDialog();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }
    }
}
