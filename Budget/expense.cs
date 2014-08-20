using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace budget {
    class expense {
        public string payTo = "";
        public int category = -1;
        public int account = -1;
        public int id = -1;
        public string notes = "";
        public DateTime postedDate;
        public DateTime expenseDate;
        public double amount = 0.00;

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

        public expense( string payTo, int category, int account, string notes, double amount, DateTime postedDate, DateTime expenseDate ) {
            this.payTo = payTo;
            this.category = category;
            this.account = account;
            this.postedDate = postedDate;
            this.expenseDate = expenseDate;
            this.id = -1;
            this.notes = notes;
            this.amount = amount;
        }

        public bool add(sqliteInterface db) {
            /* sqlite code to add expense to the database */
            /* need to pull the catid and account id to make sure those are the ones that get posted */
            if (!db.addExpense(this)) {
                return false;
            }
            return true;
        }
    }
}
