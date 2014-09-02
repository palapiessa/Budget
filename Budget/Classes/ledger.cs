using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace budgetApp {
    class ledger {
        // CREATE TABLE IF NOT EXISTS ledger (id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, balanceBefore REAL, balanceAfter REAL, expenseID INTEGER, incomeID INTEGER, accountID INTEGER, postedDate TEXT)
        public int id { get; set; }
        public double balanceBefore { get; set; }
        public double balanceAfter { get; set; }
        public int expenseID { get; set; }
        public int incomeID { get; set; }
        public int accountID { get; set; }
        public DateTime postedDate { get; set; }

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
    }
}
