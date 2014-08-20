using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace budget {
    public partial class frmAddAccount : Form {
        private sqliteInterface db = new sqliteInterface();
        public frmAddAccount() {
            InitializeComponent();
            this.db.createDatabase();
        }
        private bool addAccount() {
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

            return true;
        }
        /* update the status label */
        public void updateStatus( string message, bool error ) {
            if (error) {
                lblStatus.ForeColor = System.Drawing.Color.DarkRed;
            } else {
                lblStatus.ForeColor = System.Drawing.Color.LimeGreen;
            }
            lblStatus.Text = message;
        }
        /* event handlers */
        private void btnAdd_Click( object sender, EventArgs e ) {
            if (addAccount()) {
                updateStatus("Successfully added!", false);
            }
        }
        /* TODO: move this off the event handler */
        private void frmAddAccount_Load( object sender, EventArgs e ) {
            List<string> cats = new List<string>();
            cats = this.db.getAccountCategories();
            lblStatus.Text = "";
            /* load category combobox with values */
            foreach (string cat in cats) {
                cmbCategories.Items.Add(cat);
            }
            cmbCategories.SelectedIndex = 0;
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

    }
}
