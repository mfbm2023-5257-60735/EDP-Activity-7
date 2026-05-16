namespace PetShopInventory
{
    partial class DashboardForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel panelSidebar;
        private System.Windows.Forms.Panel panelLogo;
        private System.Windows.Forms.Label lblLogo;
        private System.Windows.Forms.Button btnNavInventory;
        private System.Windows.Forms.Button btnReport;
        private System.Windows.Forms.Button btnAbout;
        private System.Windows.Forms.Button btnUserManagement; // Added this!
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Panel panelContent;
        private System.Windows.Forms.Label lblHeader;

        // Summary Cards
        private System.Windows.Forms.Panel pnlCard1;
        private System.Windows.Forms.Label lblCardTitle1;
        public System.Windows.Forms.Label lblCardValue1;

        private System.Windows.Forms.Panel pnlCard2;
        private System.Windows.Forms.Label lblCardTitle2;
        public System.Windows.Forms.Label lblCardValue2;

        private System.Windows.Forms.Panel pnlCard3;
        private System.Windows.Forms.Label lblCardTitle3;
        public System.Windows.Forms.Label lblCardValue3;

        // Action Buttons
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDelete;

        private System.Windows.Forms.DataGridView dgvInventory;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) { components.Dispose(); }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.panelSidebar = new System.Windows.Forms.Panel();
            this.btnLogout = new System.Windows.Forms.Button();
            this.btnUserManagement = new System.Windows.Forms.Button(); // Instantiated here
            this.btnAbout = new System.Windows.Forms.Button();
            this.btnReport = new System.Windows.Forms.Button();
            this.btnNavInventory = new System.Windows.Forms.Button();
            this.panelLogo = new System.Windows.Forms.Panel();
            this.lblLogo = new System.Windows.Forms.Label();
            this.panelContent = new System.Windows.Forms.Panel();
            this.pnlCard1 = new System.Windows.Forms.Panel();
            this.lblCardTitle1 = new System.Windows.Forms.Label();
            this.lblCardValue1 = new System.Windows.Forms.Label();
            this.pnlCard2 = new System.Windows.Forms.Panel();
            this.lblCardTitle2 = new System.Windows.Forms.Label();
            this.lblCardValue2 = new System.Windows.Forms.Label();
            this.pnlCard3 = new System.Windows.Forms.Panel();
            this.lblCardTitle3 = new System.Windows.Forms.Label();
            this.lblCardValue3 = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.dgvInventory = new System.Windows.Forms.DataGridView();
            this.lblHeader = new System.Windows.Forms.Label();
            this.panelSidebar.SuspendLayout();
            this.panelLogo.SuspendLayout();
            this.panelContent.SuspendLayout();
            this.pnlCard1.SuspendLayout();
            this.pnlCard2.SuspendLayout();
            this.pnlCard3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInventory)).BeginInit();
            this.SuspendLayout();
            // 
            // panelSidebar
            // 
            this.panelSidebar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(58)))), ((int)(((byte)(183)))));
            this.panelSidebar.Controls.Add(this.btnLogout);
            this.panelSidebar.Controls.Add(this.btnUserManagement); // Added to sidebar
            this.panelSidebar.Controls.Add(this.btnAbout);
            this.panelSidebar.Controls.Add(this.btnReport);
            this.panelSidebar.Controls.Add(this.btnNavInventory);
            this.panelSidebar.Controls.Add(this.panelLogo);
            this.panelSidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelSidebar.Location = new System.Drawing.Point(0, 0);
            this.panelSidebar.Name = "panelSidebar";
            this.panelSidebar.Size = new System.Drawing.Size(220, 650);
            this.panelSidebar.TabIndex = 1;
            // 
            // btnLogout
            // 
            this.btnLogout.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnLogout.FlatAppearance.BorderSize = 0;
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.btnLogout.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(190)))), ((int)(((byte)(255)))));
            this.btnLogout.Location = new System.Drawing.Point(0, 595);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(220, 55);
            this.btnLogout.TabIndex = 0;
            this.btnLogout.Text = "Log Out";
            // 
            // btnUserManagement (THE NEW BUTTON)
            // 
            this.btnUserManagement.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnUserManagement.FlatAppearance.BorderSize = 0;
            this.btnUserManagement.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUserManagement.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.btnUserManagement.ForeColor = System.Drawing.Color.White;
            this.btnUserManagement.Location = new System.Drawing.Point(0, 245);
            this.btnUserManagement.Name = "btnUserManagement";
            this.btnUserManagement.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btnUserManagement.Size = new System.Drawing.Size(220, 55);
            this.btnUserManagement.TabIndex = 5;
            this.btnUserManagement.Text = "Users";
            this.btnUserManagement.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnAbout
            // 
            this.btnAbout.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnAbout.FlatAppearance.BorderSize = 0;
            this.btnAbout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAbout.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.btnAbout.ForeColor = System.Drawing.Color.White;
            this.btnAbout.Location = new System.Drawing.Point(0, 190);
            this.btnAbout.Name = "btnAbout";
            this.btnAbout.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btnAbout.Size = new System.Drawing.Size(220, 55);
            this.btnAbout.TabIndex = 1;
            this.btnAbout.Text = "About";
            this.btnAbout.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // Note: The broken Click event here was removed!
            // 
            // btnReport
            // 
            this.btnReport.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnReport.FlatAppearance.BorderSize = 0;
            this.btnReport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReport.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.btnReport.ForeColor = System.Drawing.Color.White;
            this.btnReport.Location = new System.Drawing.Point(0, 135);
            this.btnReport.Name = "btnReport";
            this.btnReport.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btnReport.Size = new System.Drawing.Size(220, 55);
            this.btnReport.TabIndex = 2;
            this.btnReport.Text = "Reports";
            this.btnReport.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnNavInventory
            // 
            this.btnNavInventory.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnNavInventory.FlatAppearance.BorderSize = 0;
            this.btnNavInventory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNavInventory.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.btnNavInventory.ForeColor = System.Drawing.Color.White;
            this.btnNavInventory.Location = new System.Drawing.Point(0, 80);
            this.btnNavInventory.Name = "btnNavInventory";
            this.btnNavInventory.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btnNavInventory.Size = new System.Drawing.Size(220, 55);
            this.btnNavInventory.TabIndex = 3;
            this.btnNavInventory.Text = "Dashboard";
            this.btnNavInventory.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panelLogo
            // 
            this.panelLogo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(81)))), ((int)(((byte)(45)))), ((int)(((byte)(168)))));
            this.panelLogo.Controls.Add(this.lblLogo);
            this.panelLogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelLogo.Location = new System.Drawing.Point(0, 0);
            this.panelLogo.Name = "panelLogo";
            this.panelLogo.Size = new System.Drawing.Size(220, 80);
            this.panelLogo.TabIndex = 4;
            // 
            // lblLogo
            // 
            this.lblLogo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLogo.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblLogo.ForeColor = System.Drawing.Color.White;
            this.lblLogo.Location = new System.Drawing.Point(0, 0);
            this.lblLogo.Name = "lblLogo";
            this.lblLogo.Size = new System.Drawing.Size(220, 80);
            this.lblLogo.TabIndex = 0;
            this.lblLogo.Text = "PET SHOP";
            this.lblLogo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelContent
            // 
            this.panelContent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.panelContent.Controls.Add(this.pnlCard1);
            this.panelContent.Controls.Add(this.pnlCard2);
            this.panelContent.Controls.Add(this.pnlCard3);
            this.panelContent.Controls.Add(this.btnAdd);
            this.panelContent.Controls.Add(this.btnEdit);
            this.panelContent.Controls.Add(this.btnDelete);
            this.panelContent.Controls.Add(this.dgvInventory);
            this.panelContent.Controls.Add(this.lblHeader);
            this.panelContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContent.Location = new System.Drawing.Point(220, 0);
            this.panelContent.Name = "panelContent";
            this.panelContent.Size = new System.Drawing.Size(780, 650);
            this.panelContent.TabIndex = 0;
            // 
            // pnlCard1
            // 
            this.pnlCard1.BackColor = System.Drawing.Color.White;
            this.pnlCard1.Controls.Add(this.lblCardTitle1);
            this.pnlCard1.Controls.Add(this.lblCardValue1);
            this.pnlCard1.Location = new System.Drawing.Point(30, 80);
            this.pnlCard1.Name = "pnlCard1";
            this.pnlCard1.Size = new System.Drawing.Size(220, 100);
            this.pnlCard1.TabIndex = 0;
            // 
            // lblCardTitle1
            // 
            this.lblCardTitle1.AutoSize = true;
            this.lblCardTitle1.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblCardTitle1.ForeColor = System.Drawing.Color.Gray;
            this.lblCardTitle1.Location = new System.Drawing.Point(15, 15);
            this.lblCardTitle1.Name = "lblCardTitle1";
            this.lblCardTitle1.Size = new System.Drawing.Size(204, 28);
            this.lblCardTitle1.TabIndex = 0;
            this.lblCardTitle1.Text = "Total Unique Products";
            // 
            // lblCardValue1
            // 
            this.lblCardValue1.AutoSize = true;
            this.lblCardValue1.Font = new System.Drawing.Font("Segoe UI", 26F, System.Drawing.FontStyle.Bold);
            this.lblCardValue1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(58)))), ((int)(((byte)(183)))));
            this.lblCardValue1.Location = new System.Drawing.Point(12, 40);
            this.lblCardValue1.Name = "lblCardValue1";
            this.lblCardValue1.Size = new System.Drawing.Size(60, 70);
            this.lblCardValue1.TabIndex = 1;
            this.lblCardValue1.Text = "0";
            // 
            // pnlCard2
            // 
            this.pnlCard2.BackColor = System.Drawing.Color.White;
            this.pnlCard2.Controls.Add(this.lblCardTitle2);
            this.pnlCard2.Controls.Add(this.lblCardValue2);
            this.pnlCard2.Location = new System.Drawing.Point(270, 80);
            this.pnlCard2.Name = "pnlCard2";
            this.pnlCard2.Size = new System.Drawing.Size(220, 100);
            this.pnlCard2.TabIndex = 1;
            // 
            // lblCardTitle2
            // 
            this.lblCardTitle2.AutoSize = true;
            this.lblCardTitle2.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblCardTitle2.ForeColor = System.Drawing.Color.Gray;
            this.lblCardTitle2.Location = new System.Drawing.Point(15, 15);
            this.lblCardTitle2.Name = "lblCardTitle2";
            this.lblCardTitle2.Size = new System.Drawing.Size(180, 28);
            this.lblCardTitle2.TabIndex = 0;
            this.lblCardTitle2.Text = "Total Items in Stock";
            // 
            // lblCardValue2
            // 
            this.lblCardValue2.AutoSize = true;
            this.lblCardValue2.Font = new System.Drawing.Font("Segoe UI", 26F, System.Drawing.FontStyle.Bold);
            this.lblCardValue2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(58)))), ((int)(((byte)(183)))));
            this.lblCardValue2.Location = new System.Drawing.Point(12, 40);
            this.lblCardValue2.Name = "lblCardValue2";
            this.lblCardValue2.Size = new System.Drawing.Size(60, 70);
            this.lblCardValue2.TabIndex = 1;
            this.lblCardValue2.Text = "0";
            // 
            // pnlCard3
            // 
            this.pnlCard3.BackColor = System.Drawing.Color.White;
            this.pnlCard3.Controls.Add(this.lblCardTitle3);
            this.pnlCard3.Controls.Add(this.lblCardValue3);
            this.pnlCard3.Location = new System.Drawing.Point(510, 80);
            this.pnlCard3.Name = "pnlCard3";
            this.pnlCard3.Size = new System.Drawing.Size(220, 100);
            this.pnlCard3.TabIndex = 2;
            // 
            // lblCardTitle3
            // 
            this.lblCardTitle3.AutoSize = true;
            this.lblCardTitle3.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblCardTitle3.ForeColor = System.Drawing.Color.Gray;
            this.lblCardTitle3.Location = new System.Drawing.Point(15, 15);
            this.lblCardTitle3.Name = "lblCardTitle3";
            this.lblCardTitle3.Size = new System.Drawing.Size(155, 28);
            this.lblCardTitle3.TabIndex = 0;
            this.lblCardTitle3.Text = "Low Stock Alerts";
            // 
            // lblCardValue3
            // 
            this.lblCardValue3.AutoSize = true;
            this.lblCardValue3.Font = new System.Drawing.Font("Segoe UI", 26F, System.Drawing.FontStyle.Bold);
            this.lblCardValue3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.lblCardValue3.Location = new System.Drawing.Point(12, 40);
            this.lblCardValue3.Name = "lblCardValue3";
            this.lblCardValue3.Size = new System.Drawing.Size(60, 70);
            this.lblCardValue3.TabIndex = 1;
            this.lblCardValue3.Text = "0";
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(104)))), ((int)(((byte)(200)))));
            this.btnAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAdd.FlatAppearance.BorderSize = 0;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.Location = new System.Drawing.Point(30, 200);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(120, 35);
            this.btnAdd.TabIndex = 3;
            this.btnAdd.Text = "➕ Add Item";
            this.btnAdd.UseVisualStyleBackColor = false;
            // 
            // btnEdit
            // 
            this.btnEdit.BackColor = System.Drawing.Color.White;
            this.btnEdit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEdit.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
            this.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEdit.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.btnEdit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(58)))), ((int)(((byte)(183)))));
            this.btnEdit.Location = new System.Drawing.Point(160, 200);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(120, 35);
            this.btnEdit.TabIndex = 4;
            this.btnEdit.Text = "✏️ Edit Item";
            this.btnEdit.UseVisualStyleBackColor = false;
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.White;
            this.btnDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDelete.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.btnDelete.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.btnDelete.Location = new System.Drawing.Point(290, 200);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(120, 35);
            this.btnDelete.TabIndex = 5;
            this.btnDelete.Text = "🗑️ Delete Item";
            this.btnDelete.UseVisualStyleBackColor = false;
            // 
            // dgvInventory
            // 
            this.dgvInventory.BackgroundColor = System.Drawing.Color.White;
            this.dgvInventory.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvInventory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInventory.Location = new System.Drawing.Point(30, 250);
            this.dgvInventory.Name = "dgvInventory";
            this.dgvInventory.RowHeadersWidth = 62;
            this.dgvInventory.Size = new System.Drawing.Size(700, 360);
            this.dgvInventory.TabIndex = 6;
            // 
            // lblHeader
            // 
            this.lblHeader.AutoSize = true;
            this.lblHeader.Font = new System.Drawing.Font("Segoe UI Semibold", 22F, System.Drawing.FontStyle.Bold);
            this.lblHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(58)))), ((int)(((byte)(183)))));
            this.lblHeader.Location = new System.Drawing.Point(25, 20);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(243, 60);
            this.lblHeader.TabIndex = 7;
            this.lblHeader.Text = "Dashboard";
            // 
            // DashboardForm
            // 
            this.ClientSize = new System.Drawing.Size(1000, 650);
            this.Controls.Add(this.panelContent);
            this.Controls.Add(this.panelSidebar);
            this.Name = "DashboardForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dashboard - Pet Shop";
            this.panelSidebar.ResumeLayout(false);
            this.panelLogo.ResumeLayout(false);
            this.panelContent.ResumeLayout(false);
            this.panelContent.PerformLayout();
            this.pnlCard1.ResumeLayout(false);
            this.pnlCard1.PerformLayout();
            this.pnlCard2.ResumeLayout(false);
            this.pnlCard2.PerformLayout();
            this.pnlCard3.ResumeLayout(false);
            this.pnlCard3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInventory)).EndInit();
            this.ResumeLayout(false);

        }
    }
}