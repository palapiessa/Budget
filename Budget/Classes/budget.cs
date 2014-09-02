using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace budgetApp {
    class budget {
        // CREATE TABLE IF NOT EXISTS budget (id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, name TEXT, budgetCat INTEGER, amount REAL, postedDate TEXT)
        public int id { get; set; }
        public string name { get; set; }
        public int budgetCat { get; set; }
        public double amount { get; set; }
        public DateTime postedDate { get; set; }

        public budget() {
            this.id = -1;
            this.name = "";
            this.budgetCat = -1;
            this.amount = 0.00;
            this.postedDate = DateTime.Now;
        }

        public budget( int id, string name, int budgetCat, double amount, DateTime postedDate ) {
            this.id = id;
            this.name = name;
            this.budgetCat = budgetCat;
            this.amount = amount;
            this.postedDate = postedDate;
        }

        public budget( int id, string name, int budgetCat, double amount ) {
            this.id = id;
            this.name = name;
            this.budgetCat = budgetCat;
            this.amount = amount;
            this.postedDate = DateTime.Now;
        }
    }
}
