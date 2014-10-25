using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace budgetApp.Classes.Interfaces {
    /* creates an interface to interact with the database, creating and returning expense objects */
    class iExpense : baseInterface {
        public iExpense() {
            this.className = publicEnums.classType.expense;
        }
        private expense getExpense( int id ) {
            return null;
            //return (expense)this.getByID();
            //using (this.db.dbConnection) {
            //    this.db.dbConnection.Open();
            //    using (SQLiteCommand select = this.db.dbConnection.CreateCommand()) {
            //        select.CommandText = this.getByIDQuery(this.className);
            //    }
            //}
        }
    }
}
