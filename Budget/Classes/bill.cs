using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace budgetApp {
    class bill {
        // CREATE TABLE IF NOT EXISTS bills (id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, name TEXT, budgetCat INTEGER, dueDate TEXT, postedDate TEXT, userName TEXT, password TEXT, timeframe INT, estimatedAmount REAL)
        public int id = -1;
        public string name = "";
        public int budgetCat = -1;
        public DateTime dueDate;
        public DateTime postedDate;
        public string userName = "";
        public string password = "";
        public int timeframe = -1;
        public double estAmount = 0.00;

        public bill() {
            this.id = -1;
            this.name = "";
            this.budgetCat = -1;
            this.dueDate = DateTime.Now;
            this.postedDate = DateTime.Now;
            this.userName = "";
            this.password = "";
            this.timeframe = -1;
            this.estAmount = 0.00;
        }

        public bill( int id, string name, int budgetCat, DateTime dueDate, DateTime postedDate, string userName, string password, int timeframe, double estAmount ) {
            this.id = id;
            this.name = name;
            this.budgetCat = budgetCat;
            this.dueDate = dueDate;
            this.postedDate = postedDate;
            this.userName = userName;
            this.password = password;
            this.timeframe = timeframe;
            this.estAmount = estAmount;
        }
        public bill( int id, string name, int budgetCat, DateTime dueDate, string userName, string password, int timeframe, double estAmount ) {
            this.id = id;
            this.name = name;
            this.budgetCat = budgetCat;
            this.dueDate = dueDate;
            this.postedDate = DateTime.Now;
            this.userName = userName;
            this.password = password;
            this.timeframe = timeframe;
            this.estAmount = estAmount;
        }
    }
}
