using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace budgetApp {
    class account {
        // CREATE TABLE IF NOT EXISTS accounts (id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, name TEXT, balance REAL, interest REAL, primaryCat INTEGER, postedDate TEXT, userName TEXT)
        public string name { get; set; }
        public int id { get; set; }
        public int primaryCategory { get; set; }
        public double interest { get; set; }
        public double balance { get; set; }
        public string userName { get; set; }
        public DateTime postedDate { get; set; }

        public account() {
            this.name = "";
            this.primaryCategory = -1;
            this.interest = 0.00;
            this.balance = 0.00;
            this.userName = "";
            /* TODO */
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

        public account( responseRow row ) {
            this.id = Convert.ToInt32(row.getColumnValue("id"));
            this.name = row.getColumnValue("name");
            this.postedDate = Convert.ToDateTime(row.getColumnValue("postedDate"));
            this.primaryCategory = Convert.ToInt32(row.getColumnValue("primaryCat"));
            this.interest = Convert.ToDouble(row.getColumnValue("interest"));
            this.balance = Convert.ToDouble(row.getColumnValue("balance"));
            this.userName = row.getColumnValue("userName");
        }

        /* add the account to the database */
        public bool add(sqliteInterface db) {
            if (!db.addAccount(this)) {
                /* alert error */
                return false;
            }
            try {
                /* TODO - FIX postedDate */
                ledger newledger = new ledger(0, this.balance, -1, -1, db.getAccountID(this.name), Convert.ToDateTime("2014-01-01 00:00:01"));
                if (!db.addLedger(newledger)) {
                    return false;
                }
            } catch (Exception e) {
                MessageBox.Show("An error occured.\n" + e.ToString());
                return false;
            }
            return true;
        }
    }
}
