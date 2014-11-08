using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace budgetApp {
    class budgetCat {
        public string name { get; set; }
        public int id { get; set; }
        public DateTime postedDate { get; set; }

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
