using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Windows.Forms;

namespace budgetApp {
    class iLedger : baseInterface {
        public iLedger() {
            this.className = publicEnums.classType.ledger;
        }

        #region Database Interaction

        #region Selects
        #endregion

        #region Inserts
        /// <summary>
        /// Inserts new ledger into the database
        /// </summary>
        /// <param name="l">Takes a new ledger object</param>
        /// <returns>True on succesful insertion, false on failure</returns>
        public bool insert( ledger l ) {
            bool success = false;
            // generate a list of parameters from the object
            this.query.getQueryDetails(this.insertQuery());
            this.query.addParameters(setParameters(l));
            using (this.query.sqlConn) {
                this.query.openConn();
                try {
                    this.query.command.ExecuteNonQuery();
                    success = true;
                } catch (SQLiteException e) {
                    MessageBox.Show("An error occured writing Ledger to database.\n\n" + e.ToString());
                } finally {
                    this.query.closeConn();
                }
                return success;
            }

        }
        #endregion

        #region Updates
        /// <summary>
        /// Updates the ledger with the current information for the ledger
        /// </summary>
        /// <param name="l">Ledger object that will be modified</param>
        /// <returns>True upon updating the database without issue</returns>
        public bool update( ledger l ) {
            bool succes = false;
            this.query.getQueryDetails(this.updateQuery());
            this.query.addParameters(setParameters(l));
            using (this.query.sqlConn) {
                this.query.openConn();
                try {
                    this.query.command.ExecuteNonQuery();
                    succes = true;
                } catch (SQLiteException e) {
                    MessageBox.Show("An error occured writing Ledger to database.\n\n" + e.ToString());
                } finally {
                    this.query.closeConn();
                }
                return succes;
            }
        }
        #endregion

        #region Deletes
        #endregion

        #endregion

        #region Helper Functions
        private List<parameter> setParameters( ledger l ) {
            List<parameter> parameters = new List<parameter>();
            parameter id = new parameter("@id", l.id);
            parameter balanceBefore = new parameter("@balanceBefore", l.balanceBefore);
            parameter balanceAfter = new parameter("@balanceAfter", l.balanceAfter);
            parameter expenseID = new parameter("@expenseID", l.expenseID);
            parameter incomeID = new parameter("@incomeID", l.incomeID);
            parameter accountID = new parameter("@accountID", l.accountID);
            parameter postedDate = new parameter("@postedDate", l.postedDate);

            parameters.Add(id);
            parameters.Add(balanceAfter);
            parameters.Add(balanceBefore);
            parameters.Add(postedDate);
            parameters.Add(incomeID);
            parameters.Add(accountID);
            parameters.Add(expenseID);

            return parameters;
        }

        #endregion
    }
}
