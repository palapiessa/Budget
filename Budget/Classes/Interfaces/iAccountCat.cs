using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace budgetApp {
    class iAccountCat : baseInterface {
        private string _getByID = "getAccountCategoryByID";
        private string _getID = "getAccountCategoryID";
        private string _getAll = "getAccountCategories";
        private string _getCategoryNames = "getCategoryNames";
        private string _insert = "insertAccountCategory";
        private string _update = "updateAccountCategory";
        private string _delete = "deleteAccountCategory";

        public iAccountCat() {
            this.className = publicEnums.classType.accountCategory;
        }

        #region Selects
        public accountCat getByID( int id ) {
            accountCat temp = null;
            this.inputs.Add(new parameter("@ID", id));
            if (this.executeGetSingle(this._getByID)) { temp = new accountCat(this.row); }
            return temp;
        }

        public List<string> getCategoryNames() {
            List<string> cats = new List<string>();
            if (this.executeGetMultiple(this._getCategoryNames)) {
                foreach (responseRow row in this.rows) { cats.Add(row.getColumnValue("name")); }
            } else {
                MessageBox.Show("An error occurred reading from the database.\n");
            }
            return cats;
        }

        public int getID( string name ) {
            int id = -1;
            this.inputs.Add(new parameter("@name", name));
            if (this.executeGetSingle(this._getID)) { id = Convert.ToInt32(this.row.getColumnValue("name")); }
            return id;
        }
        #endregion

        #region Inserts
        public bool insert(accountCat newAC) {
            bool success = false;
            this.setParameters(newAC);
            return success;
        }
        #endregion

        #region Updates
        #endregion

        #region Deletes
        #endregion

        #region Helper Functions
        private void setParameters( accountCat newAC ) {
            this.inputs.Add(new parameter("@id", newAC.id));
            this.inputs.Add(new parameter("@name", newAC.name));
            this.inputs.Add(new parameter("@postedDate", newAC.postedDate));
        }
        #endregion
    }
}
