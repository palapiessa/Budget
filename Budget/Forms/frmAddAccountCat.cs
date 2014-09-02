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
            if (this.parentForm != null) {
                this.parentForm.enableFormControls();
            }
            return true;
        }
        /*  */
        private void catchReturn() {
            if (add()) {
                updateStatus("Successfully added!", false);
                lstCategories.Items.Add(txtCategory.Text);
                txtCategory.Clear();
                txtCategory.Focus();
            }
        }
        private void loadCategories() {
            List<string> cats = new List<string>();
            cats = this.db.getAccountCategories();
            lblStatus.Text = "";
            lstCategories.Items.Clear();
            foreach (string cat in cats) {
                lstCategories.Items.Add(cat);
            }

        }
        private void verifyRemoveCat(int category) {
            string catName = lstCategories.Items[category].ToString(); // gets the string name of the category that was double clicked
            DialogResult remove = MessageBox.Show("Are you sure you would like to remove " + catName + "?", "Confirm Category Deletion", MessageBoxButtons.YesNo);
            if (remove == DialogResult.Yes) {
                try {
                    if (!this.db.removeAccountCat(catName)) {
                        updateStatus("Database error");
                    } else {
                        updateStatus("Successfully removed", false);
                        loadCategories();
                    }
                } catch {
                    updateStatus("Unknown error");
                }
            }
        }
        /* event handlers */
        private void exitToolStripMenuItem_Click( object sender, EventArgs e ) {
            this.Close();
        }

        private void btnAdd_Click( object sender, EventArgs e ) {
            catchReturn();
        }
        private void keyHandler( object sender, KeyEventArgs e ) {
            if (e.KeyCode == Keys.Enter) {
                catchReturn();
            }
        }

        private void frmAddAccountCat_Load( object sender, EventArgs e ) {
            loadCategories();
        }

        private void lstCategories_MouseDoubleClick( object sender, MouseEventArgs e ) {
            verifyRemoveCat(this.lstCategories.IndexFromPoint(e.Location));
            //MessageBox.Show(this.lstCategories.IndexFromPoint(e.Location).ToString());
        }

        private void btnClear_Click( object sender, EventArgs e ) {
            txtCategory.Clear();
        }
    }
}
