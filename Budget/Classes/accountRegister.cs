﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace budgetApp {
    class accountRegister {
        public string date { get; set; }
        public string receivee { get; set; }
        public string amount { get; set; }
        public string balance { get; set; }

        public accountRegister() {
            this.date = DateTime.Now.Date.ToString("d");
            this.receivee = "NULL";
            this.amount = "0.00";
            this.balance = "0.00";
        }

        public accountRegister( string date, string receivee, string amount, string balance ) {
            this.date = date;
            this.receivee = receivee;
            this.amount = amount;
            this.balance = balance;
        }
    }
}
