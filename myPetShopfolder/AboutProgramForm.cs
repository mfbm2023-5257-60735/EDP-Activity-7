using System;
using System.Windows.Forms;

namespace PetShopInventory
{
    public partial class AboutProgramForm : Form
    {
        public AboutProgramForm()
        {
            InitializeComponent();

            // ── THE BULLETPROOF WIRES ──────────────────────────────
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // ───────────────────────────────────────────────────────
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lblDescription_Click(object sender, EventArgs e)
        {
            // Left empty intentionally
        }
    }
}