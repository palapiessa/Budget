using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Windows.Forms;

namespace budgetApp {
    /// <summary>
    /// Takes in the name of the query and builds the query as needed.
    /// Utilizes the queryParameter object that parses the query to determine the parameters that are expected to be passed into the query.
    /// Utilizes the queryResponse object which determines the columns and the types for the response.
    /// 
    /// TODO : Dynamically build the query
    /// </summary>
    class queryBuilder : sqliteInterface {
        private string basePath = System.Windows.Forms.Application.StartupPath + "\\Queries\\";
        public SQLiteCommand command;
        public List<queryParameter> _queryParameters = new List<queryParameter>();
        public List<queryResponse> _queryColumns = new List<queryResponse>();

        public queryBuilder() {
            this.sqlConn.Open();
            this.command = this.sqlConn.CreateCommand();
            this.sqlConn.Close();
        }

        //public List<queryParameter> 

        /// <summary>
        /// Parses the query file to determine the incoming parameters, the actual query string and the responses that the query is expected to provide.
        /// Loads queryParameters and queryColumns with type as well as names of parameters and response columns
        /// </summary>
        /// <param name="queryName">Takes the name of the query to be parsed</param>
        public void getQueryDetails( string queryName ) {
            string fileLocation = this.basePath + queryName + ".sqlite";

            if (!File.Exists(fileLocation)) {
                // file does not exists
            }
            //List<queryParameter> queryParameters = new List<queryParameter>();
            using (StreamReader input = File.OpenText(fileLocation)) {
                if (this.sqlConn.State == ConnectionState.Closed) {
                    this.sqlConn.Open();
                }
                string line = "";
                while ((line = input.ReadLine()) != null) {
                    // build the parameter list
                    if (line.Contains("[[")) {
                        line = line.Substring(2, line.Length - 4);
                        List<string> parameters = line.Split(',').ToList<string>();
                        foreach (string param in parameters) {
                            queryParameter temp = new queryParameter();
                            temp.paramName = param.Split(' ')[0];
                            temp.dataType = param.Split(' ')[1];
                            this._queryParameters.Add(temp);
                            temp = null;
                        }
                    }
                    // build the response list
                    if (line.Contains("SELECT") || line.Contains("INSERT") || line.Contains("UPDATE") || line.Contains("DELETE")) {
                        // set the query
                        this.command.CommandText = line;
                        //int fromLocation = line.IndexOf("FROM");
                        //line = line.Substring(7, fromLocation - 7).TrimEnd(' ');
                        //List<string> columns = line.Split(',').ToList<string>();
                        ////
                        //// need to handle this case: l.ledgerID AS [ID], i.incomeID AS [incomeID]
                        //// only grabbing what is in between the brackets, as these are the names of the columns
                        ////
                        //// what about inserts, updates, deletes, this is a very rigid case
                        ////
                        //foreach (string column in columns) {
                        //    queryResponse tempColumn = new queryResponse();
                        //    tempColumn.columnName = column.Substring(1, column.Length - 2);
                        //    tempColumn.columnTypeName = getColumnTypeFromName(tempColumn.columnName);
                        //    this._queryColumns.Add(tempColumn);
                        //    tempColumn = null;
                        //}
                    }
                    //MessageBox.Show(line.ToString());
                }
            }
            if (this.sqlConn.State == ConnectionState.Open) {
                this.sqlConn.Close();
            }
        }

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
        /* all the details of the query are now known, pass expected parameters as well as their values
         * if checking for id, pass in 
         * 
         * return just the final query parameters; let the interface handle the specifics of bindings
         */
        public void addParameters(List<parameter> inputParameters) {
            foreach (queryParameter param in this._queryParameters) {
                switch (param.dataType) {
                    case "INT":
                        this.command.Parameters.Add(param.paramName, DbType.Int32).Value = Convert.ToInt32(this.getParameterValueFromList(inputParameters, param.paramName));
                        break;
                    case "REAL":
                        this.command.Parameters.Add(param.paramName, DbType.Double).Value = Convert.ToDouble(this.getParameterValueFromList(inputParameters, param.paramName));
                        break;
                    case "DATETIME":
                        this.command.Parameters.Add(param.paramName, DbType.DateTime).Value = Convert.ToDateTime(this.getParameterValueFromList(inputParameters, param.paramName));
                        break;
                    case "TEXT":
                        this.command.Parameters.Add(param.paramName, DbType.String).Value = this.getParameterValueFromList(inputParameters, param.paramName);
                        break;

                    //temp.Parameters.Add
                }
            }
            //SQLiteCommand select = 
            /**
             * General sqlite call for select
             * set CommandText to the query
             * Parse the parameters:
             *  foreach (param in parameters):
             *      switch param.type:
             *          case pubicEnums.ColumnType.text:
             *              select.Parameters.Add(param.Name, DbType.String).Value = input ---- HOW DO THIS??
             * 
             * 
             * pass in queryParameter(list) 
             */
        }
        /// <summary>
        /// Returns the matched value for the requested parameter.
        /// Eg. procedure is expecting @id. Into the 
        /// </summary>
        /// <param name="inputParameters"></param>
        /// <param name="requestedParam"></param>
        /// <returns></returns>
        private string getParameterValueFromList( List<parameter> inputParameters, string requestedParam ) {
            foreach (parameter p in inputParameters) {
                if (p.paramName == requestedParam) {
                    return p.paramValue;
                }
            }
            return "error";
        }
    }
}
