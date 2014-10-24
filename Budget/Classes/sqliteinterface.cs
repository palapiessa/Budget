using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;

namespace budgetApp
{
    class sqliteInterface
    {
        public SQLiteConnection dbConnection = null;
        public sqliteInterface() {
            string connectionString = "Data Source=" + System.Windows.Forms.Application.StartupPath + "\\budget.db;Version=3";
            this.dbConnection = new SQLiteConnection(connectionString);
            try {
                this.dbConnection.Open();
                this.dbConnection.Close();
            } catch (SQLiteException e) {
                MessageBox.Show("An exception occured with the SQLite Database\n" + e.ToString());
            }
        }
        public void createDatabase() {
            //MessageBox.Show(System.Windows.Forms.Application.StartupPath.ToString());
            try {
                dbConnection.Open();
                createTables();
                ///* check for tables */
                //string query = "SELECT name FROM sqlite_master WHERE type='table' AND name='accounts'";
                //using (SQLiteCommand check = dbConnection.CreateCommand()) {
                //    check.CommandText = query;
                //    try {
                //        SQLiteDataReader response = check.ExecuteReader();
                //        if (response["name"].ToString() == "") {
                //            MessageBox.Show("Table does not exist.");
                //            /* create table */
                //            query = "CREATE TABLE IF NOT EXISTS accounts (id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, name TEXT, balance REAL, interest REAL, primaryCat INTEGER, postedDate TEXT, userName TEXT)";
                //            using (SQLiteCommand create = dbConnection.CreateCommand()) {
                //                create.CommandText = query;
                //                try {
                //                    create.ExecuteNonQuery();
                //                } catch (SQLiteException e2) {
                //                    MessageBox.Show(e2.ToString());
                //                }
                //            }
                //        }
                //    } catch (SQLiteException e) {
                //        /* alert e */
                //        MessageBox.Show(e.ToString());
                //    }
                //}
                dbConnection.Close();
            } catch (Exception e) {
                MessageBox.Show("There was an issue creating the database.\n" + e.ToString());
            }
        }
        /* create all required tables programatically */ 
        public void createTables() {
            List<string> tables = new List<string>();
            tables.Add("CREATE TABLE IF NOT EXISTS accounts (id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, name TEXT, balance REAL, interest REAL, primaryCat INTEGER, postedDate TEXT, userName TEXT)");
            tables.Add("CREATE TABLE IF NOT EXISTS account_Category (id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, name TEXT, postedDate TEXT)");
            tables.Add("CREATE TABLE IF NOT EXISTS expenses (id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, payTo TEXT, amount REAL, expenseDate TEXT, postedDate TEXT, notes TEXT, payingAccount INTEGER, budgetCat INTEGER)");
            tables.Add("CREATE TABLE IF NOT EXISTS bills (id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, name TEXT, budgetCat INTEGER, dueDate TEXT, postedDate TEXT, userName TEXT, password TEXT, timeframe INT, estimatedAmount REAL)");
            tables.Add("CREATE TABLE IF NOT EXISTS budget_Category (id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, name TEXT, postedDate TEXT)");
            tables.Add("CREATE TABLE IF NOT EXISTS budget (id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, name TEXT, budgetCat INTEGER, amount REAL, postedDate TEXT)");
            tables.Add("CREATE TABLE IF NOT EXISTS income (id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, name TEXT, accountCat INTEGER, amount REAL, postedDate TEXT)");
            tables.Add("CREATE TABLE IF NOT EXISTS ledger (id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, balanceBefore REAL, balanceAfter REAL, expenseID INTEGER, incomeID INTEGER, accountID INTEGER, postedDate TEXT)");
            foreach (string table in tables) {
                using (SQLiteCommand create = dbConnection.CreateCommand()) {
                    create.CommandText = table;
                    try {
                        create.ExecuteNonQuery();
                    } catch (SQLiteException e){
                        MessageBox.Show("Error creating a table.\n" + e.ToString() + "\n" + table);
                    }
                }
            }
        }
        /* returns a list of the payees. there is not a table for these as we want to be able to add them as we add transactions, for sake of brevity */
        public List<string> getPayees() {
            List<string> payees = new List<string>();
            string query = "SELECT DISTINCT payTo FROM expenses";
            using (dbConnection) {
                dbConnection.Open();
                using (SQLiteCommand select = dbConnection.CreateCommand()) {
                    select.CommandText = query;
                    SQLiteDataReader response = select.ExecuteReader();
                    while (response.Read()) {
                        payees.Add(response["payTo"].ToString());
                    }
                }
                dbConnection.Close();
            }
            return payees;
        }
        /******************\
        |* ACCOUNTS TABLE *|
        \******************/
        public bool addAccount( account newAccount ) {
            string insertQuery = "INSERT INTO accounts (name, primaryCat, interest, balance, userName, postedDate)" +
                " VALUES(@name, @primaryCat, @interest, @balance, @userName, @postedDate)";
            using (dbConnection) {
                dbConnection.Open();
                using (SQLiteCommand add = dbConnection.CreateCommand()) {
                    add.CommandText = insertQuery;
                    add.Parameters.Add("@name", DbType.String).Value = newAccount.name;
                    add.Parameters.Add("@primaryCat", DbType.Int16).Value = newAccount.primaryCategory;
                    add.Parameters.Add("@interest", DbType.Double).Value = newAccount.interest;
                    add.Parameters.Add("@balance", DbType.Double).Value = newAccount.balance;
                    add.Parameters.Add("@userName", DbType.String).Value = newAccount.userName;
                    add.Parameters.Add("@postedDate", DbType.DateTime).Value = newAccount.postedDate;
                    try {
                        add.ExecuteNonQuery();
                    } catch (SQLiteException e) {
                        MessageBox.Show("There was an error adding to the database.\n" + e.ToString());
                        dbConnection.Close();
                        return false;
                    } finally {
                        dbConnection.Close();
                    }
                }
            }
            return true;
        }
        /* return an account object based on the id */
        public account getAccount( int id ) {
            account a = new account();
            a.id = id;
            string query = "SELECT name, primaryCat, interest, balance, userName, postedDate FROM accounts WHERE id = @id";
            using (dbConnection) {
                dbConnection.Open();
                using (SQLiteCommand select = dbConnection.CreateCommand()) {
                    select.CommandText = query;
                    select.Parameters.Add("@id", DbType.String).Value = a.id;
                    SQLiteDataReader response = select.ExecuteReader();
                    try {
                        response.Read();
                        a.name = response["name"].ToString();
                        a.balance = Convert.ToDouble(response["balance"]);
                        a.interest = Convert.ToInt32(response["interest"]);
                        a.primaryCategory = Convert.ToInt32(response["primaryCat"]);
                        a.userName = response["userName"].ToString();
                        a.postedDate = Convert.ToDateTime(response["postedDate"]);
                    } catch {
                        /* alert an error */
                    } finally {
                        dbConnection.Close();
                    }
                }
            }
            return a;
        }
        /* return a list of the accounts */
        public List<string> getAccounts() {
            List<string> accounts = new List<string>();
            string query = "SELECT name FROM accounts";
            using (dbConnection) {
                dbConnection.Open();
                using (SQLiteCommand select = dbConnection.CreateCommand()) {
                    select.CommandText = query;
                    SQLiteDataReader response = select.ExecuteReader();
                    while (response.Read()) {
                        accounts.Add(response["name"].ToString());
                    }
                }
                dbConnection.Close();
            }
            return accounts;
        }
        /* return the id of the account in the database from the name of the account */
        public int getAccountID( string name ) {
            string query = "SELECT id FROM accounts WHERE name = @name";
            int accountID = -1;
            using (dbConnection) {
                dbConnection.Open();
                using (SQLiteCommand select = dbConnection.CreateCommand()) {
                    select.CommandText = query;
                    select.Parameters.Add("@name", DbType.String).Value = name;
                    SQLiteDataReader response = select.ExecuteReader();
                    if (response.HasRows) {
                        accountID = Convert.ToInt32(response["id"]);
                    }
                }
                dbConnection.Close();
            }
            return accountID;
        }
        /**************************\
        |* ACCOUNT CATEGORY TABLE *|
        \**************************/
        /* retrive all the account category types */
        public List<string> getAccountCategories() {
            List<string> cats = new List<string>();
            string query = "SELECT name FROM account_Category";
            using (dbConnection) {
                dbConnection.Open();
                using (SQLiteCommand select = dbConnection.CreateCommand()) {
                    select.CommandText = query;
                    SQLiteDataReader response = select.ExecuteReader();
                    while (response.Read()) {
                        cats.Add(response["name"].ToString());
                    }
                }
                dbConnection.Close();
            }
            return cats;
        }
        /* get the account category from the name */
        public int getAccountCatID( string name ) {
            string query = "SELECT id FROM account_Category WHERE name = @name";
            int value = -1;
            using (dbConnection) {
                dbConnection.Open();
                using (SQLiteCommand select = dbConnection.CreateCommand()) {
                    select.CommandText = query;
                    select.Parameters.Add("@name", DbType.String).Value = name;
                    SQLiteDataReader response = select.ExecuteReader();
                    if (response.HasRows) {
                        value = Convert.ToInt16(response["id"]);
                    }
                }
                dbConnection.Close();
            }
            return value;
        }
        /* add a new account category to the table */
        public bool addAccountCat(accountCat newCat) {
            bool value = false;
            string insertQuery = "INSERT INTO account_Category (name, postedDate) VALUES (@name, @postedDate)";
            using (dbConnection) {
                dbConnection.Open();
                using (SQLiteCommand insert = dbConnection.CreateCommand()) {
                    insert.CommandText = insertQuery;
                    insert.Parameters.Add("@name", DbType.String).Value = newCat.name;
                    insert.Parameters.Add("@postedDate", DbType.DateTime).Value = newCat.postedDate;
                    try {
                        insert.ExecuteNonQuery();
                        value = true;
                    } catch (SQLiteException e) {
                        MessageBox.Show("An error occurred writing to the database.\n" + e.ToString());
                    } finally {
                        dbConnection.Close();
                    }
                }
            }
            return value;
        }
        /* Remove account category from database. */
        public bool removeAccountCat( string name ) {
            bool success = false;
            string delete = "DELETE FROM account_Category WHERE name = @name";
            using (dbConnection) {
                dbConnection.Open();
                using (SQLiteCommand remove = dbConnection.CreateCommand()) {
                    remove.CommandText = delete;
                    remove.Parameters.Add("@name", DbType.String).Value = name;
                    try {
                        remove.ExecuteNonQuery();
                        success = true;
                    } catch (SQLiteException e) {
                        MessageBox.Show("An error occured removing " + name + " from database.\n" + e.ToString());
                    } finally {
                        dbConnection.Close();
                    }
                }
            }
            return success;
        }
        /*****************\
        |* EXPENSE TABLE *|
        \*****************/
        /* returns the last expense that was entered for a specific account */
        public int getLastExpenseID( int accountID ) {
            int value = -1;
            string query = "SELECT e.ID FROM expenses e WHERE e.payingAccount = @accountID GROUP BY e.payingAccount HAVING e.postedDate = MAX(e.postedDate)";
            using (dbConnection) {
                dbConnection.Open();
                using (SQLiteCommand select = dbConnection.CreateCommand()) {
                    select.Parameters.Add("@accountID", DbType.Int32).Value = accountID;
                    select.CommandText = query;
                    SQLiteDataReader response = select.ExecuteReader();
                    if (response.HasRows) {
                        value = Convert.ToInt32(response["ID"]);
                        //MessageBox.Show(value.ToString());
                    }
                }
                dbConnection.Close();
            }
            return value;
        }
        /* using the expense id, return the entire expense object */
        public expense getExpense( int id ) {
            expense e = new expense();
            e.id = id;
            string query = "SELECT payTo, amount, budgetCat, expenseDate, postedDate, payingAccount, notes FROM expenses e WHERE e.id = @id";
            using (dbConnection) {
                dbConnection.Open();
                using (SQLiteCommand select = dbConnection.CreateCommand()) {
                    select.Parameters.Add("@id", DbType.Int32).Value = id;
                    select.CommandText = query;
                    select.CommandType = System.Data.CommandType.Text;
                    SQLiteDataReader response = select.ExecuteReader();

                    e.payTo = response["payTo"].ToString();
                    e.amount = Convert.ToDouble(response["amount"]);
                    e.category = Convert.ToInt32(response["budgetCat"]);
                    e.account = Convert.ToInt32(response["payingAccount"]);
                    e.notes = response["notes"].ToString();
                    e.postedDate = Convert.ToDateTime(response["postedDate"]);
                    e.expenseDate = Convert.ToDateTime(response["expenseDate"]);
                }
                dbConnection.Close();
            }
            return e;
        }
        /* return a list of expenses in a timeframe */
        public List<expense> getExpenseTimeFrame( DateTime start, DateTime end ) {
            List<expense> exps = new List<expense>();
            string query = "SELECT payTo, amount, budgetCat, expenseDate, postedDate, payingAccount, notes FROM expenses e WHERE e.expenseDate BETWEEN @start AND @end ORDER BY e.expenseDate ASC";
            using (dbConnection) {
                dbConnection.Open();
                using (SQLiteCommand select = dbConnection.CreateCommand()) {
                    select.CommandText = query;
                    select.Parameters.Add("@start", DbType.DateTime).Value = start;
                    select.Parameters.Add("@end", DbType.DateTime).Value = end;
                    SQLiteDataReader response = select.ExecuteReader();
                    try {
                        while (response.Read()) {
                            string payTo = response["payTo"].ToString();
                            double amount = Convert.ToDouble(response["amount"]);
                            int bCat = Convert.ToInt32(response["budgetCat"]);
                            int pAccount = Convert.ToInt32(response["payingAccount"]);
                            string notes = response["notes"].ToString();
                            DateTime post = Convert.ToDateTime(response["postedDate"]);
                            DateTime expDate = Convert.ToDateTime(response["expenseDate"]);
                            expense temp = new expense(payTo, bCat, pAccount, notes, amount, expDate, post);
                            exps.Add(temp);
                        }
                    } catch (SQLiteException e) {
                        MessageBox.Show("An error occurred reading from the database.\n" + e.ToString());
                        exps.Clear();
                    } finally {
                        dbConnection.Close();
                    }
                }
            }
            return exps;
        }
        /* write expense to the database */
        public bool addExpense( expense newExpense ) {
            string query = "INSERT INTO expenses (payTo, amount, expenseDate, postedDate, notes, payingAccount, budgetCat) VALUES(@payTo, @amount, @expenseDate, @postedDate, @notes, @payingAccount, @budgetCat)";
            bool value = false;
            using (dbConnection) {
                dbConnection.Open();
                using (SQLiteCommand insert = dbConnection.CreateCommand()) {
                    insert.CommandText = query;
                    insert.Parameters.Add("@payTo", DbType.String).Value = newExpense.payTo;
                    insert.Parameters.Add("@amount", DbType.Double).Value = newExpense.amount;
                    insert.Parameters.Add("@postedDate", DbType.DateTime).Value = newExpense.postedDate;
                    insert.Parameters.Add("@expenseDate", DbType.DateTime).Value = newExpense.expenseDate;
                    insert.Parameters.Add("@notes", DbType.String).Value = newExpense.notes;
                    insert.Parameters.Add("@payingAccount", DbType.Int16).Value = newExpense.account;
                    insert.Parameters.Add("@budgetCat", DbType.Int16).Value = newExpense.category;
                    try {
                        insert.ExecuteNonQuery();
                        value = true;
                    } catch (SQLiteException e) {
                        MessageBox.Show("An error occurred writing to the database.\n" + e.ToString());
                    } finally {
                        dbConnection.Close();
                    }
                }
            }
            return value;
        }
        /*************************\
        |* BUDGET CATEGORY TABLE *|
        \*************************/
        public List<string> getBudgetCats() {
            List<string> cats = new List<string>();
            string query = "SELECT name FROM budget_Category";
            using (dbConnection) {
                dbConnection.Open();
                using (SQLiteCommand select = dbConnection.CreateCommand()) {
                    select.CommandText = query;
                    SQLiteDataReader response = select.ExecuteReader();
                    while (response.Read()) {
                        cats.Add(response["name"].ToString());
                    }
                }
                dbConnection.Close();
            }
            return cats;
        }
        /* return the id of the budget category */
        public int getBudgetCategoryID( string name ) {
            string query = "SELECT id FROM budget_Category WHERE name = @name";
            int id = -1;
            using (dbConnection) {
                dbConnection.Open();
                using (SQLiteCommand select = dbConnection.CreateCommand()) {
                    select.CommandText = query;
                    select.Parameters.Add("@name", DbType.String).Value = name;
                    SQLiteDataReader response = select.ExecuteReader();
                    if (response.HasRows) {
                        id = Convert.ToInt16(response["id"]);
                    }
                }
                dbConnection.Close();
            }
            return id;
        }
        /* add budget category */
        public bool addBudgetCategory( budgetCat bc ) {
            string query = "INSERT INTO budget_Category (name, postedDate) VALUES(@name, @postedDate)";
            bool value = false;
            using (dbConnection) {
                dbConnection.Open();
                using (SQLiteCommand insert = dbConnection.CreateCommand()) {
                    insert.CommandText = query;
                    insert.Parameters.Add("@name", DbType.String).Value = bc.name;
                    insert.Parameters.Add("@postedDate", DbType.DateTime).Value = bc.postedDate;
                    try {
                        insert.ExecuteNonQuery();
                        value = true;
                    } catch (SQLiteException e) {
                        MessageBox.Show("An error occurred writing to the database.\n" + e.ToString());
                    } finally {
                        dbConnection.Close();
                    }
                }
            }
            return value;
        }
        /****************\
        |* LEDGER TABLE *|
        \****************/
        /* adds the ledger object to the ledger table */
        public bool addLedger( ledger l ) {
            string query = "INSERT INTO ledger (balanceBefore, balanceAfter, expenseID, incomeID, accountID, postedDate) VALUES(@balanceBefore, @balanceAfter, @expenseID, @incomeID, @accountID, @postedDate)";
            bool value = false;
            using (dbConnection) {
                dbConnection.Open();
                using (SQLiteCommand insert = dbConnection.CreateCommand()) {
                    insert.CommandText = query;
                    insert.Parameters.Add("@balanceBefore", DbType.Double).Value = l.balanceBefore;
                    insert.Parameters.Add("@balanceAfter", DbType.Double).Value = l.balanceAfter;
                    insert.Parameters.Add("@expenseID", DbType.Int32).Value = l.expenseID;
                    insert.Parameters.Add("@incomeID", DbType.Int32).Value = l.incomeID;
                    insert.Parameters.Add("@accountID", DbType.Int32).Value = l.accountID;
                    insert.Parameters.Add("@postedDate", DbType.DateTime).Value = l.postedDate;
                    try {
                        insert.ExecuteNonQuery();
                        value = true;
                    } catch (SQLiteException e) {
                        MessageBox.Show("An error occurred writing to the database.\n" + e.ToString());
                    } finally {
                        dbConnection.Close();
                    }
                }
            }
            return value;
        }
        /* get the last ledger entered for an account */
        public ledger getLastLedgerForAccount( int accountID ) {
            ledger l = new ledger();
            string query = "SELECT led.ID, led.balanceBefore, led.balanceAfter, led.expenseID, led.incomeID, led.accountID, led.postedDate FROM LEDGER led" +
                " WHERE led.accountID = @accountID ORDER BY led.postedDate DESC LIMIT 1";
            using (dbConnection) {
                dbConnection.Open();
                using (SQLiteCommand select = dbConnection.CreateCommand()) {
                    select.CommandText = query;
                    select.Parameters.Add("@accountID", DbType.Int32).Value = accountID;
                    SQLiteDataReader response = select.ExecuteReader();
                    if (response.HasRows) {
                        l.id = Convert.ToInt32(response["ID"]);
                        l.balanceBefore = Convert.ToDouble(response["balanceBefore"]);
                        l.balanceAfter = Convert.ToDouble(response["balanceAfter"]);
                        l.expenseID = Convert.ToInt32(response["expenseID"]);
                        l.incomeID = Convert.ToInt32(response["incomeID"]);
                        l.accountID = Convert.ToInt32(response["accountID"]);
                        l.postedDate = Convert.ToDateTime(response["postedDate"]);
                    }
                }
                dbConnection.Close();
            }
            return l;
        }
        /* returns a datetime with the first or last entry date for a ledger */
        public DateTime getMinLedgerDate( int accountID, DateTime startTime ) {
            DateTime initial = DateTime.MinValue;
            string query = "SELECT MIN(led.postedDate)" + "AS [minDate] FROM ledger led WHERE led.accountID = @accountID AND led.postedDate > @start";// +" AND led.expenseID <> -1";
            using (dbConnection) {
                dbConnection.Open();
                using (SQLiteCommand select = dbConnection.CreateCommand()) {
                    select.CommandText = query;
                    select.Parameters.Add("@accountID", DbType.Int32).Value = accountID;
                    select.Parameters.Add("@start", DbType.DateTime).Value = startTime;
                    SQLiteDataReader response = select.ExecuteReader();
                    if (response.HasRows) {
                        //MessageBox.Show(response["minDate"].ToString());
                        if (response["minDate"] != null) {
                            initial = Convert.ToDateTime(response["minDate"]);
                        }
                    }
                }
                dbConnection.Close();
            }

            /* handle the case where the entered time is before the first expense date, but after the account creation */
            if (initial > startTime) {
                initial = startTime;
            }
            return initial;
        }
        /* updates balances approriately when the new expense entered has a posting date that is before another entry in the ledger table */
        public bool updateLedgersBeforeTimeFrame( expense newExpense ) {
            List<ledger> befores = new List<ledger>();
            DateTime first = this.getMinLedgerDate(newExpense.account, newExpense.expenseDate);
            ledger lastLedger = new ledger();
            lastLedger = this.getLastLedgerForAccount(newExpense.account);
            DateTime last = lastLedger.postedDate;
            string query = "SELECT led.ID, led.balanceBefore, led.balanceAfter, led.expenseID, led.incomeID, led.accountID, led.postedDate FROM LEDGER led" +
                " WHERE led.accountID = @accountID AND led.postedDate BETWEEN @first AND @last ORDER BY led.postedDate ASC";
            /* get a list of the ledgers from the new date to the last date in the ledger */
            using (dbConnection) {
                dbConnection.Open();
                using (SQLiteCommand select = dbConnection.CreateCommand()) {
                    select.CommandText = query;
                    select.Parameters.Add("@accountID", DbType.Int32).Value = newExpense.account;
                    select.Parameters.Add("@first", DbType.DateTime).Value = first;
                    select.Parameters.Add("@last", DbType.DateTime).Value = last;
                    SQLiteDataReader response = select.ExecuteReader();
                    while (response.Read()) {
                        ledger temp = new ledger();
                        temp.id = Convert.ToInt32(response["ID"]);
                        temp.balanceBefore = Convert.ToDouble(response["balanceBefore"]);
                        temp.balanceAfter = Convert.ToDouble(response["balanceAfter"]);
                        temp.expenseID = Convert.ToInt32(response["expenseID"]);
                        temp.incomeID = Convert.ToInt32(response["incomeID"]);
                        temp.accountID = Convert.ToInt32(response["accountID"]);
                        temp.postedDate = Convert.ToDateTime(response["postedDate"]);
                        // append, in order, the ledgers to the list
                        befores.Add(temp);
                    }
                }
                dbConnection.Close();
            }

            //return false;
           
            /* alter the first entry */
            int firstID = befores[0].id;
            ledger newLedger = new ledger();
            double tempBB = 0.00; // will be the Before Balance from the first item that is in the database
            double tempBA = 0.00; // will be the corrected after balance
            /* start with the youngest ledger that is older than the new expense */
            tempBB = befores[0].balanceBefore;
            newLedger.balanceBefore = tempBB;
            tempBA = tempBB - (newExpense.amount);
            newLedger.balanceAfter = tempBA;
            newLedger.postedDate = newExpense.expenseDate;
            newLedger.expenseID = newExpense.id;
            newLedger.accountID = newExpense.account;
            /* new ledger is complete, insert into database */
            if (!addLedger(newLedger)) {
                return false;
            }
            /* update the ledgers */
            expense tempExpense = new expense();
            for (int i = 0; i < befores.Count; i++) {
                tempExpense = getExpense(befores[i].expenseID);
                tempBB = tempBA;
                tempBA = tempBB - tempExpense.amount;
                befores[i].balanceBefore = tempBB;
                befores[i].balanceAfter = tempBA;
                if (!updateLedger(befores[i])) {
                    MessageBox.Show("An error occurred updating the ledger.\n");
                    return false;
                }
            }

            return true;
        }
        /* updates a ledger */
        public bool updateLedger(ledger l) {
            bool value = false;
            string query = "UPDATE ledger SET balanceBefore=@newBefore, balanceAfter=@newAfter WHERE id = @id";
            using (dbConnection) {
                dbConnection.Open();
                using (SQLiteCommand update = dbConnection.CreateCommand()) {
                    update.CommandText = query;
                    update.Parameters.Add("@newBefore", DbType.Double).Value = l.balanceBefore;
                    update.Parameters.Add("@newAfter", DbType.Double).Value = l.balanceAfter;
                    update.Parameters.Add("@id", DbType.Int32).Value = l.id;
                    try {
                        update.ExecuteNonQuery();
                        value = true;
                    } catch (SQLiteException e) {
                        MessageBox.Show("An error occurred writing to database.\n" + e.ToString());
                    } finally {
                        dbConnection.Close();
                    }
                }
            }
            return value;
        }
        /******************\
        |* REGISTER TABLE *|
        \******************/
        public List<accountRegister> getRegisterInTimeFrame( DateTime start, DateTime end, account act ) {
            List<accountRegister> registers = new List<accountRegister>();
            string query = "SELECT l.postedDate AS [date], l.balanceAfter as [balance], " +
                "CASE WHEN (l.expenseID = -1 AND l.incomeID = -1) THEN 'Account Opening' WHEN l.expenseID = -1 THEN i.Name ELSE e.payTo END AS [receivee], "+
                "CASE WHEN (l.expenseID = -1 AND l.incomeID = -1) THEN l.BalanceAfter WHEN l.expenseID = -1 THEN i.amount ELSE e.amount END AS [amount] " +
                "FROM ledger l LEFT OUTER JOIN expenses e ON e.ID = l.expenseID LEFT OUTER JOIN income i ON i.ID = l.incomeID " +
                "WHERE l.postedDate BETWEEN @start AND @end AND l.AccountID = @account " +
                "ORDER BY l.postedDate ASC";
            try {
                using (dbConnection) {
                    dbConnection.Open();
                    using (SQLiteCommand select = dbConnection.CreateCommand()) {
                        select.CommandText = query;
                        select.Parameters.Add("@start", DbType.Date).Value = start;
                        select.Parameters.Add("@end", DbType.Date).Value = end;
                        select.Parameters.Add("@account", DbType.Int32).Value = act.id;
                        SQLiteDataReader response = select.ExecuteReader();
                        while (response.Read()) {
                            accountRegister temp = new accountRegister();
                            temp.date = Convert.ToDateTime(response["date"]);
                            temp.amount = string.Format("{0:C}", decimal.Parse(response["amount"].ToString()));
                            temp.balance = string.Format("{0:C}", decimal.Parse(response["balance"].ToString()));
                            temp.receivee = Convert.ToString(response["receivee"]);
                            registers.Add(temp);
                            temp = null;
                        }
                    }
                }
            } catch (SQLiteException e) {
                MessageBox.Show("An error occured loading the ledger information.\n" + e.ToString());
            } finally {
                this.dbConnection.Close();
            }
            return registers;
        }

    }    
}
