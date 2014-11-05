using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;
using budgetApp.Classes.Interfaces;

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
        //private iExpense db = new iExpense();
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

        public expense( responseRow response ) {
            this.id = Convert.ToInt32(response.getColumnValue("id"));
            this.payTo = response.getColumnValue("payTo");
            this.amount = Convert.ToDouble(response.getColumnValue("amount"));
            this.category = Convert.ToInt32(response.getColumnValue("budgetCat"));
            this.account = Convert.ToInt32(response.getColumnValue("payingAccount"));
            this.notes = response.getColumnValue("notes");
            this.postedDate = Convert.ToDateTime(response.getColumnValue("postedDate"));
            this.expenseDate = Convert.ToDateTime(response.getColumnValue("expenseDate"));
        }

        #endregion

        #region Methods
        /// <summary>
        /// Adds expense to the database. Uses the controller which contains generic interface objects as the database interactions.
        /// </summary>
        /// <returns>true / false depending on whether all actions successfully completed or not</returns>
        public bool add() {
            /* add the expense */
            if (!controller.iE.insert(this)) { return false; }
            /* assign expense id */
            this.id = controller.iE.getLastID(this.account);
            /* test if ledgers have to be updated */
            ledger lastLed = controller.iL.getLastLedgerByAccount(this.account);
            if (lastLed.accountID == -1) { return false; }
            /* check if new expense is before prior expenses and update ledger accordingly */
            if (lastLed.postedDate > this.expenseDate) {
                this.id = this.id = controller.iE.getLastID(this.account);
                if (!controller.iL.updateLedersBeforeTimeFrame(this)) {
                    MessageBox.Show("An error occurred updating prior records.");
                    return false;
                }
            } else {
                ledger newLed = new ledger(lastLed.balanceAfter, (lastLed.balanceAfter + this.amount), this.id, -1, this.account, this.expenseDate);
                if (!controller.iL.insert(newLed)) {
                    return false;
                }
            }
            return true;
        }
        #endregion
    }
}
