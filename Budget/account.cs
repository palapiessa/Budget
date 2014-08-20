using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace budget {
    class account {
        public string name = "";
        public int id = -1;
        public int primaryCategory = -1;
        public double interest = 0.00;
        public double balance = 0.00;
        public string userName = "";
        public DateTime postedDate = DateTime.MinValue;

        public account() {
            this.name = "";
            this.primaryCategory = -1;
            this.interest = 0.00;
            this.balance = 0.00;
            this.userName = "";
            this.postedDate = DateTime.Now;
            this.id = -1;
        }
        public account( string name, int primaryCat, double interest, double balance, string userName ) {
            this.postedDate = DateTime.Now;
            this.primaryCategory = primaryCat;
            this.name = name;
            this.interest = interest;
            this.balance = balance;
            this.userName = userName;
        }

        /* add the account to the database */
        public bool add(sqliteInterface db) {
            if (!db.addAccount(this)) {
                /* alert error */
                return false;
            }
            return true;
        }
    }
}
