using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace budgetApp {
    class publicEnums {
        public enum columnType { none, text, date, datetime, real, integer };
        public enum classType { none, account, accountCategory, accountRegister, bill, budget, budgetCategory, expense, income, ledger }

        private publicEnums.columnType getColumnTypeFromName( string columnName ) {
            switch (columnName) {
                /* Text columns */
                case "payTo":
                    return publicEnums.columnType.text;
                case "notes":
                    return publicEnums.columnType.text;
                case "name":
                    return publicEnums.columnType.text;
                case "userName":
                    return publicEnums.columnType.text;
                /* Integer columns */
                case "category":
                    return publicEnums.columnType.integer;
                case "account":
                    return publicEnums.columnType.integer;
                case "expenseID":
                    return publicEnums.columnType.integer;
                case "incomeID":
                    return publicEnums.columnType.integer;
                case "primaryCat":
                    return publicEnums.columnType.integer;
                /* Real/Double Columns */
                case "balance":
                    return publicEnums.columnType.real;
                case "interest":
                    return publicEnums.columnType.real;
                case "balanceBefore":
                    return publicEnums.columnType.real;
                case "balanceAfter":
                    return publicEnums.columnType.real;
                case "amount":
                    return publicEnums.columnType.real;
                /* Datetime columns */
                case "expenseDate":
                    return publicEnums.columnType.datetime;
                case "postedDate":
                    return publicEnums.columnType.datetime;

            }
            return publicEnums.columnType.none;
        }
    }
}
