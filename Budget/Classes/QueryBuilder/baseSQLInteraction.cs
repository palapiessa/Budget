using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Windows.Forms;

namespace budgetApp {
    /* the most basic interface class, other interfaces will inherit from this one */
    class baseInterface {
        #region Parameters
        protected publicEnums.classType className = publicEnums.classType.none;
        protected queryBuilder query = new queryBuilder();
        protected List<parameter> inputs = new List<parameter>();
        protected List<responseRow> rows = null; // set when multiple rows are expected as a result
        protected responseRow row = null; // set when only one row is expected as a result
        protected SQLiteDataReader response = null;//new SQLiteDataReader();
        #endregion

        #region Database Interactions
        /// <summary>
        /// Executes a given query, dynamically creating the number of columns and number of rows, adding to this.rows.
        /// this.rows can be interfaced with at a higher level to create various objects.
        /// </summary>
        /// <param name="queryName"></param>
        /// <returns></returns>
        protected bool executeGetMultiple(string queryName) {
            bool success = true;
            this.rows = new List<responseRow>();
            List<responseColumn> cols = new List<responseColumn>();
            
            this.query.getQueryDetails(queryName);
            this.query.addParameters(this.inputs);
            using (this.query.sqlConn) {
                this.query.openConn();
                using (this.query.command) {
                    this.response = this.query.command.ExecuteReader();
                    try {
                        while (this.response.Read()) {
                            for (int i = 0; i < this.response.FieldCount; i++) {
                                cols.Add(new responseColumn(this.response.GetName(i), this.response[i].ToString()));
                                //string temp = this.response.GetName(i);
                            }
                            this.rows.Add(new responseRow(cols));
                            cols.Clear();
                        }
                    } catch (SQLiteException e) {
                        MessageBox.Show("An error occured reading from the database.\n\n" + e.ToString());
                        success = false;
                    } finally {
                        /* deconstruct */
                        this.query.closeConn();
                        this.inputs.Clear();
                    }
                }

            }
            return success;
        }
        /// <summary>
        /// Executes given query, setting only this.row, as only a single result is expected back.
        /// </summary>
        /// <param name="queryName"></param>
        /// <returns></returns>
        protected bool executeGetSingle( string queryName ) {
            bool success = true;
            this.row = new responseRow();
            List<responseColumn> cols = new List<responseColumn>();

            this.query.getQueryDetails(queryName);
            this.query.addParameters(this.inputs);

            using (this.query.sqlConn) {
                this.query.openConn();
                using (this.query.command) {
                    this.response = this.query.command.ExecuteReader();
                    try {
                        if (this.response.HasRows) {
                            for (int i = 0; i < this.response.FieldCount; i++) {
                                cols.Add(new responseColumn(this.response.GetName(i), this.response[i].ToString()));
                            }
                        }
                        /* Add the columns to the row object */
                        this.row = new responseRow(cols);
                    } catch (SQLiteException e) {
                        MessageBox.Show("Error in reading from database." + e.ToString());
                        success = false;
                    } finally {
                        this.query.closeConn();
                        this.inputs.Clear();
                    }
                }
            }
            return success;
        }
        /// <summary>
        /// Used to execute a database operation that is not returning rows (i.e. INSERT, DELETE, UPDATE)
        /// </summary>
        /// <param name="queryName"></param>
        /// <returns>true upon success</returns>
        protected bool executeNonQuery( string queryName ) {
            bool success = true;
            this.query.getQueryDetails(queryName);
            this.query.addParameters(this.inputs);
            using (this.query.sqlConn) {
                this.query.openConn();
                try {
                    this.query.command.ExecuteNonQuery();
                    success = true;
                } catch (SQLiteException e) {
                    MessageBox.Show("An error occured writing to the database.\n\n" + e.ToString());
                    success = false;
                } finally {
                    this.inputs.Clear();
                    this.query.closeConn();
                }
            }

            return success;
        }
        #endregion

        #region Query Names
        /// <summary>
        /// Returns the name of the query responsible for pulling information from the database by the id of the object.
        /// </summary>
        /// <returns>String that contains query name</returns>
        protected string getByIDQuery() {
            switch (this.className) {
                case publicEnums.classType.none:
                    return "error";
                case publicEnums.classType.account:
                    return "getAccountByID";
                case publicEnums.classType.accountCategory:
                    return "getAccountCategoryByID";
                case publicEnums.classType.accountRegister:
                    return "getAccountRegisterByID";
                case publicEnums.classType.bill:
                    return "getBillByID";
                case publicEnums.classType.budget:
                    return "getBudgetByID";
                case publicEnums.classType.budgetCategory:
                    return "getBugdetCategoryByID";
                case publicEnums.classType.income:
                    return "getIncomeByID";
                case publicEnums.classType.ledger:
                    return "getLedgerByID";
            }
            return "error";
        }
        /// <summary>
        /// Returns the name of the query responsible for pulling information from the database via the name of the class.
        /// </summary>
        /// <param name="returnList">Determines whether one response or a list of responses is to be expected</param>
        /// <returns name="queryName">String that contains the query name for getting information from the database based on the name passed to it</returns>
        protected string getByNameQuery( bool returnList = false ) {
            string queryName = "error";
            switch (this.className) {
                case publicEnums.classType.none:
                    queryName = "error";
                    break;
                case publicEnums.classType.account:
                    queryName = "getAccountByID";
                    break;
                case publicEnums.classType.accountCategory:
                    queryName = "getAccountCategoryByID";
                    break;
                case publicEnums.classType.accountRegister:
                    queryName = "getAccountRegisterByID";
                    break;
                case publicEnums.classType.bill:
                    queryName = "getBillByID";
                    break;
                case publicEnums.classType.budget:
                    queryName = "getBudgetByID";
                    break;
                case publicEnums.classType.budgetCategory:
                    queryName = "getBugdetCategoryByID";
                    break;
                case publicEnums.classType.expense:
                    queryName = "getExpenseByID";
                    break;
                case publicEnums.classType.income:
                    queryName = "getIncomeByID";
                    break;
                case publicEnums.classType.ledger:
                    queryName = "getLedgerByID";
                    break;
            }
            // different queries for one object vs all of them, append All to make sure a list is going to be returned
            if (returnList) { queryName = queryName + "All"; }
            return queryName;
        }
        protected string getByDateRange() {
            switch (this.className) {
                case publicEnums.classType.none:
                    return "error";
                case publicEnums.classType.expense:
                    return "getExpenseDateRange";
            }
            return "error";
        }
        protected string getLastID() {
            switch (this.className) {
                case publicEnums.classType.expense:
                    return "getLastExpenseID";
            }
            return "error";
        }
        protected string insertQuery() {
            switch (this.className) {
                case publicEnums.classType.expense:
                    return "insertExpense";
                case publicEnums.classType.ledger:
                    return "insertLedger";
            }
            return "error";
        }

        protected string updateQuery() {
            switch (this.className) {
                case publicEnums.classType.ledger:
                    return "updateLedger";
            }
            return "error";
        }
        #endregion
    }
}
