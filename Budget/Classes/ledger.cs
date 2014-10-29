using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace budgetApp {
    class ledger {
        // CREATE TABLE IF NOT EXISTS ledger (id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, balanceBefore REAL, balanceAfter REAL, expenseID INTEGER, incomeID INTEGER, accountID INTEGER, postedDate TEXT)
        #region Initialization
        private int _id;
        private double _balanceBefore;
        private double _balanceAfter;
        private int _expenseID;
        private int _incomeID;
        private int _accountID;
        private DateTime _postedDate;
        public int id { get { return _id; } set { _id = value; } }
        public double balanceBefore { get { return _balanceBefore; } set { _balanceBefore = value; } }
        public double balanceAfter { get { return _balanceAfter; } set { _balanceAfter = value; } }
        public int expenseID { get { return _expenseID; } set { _expenseID = value; } }
        public int incomeID { get { return _incomeID; } set { _incomeID = value; } }
        public int accountID { get { return _accountID; } set { _accountID = value; } }
        public DateTime postedDate { get { return _postedDate; } set { _postedDate = value; } }
        #endregion

        #region Constructors
        public ledger() {
            this.id = -1;
            this.balanceBefore = 0.00;
            this.balanceAfter = 0.00;
            this.expenseID = -1;
            this.incomeID = -1;
            this.accountID = -1;
            this.postedDate = DateTime.Now;
        }
        public ledger( int id, double balanceBefore, double balanceAfter, int expenseID, int incomeID, int accountID, DateTime postedDate ) {
            this.id = id;
            this.balanceBefore = balanceBefore;
            this.balanceAfter = balanceAfter;
            this.expenseID = expenseID;
            this.incomeID = incomeID;
            this.accountID = accountID;
            this.postedDate = postedDate;
        }
        public ledger( double balanceBefore, double balanceAfter, int expenseID, int incomeID, int accountID, DateTime postedDate ) {
            this.id = -1;
            this.balanceBefore = balanceBefore;
            this.balanceAfter = balanceAfter;
            this.expenseID = expenseID;
            this.incomeID = incomeID;
            this.accountID = accountID;
            this.postedDate = postedDate;
        }
        public ledger( double balanceBefore, double balanceAfter, int expenseID, int incomeID, int accountID ) {
            this.id = -1;
            this.balanceBefore = balanceBefore;
            this.balanceAfter = balanceAfter;
            this.expenseID = expenseID;
            this.incomeID = incomeID;
            this.accountID = accountID;
            this.postedDate = DateTime.Now;
        }
        public ledger( int id, double balanceBefore, double balanceAfter, int expenseID, int incomeID, int accountID ) {
            this.id = id;
            this.balanceBefore = balanceBefore;
            this.balanceAfter = balanceAfter;
            this.expenseID = expenseID;
            this.incomeID = incomeID;
            this.accountID = accountID;
            this.postedDate = DateTime.Now;
        }

        public ledger( SQLiteDataReader response ) {
            this.id = Convert.ToInt32(response["id"]);
            this.balanceBefore = Convert.ToDouble(response["balanceBefore"]);
            this.balanceAfter = Convert.ToDouble(response["balanceAfter"]);
            this.incomeID = Convert.ToInt32(response["incomeID"]);
            this.expenseID = Convert.ToInt32(response["expenseID"]);
            this.accountID = Convert.ToInt32(response["accountID"]);
            this.postedDate = Convert.ToDateTime(response["postedDate"]);
        }

        public ledger( responseRow response ) {
            this.id = Convert.ToInt32(response.getColumnValue("id"));
            this.balanceBefore = Convert.ToDouble(response.getColumnValue("balanceBefore"));
            this.balanceAfter = Convert.ToDouble(response.getColumnValue("balanceAfter"));
            this.incomeID = Convert.ToInt32(response.getColumnValue("incomeID"));
            this.expenseID = Convert.ToInt32(response.getColumnValue("expenseID"));
            this.accountID = Convert.ToInt32(response.getColumnValue("accountID"));
            this.postedDate = Convert.ToDateTime(response.getColumnValue("postedDate"));
        }
        #endregion
    }
}
