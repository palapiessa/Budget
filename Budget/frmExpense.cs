using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace budget
{
    public partial class frmEnterExpense : Form
    {
        private budget.sqliteInterface sql = null;
        public frmEnterExpense()
        {
            InitializeComponent();
        }

        private void frmEnterExpense_Load(object sender, EventArgs e) {
            this.sql = new budget.sqliteInterface();
            this.sql.createDatabase();
        }

    }
}
