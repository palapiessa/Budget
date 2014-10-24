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

        public frmLanding() {
            InitializeComponent();
            this.db.createDatabase();
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
            frmEnterExpense newEX = new frmEnterExpense();
            newEX.newEntry += new EventHandler(OnNewEntry);
            newEX.Show();
        }
        private void OnNewEntry( object sender, EventArgs e ) {
            this.loadRegister();
        }
        private void btnViewExps_Click( object sender, EventArgs e ) {
            frmViewExpenses view = new frmViewExpenses();
            view.Show();
        }

        private void frmLanding_Load( object sender, EventArgs e ) {
            loadRegister();
        }

        private void btnTesting_Click( object sender, EventArgs e ) {
            this.dgvLedger.DataSource = null;
            loadRegister();

            /*DateTime test = DateTime.MaxValue;
            test = this.db.getLedgerDate(10);
            test = this.db.getLedgerDate(10, false);
            MessageBox.Show(test.ToString());*/
            //ledger l = new ledger(0.00, 1000.00, 72, -1, 10, Convert.ToDateTime("2014-06-01 00:00:59.0001"));
            //expense test = this.db.getExpense(18);
            /*test.expenseDate = Convert.ToDateTime("2014-08-01 11:30:10.00001");
            test.account = 10;
            test.amount = 500.00;*/
            //this.db.updateLedgersBeforeTimeFrame(test);
        }
        #endregion
        
        #region methods
        private void loadRegister( DateTime start = default(DateTime), DateTime end = default(DateTime)) {
            try {
                this.dgvLedger.DataSource = null;
            } catch {
                // do nothing
            }
            if (start == default(DateTime) && end == default(DateTime)) {
                start = DateTime.Now.AddDays(-365);
                end = DateTime.Now.AddDays(+30);
            }
            account reqAccount = new account();
            // TODO : Tie the get account to a drop down or another control
            reqAccount = this.db.getAccount((this.db.getAccountID("RCB")));
            List<accountRegister> registers = new List<accountRegister>();
            registers = this.db.getRegisterInTimeFrame(start, end, reqAccount);


            /* Bind the list of account registers to the datagridview for proper display */
            this.dgvLedger.DataSource = registers;
        }
        #endregion
    }
}
