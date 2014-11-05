using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace budgetApp.Classes.Interfaces {
    class controller {

        private static iExpense expenseInterface;
        private static iLedger ledgerInterface;
        private static iAccount accountInterface;

        public static iExpense iE { get { return expenseInterface ?? (expenseInterface = new iExpense()); } }
        public static iLedger iL { get { return ledgerInterface ?? (ledgerInterface = new iLedger()); } }
        public static iAccount iA { get { return accountInterface ?? (accountInterface = new iAccount()); } }

    }
}
