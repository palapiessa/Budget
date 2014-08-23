using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace budgetApp {
    class budgetCat {
        // CREATE TABLE IF NOT EXISTS budget_Category (id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, name TEXT, postedDate TEXT)
        public string name = "";
        public int id = -1;
        public DateTime postedDate;
        private string p;

        public budgetCat() {
            this.name = "";
            this.id = -1;
            this.postedDate = DateTime.Now;
        }

        public budgetCat( string name ) {
            this.name = name;
            this.postedDate = DateTime.Now;
        }

        public budgetCat( string name, int id ) {
            this.name = name;
            this.id = id;
            this.postedDate = DateTime.Now;
        }

        public budgetCat( string name, int id, DateTime postedDate ) {
            this.name = name;
            this.id = id;
            this.postedDate = postedDate;
        }
    }
}
