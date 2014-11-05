using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Windows.Forms;

namespace budgetApp {
    class iLedger : baseInterface {
        private string _getByID = "getLedgerByID";
        private string _getMinLedger = "getMinLedger";
        private string _lastByAccount = "getLastLedgerByAccount";
        private string _update = "updateLedger";
        private string _updateBeforeTimeFrame = "updateLedgersBeforeTimeFrame";
        private string _insert = "insertLedger";
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
            
            this.inputs.Add(new parameter("@accountID", accountID));
            this.inputs.Add(new parameter("@start", startTime));

            if (this.executeGetSingle(this._getMinLedger)) {
                initial = Convert.ToDateTime(this.row.getColumnValue("minDate"));
            }
            
            //this.query.getQueryDetails("getMinLedger");
            //this.query.addParameters(this.inputs);

            //using (this.query.sqlConn) {
            //    this.query.openConn();
            //    try {
            //        this.response = this.query.command.ExecuteReader();
            //        if (this.response.HasRows) {
            //            if (this.response["minDate"] != null) {
            //                initial = Convert.ToDateTime(this.response["minDate"]);
            //            }
            //        }
            //    } catch (SQLiteException e) {
            //        MessageBox.Show("An error occured with getMinLedger query.\n\n" + e.ToString());
            //    } finally {
            //        this.inputs.Clear();
            //        //this.query.command;
            //        this.query.closeConn();
                    
            //    }
            //}
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

            if (this.executeGetSingle(this._lastByAccount)) {
                temp = new ledger(this.row);
            } else {
                MessageBox.Show("An error occurred reading the ledger.");
            }
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
            this.setParameters(l);

            if (this.executeNonQuery(this._insert)) {
                success = true;
            }
            return success;
        }
        #endregion

        #region Updates
        /// <summary>
        /// Updates the ledger with the current information for the ledger
        /// </summary>
        /// <param name="l">Ledger object that will be modified</param>
        /// <returns>True upon updating the database without issue</returns>
        public bool update( ledger l ) {
            bool success = false;

            this.setParameters(l);

            if (this.executeNonQuery(this._update)) {
                success = true;
            } else {
                // error
            }

            return success;
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

            if (this.executeGetMultiple(this._updateBeforeTimeFrame)) {
                foreach (responseRow row in this.rows) {
                    ledger temp = new ledger(row);
                    befores.Add(temp);
                    temp = null;
                }
            }

            //this.query.getQueryDetails("updateLedgersBeforeTimeFrame");
            //this.query.addParameters(this.inputs);
            //using (this.query.sqlConn) {
            //    this.query.openConn();
            //    using (this.query.command) {
            //        this.response = this.query.command.ExecuteReader();
            //        while (this.response.Read()) {
            //            ledger temp = new ledger(this.response);
            //            befores.Add(temp);
            //            temp = null;
            //        }
            //    }
            //    this.query.command = null;
            //    this.query.closeConn();
            //}

            int firstID = befores[0].id;
            ledger newLedger = new ledger();
            double tempBB = 0.00; // will be the Before Balance from the first item that is in the database
            double tempBA = 0.00; // will be the corrected after balance
            /* start with the youngest ledger that is older than the new expense */
            tempBB = befores[0].balanceBefore;
            newLedger.balanceBefore = tempBB;
            tempBA = tempBB + (newEx.amount);
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
            success = true;
            expenseInterface = null;
            return success;
        }
        #endregion

        #region Deletes
        #endregion

        #endregion

        #region Helper Functions
        private void setParameters( ledger l ) {
            this.inputs.Add(new parameter("@id", l.id));
            this.inputs.Add(new parameter("@balanceBefore", l.balanceBefore));
            this.inputs.Add(new parameter("@balanceAfter", l.balanceAfter));
            this.inputs.Add(new parameter("@expenseID", l.expenseID));
            this.inputs.Add(new parameter("@incomeID", l.incomeID));
            this.inputs.Add(new parameter("@accountID", l.accountID));
            this.inputs.Add(new parameter("@postedDate", l.postedDate));
        }

        #endregion
    }
}
