using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace budgetApp {
    class queryResponse {
        private string _columnName;
        private publicEnums.columnType _columnType;
        
        public string columnName {
            get { return _columnName; }
            set { _columnName = value; }
        }

        public publicEnums.columnType columnTypeName {
            get { return _columnType; }
            set { _columnType = value; }
        }
    }
}
