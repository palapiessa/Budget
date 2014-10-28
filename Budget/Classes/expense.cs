using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;

namespace budgetApp {
    class expense {
        #region Initialization
        private string _payTo;
        private int _category;
        private int _account;
        private int _id;
        private string _notes;
        private DateTime _postedDate;
        private DateTime _expenseDate;
        private double _amount;
        public string payTo { get { return _payTo;} set { _payTo = value; } }
        public int category { get { return _category; } set { _category = value; } }
        public int account { get { return _account; } set { _account = value; } }
        public int id { get { return _id; } set { _id = value; } }
        public string notes { get { return _notes; } set { _notes = value; } }
        public DateTime postedDate { get { return _postedDate; } set { _postedDate = value; } }
        public DateTime expenseDate { get { return _expenseDate; } set { _expenseDate = value; } }
        public double amount { get { return _amount; } set { _amount = value; } }
        #endregion

        #region Constructors
        public expense() {
            this.payTo = "";
            this.category = -1;
            this.account = -1;
            this.postedDate = DateTime.Now;
            this.id = -1;
            this.notes = "";
            this.amount = 0.00;
            this.expenseDate = DateTime.Now;
        }
        public expense( string payTo, int category, int account, string notes, double amount, DateTime expenseDate ) {
            this.payTo = payTo;
            this.category = category;
            this.account = account;
            this.postedDate = DateTime.Now;
            this.expenseDate = expenseDate;
            this.id = -1;
            this.notes = notes;
            this.amount = amount;
        }

        public expense( string payTo, int category, int account, string notes, double amount, DateTime expenseDate, DateTime postedDate ) {
            this.payTo = payTo;
            this.category = category;
            this.account = account;
            this.postedDate = postedDate;
            this.expenseDate = expenseDate;
            this.id = -1;
            this.notes = notes;
            this.amount = amount;
        }

        public expense( SQLiteDataReader response ) {
            this.id = Convert.ToInt32(response["id"]); 
            this.payTo = response["payTo"].ToString();
            this.amount = Convert.ToDouble(response["amount"]);
            this.category = Convert.ToInt32(response["budgetCat"]);
            this.account = Convert.ToInt32(response["payingAccount"]);
            this.notes = response["notes"].ToString();
            this.postedDate = Convert.ToDateTime(response["postedDate"]);
            this.expenseDate = Convert.ToDateTime(response["expenseDate"]);
        }
        #endregion

        /*
         * TODO : Use the interface to interact, rather than direct access to sqliteinterface
         * Where to put this? Should every instance of expense have an interface? No...
         * Give the entry form access to the interface or create a controller that handles it. Not a fan of this one..
         */
        #region Methods
        public bool add(sqliteInterface db) {
            /* sqlite code to add expense to the database */
            /* need to pull the catid and account id to make sure those are the ones that get posted */
            if (!db.addExpense(this)) {
                return false;
            }

            /* TODO : FROM HERE CODE NEEDS TO BE CONVERTED TO USE THE NEW INTERFACE */
            this.id = db.getLastExpenseID(this.account);
            ledger lastLed = db.getLastLedgerForAccount(this.account);
            if (lastLed.accountID == -1) {
                return false;
            }
            if (lastLed.postedDate > this.expenseDate) {
                this.id = db.getLastExpenseID(this.account);
                //MessageBox.Show("Expense date before last posted. Problem time...");
                if (!db.updateLedgersBeforeTimeFrame(this)) {
                    MessageBox.Show("An error occurred updating prior records.");
                    return false;
                }
            } else {
                ledger newLed = new ledger(lastLed.balanceAfter, (lastLed.balanceAfter + this.amount), this.id, -1, this.account, this.expenseDate);
                if (!db.addLedger(newLed)) {
                    return false;
                }
            }
            return true;
        }
        #endregion
    }
}
