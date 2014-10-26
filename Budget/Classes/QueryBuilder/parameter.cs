using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace budgetApp {
    class parameter {
        private string _paramName;
        private string _paramValue;

        public string paramName {
            get { return _paramName; }
            set { _paramName = value; }
        }

        public string paramValue {
            get { return _paramValue; }
            set { _paramValue = value; }
        }

        public parameter( string name, string value ) {
            this.paramName = name;
            this.paramValue = value;
        }
    }
}
