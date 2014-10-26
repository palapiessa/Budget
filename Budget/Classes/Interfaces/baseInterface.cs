using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace budgetApp {
    /* the most basic interface class, other interfaces will inherit from this one */
    class baseInterface {
        protected publicEnums.classType className = publicEnums.classType.none;
        protected sqliteInterface db = new sqliteInterface();
        protected queryBuilder query = new queryBuilder();
        protected List<parameter> inputs = new List<parameter>();
        protected SQLiteDataReader response = null;

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
                case publicEnums.classType.expense:
                    return "getExpenseByID";
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
    }
}
