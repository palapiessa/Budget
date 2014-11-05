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
        public account getByID( int accountID ) {
            account temp = null;
            this.inputs.Add(new parameter("@ID", accountID));
            if (this.executeGetSingle(this._getByID)) { temp = new account(this.row); }
            return temp;
        }

        public account getID( string name ) {
            account temp = null;
            this.inputs.Add(new parameter("@name", name));
            if (this.executeGetSingle(this._getID)) { temp = new account(this.row); }
            return temp;
        }

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
    }
}
