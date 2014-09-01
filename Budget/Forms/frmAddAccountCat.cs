using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace budgetApp {
    public partial class frmAddAccountCat : Form {
        sqliteInterface db = new sqliteInterface();
        private frmAddAccount parentForm;
        public frmAddAccountCat() {
            InitializeComponent();
            lblStatus.Text = "";
        }

        public frmAddAccountCat( frmAddAccount parent = null) {
            // TODO: Complete member initialization
            InitializeComponent();
            this.parentForm = parent;
            lblStatus.Text = "";
        }
        private void updateStatus( string message, bool error = true ) {
            lblStatus.ForeColor = (error) ? System.Drawing.Color.DarkRed : System.Drawing.Color.LimeGreen;
            lblStatus.Text = message;
        }
        private bool add() {
            accountCat ac = new accountCat(txtCategory.Text);
            try {
                if (ac.name == "") {
                    updateStatus("Please enter a category.");
                    return false;
                }
                if (!this.db.addAccountCat(ac)) {
                    updateStatus("Error adding to database.");
                    return false;
                }
            } catch (Exception e) {
                updateStatus("An error occurred.");
                MessageBox.Show(e.ToString());
            }
            this.parentForm.enableFormControls();
            return true;
        }
        /* event handlers */
        private void exitToolStripMenuItem_Click( object sender, EventArgs e ) {
            this.Close();
        }

        private void btnAdd_Click( object sender, EventArgs e ) {
            if (add()) {
                updateStatus("Successfully added!", false);
                txtCategory.Clear();
            }
        }
    }
}
