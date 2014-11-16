using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace budgetApp {
    class bill {
        // CREATE TABLE IF NOT EXISTS bills (id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, name TEXT, budgetCat INTEGER, dueDate TEXT, postedDate TEXT, userName TEXT, password TEXT, timeframe INT, estimatedAmount REAL)
        #region Initialization
        private int _id;
        private string _name;
        private int _budgetCat;
        private DateTime _dueDate;
        private DateTime _postedDate;
        private string _userName;
        private string _password;
        private int _timeframe;
        private double _estAmount;

        public int id { get {return _id; } set { _id = value;} }
        public string name { get {return _name; } set { _name = value;} }
        public int budgetCat { get {return _budgetCat; } set { _budgetCat = value;} }
        public DateTime dueDate { get {return _dueDate; } set { _dueDate = value;} }
        public DateTime postedDate { get {return _postedDate; } set { _postedDate = value;} }
        public string userName { get {return _userName; } set { _userName = value;} }
        public string password { get {return _password; } set { _password = value;} }
        public int timeframe { get {return _timeframe; } set { _timeframe = value;} }
        public double estAmount { get {return _estAmount; } set { _estAmount = value;} }
        #endregion

        #region Constructors
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

        public bill ( responseRow row ) {
            this._id = Convert.ToInt32(row.getColumnValue("id"));
            this._name = row.getColumnValue("name");
            this._budgetCat = Convert.ToInt32(row.getColumnValue("budgetCat"));
            this._dueDate = Convert.ToDateTime(row.getColumnValue("dueDate"));
            this._postedDate = Convert.ToDateTime(row.getColumnValue("postedDate"));
            this._userName = row.getColumnValue("userName");
            this._password = row.getColumnValue("password");
            this._timeframe = Convert.ToInt32(row.getColumnValue("timeFrame"));
            this._estAmount = Convert.ToDouble(row.getColumnValue("estAmount"));
        }
        #endregion
    }
}
