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
    /// </summary>
    class queryBuilder : sqliteInterface {
        private string basePath = System.Windows.Forms.Application.StartupPath + "\\Queries\\";
        public SQLiteCommand command;
        public List<queryParameter> _queryParameters = new List<queryParameter>();
        public List<responseColumn> _queryColumns = new List<responseColumn>();

        #region Initialization
        public queryBuilder() {
            this.openConn();
            this.command = this.sqlConn.CreateCommand();
            this.closeConn();
        }
        #endregion

        #region Methods
        /// <summary>
        /// Parses the query file to determine the incoming parameters, the actual query string and the responses that the query is expected to provide.
        /// Loads queryParameters and queryColumns with type as well as names of parameters and response columns
        /// </summary>
        /// <param name="queryName">Takes the name of the query to be parsed</param>
        public void getQueryDetails( string queryName ) {
            this.command = this.sqlConn.CreateCommand();
            this.command.Parameters.Clear();
            this._queryParameters.Clear();
            string fileLocation = this.basePath + queryName + ".sqlite";
            if (!File.Exists(fileLocation)) {
                // file does not exists
            }
            //List<queryParameter> queryParameters = new List<queryParameter>();
            using (StreamReader input = File.OpenText(fileLocation)) {
                this.openConn();
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
                    /* the readline contains the actual query */
                    if (line.Contains("SELECT") || line.Contains("INSERT") || line.Contains("UPDATE") || line.Contains("DELETE")) {
                        // set the query
                        this.command.CommandText = line;
                    }
                }
            }
            this.closeConn();
        }

        /// <summary>
        /// Formats and adds the parameters to the command object
        /// </summary>
        /// <param name="inputParameters"></param>
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

                }
            }
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
        #endregion
    }
}
