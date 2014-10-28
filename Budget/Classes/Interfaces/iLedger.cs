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
        /// <summary>
        /// Finds the first ledger that is posted after the new ledgers posted date
        /// </summary>
        /// <param name="accountID">Integer for the account to inspect</param>
        /// <param name="startTime">The posted date of the new ledger</param>
        /// <returns>Datetime with first ledger that has a date passed the new ledger date</returns>
        public DateTime getMinLedgerDate( int accountID, DateTime startTime ) {
            DateTime initial = DateTime.MinValue;
            parameter actID = new parameter("@accountID", accountID);
            parameter start = new parameter("@start", startTime);
            this.inputs.Add(actID);
            this.inputs.Add(start);
            
            this.query.getQueryDetails("getMinLedger");
            this.query.addParameters(this.inputs);

            using (this.query.sqlConn) {
                this.query.openConn();
                try {
                    this.response = this.query.command.ExecuteReader();
                    if (this.response.HasRows) {
                        if (this.response["minDate"] != null) {
                            initial = Convert.ToDateTime(this.response["minDate"]);
                        }
                    }
                } catch (SQLiteException e) {
                    MessageBox.Show("An error occured with getMinLedger query.\n\n" + e.ToString());
                } finally {
                    this.inputs.Clear();
                    //this.query.command;
                    this.query.closeConn();
                    
                }
            }
            if (initial > startTime) { initial = startTime; }

            return initial;
        }
        /// <summary>
        /// Returns the chronologically last ledger for a given account from the database
        /// </summary>
        /// <param name="accountID"></param>
        /// <returns>ledger object</returns>
        public ledger getLastLedgerByAccount( int accountID ) {
            ledger temp = null;

            this.inputs.Add(new parameter("@accountID", accountID));

            this.query.getQueryDetails("getLastLedgerByAccount");
            this.query.addParameters(this.inputs);

            using (this.query.sqlConn) {
                this.query.openConn();
                using (this.query.command) {
                    this.response = this.query.command.ExecuteReader();
                    this.response.Read();
                    temp = new ledger(response);
                }
            }
            this.inputs.Clear();
            this.query.closeConn();
            return temp;
        }
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

        public bool updateLedersBeforeTimeFrame( expense newEx ) {
            bool success = false;
            List<ledger> befores = new List<ledger>();
            DateTime first = this.getMinLedgerDate(newEx.account, newEx.expenseDate);
            ledger lastLedger = new ledger();
            lastLedger = this.getLastLedgerByAccount(newEx.account);
            DateTime last = lastLedger.postedDate;

            this.inputs.Add(new parameter("@accountID", newEx.account));
            this.inputs.Add(new parameter("@first", first));
            this.inputs.Add(new parameter("@last", last));

            this.query.getQueryDetails("updateLedgersBeforeTimeFrame");
            this.query.addParameters(this.inputs);
            using (this.query.sqlConn) {
                this.query.openConn();
                using (this.query.command) {
                    this.response = this.query.command.ExecuteReader();
                    while (this.response.Read()) {
                        ledger temp = new ledger(this.response);
                        befores.Add(temp);
                        temp = null;
                    }
                }
                this.query.command = null;
                this.query.closeConn();
            }

            int firstID = befores[0].id;
            ledger newLedger = new ledger();
            double tempBB = 0.00; // will be the Before Balance from the first item that is in the database
            double tempBA = 0.00; // will be the corrected after balance
            /* start with the youngest ledger that is older than the new expense */
            tempBB = befores[0].balanceBefore;
            newLedger.balanceBefore = tempBB;
            tempBA = tempBB - (newEx.amount);
            newLedger.balanceAfter = tempBA;
            newLedger.postedDate = newEx.expenseDate;
            newLedger.expenseID = newEx.id;
            newLedger.accountID = newEx.account;
            /* new ledger is complete, insert into database */
            if (!this.insert(newLedger)) {
                return false;
            }
            /* update the ledgers */
            iExpense expenseInterface = new iExpense();
            expense tempExpense = new expense();
            for (int i = 0; i < befores.Count; i++) {
                tempExpense = expenseInterface.getByID(befores[i].expenseID);
                tempBB = tempBA;
                tempBA = tempBB + tempExpense.amount;
                befores[i].balanceBefore = tempBB;
                befores[i].balanceAfter = tempBA;
                
                if (!this.update(befores[i])) {
                    MessageBox.Show("An error occurred updating the ledger.\n");
                    return false;
                }
            }

            return success;
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
