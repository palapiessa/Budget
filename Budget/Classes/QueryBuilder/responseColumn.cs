using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace budgetApp {
    /// <summary>
    /// Basic column used in parsing generic queries. Probably not as memory efficient as the basic SQLiteDataReader object response, but allows more customized control
    /// including building dynamic queries, using one base interface for all queries and custom object creation and handling.
    /// </summary>
    class responseColumn {

        #region Parameters
        private string _columnName;
        private string _columnValue;//publicEnums.columnType _columnType;
        #endregion

        #region Getters/Setters
        public string columnName {
            get { return _columnName; }
            set { _columnName = value; }
        }

        public string columnValue {
            get { return _columnValue; }
            set { _columnValue = value; }
        }

        public responseColumn( string name, string value ) {
            this._columnName = name;
            this._columnValue = value;
        }
        #endregion
    }
}
