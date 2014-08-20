using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;

namespace budget
{
    class sqliteInterface
    {
        public SQLiteConnection dbConnection = null;
        public sqliteInterface() {
            string connectionString = "Data Source=" + System.Windows.Forms.Application.StartupPath + "\\budget.db;Version=3";
            this.dbConnection = new SQLiteConnection(connectionString);
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
                        a.balance = (double)response["balance"];
                        a.interest = (double)response["interest"];
                        a.primaryCategory = (int)response["primaryCat"];
                        a.userName = response["userName"].ToString();
                        a.postedDate = (DateTime)response["postedDate"];
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
        /*****************\
        |* EXPENSE TABLE *|
        \*****************/
        /* return an expense object from the id */
        public expense getExpense( int id ) {
            expense e = new expense();
            e.id = id;
            string query = "SELECT payTo, amount, budgetCat, expenseDate, postedDate, payingAccount, notes FROM expenses e WHERE e.id = ?";
            using (dbConnection) {
                dbConnection.Open();
                using (SQLiteCommand select = dbConnection.CreateCommand()) {
                    select.Parameters.Add(id);
                    select.CommandText = query;
                    select.CommandType = System.Data.CommandType.Text;
                    SQLiteDataReader response = select.ExecuteReader();

                    e.payTo = response["payTo"].ToString();
                    e.amount = Convert.ToDouble(response["amount"]);
                    e.category = Convert.ToInt32(response["budgetCat"]);
                    e.account = Convert.ToInt32(response["payingAccount"]);
                    e.notes = response["notes"].ToString();
                    e.postedDate = (DateTime)response["postedDate"];
                }
            }
            return e;
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
        public bool addBudgetCategory( string name ) {
            string query = "INSERT INTO budget_Category (name, postedDate) VALUES(@name, @postedDate)";
            bool value = false;
            using (dbConnection) {
                dbConnection.Open();
                using (SQLiteCommand insert = dbConnection.CreateCommand()) {
                    insert.CommandText = query;
                    insert.Parameters.Add("@name", DbType.String).Value = name;
                    insert.Parameters.Add("@postedDate", DbType.DateTime).Value = DateTime.Now;
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
    }    
}
