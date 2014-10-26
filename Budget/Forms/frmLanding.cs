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
    public partial class frmLanding : Form {
        #region initialization
        private sqliteInterface db = new sqliteInterface();
        private DateTime timeframeStart;
        private DateTime timeframeEnd;

        public frmLanding() {
            InitializeComponent();

            //expense test2 = new expense();
            //test.insertExpense(test2);
            //List<parameter> ps = new List<parameter>();
            //parameter p = new parameter("@ID", "1");
            //ps.Add(p);
            //test.getExpense(1);
            /*queryBuilder test = new queryBuilder();
            test.getQueryDetails("GetAccountByID");*/

            this.db.createDatabase();
            this.loadAccountsCombo();
            this.setInitalDates();
            this.loadRegister();
            //iExpense test = new iExpense();
            //MessageBox.Show(test.getLastExpenseID(1).ToString());
        }
        /* attempt to load ledger in a range */
        private void test() {
            DateTime end = DateTime.Now;
            DateTime start = DateTime.Now.AddDays(-30);
            //string[] row = new string[] { "2014-08-08", "Test", (12.12).ToString(), (1910.15).ToString() };
            //this.dgvLedger.Rows.Add(row);
        }
        #endregion

        #region EventHandlers
        /* event handlers */
        private void btnAccount_Click( object sender, EventArgs e ) {
            frmAddAccount newAccount = new frmAddAccount();
            newAccount.Show();
        }

        private void btnAddAccountCat_Click( object sender, EventArgs e ) {
            frmAddAccountCat newAC = new frmAddAccountCat();
            newAC.Show();
        }

        private void btnAddBudgetCat_Click( object sender, EventArgs e ) {
            frmAddBudgetCat newBC = new frmAddBudgetCat();
            newBC.Show();
        }

        private void btnAddExpense_Click( object sender, EventArgs e ) {
            int selectedAccount = this.db.getAccountID(this.getSelectedAccount());
            frmEnterExpense newEX = new frmEnterExpense(selectedAccount);
            newEX.newEntry += new EventHandler(OnNewEntry);
            newEX.Show();
        }
        /**
         * Handles event raised by a child form to refresh the ledger
         */
        private void OnNewEntry( object sender, EventArgs e ) {
            this.loadRegister();
        }
        private void btnViewExps_Click( object sender, EventArgs e ) {
            frmViewExpenses view = new frmViewExpenses();
            view.Show();
        }

        private void frmLanding_Load( object sender, EventArgs e ) {
            //loadRegister();
        }

        private void btnTesting_Click( object sender, EventArgs e ) {
            loadRegister();
        }
        private void dtpStart_ValueChanged( object sender, EventArgs e ) {
            /* ensure the start date is before the end date */
            if (this.dtpStart.Value > this.dtpEnd.Value) {
                this.dtpStart.Value = this.dtpEnd.Value.AddDays(-1);
            } else {
                this.timeframeStart = this.dtpStart.Value;
            }
            loadRegister();
        }
        private void dtpEnd_ValueChanged( object sender, EventArgs e ) {
            /* ensure the end date is after the start date */
            if (this.dtpEnd.Value < this.dtpStart.Value) {
                this.dtpEnd.Value = this.dtpStart.Value.AddDays(1);
            } else {
                this.timeframeEnd = this.dtpEnd.Value;
            }
            loadRegister();
        }
        private void dgvLedger_CellContentDoubleClick( object sender, DataGridViewCellEventArgs e ) {
            //MessageBox.Show(e.ColumnIndex.ToString() + " " + e.RowIndex.ToString());
            // do something with caught information
        }

        private void cmbAccount_SelectedIndexChanged( object sender, EventArgs e ) {
            loadRegister();
        }
        #endregion
        
        #region Methods
        private void loadRegister() {
            try {
                this.dgvLedger.DataSource = null;
            } catch {
                // do nothing
            }
            if (this.timeframeStart == default(DateTime) && this.timeframeEnd == default(DateTime)) {
                this.timeframeStart = DateTime.Now.AddDays(-365);
                this.timeframeEnd = DateTime.Now.AddDays(+30);
            }
            if (this.cmbAccount.Items.Count > 0) {
                account reqAccount = new account();
                // TODO : Tie the get account to a drop down or another control
                reqAccount = this.db.getAccount((this.db.getAccountID(this.getSelectedAccount())));
                List<accountRegister> registers = new List<accountRegister>();
                registers = this.db.getRegisterInTimeFrame(this.timeframeStart, this.timeframeEnd, reqAccount);


                /* Bind the list of account registers to the datagridview for proper display */
                this.dgvLedger.DataSource = registers;
            }
        }
        /* inital dates for the register to display */
        private void setInitalDates() {
            this.timeframeStart = DateTime.Now.AddDays(-30);
            this.timeframeEnd = DateTime.Now.AddDays(+1);

            this.dtpStart.Value = this.timeframeStart;
            this.dtpEnd.Value = this.timeframeEnd;
        }
        /* Fills drop down combo box with account names */
        private void loadAccountsCombo() {
            this.cmbAccount.Enabled = false;
            List<string> accounts = new List<string>();
            accounts = this.db.getAccounts();
            foreach (string act in accounts) {
                this.cmbAccount.Items.Add(act);
            }
            if (this.cmbAccount.Items.Count > 0) {
                this.cmbAccount.SelectedIndex = 0; // set initial to first account
                this.cmbAccount.Enabled = true;
            }
        }
        private string getSelectedAccount() {
            return this.cmbAccount.SelectedItem.ToString();
        }
        #endregion
    }
}
