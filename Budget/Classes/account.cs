using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using budgetApp.Classes.Interfaces;

namespace budgetApp {
    class account {
        #region Initialization
        private string _name;
        private int _id;
        private int _primaryCategory;
        private double _interest;
        private double _balance;
        private string _userName;
        private DateTime _postedDate; public string name { get { return _name; } set { _name = value; } }
        public int id { get { return _id; } set { _id = value; } }
        public int primaryCategory { get { return _primaryCategory; } set { _primaryCategory = value; } }
        public double interest { get { return _interest; } set { _interest = value; } }
        public double balance { get { return _balance; } set { _balance = value; } }
        public string userName { get { return _userName; } set { _userName = value; } }
        public DateTime postedDate { get { return _postedDate; } set { _postedDate = value; } }
        #endregion

        #region Constructors
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
        #endregion

        #region Methods
        /* add the account to the database */
        public bool add() {
            if (!controller.iA.insert(this)) { return false; }

            try {
                /* TODO - FIX postedDate */
                ledger newledger = new ledger(0, this.balance, -1, -1, controller.iA.getID(this.name), Convert.ToDateTime("2014-01-01 00:00:01"));
                if (!controller.iL.insert(newledger)) { return false; }
            } catch (Exception e) {
                MessageBox.Show("An error occured.\n" + e.ToString());
                return false;
            }
            return true;
        }
        #endregion
    }
}
