using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace budgetapp {
    public partial class frmAddBudgetCat : Form {
        sqliteInterface db = new sqliteInterface();
        public frmAddBudgetCat() {
            InitializeComponent();
            lblStatus.Text = "";
        }
        /* update the status label */
        public void updateStatus( string message, bool error = true ) {
            if (error) {
                lblStatus.ForeColor = System.Drawing.Color.DarkRed;
            } else {
                lblStatus.ForeColor = System.Drawing.Color.LimeGreen;
            }
            lblStatus.Text = message;
        }

        public bool addBudgetCat() {
            budgetCat bc = new budgetCat(txtCategory.Text);
            try {
                if (bc.name == "") {
                    updateStatus("Please enter a category.");
                    return false;
                }
                if (!this.db.addBudgetCategory(bc)) {
                    updateStatus("Error adding to database.");
                    return false;
                } 
            } catch (Exception e) {
                updateStatus("An error occurred.");
                MessageBox.Show(e.ToString());
            }
            return true;
        }
        /* event handlers */
        private void btnAdd_Click( object sender, EventArgs e ) {
            if (addBudgetCat()) {
                updateStatus("Successfully added!", false);
                txtCategory.Clear();
            }
        }
    }
}
