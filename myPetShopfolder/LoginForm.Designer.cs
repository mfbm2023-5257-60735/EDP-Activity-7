namespace PetShopInventory
{
    partial class LoginForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.LinkLabel linkRecovery;
        private System.Windows.Forms.Panel pnlLoginCard;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) { components.Dispose(); }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.pnlLoginCard = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblUsername = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.btnLogin = new System.Windows.Forms.Button();
            this.linkRecovery = new System.Windows.Forms.LinkLabel();
            this.btnExit = new System.Windows.Forms.Button();
            this.pnlLoginCard.SuspendLayout();
            this.SuspendLayout();

            // pnlLoginCard
            this.pnlLoginCard.BackColor = System.Drawing.Color.White;
            this.pnlLoginCard.Controls.Add(this.lblTitle);
            this.pnlLoginCard.Controls.Add(this.lblUsername);
            this.pnlLoginCard.Controls.Add(this.txtUsername);
            this.pnlLoginCard.Controls.Add(this.lblPassword);
            this.pnlLoginCard.Controls.Add(this.txtPassword);
            this.pnlLoginCard.Controls.Add(this.btnLogin);
            this.pnlLoginCard.Controls.Add(this.linkRecovery);
            this.pnlLoginCard.Location = new System.Drawing.Point(50, 50);
            this.pnlLoginCard.Size = new System.Drawing.Size(350, 400);

            // lblTitle
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(103, 58, 183);
            this.lblTitle.Location = new System.Drawing.Point(0, 30);
            this.lblTitle.Size = new System.Drawing.Size(350, 45);
            this.lblTitle.Text = "PET SHOP";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // lblUsername & txtUsername
            this.lblUsername.AutoSize = true;
            this.lblUsername.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblUsername.ForeColor = System.Drawing.Color.Gray;
            this.lblUsername.Location = new System.Drawing.Point(35, 100);
            this.lblUsername.Text = "Username";

            this.txtUsername.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtUsername.Location = new System.Drawing.Point(35, 125);
            this.txtUsername.Size = new System.Drawing.Size(280, 29);

            // lblPassword & txtPassword
            this.lblPassword.AutoSize = true;
            this.lblPassword.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblPassword.ForeColor = System.Drawing.Color.Gray;
            this.lblPassword.Location = new System.Drawing.Point(35, 175);
            this.lblPassword.Text = "Password";

            this.txtPassword.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtPassword.Location = new System.Drawing.Point(35, 200);
            this.txtPassword.PasswordChar = '●';
            this.txtPassword.Size = new System.Drawing.Size(280, 29);

            // btnLogin
            this.btnLogin.BackColor = System.Drawing.Color.FromArgb(186, 104, 200);
            this.btnLogin.FlatAppearance.BorderSize = 0;
            this.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogin.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.btnLogin.ForeColor = System.Drawing.Color.White;
            this.btnLogin.Location = new System.Drawing.Point(35, 260);
            this.btnLogin.Size = new System.Drawing.Size(280, 45);
            this.btnLogin.Text = "LOGIN";
            this.btnLogin.Cursor = System.Windows.Forms.Cursors.Hand;

            // linkRecovery
            this.linkRecovery.ActiveLinkColor = System.Drawing.Color.FromArgb(103, 58, 183);
            this.linkRecovery.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.linkRecovery.LinkColor = System.Drawing.Color.FromArgb(186, 104, 200);
            this.linkRecovery.Location = new System.Drawing.Point(0, 320);
            this.linkRecovery.Size = new System.Drawing.Size(350, 20);
            this.linkRecovery.Text = "Forgot Password?";
            this.linkRecovery.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // btnExit
            this.btnExit.FlatAppearance.BorderSize = 0;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Underline);
            this.btnExit.ForeColor = System.Drawing.Color.Gray;
            this.btnExit.Location = new System.Drawing.Point(180, 470);
            this.btnExit.Size = new System.Drawing.Size(90, 30);
            this.btnExit.Text = "Exit System";
            this.btnExit.Cursor = System.Windows.Forms.Cursors.Hand;

            // LoginForm
            this.BackColor = System.Drawing.Color.FromArgb(245, 245, 245);
            this.ClientSize = new System.Drawing.Size(450, 530);
            this.Controls.Add(this.pnlLoginCard);
            this.Controls.Add(this.btnExit);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login - Pet Shop";
            this.pnlLoginCard.ResumeLayout(false);
            this.pnlLoginCard.PerformLayout();
            this.ResumeLayout(false);
        }
    }
}