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
    public partial class frmAddAccount : Form {
        private sqliteInterface db = new sqliteInterface();
        private bool addAccountCat = true;
        public frmAddAccount() {
            InitializeComponent();
            this.db.createDatabase();
        }
        /* clean the form data, ensure proper fields are entered, display errors where found
         * attempt to add the account to the database
         */
        private bool addAccount() {
            if (this.addAccountCat) {
                updateStatus("Update account category", true);
                return false;
            }
            account newAccount = new account();
            try {
                if (txtAccount.Text != "") {
                    newAccount.name = txtAccount.Text;
                } else {
                    updateStatus("Please enter account name.", true);
                    return false;
                }
                if (cmbCategories.Text != "") {
                    newAccount.primaryCategory = this.db.getAccountCatID(cmbCategories.Text);
                    if (newAccount.primaryCategory == -1) {
                        updateStatus("Error with category.", true);
                        return false;
                    }
                } else {
                    updateStatus("Please select a category.", true);
                    return false;
                }
                if (txtUser.Text != "") {
                    newAccount.userName = txtUser.Text;
                } else {
                    updateStatus("Please enter a user name.", true);
                    return false;
                }
                newAccount.interest = Convert.ToDouble(nudInterest.Value);
                newAccount.balance = Convert.ToDouble(nudBalance.Value);
                if (!newAccount.add(this.db)) {
                    updateStatus("Error adding to database.", true);
                    return false;
                } else {
                    return true;
                }
            } catch (Exception e) {
                /* do something with exception */
                updateStatus("An error occurred.", true);
                MessageBox.Show(e.ToString());
                return false;
            }
            //MessageBox.Show(newAccount.interest.ToString());
        }
        /* update the status label */
        public void updateStatus( string message, bool error ) {
            lblStatus.ForeColor = (error) ? System.Drawing.Color.DarkRed : System.Drawing.Color.LimeGreen;
            lblStatus.Text = message;
        }
        /* load the combo box with categories */
        private void loadComboCats() {
            List<string> cats = new List<string>();
            cats = this.db.getAccountCategories();
            lblStatus.Text = "";
            cmbCategories.Items.Clear();
            foreach (string cat in cats) {
                cmbCategories.Items.Add(cat);
            }
        }
        /* enable the form controls based on the results of the account cateogry calls */
        public void enableFormControls() {
            loadComboCats();
            if (cmbCategories.Items.Count > 0) {
                this.addAccountCat = false;
                switchFormControls();
            } else {
                switchFormControls(false);
            }
        }
        /* cleans the form to default values */
        private void clearForm() {
            txtAccount.Text = "";
            txtUser.Text = "";
            nudBalance.Value = (decimal)0.00;
            nudInterest.Value = (decimal)0.00;
            cmbCategories.SelectedIndex = 0;
        }
        /* enable or disable the controls for the form */
        private void switchFormControls( bool enable = true ) {
            if (!enable) {
                btnAdd.Enabled = false;
                cmbCategories.Enabled = false;
                txtAccount.Enabled = false;
                txtUser.Enabled = false;
                nudBalance.Enabled = false;
                nudInterest.Enabled = false;
            } else {
                btnAdd.Enabled = true;
                cmbCategories.Enabled = true;
                txtAccount.Enabled = true;
                txtUser.Enabled = true;
                nudBalance.Enabled = true;
                nudInterest.Enabled = true;
            }
        }
        /* process the entered return */
        public void catchReturn() {
            if (addAccount()) {
                updateStatus("Successfully added!", false);
                clearForm();
            }
        }
        /* event handlers */
        private void btnAdd_Click( object sender, EventArgs e ) {
            catchReturn();
        }
        private void frmAddAccount_Load( object sender, EventArgs e ) {
            /* load category combobox with values */
            enableFormControls();
        }

        /* close the form */
        private void exitToolStripMenuItem_Click( object sender, EventArgs e ) {
            this.Close();
        }

        private void addExpenseToolStripMenuItem_Click( object sender, EventArgs e ) {
            frmEnterExpense newExpense = new frmEnterExpense();
            newExpense.Show();
        }

        private void addBudgetCatToolStripMenuItem_Click( object sender, EventArgs e ) {
            frmAddBudgetCat newBudgetCat = new frmAddBudgetCat();
            newBudgetCat.Show();
        }

        private void btnCancel_Click( object sender, EventArgs e ) {
            this.Close();
        }

        private void lblAddCat_Click( object sender, EventArgs e ) {
            frmAddAccountCat newCat = new frmAddAccountCat(this);
            newCat.Show();
        }
        /* catch a key press and process it */
        private void fullForm_KeyDown( object sender, KeyEventArgs e ) {
            if (e.KeyCode == Keys.Enter) {
                catchReturn();
            }
        }
    }
}
