using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient; 

namespace PetShopInventory
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();

            // ── THE BULLETPROOF WIRES ──────────────────────────────
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            this.linkRecovery.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkRecovery_LinkClicked);
            // ───────────────────────────────────────────────────────
        }

        // ── The Database Login Event ────────────────────────────────
        private void btnLogin_Click(object sender, EventArgs e)
        {
            // 1. Check if fields are empty
            if (string.IsNullOrWhiteSpace(txtUsername.Text) || string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Please enter both username and password.");
                return;
            }

            // 2. Call the DatabaseConnection class we just made
            DatabaseConnection db = new DatabaseConnection();
            using (MySqlConnection conn = db.GetConnection())
            {
                try
                {
                    conn.Open();
                    // 3. Ask the database if the user exists and is Active
                    string query = "SELECT COUNT(*) FROM users WHERE Username = @user AND Password = @pass AND Status = 'Active'";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@user", txtUsername.Text.Trim());
                        cmd.Parameters.AddWithValue("@pass", txtPassword.Text);

                        int result = Convert.ToInt32(cmd.ExecuteScalar());

                        // 4. If result is greater than 0, a match was found!
                        if (result > 0)
                        {
                            this.Hide();
                            DashboardForm dashboard = new DashboardForm();
                            dashboard.ShowDialog();
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Invalid username or password, or account is inactive.\nPlease try again.",
                                "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            txtPassword.Clear();
                            txtPassword.Focus();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Database Connection Error: Make sure XAMPP is running!\n" + ex.Message);
                }
            }
        }

        // ── The Exit Button Event ───────────────────────────────────
        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // ── The Forgot Password Link Event ──────────────────────────
        private void linkRecovery_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            PasswordRecoveryForm recovery = new PasswordRecoveryForm();
            recovery.ShowDialog();
            this.Show();
        }
    }
}