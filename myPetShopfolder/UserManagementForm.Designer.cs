namespace PetShopInventory
{
    partial class UserManagementForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dgvUsers;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblHeader;

        // Main Action Buttons
        private System.Windows.Forms.Button btnAddUser;
        private System.Windows.Forms.Button btnEditProfile;
        private System.Windows.Forms.Button btnToggleStatus;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnSearch;

        // POP-UP PANEL
        private System.Windows.Forms.Panel pnlPopup;
        private System.Windows.Forms.Label lblPopupTitle;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtProfileName;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label l1, l2, l3, l4;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) { components.Dispose(); }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblHeader = new System.Windows.Forms.Label();
            this.dgvUsers = new System.Windows.Forms.DataGridView();
            this.btnAddUser = new System.Windows.Forms.Button();
            this.btnEditProfile = new System.Windows.Forms.Button();
            this.btnToggleStatus = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();

            this.pnlPopup = new System.Windows.Forms.Panel();
            this.lblPopupTitle = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtProfileName = new System.Windows.Forms.TextBox();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.l1 = new System.Windows.Forms.Label();
            this.l2 = new System.Windows.Forms.Label();
            this.l3 = new System.Windows.Forms.Label();
            this.l4 = new System.Windows.Forms.Label();

            this.pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsers)).BeginInit();
            this.pnlPopup.SuspendLayout();
            this.SuspendLayout();

            // ── HEADER ──
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(58)))), ((int)(((byte)(183)))));
            this.pnlHeader.Controls.Add(this.lblHeader);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Size = new System.Drawing.Size(850, 70);

            this.lblHeader.AutoSize = true;
            this.lblHeader.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblHeader.ForeColor = System.Drawing.Color.White;
            this.lblHeader.Location = new System.Drawing.Point(20, 18);
            this.lblHeader.Text = "System User Management";

            // ── MAIN ACTION BAR ──
            this.btnAddUser.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btnAddUser.ForeColor = System.Drawing.Color.White;
            this.btnAddUser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddUser.Location = new System.Drawing.Point(30, 90);
            this.btnAddUser.Size = new System.Drawing.Size(120, 40);
            this.btnAddUser.Text = "➕ Add User";

            this.btnEditProfile.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnEditProfile.ForeColor = System.Drawing.Color.White;
            this.btnEditProfile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditProfile.Location = new System.Drawing.Point(160, 90);
            this.btnEditProfile.Size = new System.Drawing.Size(120, 40);
            this.btnEditProfile.Text = "✏️ Edit Profile";

            this.btnToggleStatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(196)))), ((int)(((byte)(15)))));
            this.btnToggleStatus.ForeColor = System.Drawing.Color.Black;
            this.btnToggleStatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnToggleStatus.Location = new System.Drawing.Point(290, 90);
            this.btnToggleStatus.Size = new System.Drawing.Size(150, 40);
            this.btnToggleStatus.Text = "🔄 Toggle Status";

            this.txtSearch.Location = new System.Drawing.Point(540, 98);
            this.txtSearch.Size = new System.Drawing.Size(180, 25);
            this.btnSearch.BackColor = System.Drawing.Color.Gray;
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Location = new System.Drawing.Point(730, 93);
            this.btnSearch.Size = new System.Drawing.Size(90, 35);
            this.btnSearch.Text = "Search";

            // ── DATAGRIDVIEW ──
            this.dgvUsers.BackgroundColor = System.Drawing.Color.White;
            this.dgvUsers.Location = new System.Drawing.Point(30, 150);
            this.dgvUsers.Size = new System.Drawing.Size(790, 380);
            this.dgvUsers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvUsers.AllowUserToAddRows = false; // STOPS THE BLANK ROW!
            this.dgvUsers.ReadOnly = true;
            this.dgvUsers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;

            // ── POP-UP PANEL (Hidden by default) ──
            this.pnlPopup.BackColor = System.Drawing.Color.White;
            this.pnlPopup.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlPopup.Controls.Add(this.lblPopupTitle);
            this.pnlPopup.Controls.Add(this.l1); this.pnlPopup.Controls.Add(this.txtUsername);
            this.pnlPopup.Controls.Add(this.l2); this.pnlPopup.Controls.Add(this.txtPassword);
            this.pnlPopup.Controls.Add(this.l3); this.pnlPopup.Controls.Add(this.txtProfileName);
            this.pnlPopup.Controls.Add(this.l4); this.pnlPopup.Controls.Add(this.cmbStatus);
            this.pnlPopup.Controls.Add(this.btnSave);
            this.pnlPopup.Controls.Add(this.btnCancel);
            this.pnlPopup.Location = new System.Drawing.Point(250, 120);
            this.pnlPopup.Size = new System.Drawing.Size(350, 380);
            this.pnlPopup.Visible = false; // HIDDEN INITIALLY

            this.lblPopupTitle.AutoSize = true;
            this.lblPopupTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblPopupTitle.Location = new System.Drawing.Point(20, 20);
            this.lblPopupTitle.Text = "User Details";

            this.l1.Location = new System.Drawing.Point(20, 70); this.l1.Text = "Username:";
            this.txtUsername.Location = new System.Drawing.Point(20, 90); this.txtUsername.Size = new System.Drawing.Size(300, 25);

            this.l2.Location = new System.Drawing.Point(20, 130); this.l2.Text = "Password:";
            this.txtPassword.Location = new System.Drawing.Point(20, 150); this.txtPassword.Size = new System.Drawing.Size(300, 25);

            this.l3.Location = new System.Drawing.Point(20, 190); this.l3.Text = "Profile Name:";
            this.txtProfileName.Location = new System.Drawing.Point(20, 210); this.txtProfileName.Size = new System.Drawing.Size(300, 25);

            this.l4.Location = new System.Drawing.Point(20, 250); this.l4.Text = "Status:";
            this.cmbStatus.Location = new System.Drawing.Point(20, 270); this.cmbStatus.Size = new System.Drawing.Size(300, 25);
            this.cmbStatus.Items.AddRange(new object[] { "Active", "Inactive" });

            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(58)))), ((int)(((byte)(183)))));
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(20, 320);
            this.btnSave.Size = new System.Drawing.Size(140, 40);
            this.btnSave.Text = "Save";

            this.btnCancel.Location = new System.Drawing.Point(180, 320);
            this.btnCancel.Size = new System.Drawing.Size(140, 40);
            this.btnCancel.Text = "Cancel";

            // ── FORM SETTINGS ──
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(246)))), ((int)(((byte)(250)))));
            this.ClientSize = new System.Drawing.Size(850, 560);
            this.Controls.Add(this.pnlPopup); // Add popup to front
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.btnAddUser);
            this.Controls.Add(this.btnEditProfile);
            this.Controls.Add(this.btnToggleStatus);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.dgvUsers);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "User Management";

            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsers)).EndInit();
            this.pnlPopup.ResumeLayout(false);
            this.pnlPopup.PerformLayout();
            this.ResumeLayout(false);
        }
    }
}