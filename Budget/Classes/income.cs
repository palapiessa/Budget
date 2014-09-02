using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace budgetApp {
    class income {
        // CREATE TABLE IF NOT EXISTS income (id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, name TEXT, accountCat INTEGER, amount REAL, postedDate TEXT)
        public int id { get; set; }
        public string name { get; set; }
        public int accountCat { get; set; }
        public double amount { get; set; }
        public DateTime postedDate { get; set; }

        public income() {
            this.id = -1;
            this.name = "";
            this.accountCat = -1;
            this.amount = 0.00;
            this.postedDate = DateTime.Now;
        }
        public income( int id, string name, int accountCat, double amount, DateTime postedDate ) {
            this.id = id;
            this.name = name;
            this.accountCat = accountCat;
            this.amount = amount;
            this.postedDate = postedDate;
        }
        public income( int id, string name, int accountCat, double amount ) {
            this.id = id;
            this.name = name;
            this.accountCat = accountCat;
            this.amount = amount;
            this.postedDate = DateTime.Now;
        }
    }
}
