using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace budgetApp
{
    public partial class frmEnterExpense : Form
    {
        private sqliteInterface db = new sqliteInterface();
        private int accountID;
        public event EventHandler newEntry;
        protected virtual void OnNewEntry( object sender, EventArgs e ) {
            // do something?
            newEntry(this, e);
        }
        public frmEnterExpense(int accountID = -1)
        {
            InitializeComponent();
            this.accountID = accountID;
            lblStatus.Text = "";
        }
        #region methods
        /* update the status label */
        private void updateStatus( string message, bool error = true ) {
            if (error) {
                lblStatus.ForeColor = System.Drawing.Color.DarkRed;
            } else {
                lblStatus.ForeColor = System.Drawing.Color.LimeGreen;
            }
            lblStatus.Text = message;
        }
        private bool addExpense() {
            expense newExpense = new expense();
            try {
                newExpense.account = this.db.getAccountID(cmbAccount.Text);
                if (newExpense.account == -1) {
                    /* an error occurred */
                    updateStatus("Invalid account");
                    return false;
                }
                newExpense.payTo = cmbPayTo.Text;
                newExpense.amount = Convert.ToDouble(nudAmount.Value) * -1;
                newExpense.expenseDate = dtpPaidDate.Value;
                newExpense.postedDate = DateTime.Now;
                newExpense.notes = txtNotes.Text;
                newExpense.category = this.db.getBudgetCategoryID(cmbCategory.Text);
                if (newExpense.category == -1) {
                    /* an error occurred */
                    updateStatus("Invalid Category");
                    return false;
                }
                if (!newExpense.add(this.db)) {
                    updateStatus("Error adding to database.");
                    return false;
                } else {
                    return true;
                }
            } catch (Exception e) {
                updateStatus("An error occurred.");
                MessageBox.Show(e.ToString());
                return false;
            }
        }
        /* fill payees combo box */
        private void loadPayees() {
            List<string> payees = new List<string>();
            payees = this.db.getPayees();
            cmbPayTo.Items.Add("(Enter new)");
            foreach (string payee in payees) {
                cmbPayTo.Items.Add(payee);
            }
            cmbPayTo.SelectedIndex = 0;
        }
        /* fill accounts combo box */
        private void loadAccounts() {
            List<string> accounts = new List<string>();
            accounts = this.db.getAccounts();
            if (accounts.Count == 0) {
                cmbAccount.Items.Add("Please add an account first.");
            }
            foreach (string account in accounts) {
                cmbAccount.Items.Add(account);
            }
            account curAccount = this.db.getAccount(this.accountID);
            cmbAccount.SelectedText = curAccount.name;
            //cmbAccount.SelectedIndex = 0;
        }
        /* fill category combo box */
        private void loadCats() {
            List<string> budgetCats = new List<string>();
            budgetCats = this.db.getBudgetCats();
            cmbCategory.Items.Add("None");
            foreach (string cat in budgetCats) {
                cmbCategory.Items.Add(cat);
            }
            cmbCategory.SelectedIndex = 0;
        }
        /* load form's combo boxes with information from database */
        private void loadCombos() {
            loadAccounts();
            loadCats();
            loadPayees();
        }
        /* reset the inputs to default */
        private void resetInputs() {
            nudAmount.Value = 0;
            txtNotes.Clear();
            /* reload combo box with payees */
            cmbPayTo.Items.Clear();
            loadPayees();
            cmbAccount.SelectedIndex = 0;
            cmbCategory.SelectedIndex = 0;
            return;
        }
        #endregion
        #region eventhandlers
        private void frmEnterExpense_Load(object sender, EventArgs e) {
            this.db = new sqliteInterface();
            this.db.createDatabase();
            loadCombos();
        }

        private void btnEnter_Click( object sender, EventArgs e ) {
            if (!addExpense()) {
                /* and error occurred */
            } else {
                updateStatus("Successfully added!", false);
                resetInputs();
                OnNewEntry(this, null);
                this.Close();
            }
        }
        #endregion
    }
}
