using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace budgetApp {
    class iAccount : baseInterface {
        private string _getByID = "getAccountByID";
        private string _getID = "getAccountID";
        private string _getAccountNames = "getAccountNames";
        private string _insert = "insertAccount";
        private string _update = "updateAccount";

        public iAccount() {
            this.className = publicEnums.classType.account;
        }
        #region Selects
        /// <summary>
        /// 
        /// </summary>
        /// <param name="accountID"></param>
        /// <returns></returns>
        public account getByID( int accountID ) {
            account temp = null;
            this.inputs.Add(new parameter("@ID", accountID));
            if (this.executeGetSingle(this._getByID)) { temp = new account(this.row); }
            return temp;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public int getID( string name ) {
            int id = -1;
            this.inputs.Add(new parameter("@name", name));
            if (this.executeGetSingle(this._getID)) { id = Convert.ToInt32(this.row.getColumnValue("id")); }
            return id;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<string> getAccountNames() {
            List<string> accs = new List<string>();
            if (this.executeGetMultiple(this._getAccountNames)) {
                foreach (responseRow row in this.rows) { accs.Add(row.getColumnValue("name")); }
            } else {
                MessageBox.Show("An error occurred reading from the database.");
            }
            return accs;
        }
        #endregion
        /// <summary>
        /// Inserts account into the accounts table.
        /// </summary>
        /// <param name="newAccount">Accepts an account object</param>
        /// <returns>True on successful insert, false on error</returns>
        #region Inserts
        public bool insert( account newAccount ) {
            bool success = false;
            this.setParameters(newAccount);
            if (this.executeNonQuery(this._insert)) {
                success = true;
            }
            return success;
        }
        #endregion

        #region Updates
        #endregion

        #region Deletes
        #endregion

        #region Helper Functions
        private void setParameters( account acc ) {
            this.inputs.Add(new parameter("@id", acc.id));
            this.inputs.Add(new parameter("@name", acc.name));
            this.inputs.Add(new parameter("@primaryCat", acc.primaryCategory));
            this.inputs.Add(new parameter("@interest", acc.interest));
            this.inputs.Add(new parameter("@balance", acc.balance));
            this.inputs.Add(new parameter("@userName", acc.userName));
            this.inputs.Add(new parameter("@postedDate", acc.postedDate));

        }
        #endregion
    }
}
