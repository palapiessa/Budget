using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace budgetApp {
    class accountCat {
        #region Initialization
        private int _id;
        private string _name;
        private DateTime _postedDate;
        public int id { get { return _id; } set { _id = value ;} }
        public string name { get { return _name; } set { _name = value; } }
        public DateTime postedDate { get { return _postedDate; } set { _postedDate = value; } }
        #endregion

        #region Constructors
        public accountCat() {
            this.id = -1;
            this.name = "";
            this.postedDate = DateTime.Now;
        }
        public accountCat( string name ) {
            this.id = -1;
            this.name = name;
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

        public accountCat( responseRow row ) {
            this.id = Convert.ToInt32(row.getColumnValue("id"));
            this.name = row.getColumnValue("name");
            this.postedDate = Convert.ToDateTime(row.getColumnValue("postedDate"));
        }
        #endregion
    }
}
