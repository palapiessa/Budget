using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SQLite;

namespace budgetApp {
    /* creates an interface to interact with the database, creating and returning expense objects, adding to the database, etc. */
    class iExpense : baseInterface {
        public iExpense() {
            this.className = publicEnums.classType.expense;
        }
        #region Database Interaction

        #region Selects
        /// <summary>
        /// Returns an expense from the database based on the passed in expense id
        /// </summary>
        /// <param name="expenseID"></param>
        /// <returns></returns>
        public expense getByID( int expenseID ) {
            expense temp = null;
            /* create parameter list */            
            parameter inp = new parameter("@ID", expenseID);
            //List<parameter> inputs = new List<parameter>();
            this.inputs.Add(inp);

            /* build the query */
            this.query.getQueryDetails(this.getByIDQuery());
            this.query.addParameters(this.inputs);
            /* process the query and build the expense object */
            using (this.query.sqlConn) {
                this.query.openConn();
                using (this.query.command) {
                    this.response = this.query.command.ExecuteReader();
                    this.response.Read();
                    temp = new expense(this.response);
                }
            }
            this.query.closeConn();
            this.inputs.Clear();
            return temp;
        }

        public List<expense> getByTimeFrame( DateTime start, DateTime end ) {
            List<expense> exps = new List<expense>();
            expense temp = null;

            parameter pStart = new parameter("@start", start);
            parameter pEnd = new parameter("@end", end);
            this.inputs.Add(pStart);
            this.inputs.Add(pEnd);
            
            /* process the query */
            this.executeGetMultiple(this.getByDateRange());
            foreach (SQLiteDataReader ex in this.responses) {
                // need an open data connection to get the responses
                temp = new expense(ex);
                exps.Add(temp);
            }

            return exps;
            /* build query */
            //this.query.getQueryDetails(this.getByDateRange());
            //this.query.addParameters(this.inputs);
            //using (this.query.sqlConn) {
            //    this.query.openConn();
            //    using (this.query.command) {
            //        this.response = this.query.command.ExecuteReader();
            //        try {
            //            while (this.response.Read()) {
            //                temp = new expense(this.response);
            //                exps.Add(temp);
            //                temp = null;
            //            }
            //        } catch (SQLiteException e) {
            //            MessageBox.Show("An error occured reading from the database.\n\n" + e.ToString());
            //            exps.Clear();
            //        } finally {
            //            /* deconstruct */
            //            this.query.closeConn();
            //            this.inputs.Clear();
            //        }
            //    }

            //}
            //return exps;
        }
        /// <summary>
        /// Returns the last expense ID for a given account
        /// </summary>
        /// <param name="accountID"></param>
        /// <returns></returns>
        public int getLastID( int accountID ) {
            int id = -1; // error
            parameter actID = new parameter("@accountID", accountID);
            this.inputs.Add(actID);

            this.query.getQueryDetails(this.getLastID());
            this.query.addParameters(this.inputs);
            using (this.query.sqlConn) {
                this.query.openConn();
                using (this.query.command) {
                    try {
                        this.response = this.query.command.ExecuteReader();
                        this.response.Read();
                        id = Convert.ToInt32(this.response["id"]);
                    } catch (SQLiteException e) {
                        MessageBox.Show("An error occured loading the last expense from database.\n\n" + e.ToString());
                    } finally {
                        this.query.closeConn();
                    }
                }
            }
            return id;
        }
        #endregion

        #region Insertions
        /// <summary>
        /// Inserts a new expense into the database.
        /// </summary>
        /// <param name="newExpense"></param>
        /// <returns>True if the expense is successfully added, false if not</returns>
        public bool insert( expense newExpense ) {
            bool success = false;
            // generate a list of parameters from the object
            this.query.getQueryDetails(this.insertQuery());
            setParameters(newExpense);
            this.query.addParameters(this.inputs);
            using (this.query.sqlConn) {
                this.query.openConn();
                try {
                    this.query.command.ExecuteNonQuery();
                    success = true;
                } catch (SQLiteException e) {
                    MessageBox.Show("An error occured write Expense to database.\n\n" + e.ToString());
                } finally {
                    this.inputs.Clear();
                    this.query.closeConn();
                }
                return success;
            }
        }
        #endregion

        #region Deletes
        #endregion

        #region Updates
        #endregion

        #endregion

        #region HelperFunctions
        /// <summary>
        /// Converts expense object into a list of parameters to be inserted into database.
        /// </summary>
        /// <param name="ex"></param>
        /// <returns>list of parameter object type</returns>
        private void setParameters( expense ex ) {
            this.inputs.Add(new parameter("@id", ex.id));
            this.inputs.Add(new parameter("@payTo", ex.payTo));
            this.inputs.Add(new parameter("@amount", ex.amount));
            this.inputs.Add(new parameter("@postedDate", ex.postedDate));
            this.inputs.Add(new parameter("@expenseDate", ex.expenseDate));
            this.inputs.Add(new parameter("@notes", ex.notes));
            this.inputs.Add(new parameter("@payingAccount", ex.account));
            this.inputs.Add(new parameter("@budgetCat", ex.category));
        }
        #endregion
    }
}
