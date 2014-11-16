using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace budgetApp {
    class iBill : baseInterface {
        private string _getByID = "getBillByID";
        private string _getID = "getBillID";
        //private string _getAccountNames = "getAccountNames";
        private string _insert = "insertBill";
        private string _update = "updateBill";

        public iBill() {
            this.className = publicEnums.classType.bill;
        }
        #region Selects
        /// <summary>
        /// 
        /// </summary>
        /// <param name="billID"></param>
        /// <returns></returns>
        public bill getByID( int billID ) {
            bill temp = null;
            this.inputs.Add(new parameter("@ID", billID));
            if (this.executeGetSingle(this._getByID)) { temp = new bill(this.row); }
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
        //public List<string> getAccountNames() {
        //    List<string> accs = new List<string>();
        //    if (this.executeGetMultiple(this._getAccountNames)) {
        //        foreach (responseRow row in this.rows) { accs.Add(row.getColumnValue("name")); }
        //    } else {
        //        MessageBox.Show("An error occurred reading from the database.");
        //    }
        //    return accs;
        //}
        #endregion
        /// <summary>
        /// Inserts bill into the accounts table.
        /// </summary>
        /// <param name="newBill">Accepts an bill object</param>
        /// <returns>True on successful insert, false on error</returns>
        #region Inserts
        public bool insert( bill newBill ) {
            bool success = false;
            this.setParameters(newBill);
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
        private void setParameters( bill b ) {
            this.inputs.Add(new parameter("@id", b.id));
            this.inputs.Add(new parameter("@name", b.name));
            this.inputs.Add(new parameter("@budgetCat", b.budgetCat));
            this.inputs.Add(new parameter("@dueDate", b.dueDate));
            this.inputs.Add(new parameter("@postedDate", b.postedDate));
            this.inputs.Add(new parameter("@timeframe", b.timeFrame));
            this.inputs.Add(new parameter("@estAmount", b.estAmount));
            this.inputs.Add(new parameter("@userName", b.userName));
            this.inputs.Add(new parameter("@password", b.password));
        }
        #endregion
    }
}
