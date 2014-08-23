namespace budgetApp {
    partial class frmLanding {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose( bool disposing ) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            this.mnuMain = new System.Windows.Forms.MenuStrip();
            this.menuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnAccount = new System.Windows.Forms.Button();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.dgvLedger = new System.Windows.Forms.DataGridView();
            this.dgvDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvPayto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvBalance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnViewExps = new System.Windows.Forms.Button();
            this.btnAddExpense = new System.Windows.Forms.Button();
            this.btnAddBudgetCat = new System.Windows.Forms.Button();
            this.btnAddAccountCat = new System.Windows.Forms.Button();
            this.ledgerBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.mnuMain.SuspendLayout();
            this.pnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLedger)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ledgerBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // mnuMain
            // 
            this.mnuMain.BackColor = System.Drawing.SystemColors.ControlDark;
            this.mnuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuToolStripMenuItem});
            this.mnuMain.Location = new System.Drawing.Point(0, 0);
            this.mnuMain.Name = "mnuMain";
            this.mnuMain.Size = new System.Drawing.Size(1764, 24);
            this.mnuMain.TabIndex = 1;
            this.mnuMain.Text = "menu";
            // 
            // menuToolStripMenuItem
            // 
            this.menuToolStripMenuItem.Name = "menuToolStripMenuItem";
            this.menuToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.menuToolStripMenuItem.Text = "Menu";
            // 
            // btnAccount
            // 
            this.btnAccount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnAccount.Location = new System.Drawing.Point(1636, 52);
            this.btnAccount.Name = "btnAccount";
            this.btnAccount.Size = new System.Drawing.Size(116, 52);
            this.btnAccount.TabIndex = 0;
            this.btnAccount.Text = "Add Account";
            this.btnAccount.UseVisualStyleBackColor = true;
            this.btnAccount.Click += new System.EventHandler(this.btnAccount_Click);
            // 
            // pnlMain
            // 
            this.pnlMain.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlMain.Controls.Add(this.dgvLedger);
            this.pnlMain.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.pnlMain.Location = new System.Drawing.Point(12, 36);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(1618, 669);
            this.pnlMain.TabIndex = 5;
            // 
            // dgvLedger
            // 
            this.dgvLedger.AllowUserToAddRows = false;
            this.dgvLedger.AllowUserToDeleteRows = false;
            this.dgvLedger.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLedger.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvDate,
            this.dgvPayto,
            this.dgvAmount,
            this.dgvBalance});
            this.dgvLedger.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvLedger.Location = new System.Drawing.Point(0, 0);
            this.dgvLedger.Name = "dgvLedger";
            this.dgvLedger.ReadOnly = true;
            this.dgvLedger.Size = new System.Drawing.Size(1614, 665);
            this.dgvLedger.TabIndex = 6;
            this.dgvLedger.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // dgvDate
            // 
            this.dgvDate.HeaderText = "Date";
            this.dgvDate.MinimumWidth = 50;
            this.dgvDate.Name = "dgvDate";
            this.dgvDate.ReadOnly = true;
            this.dgvDate.Width = 150;
            // 
            // dgvPayto
            // 
            this.dgvPayto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dgvPayto.HeaderText = "Paid To";
            this.dgvPayto.MinimumWidth = 50;
            this.dgvPayto.Name = "dgvPayto";
            this.dgvPayto.ReadOnly = true;
            // 
            // dgvAmount
            // 
            this.dgvAmount.HeaderText = "Amount";
            this.dgvAmount.MinimumWidth = 50;
            this.dgvAmount.Name = "dgvAmount";
            this.dgvAmount.ReadOnly = true;
            this.dgvAmount.Width = 150;
            // 
            // dgvBalance
            // 
            this.dgvBalance.HeaderText = "Balance";
            this.dgvBalance.MinimumWidth = 50;
            this.dgvBalance.Name = "dgvBalance";
            this.dgvBalance.ReadOnly = true;
            this.dgvBalance.Width = 150;
            // 
            // btnViewExps
            // 
            this.btnViewExps.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnViewExps.Location = new System.Drawing.Point(1636, 330);
            this.btnViewExps.Name = "btnViewExps";
            this.btnViewExps.Size = new System.Drawing.Size(116, 52);
            this.btnViewExps.TabIndex = 4;
            this.btnViewExps.Text = "View Expenses";
            this.btnViewExps.UseVisualStyleBackColor = true;
            this.btnViewExps.Click += new System.EventHandler(this.btnViewExps_Click);
            // 
            // btnAddExpense
            // 
            this.btnAddExpense.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnAddExpense.Location = new System.Drawing.Point(1636, 258);
            this.btnAddExpense.Name = "btnAddExpense";
            this.btnAddExpense.Size = new System.Drawing.Size(116, 52);
            this.btnAddExpense.TabIndex = 3;
            this.btnAddExpense.Text = "Add Expense";
            this.btnAddExpense.UseVisualStyleBackColor = true;
            this.btnAddExpense.Click += new System.EventHandler(this.btnAddExpense_Click);
            // 
            // btnAddBudgetCat
            // 
            this.btnAddBudgetCat.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnAddBudgetCat.Location = new System.Drawing.Point(1636, 188);
            this.btnAddBudgetCat.Name = "btnAddBudgetCat";
            this.btnAddBudgetCat.Size = new System.Drawing.Size(116, 52);
            this.btnAddBudgetCat.TabIndex = 2;
            this.btnAddBudgetCat.Text = "Add Budget Category";
            this.btnAddBudgetCat.UseVisualStyleBackColor = true;
            this.btnAddBudgetCat.Click += new System.EventHandler(this.btnAddBudgetCat_Click);
            // 
            // btnAddAccountCat
            // 
            this.btnAddAccountCat.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnAddAccountCat.Location = new System.Drawing.Point(1636, 119);
            this.btnAddAccountCat.Name = "btnAddAccountCat";
            this.btnAddAccountCat.Size = new System.Drawing.Size(116, 52);
            this.btnAddAccountCat.TabIndex = 1;
            this.btnAddAccountCat.Text = "Add Account Category";
            this.btnAddAccountCat.UseVisualStyleBackColor = true;
            this.btnAddAccountCat.Click += new System.EventHandler(this.btnAddAccountCat_Click);
            // 
            // ledgerBindingSource
            // 
            this.ledgerBindingSource.DataSource = typeof(budgetApp.ledger);
            // 
            // frmLanding
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(1764, 717);
            this.Controls.Add(this.btnViewExps);
            this.Controls.Add(this.btnAddExpense);
            this.Controls.Add(this.btnAddBudgetCat);
            this.Controls.Add(this.btnAddAccountCat);
            this.Controls.Add(this.btnAccount);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.mnuMain);
            this.MainMenuStrip = this.mnuMain;
            this.Name = "frmLanding";
            this.Text = "Home Page";
            this.mnuMain.ResumeLayout(false);
            this.mnuMain.PerformLayout();
            this.pnlMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLedger)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ledgerBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mnuMain;
        private System.Windows.Forms.ToolStripMenuItem menuToolStripMenuItem;
        private System.Windows.Forms.Button btnAccount;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Button btnViewExps;
        private System.Windows.Forms.Button btnAddExpense;
        private System.Windows.Forms.Button btnAddBudgetCat;
        private System.Windows.Forms.Button btnAddAccountCat;
        private System.Windows.Forms.DataGridView dgvLedger;
        private System.Windows.Forms.BindingSource ledgerBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvPayto;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvBalance;
    }
}