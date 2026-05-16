using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Excel = Microsoft.Office.Interop.Excel;

namespace PetShopInventory
{
    public partial class ReportGeneratorForm : Form
    {
        private DataTable currentReportTable = new DataTable();
        private string currentReportTitle = "Inventory Report";
        private string currentChartLabelColumn = "Product Name";
        private string currentChartValueColumn = "Stock Qty";
        private string logoPath = Path.Combine(Application.StartupPath, "Images", "logo.jpeg");

        public ReportGeneratorForm()
        {
            InitializeComponent();
            this.Load += ReportGeneratorForm_Load;
            this.btnLoad.Click += btnLoad_Click;
            this.btnExport.Click += btnExport_Click;
            this.btnClose.Click += btnClose_Click;
        }

        private void ReportGeneratorForm_Load(object sender, EventArgs e)
        {
            try
            {
                if (File.Exists(logoPath)) picLogo.Image = Image.FromFile(logoPath);
            }
            catch { }

            cmbReportType.Items.Clear();
            cmbReportType.Items.Add("Inventory Stock Report");
            cmbReportType.Items.Add("Sales Order Report");
            cmbReportType.Items.Add("Payment Transaction Report");
            cmbReportType.SelectedIndex = 0;
            StyleGrid();
            LoadSelectedReport();
        }

        private void StyleGrid()
        {
            dgvReportPreview.EnableHeadersVisualStyles = false;
            dgvReportPreview.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#4E56C0");
            dgvReportPreview.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvReportPreview.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dgvReportPreview.DefaultCellStyle.Font = new Font("Segoe UI", 9F);
            dgvReportPreview.DefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#D78FEE");
            dgvReportPreview.DefaultCellStyle.SelectionForeColor = ColorTranslator.FromHtml("#2D1B3D");
            dgvReportPreview.AlternatingRowsDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#F8E8FF");
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            LoadSelectedReport();
        }

        private void LoadSelectedReport()
        {
            int selected = cmbReportType.SelectedIndex;
            string query = "";

            if (selected == 0)
            {
                currentReportTitle = "Inventory Stock Report";
                currentChartLabelColumn = "Product Name";
                currentChartValueColumn = "Stock Qty";

                query = @"SELECT 
                                product_id AS `Product ID`, 
                                product_name AS `Product Name`, 
                                category AS `Category`,
                                price AS `Unit Price`, 
                                stock_qty AS `Stock Qty`
                         FROM products
                         ORDER BY product_name";
            }
            else if (selected == 1)
            {
                currentReportTitle = "Sales Order Report";
                currentChartLabelColumn = "Product Ordered";
                currentChartValueColumn = "Qty";

                query = @"SELECT 
                    o.order_id AS `Order ID`,
                    c.full_name AS `Customer`,
                    DATE_FORMAT(o.order_date, '%Y-%m-%d %H:%i') AS `Order Date`,
                    pr.product_name AS `Product Ordered`,
                    pr.price AS `Unit Price`,
                    oi.quantity AS `Qty`,
                    o.total_amount AS `Order Total`
             FROM orders o
             INNER JOIN customers c ON c.customer_id = o.customer_id
             INNER JOIN order_items oi ON oi.order_id = o.order_id
             INNER JOIN products pr ON pr.product_id = oi.product_id
             ORDER BY o.order_date DESC, o.order_id DESC";
            }
            else
            {
                currentReportTitle = "Payment Transaction Report";
                currentChartLabelColumn = "Method";
                currentChartValueColumn = "Amount";

                query = @"SELECT 
                                p.payment_id AS `Payment ID`, 
                                DATE_FORMAT(p.payment_date, '%Y-%m-%d %H:%i') AS `Payment Date`,
                                c.full_name AS `Customer`, 
                                p.method AS `Method`, 
                                p.payment_status AS `Payment Status`, 
                                p.amount AS `Amount`
                         FROM payments p
                         INNER JOIN orders o ON o.order_id = p.order_id
                         INNER JOIN customers c ON c.customer_id = o.customer_id
                         ORDER BY p.payment_date DESC";
            }

            try
            {
                DatabaseConnection db = new DatabaseConnection();
                using (MySqlConnection conn = db.GetConnection())
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                {
                    currentReportTable = new DataTable();
                    adapter.Fill(currentReportTable);
                    dgvReportPreview.DataSource = currentReportTable;
                    FormatCurrencyColumns();
                    lblRecordCount.Text = currentReportTable.Rows.Count + " record(s) loaded";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database error while loading report. Make sure XAMPP/MySQL is running and petshop_db is imported.\n\n" + ex.Message,
                    "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FormatCurrencyColumns()
        {
            foreach (DataGridViewColumn col in dgvReportPreview.Columns)
            {
                if (col.Name.Contains("Price") || col.Name.Contains("Amount") || col.Name.Contains("Total"))
                {
                    col.DefaultCellStyle.Format = "₱#,##0.00";
                    col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                }

                if (col.Name.Contains("Qty") || col.Name.Contains("Quantity"))
                {
                    col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            if (currentReportTable == null || currentReportTable.Rows.Count == 0)
            {
                MessageBox.Show("Please load a report with records first.", "No Data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "Excel Workbook (*.xlsx)|*.xlsx";
                sfd.FileName = currentReportTitle.Replace(" ", "_") + "_" + DateTime.Now.ToString("yyyyMMdd_HHmm") + ".xlsx";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    ExportToExcel(sfd.FileName);
                }
            }
        }

        private void ExportToExcel(string filePath)
        {
            Excel.Application excelApp = null;
            Excel.Workbook workbook = null;
            Excel.Worksheet reportSheet = null;
            Excel.Worksheet chartSheet = null;

            try
            {
                excelApp = new Excel.Application();
                excelApp.DisplayAlerts = false;

                workbook = excelApp.Workbooks.Add();
                reportSheet = workbook.Worksheets[1];
                reportSheet.Name = "Report";

                chartSheet = workbook.Worksheets.Add(After: reportSheet);
                chartSheet.Name = "Graph";

                int totalColumns = currentReportTable.Columns.Count;
                int lastDataRow = currentReportTable.Rows.Count + 5;

                // HEADER
                reportSheet.Range["A1", GetExcelColumnName(totalColumns) + "1"].Merge();
                reportSheet.Range["A1"].Value = "Pet Shop";
                reportSheet.Range["A1"].Font.Bold = true;
                reportSheet.Range["A1"].Font.Size = 18;
                reportSheet.Range["A1"].Font.Color = ColorTranslator.ToOle(ColorTranslator.FromHtml("#4E56C0"));
                reportSheet.Range["A1"].HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

                reportSheet.Range["A2", GetExcelColumnName(totalColumns) + "2"].Merge();
                reportSheet.Range["A2"].Value = currentReportTitle;
                reportSheet.Range["A2"].Font.Bold = true;
                reportSheet.Range["A2"].Font.Size = 14;
                reportSheet.Range["A2"].HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

                reportSheet.Range["A3", GetExcelColumnName(totalColumns) + "3"].Merge();
                reportSheet.Range["A3"].Value = "Generated: " + DateTime.Now.ToString("MMMM dd, yyyy hh:mm tt");
                reportSheet.Range["A3"].HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

                if (File.Exists(logoPath))
                {
                    Excel.Pictures pictures = (Excel.Pictures)reportSheet.Pictures();
                    Excel.Picture picture = pictures.Insert(logoPath);
                    picture.Left = 10;
                    picture.Top = 8;
                    picture.Width = 60;
                    picture.Height = 45;
                }

                // TABLE HEADERS
                for (int c = 0; c < totalColumns; c++)
                {
                    Excel.Range cell = reportSheet.Cells[5, c + 1];
                    cell.Value = currentReportTable.Columns[c].ColumnName;
                    cell.Font.Bold = true;
                    cell.Font.Color = ColorTranslator.ToOle(Color.White);
                    cell.Interior.Color = ColorTranslator.ToOle(ColorTranslator.FromHtml("#4E56C0"));
                    cell.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                }

                // DATA
                for (int r = 0; r < currentReportTable.Rows.Count; r++)
                {
                    for (int c = 0; c < totalColumns; c++)
                    {
                        reportSheet.Cells[r + 6, c + 1] = currentReportTable.Rows[r][c];
                    }
                }

                Excel.Range tableRange = reportSheet.Range["A5", GetExcelColumnName(totalColumns) + lastDataRow.ToString()];
                tableRange.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                tableRange.Columns.AutoFit();

                foreach (Excel.Range cell in tableRange.Columns)
                {
                    if (cell.ColumnWidth > 32) cell.ColumnWidth = 32;
                }

                // Currency formats
                for (int c = 0; c < totalColumns; c++)
                {
                    string colName = currentReportTable.Columns[c].ColumnName;

                    if (colName.Contains("Price") || colName.Contains("Amount") || colName.Contains("Total"))
                    {
                        reportSheet.Range[
                            GetExcelColumnName(c + 1) + "6",
                            GetExcelColumnName(c + 1) + lastDataRow
                        ].NumberFormat = "₱#,##0.00";
                    }
                }

                // SIGNATURE PLACEHOLDER
                int signatureRow = lastDataRow + 4;
                reportSheet.Cells[signatureRow, 1] = "Prepared / Certified by:";
                reportSheet.Cells[signatureRow + 3, 1] = txtSigner.Text.Trim() == "" ? "________________________" : txtSigner.Text.Trim();
                reportSheet.Cells[signatureRow + 4, 1] = "Signature over Printed Name";
                reportSheet.Range["A" + (signatureRow + 3), "C" + (signatureRow + 3)].Borders[Excel.XlBordersIndex.xlEdgeBottom].LineStyle = Excel.XlLineStyle.xlContinuous;

                // SHEET 2 DATA FOR GRAPH
                DataTable chartTable = BuildChartTable();

                chartSheet.Cells[1, 1] = currentChartLabelColumn;
                chartSheet.Cells[1, 2] = currentChartValueColumn;
                chartSheet.Range["A1", "B1"].Font.Bold = true;
                chartSheet.Range["A1", "B1"].Interior.Color = ColorTranslator.ToOle(ColorTranslator.FromHtml("#4E56C0"));
                chartSheet.Range["A1", "B1"].Font.Color = ColorTranslator.ToOle(Color.White);

                for (int r = 0; r < chartTable.Rows.Count; r++)
                {
                    chartSheet.Cells[r + 2, 1] = chartTable.Rows[r][0];
                    chartSheet.Cells[r + 2, 2] = chartTable.Rows[r][1];
                }

                chartSheet.Columns.AutoFit();

                Excel.ChartObjects chartObjects = (Excel.ChartObjects)chartSheet.ChartObjects();
                Excel.ChartObject chartObject = chartObjects.Add(320, 20, 600, 360);
                Excel.Chart chart = chartObject.Chart;

                chart.SetSourceData(chartSheet.Range["A1", "B" + (chartTable.Rows.Count + 1)]);
                chart.ChartType = Excel.XlChartType.xlColumnClustered;
                chart.HasTitle = true;
                chart.ChartTitle.Text = currentReportTitle + " Graph";
                chart.HasLegend = false;

                workbook.SaveAs(filePath);

                MessageBox.Show("Excel report exported successfully!\n\n" + filePath,
                    "Export Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Excel export failed. Make sure Microsoft Excel is installed and close any open copy of the same file.\n\n" + ex.Message,
                    "Export Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (workbook != null) workbook.Close(false);
                if (excelApp != null) excelApp.Quit();
            }
        }

        private DataTable BuildChartTable()
        {
            DataTable chartTable = new DataTable();
            chartTable.Columns.Add(currentChartLabelColumn);
            chartTable.Columns.Add(currentChartValueColumn, typeof(decimal));

            int labelIndex = currentReportTable.Columns[currentChartLabelColumn].Ordinal;
            int valueIndex = currentReportTable.Columns[currentChartValueColumn].Ordinal;

            // This groups same labels together.
            // Example:
            // Sales graph: same product names are combined by total Qty.
            // Payment graph: same payment methods are combined by total Amount.
            foreach (DataRow row in currentReportTable.Rows)
            {
                string label = row[labelIndex].ToString();
                decimal value = Convert.ToDecimal(row[valueIndex]);

                DataRow existingRow = null;

                foreach (DataRow chartRow in chartTable.Rows)
                {
                    if (chartRow[currentChartLabelColumn].ToString() == label)
                    {
                        existingRow = chartRow;
                        break;
                    }
                }

                if (existingRow == null)
                {
                    DataRow newRow = chartTable.NewRow();
                    newRow[currentChartLabelColumn] = label;
                    newRow[currentChartValueColumn] = value;
                    chartTable.Rows.Add(newRow);
                }
                else
                {
                    existingRow[currentChartValueColumn] =
                        Convert.ToDecimal(existingRow[currentChartValueColumn]) + value;
                }
            }

            return chartTable;
        }

        private string GetExcelColumnName(int columnNumber)
        {
            int dividend = columnNumber;
            string columnName = String.Empty;

            while (dividend > 0)
            {
                int modulo = (dividend - 1) % 26;
                columnName = Convert.ToChar(65 + modulo).ToString() + columnName;
                dividend = (dividend - modulo) / 26;
            }

            return columnName;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}