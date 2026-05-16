using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace PetShopInventory
{
    public partial class UserManagementForm : Form
    {
        // Tracks if the popup is adding a new user or editing an existing one
        private bool isEditMode = false;
        private string selectedUsername = "";

        public UserManagementForm()
        {
            InitializeComponent();

            this.Load += new System.EventHandler(this.UserManagementForm_Load);
            this.btnAddUser.Click += new System.EventHandler(this.btnAddUser_Click);
            this.btnEditProfile.Click += new System.EventHandler(this.btnEditProfile_Click);
            this.btnToggleStatus.Click += new System.EventHandler(this.btnToggleStatus_Click);
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);

            // Popup Buttons
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
        }

        private void UserManagementForm_Load(object sender, EventArgs e)
        {
            LoadUserList();
        }

        private void LoadUserList(string searchQuery = "")
        {
            DatabaseConnection db = new DatabaseConnection();
            using (MySqlConnection conn = db.GetConnection())
            {
                try
                {
                    conn.Open();
                    string query = "SELECT UserID, Username, ProfileName, Status FROM users";
                    if (!string.IsNullOrEmpty(searchQuery)) query += " WHERE Username LIKE @search OR ProfileName LIKE @search";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        if (!string.IsNullOrEmpty(searchQuery)) cmd.Parameters.AddWithValue("@search", "%" + searchQuery + "%");
                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            adapter.Fill(dt);
                            dgvUsers.DataSource = dt;
                        }
                    }
                }
                catch (Exception ex) { MessageBox.Show("Database Error: " + ex.Message); }
            }
        }

        // ── 1. ADD USER (Shows Blank Popup) ──
        private void btnAddUser_Click(object sender, EventArgs e)
        {
            isEditMode = false;
            lblPopupTitle.Text = "Add New User";
            txtUsername.Clear();
            txtUsername.Enabled = true; // Can type username
            txtPassword.Clear();
            txtProfileName.Clear();
            cmbStatus.SelectedIndex = 0; // Default Active

            pnlPopup.BringToFront();
            pnlPopup.Visible = true;
        }

        // ── 2. EDIT PROFILE (Shows Filled Popup) ──
        private void btnEditProfile_Click(object sender, EventArgs e)
        {
            if (dgvUsers.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please click a user row first to edit.");
                return;
            }

            isEditMode = true;
            lblPopupTitle.Text = "Edit User Profile";

            // Get data from clicked row
            DataGridViewRow row = dgvUsers.SelectedRows[0];
            selectedUsername = row.Cells["Username"].Value.ToString();

            txtUsername.Text = selectedUsername;
            txtUsername.Enabled = false; // Don't let them change the username while editing
            txtPassword.Text = "********"; // Placeholder
            txtProfileName.Text = row.Cells["ProfileName"].Value.ToString();
            cmbStatus.SelectedItem = row.Cells["Status"].Value.ToString();

            pnlPopup.BringToFront();
            pnlPopup.Visible = true;
        }

        // ── 3. SAVE BUTTON (Inside Popup) ──
        private void btnSave_Click(object sender, EventArgs e)
        {
            DatabaseConnection db = new DatabaseConnection();
            using (MySqlConnection conn = db.GetConnection())
            {
                try
                {
                    conn.Open();
                    string query = "";
                    if (isEditMode)
                    {
                        query = "UPDATE users SET ProfileName = @profile, Status = @status WHERE Username = @user";
                    }
                    else
                    {
                        query = "INSERT INTO users (Username, Password, ProfileName, Status) VALUES (@user, @pass, @profile, @status)";
                    }

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@user", txtUsername.Text);
                        cmd.Parameters.AddWithValue("@pass", txtPassword.Text); // Only used in Add mode
                        cmd.Parameters.AddWithValue("@profile", txtProfileName.Text);
                        cmd.Parameters.AddWithValue("@status", cmbStatus.SelectedItem.ToString());
                        cmd.ExecuteNonQuery();

                        MessageBox.Show(isEditMode ? "Profile Updated!" : "User Added!");
                        pnlPopup.Visible = false;
                        LoadUserList();
                    }
                }
                catch (Exception ex) { MessageBox.Show("Error: " + ex.Message); }
            }
        }

        // ── 4. CANCEL BUTTON (Inside Popup) ──
        private void btnCancel_Click(object sender, EventArgs e)
        {
            pnlPopup.Visible = false;
        }

        // ── 5. TOGGLE STATUS BUTTON (One Click Fix) ──
        private void btnToggleStatus_Click(object sender, EventArgs e)
        {
            if (dgvUsers.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please click a user row first to toggle status.");
                return;
            }

            DataGridViewRow row = dgvUsers.SelectedRows[0];
            string userToToggle = row.Cells["Username"].Value.ToString();
            string currentStatus = row.Cells["Status"].Value.ToString();

            // Flip the status
            string newStatus = (currentStatus == "Active") ? "Inactive" : "Active";

            DatabaseConnection db = new DatabaseConnection();
            using (MySqlConnection conn = db.GetConnection())
            {
                try
                {
                    conn.Open();
                    string query = "UPDATE users SET Status = @status WHERE Username = @user";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@status", newStatus);
                        cmd.Parameters.AddWithValue("@user", userToToggle);
                        cmd.ExecuteNonQuery();

                        MessageBox.Show($"Status changed to {newStatus}!");
                        LoadUserList();
                    }
                }
                catch (Exception ex) { MessageBox.Show("Error: " + ex.Message); }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadUserList(txtSearch.Text);
        }
    }
}