using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace budgetApp {
    /// <summary>
    /// Contains a string representation of a single row from a database query. Columns can be added dynamically, depending on the number of columns being return from the query.
    /// </summary>
    class responseRow {
        #region Properties
        private List<responseColumn> columns = new List<responseColumn>();
        #endregion

        #region Constructors
        public responseRow() {
            // nothing for now
        }
        public responseRow(List<responseColumn> cols) {
            foreach (responseColumn col in cols) {
                this.columns.Add(col);
            }
        }
        #endregion

        #region Methods
        /// <summary>
        /// Adds a column to the row
        /// </summary>
        /// <param name="colName"></param>
        /// <param name="colValue"></param>
        public void addColumn( string colName, string colValue ) {
            this.columns.Add(new responseColumn(colName, colValue));
        }
        /// <summary>
        /// Adds column to the row
        /// </summary>
        /// <param name="col"></param>
        public void addColumn(responseColumn col) {
            this.columns.Add(col);
        }
        /// <summary>
        /// Adds all columns in an existing row
        /// </summary>
        /// <param name="row"></param>
        public void addRow( List<responseColumn> row ) {
            foreach (responseColumn col in row) {
                this.columns.Add(col);
            }
        }
        /// <summary>
        /// Gets the integer index of a column name
        /// </summary>
        /// <param name="colName"></param>
        /// <returns>integer</returns>
        public int getIndexOfColumnName( string colName ) {
            for (int i = 0; i < this.columns.Count; i++) {
                if (colName == this.columns[i].columnName) {
                    return i;
                }
            }
            // did not find, catch the error on the calling procedure
            return -1;
        }
        /// <summary>
        /// Gets a column by index
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public responseColumn getColumn( int index ) {
            return this.columns[index];
        }
        /// <summary>
        /// Gets a column by its name
        /// </summary>
        /// <param name="colName"></param>
        /// <returns></returns>
        public responseColumn getColumn( string colName ) {
            foreach (responseColumn col in this.columns) {
                if (col.columnName == colName) {
                    return col;
                }
            }
            return null;
        }
        /// <summary>
        /// Gets value of column based on the inserted name
        /// </summary>
        /// <param name="colName"></param>
        /// <returns>string with the value of the column with the input column name</returns>
        public string getColumnValue( string colName ) {
            foreach (responseColumn col in this.columns) {
                if (col.columnName == colName) {
                    return col.columnValue;
                }
            }
            return string.Empty;
        }
        /// <summary>
        /// Returns the entire row (and all the columns in it)
        /// </summary>
        /// <returns></returns>
        public List<responseColumn> getRow() {
            return this.columns;
        }
        #endregion
    }
}
