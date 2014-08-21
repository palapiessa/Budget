using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace budgetapp {
    class accountCat {
        // CREATE TABLE IF NOT EXISTS account_Category (id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, name TEXT, postedDate TEXT)
        public int id = -1;
        public string name = "";
        public DateTime postedDate;

        public accountCat() {
            this.id = -1;
            this.name = "";
            this.postedDate = DateTime.Now;
        }

        public accountCat( int id, string name, DateTime postedDate ) {
            this.id = id;
            this.name = name;
            this.postedDate = postedDate;
        }

        public accountCat( int id, string name ) {
            this.id = id;
            this.name = name;
            this.postedDate = DateTime.Now;
        }
    }
}
