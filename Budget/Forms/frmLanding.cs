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
        private sqliteInterface db = new sqliteInterface();
        public frmLanding() {
            InitializeComponent();
            this.db.createDatabase();
            test();
        }
        
        /* attempt to load ledger in a range */
        private void test() {
            string[] row = new string[] { "2014-08-08", "Test", (12.12).ToString(), (1910.15).ToString() };
            this.dgvLedger.Rows.Add(row);
            /*row.Cells[0].Value = "2014-08-22";
            row.Cells[1].Value = "Test";
            row.Cells[2].Value = 12.12;
            row.Cells[3].Value = 1910.15;
            dgvLedger.Rows.Add(row);*/
        }
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
            newEX.Show();
        }

        private void btnViewExps_Click( object sender, EventArgs e ) {
            frmViewExpenses view = new frmViewExpenses();
            view.Show();
        }

        private void dataGridView1_CellContentClick( object sender, DataGridViewCellEventArgs e ) {

        }

        private void btnTesting_Click( object sender, EventArgs e ) {
            /*DateTime test = DateTime.MaxValue;
            test = this.db.getLedgerDate(10);
            test = this.db.getLedgerDate(10, false);
            MessageBox.Show(test.ToString());*/
            //ledger l = new ledger(0.00, 1000.00, 72, -1, 10, Convert.ToDateTime("2014-06-01 00:00:59.0001"));
            expense test = this.db.getExpense(18);
            
            /*test.expenseDate = Convert.ToDateTime("2014-08-01 11:30:10.00001");
            test.account = 10;
            test.amount = 500.00;*/
            this.db.updateLedgersBeforeTimeFrame(test);
        }
    }
}
