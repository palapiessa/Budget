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
            this.btnViewExps = new System.Windows.Forms.Button();
            this.btnAddExpense = new System.Windows.Forms.Button();
            this.btnAddBudgetCat = new System.Windows.Forms.Button();
            this.btnAddAccountCat = new System.Windows.Forms.Button();
            this.btnTesting = new System.Windows.Forms.Button();
            this.dtpStart = new System.Windows.Forms.DateTimePicker();
            this.dtpEnd = new System.Windows.Forms.DateTimePicker();
            this.lblEndDate = new System.Windows.Forms.Label();
            this.pnlDate = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbAccount = new System.Windows.Forms.ComboBox();
            this.pnlAccounts = new System.Windows.Forms.Panel();
            this.lblAccounts = new System.Windows.Forms.Label();
            this.accountRegisterBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ledgerBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.ledgerBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.receiveeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.amountDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.balanceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mnuMain.SuspendLayout();
            this.pnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLedger)).BeginInit();
            this.pnlDate.SuspendLayout();
            this.pnlAccounts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.accountRegisterBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ledgerBindingSource1)).BeginInit();
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
            this.mnuMain.Size = new System.Drawing.Size(1809, 24);
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
            this.btnAccount.Location = new System.Drawing.Point(1636, 304);
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
            this.pnlMain.Size = new System.Drawing.Size(1509, 669);
            this.pnlMain.TabIndex = 5;
            // 
            // dgvLedger
            // 
            this.dgvLedger.AutoGenerateColumns = false;
            this.dgvLedger.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLedger.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dateDataGridViewTextBoxColumn,
            this.receiveeDataGridViewTextBoxColumn,
            this.amountDataGridViewTextBoxColumn,
            this.balanceDataGridViewTextBoxColumn});
            this.dgvLedger.DataSource = this.accountRegisterBindingSource;
            this.dgvLedger.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvLedger.Location = new System.Drawing.Point(0, 0);
            this.dgvLedger.Name = "dgvLedger";
            this.dgvLedger.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLedger.Size = new System.Drawing.Size(1505, 665);
            this.dgvLedger.TabIndex = 0;
            this.dgvLedger.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLedger_CellContentDoubleClick);
            // 
            // btnViewExps
            // 
            this.btnViewExps.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnViewExps.Location = new System.Drawing.Point(1636, 582);
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
            this.btnAddExpense.Location = new System.Drawing.Point(1636, 510);
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
            this.btnAddBudgetCat.Location = new System.Drawing.Point(1636, 440);
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
            this.btnAddAccountCat.Location = new System.Drawing.Point(1636, 371);
            this.btnAddAccountCat.Name = "btnAddAccountCat";
            this.btnAddAccountCat.Size = new System.Drawing.Size(116, 52);
            this.btnAddAccountCat.TabIndex = 1;
            this.btnAddAccountCat.Text = "Add Account Category";
            this.btnAddAccountCat.UseVisualStyleBackColor = true;
            this.btnAddAccountCat.Click += new System.EventHandler(this.btnAddAccountCat_Click);
            // 
            // btnTesting
            // 
            this.btnTesting.Location = new System.Drawing.Point(1636, 657);
            this.btnTesting.Name = "btnTesting";
            this.btnTesting.Size = new System.Drawing.Size(116, 45);
            this.btnTesting.TabIndex = 6;
            this.btnTesting.Text = "Test Button";
            this.btnTesting.UseVisualStyleBackColor = true;
            this.btnTesting.Click += new System.EventHandler(this.btnTesting_Click);
            // 
            // dtpStart
            // 
            this.dtpStart.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpStart.Location = new System.Drawing.Point(15, 27);
            this.dtpStart.Name = "dtpStart";
            this.dtpStart.Size = new System.Drawing.Size(81, 20);
            this.dtpStart.TabIndex = 7;
            this.dtpStart.ValueChanged += new System.EventHandler(this.dtpStart_ValueChanged);
            // 
            // dtpEnd
            // 
            this.dtpEnd.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpEnd.Location = new System.Drawing.Point(15, 74);
            this.dtpEnd.Name = "dtpEnd";
            this.dtpEnd.Size = new System.Drawing.Size(81, 20);
            this.dtpEnd.TabIndex = 8;
            this.dtpEnd.ValueChanged += new System.EventHandler(this.dtpEnd_ValueChanged);
            // 
            // lblEndDate
            // 
            this.lblEndDate.AutoSize = true;
            this.lblEndDate.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.lblEndDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblEndDate.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblEndDate.Location = new System.Drawing.Point(12, 54);
            this.lblEndDate.Name = "lblEndDate";
            this.lblEndDate.Size = new System.Drawing.Size(67, 17);
            this.lblEndDate.TabIndex = 10;
            this.lblEndDate.Text = "End Date";
            // 
            // pnlDate
            // 
            this.pnlDate.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.pnlDate.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlDate.Controls.Add(this.dtpEnd);
            this.pnlDate.Controls.Add(this.lblEndDate);
            this.pnlDate.Controls.Add(this.label1);
            this.pnlDate.Controls.Add(this.dtpStart);
            this.pnlDate.Location = new System.Drawing.Point(1547, 142);
            this.pnlDate.Name = "pnlDate";
            this.pnlDate.Size = new System.Drawing.Size(120, 118);
            this.pnlDate.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(12, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 17);
            this.label1.TabIndex = 9;
            this.label1.Text = "Start Date";
            // 
            // cmbAccount
            // 
            this.cmbAccount.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.cmbAccount.FormattingEnabled = true;
            this.cmbAccount.Location = new System.Drawing.Point(15, 38);
            this.cmbAccount.Name = "cmbAccount";
            this.cmbAccount.Size = new System.Drawing.Size(182, 24);
            this.cmbAccount.TabIndex = 1;
            this.cmbAccount.SelectedIndexChanged += new System.EventHandler(this.cmbAccount_SelectedIndexChanged);
            // 
            // pnlAccounts
            // 
            this.pnlAccounts.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.pnlAccounts.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlAccounts.Controls.Add(this.lblAccounts);
            this.pnlAccounts.Controls.Add(this.cmbAccount);
            this.pnlAccounts.Location = new System.Drawing.Point(1547, 36);
            this.pnlAccounts.Name = "pnlAccounts";
            this.pnlAccounts.Size = new System.Drawing.Size(220, 100);
            this.pnlAccounts.TabIndex = 12;
            // 
            // lblAccounts
            // 
            this.lblAccounts.AutoSize = true;
            this.lblAccounts.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.lblAccounts.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblAccounts.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblAccounts.Location = new System.Drawing.Point(12, 18);
            this.lblAccounts.Name = "lblAccounts";
            this.lblAccounts.Size = new System.Drawing.Size(102, 17);
            this.lblAccounts.TabIndex = 10;
            this.lblAccounts.Text = "Select Account";
            // 
            // accountRegisterBindingSource
            // 
            this.accountRegisterBindingSource.DataSource = typeof(budgetApp.accountRegister);
            // 
            // ledgerBindingSource1
            // 
            this.ledgerBindingSource1.DataSource = typeof(budgetApp.ledger);
            // 
            // ledgerBindingSource
            // 
            this.ledgerBindingSource.DataSource = typeof(budgetApp.ledger);
            // 
            // dateDataGridViewTextBoxColumn
            // 
            this.dateDataGridViewTextBoxColumn.DataPropertyName = "date";
            this.dateDataGridViewTextBoxColumn.HeaderText = "Date";
            this.dateDataGridViewTextBoxColumn.MinimumWidth = 100;
            this.dateDataGridViewTextBoxColumn.Name = "dateDataGridViewTextBoxColumn";
            this.dateDataGridViewTextBoxColumn.Width = 150;
            // 
            // receiveeDataGridViewTextBoxColumn
            // 
            this.receiveeDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.receiveeDataGridViewTextBoxColumn.DataPropertyName = "receivee";
            this.receiveeDataGridViewTextBoxColumn.HeaderText = "Name";
            this.receiveeDataGridViewTextBoxColumn.MinimumWidth = 70;
            this.receiveeDataGridViewTextBoxColumn.Name = "receiveeDataGridViewTextBoxColumn";
            // 
            // amountDataGridViewTextBoxColumn
            // 
            this.amountDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.amountDataGridViewTextBoxColumn.DataPropertyName = "amount";
            this.amountDataGridViewTextBoxColumn.HeaderText = "Transaction Amount";
            this.amountDataGridViewTextBoxColumn.Name = "amountDataGridViewTextBoxColumn";
            this.amountDataGridViewTextBoxColumn.Width = 146;
            // 
            // balanceDataGridViewTextBoxColumn
            // 
            this.balanceDataGridViewTextBoxColumn.DataPropertyName = "balance";
            this.balanceDataGridViewTextBoxColumn.HeaderText = "Balance";
            this.balanceDataGridViewTextBoxColumn.Name = "balanceDataGridViewTextBoxColumn";
            // 
            // frmLanding
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(1809, 717);
            this.Controls.Add(this.pnlAccounts);
            this.Controls.Add(this.btnTesting);
            this.Controls.Add(this.btnViewExps);
            this.Controls.Add(this.btnAddExpense);
            this.Controls.Add(this.btnAddBudgetCat);
            this.Controls.Add(this.btnAddAccountCat);
            this.Controls.Add(this.btnAccount);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.mnuMain);
            this.Controls.Add(this.pnlDate);
            this.MainMenuStrip = this.mnuMain;
            this.Name = "frmLanding";
            this.Text = "Home Page";
            this.Load += new System.EventHandler(this.frmLanding_Load);
            this.mnuMain.ResumeLayout(false);
            this.mnuMain.PerformLayout();
            this.pnlMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLedger)).EndInit();
            this.pnlDate.ResumeLayout(false);
            this.pnlDate.PerformLayout();
            this.pnlAccounts.ResumeLayout(false);
            this.pnlAccounts.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.accountRegisterBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ledgerBindingSource1)).EndInit();
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
        private System.Windows.Forms.BindingSource ledgerBindingSource;
        private System.Windows.Forms.Button btnTesting;
        private System.Windows.Forms.BindingSource ledgerBindingSource1;
        private System.Windows.Forms.BindingSource accountRegisterBindingSource;
        private System.Windows.Forms.DataGridView dgvLedger;
        private System.Windows.Forms.DateTimePicker dtpStart;
        private System.Windows.Forms.DateTimePicker dtpEnd;
        private System.Windows.Forms.Label lblEndDate;
        private System.Windows.Forms.Panel pnlDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbAccount;
        private System.Windows.Forms.Panel pnlAccounts;
        private System.Windows.Forms.Label lblAccounts;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn receiveeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn amountDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn balanceDataGridViewTextBoxColumn;
    }
}