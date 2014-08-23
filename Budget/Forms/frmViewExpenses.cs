using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace budgetApp {
    public partial class frmViewExpenses : Form {
        sqliteInterface db = new sqliteInterface();
        public frmViewExpenses() {
            InitializeComponent();
            loadExpenses();
        }

        private void loadExpenses() {
            List<expense> exps = new List<expense>();
            DateTime start = Convert.ToDateTime("2014-08-17 00:00:00");
            DateTime end = Convert.ToDateTime("2014-08-31 00:00:00");
            exps = this.db.getExpenseTimeFrame(start, end);
            foreach (expense e in exps) {
                string temp = e.expenseDate.ToString() + " - " + e.amount.ToString() + " - " + e.category.ToString();
                lstExpenses.Items.Add(temp);
            }
        }

        private void frmViewExpenses_Load( object sender, EventArgs e ) {

        }
    }
}
