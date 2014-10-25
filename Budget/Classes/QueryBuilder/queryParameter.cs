using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace budgetApp {
    class queryParameter {
            private string _paramName;
            private string _dataType;

            public string paramName {
                get { return _paramName; }
                set { _paramName = value; }
            }

            public string dataType {
                get { return _dataType; }
                set { _dataType = value; }
            }
    }
}
