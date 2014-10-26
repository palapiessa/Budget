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
        private queryBuilder query = new queryBuilder();
        public iExpense() {
            this.className = publicEnums.classType.expense;
        }

        /// <summary>
        /// Returns an expense from the database based on the passed in expense id
        /// </summary>
        /// <param name="expenseID"></param>
        /// <returns></returns>
        public expense getExpense( int expenseID ) {
            expense temp = null;
            /* create parameter list */            
            parameter inp = new parameter("@ID", expenseID.ToString());
            List<parameter> inputs = new List<parameter>();
            inputs.Add(inp);

            /* build the query */
            this.query.getQueryDetails(this.getByIDQuery());
            this.query.addParameters(inputs);
            /* process the query and build the expense object */
            using (this.query.sqlConn) {
                if (this.query.sqlConn.State == ConnectionState.Closed) {
                    this.query.sqlConn.Open();
                }
                using (this.query.command) {
                    SQLiteDataReader response = this.query.command.ExecuteReader();
                    response.Read();
                    temp = new expense(response);
                }
            }
            if (this.query.sqlConn.State == ConnectionState.Open) {
                this.query.sqlConn.Close();
            }
            return temp;
        }
        /// <summary>
        /// Inserts a new expense into the database.
        /// </summary>
        /// <param name="newExpense"></param>
        /// <returns>True if the expense is successfully added, false if not</returns>
        public bool insertExpense( expense newExpense ) {
            bool success = false;
            // generate a list of parameters from the object
            this.query.getQueryDetails(this.insertQuery());
            this.query.addParameters(setParameters(newExpense));
            using (this.query.sqlConn) {
                if (this.query.sqlConn.State == ConnectionState.Closed) {
                    this.query.sqlConn.Open();
                }
                try {
                    this.query.command.ExecuteNonQuery();
                    success = true;
                } catch (SQLiteException e) {
                    MessageBox.Show("An error occured write Expense to database.\n\n" + e.ToString());
                } finally {
                    if (this.query.sqlConn.State == ConnectionState.Open) {
                        this.query.sqlConn.Close();
                    }
                }
                return success;
            }
        }
        /// <summary>
        /// Converts expense object into a list of parameters to be inserted into database.
        /// </summary>
        /// <param name="ex"></param>
        /// <returns>list of parameter object type</returns>
        private List<parameter> setParameters( expense ex ) {
            List<parameter> parameters = new List<parameter>();
            parameter payTo = new parameter("@payTo", ex.payTo);
            parameter amount = new parameter("@amount", ex.amount.ToString());
            parameter postedDate = new parameter("@postedDate", ex.postedDate.ToString());
            parameter expenseDate = new parameter("@expenseDate", ex.expenseDate.ToString());
            parameter notes = new parameter("@notes", ex.notes);
            parameter payingAccount = new parameter("@payingAccount", ex.account.ToString());
            parameter budgetCat = new parameter("@budgetCat", ex.category.ToString());

            parameters.Add(payTo);
            parameters.Add(amount);
            parameters.Add(postedDate);
            parameters.Add(expenseDate);
            parameters.Add(notes);
            parameters.Add(payingAccount);
            parameters.Add(budgetCat);

            return parameters;
        }

    }
}
