namespace budgetApp
{
    partial class frmEnterExpense
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.mnuMain = new System.Windows.Forms.MenuStrip();
            this.menuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblPayTo = new System.Windows.Forms.Label();
            this.lblBudgetCategory = new System.Windows.Forms.Label();
            this.lblAccount = new System.Windows.Forms.Label();
            this.dtpPaidDate = new System.Windows.Forms.DateTimePicker();
            this.cmbPayTo = new System.Windows.Forms.ComboBox();
            this.cmbCategory = new System.Windows.Forms.ComboBox();
            this.cmbAccount = new System.Windows.Forms.ComboBox();
            this.btnEnter = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.nudAmount = new System.Windows.Forms.NumericUpDown();
            this.lblAmount = new System.Windows.Forms.Label();
            this.lbNotes = new System.Windows.Forms.Label();
            this.txtNotes = new System.Windows.Forms.TextBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.mnuMain.SuspendLayout();
            this.pnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudAmount)).BeginInit();
            this.SuspendLayout();
            // 
            // mnuMain
            // 
            this.mnuMain.BackColor = System.Drawing.SystemColors.ControlDark;
            this.mnuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuToolStripMenuItem});
            this.mnuMain.Location = new System.Drawing.Point(0, 0);
            this.mnuMain.Name = "mnuMain";
            this.mnuMain.Size = new System.Drawing.Size(532, 24);
            this.mnuMain.TabIndex = 0;
            this.mnuMain.Text = "Main Menu";
            // 
            // menuToolStripMenuItem
            // 
            this.menuToolStripMenuItem.BackColor = System.Drawing.SystemColors.ControlDark;
            this.menuToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.menuToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
            this.menuToolStripMenuItem.Name = "menuToolStripMenuItem";
            this.menuToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.menuToolStripMenuItem.Text = "Menu";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(92, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDate.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lblDate.Location = new System.Drawing.Point(51, 51);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(132, 20);
            this.lblDate.TabIndex = 1;
            this.lblDate.Text = "Date of Expense:";
            // 
            // lblPayTo
            // 
            this.lblPayTo.AutoSize = true;
            this.lblPayTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPayTo.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lblPayTo.Location = new System.Drawing.Point(122, 90);
            this.lblPayTo.Name = "lblPayTo";
            this.lblPayTo.Size = new System.Drawing.Size(61, 20);
            this.lblPayTo.TabIndex = 2;
            this.lblPayTo.Text = "Pay To:";
            // 
            // lblBudgetCategory
            // 
            this.lblBudgetCategory.AutoSize = true;
            this.lblBudgetCategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBudgetCategory.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lblBudgetCategory.Location = new System.Drawing.Point(50, 130);
            this.lblBudgetCategory.Name = "lblBudgetCategory";
            this.lblBudgetCategory.Size = new System.Drawing.Size(133, 20);
            this.lblBudgetCategory.TabIndex = 3;
            this.lblBudgetCategory.Text = "Budget Category:";
            // 
            // lblAccount
            // 
            this.lblAccount.AutoSize = true;
            this.lblAccount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAccount.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lblAccount.Location = new System.Drawing.Point(35, 172);
            this.lblAccount.Name = "lblAccount";
            this.lblAccount.Size = new System.Drawing.Size(148, 20);
            this.lblAccount.TabIndex = 4;
            this.lblAccount.Text = "Paid From Account:";
            // 
            // dtpPaidDate
            // 
            this.dtpPaidDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpPaidDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpPaidDate.Location = new System.Drawing.Point(207, 51);
            this.dtpPaidDate.MaxDate = new System.DateTime(2016, 12, 31, 0, 0, 0, 0);
            this.dtpPaidDate.MinDate = new System.DateTime(2014, 1, 1, 0, 0, 0, 0);
            this.dtpPaidDate.Name = "dtpPaidDate";
            this.dtpPaidDate.Size = new System.Drawing.Size(278, 26);
            this.dtpPaidDate.TabIndex = 1;
            // 
            // cmbPayTo
            // 
            this.cmbPayTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbPayTo.FormattingEnabled = true;
            this.cmbPayTo.Location = new System.Drawing.Point(207, 88);
            this.cmbPayTo.Name = "cmbPayTo";
            this.cmbPayTo.Size = new System.Drawing.Size(278, 28);
            this.cmbPayTo.TabIndex = 2;
            // 
            // cmbCategory
            // 
            this.cmbCategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbCategory.FormattingEnabled = true;
            this.cmbCategory.Location = new System.Drawing.Point(193, 85);
            this.cmbCategory.Name = "cmbCategory";
            this.cmbCategory.Size = new System.Drawing.Size(278, 28);
            this.cmbCategory.TabIndex = 3;
            // 
            // cmbAccount
            // 
            this.cmbAccount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbAccount.FormattingEnabled = true;
            this.cmbAccount.Location = new System.Drawing.Point(193, 127);
            this.cmbAccount.Name = "cmbAccount";
            this.cmbAccount.Size = new System.Drawing.Size(278, 28);
            this.cmbAccount.TabIndex = 4;
            // 
            // btnEnter
            // 
            this.btnEnter.FlatAppearance.BorderSize = 2;
            this.btnEnter.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEnter.Location = new System.Drawing.Point(219, 311);
            this.btnEnter.Name = "btnEnter";
            this.btnEnter.Size = new System.Drawing.Size(94, 43);
            this.btnEnter.TabIndex = 7;
            this.btnEnter.Text = "Enter Expense";
            this.btnEnter.UseVisualStyleBackColor = true;
            this.btnEnter.Click += new System.EventHandler(this.btnEnter_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.FlatAppearance.BorderSize = 2;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(342, 311);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(89, 43);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // pnlMain
            // 
            this.pnlMain.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlMain.Controls.Add(this.lblStatus);
            this.pnlMain.Controls.Add(this.txtNotes);
            this.pnlMain.Controls.Add(this.lbNotes);
            this.pnlMain.Controls.Add(this.nudAmount);
            this.pnlMain.Controls.Add(this.cmbCategory);
            this.pnlMain.Controls.Add(this.cmbAccount);
            this.pnlMain.Controls.Add(this.btnEnter);
            this.pnlMain.Controls.Add(this.lblAmount);
            this.pnlMain.Controls.Add(this.btnCancel);
            this.pnlMain.Location = new System.Drawing.Point(12, 40);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(508, 372);
            this.pnlMain.TabIndex = 7;
            // 
            // nudAmount
            // 
            this.nudAmount.DecimalPlaces = 2;
            this.nudAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudAmount.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.nudAmount.Location = new System.Drawing.Point(193, 167);
            this.nudAmount.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.nudAmount.Minimum = new decimal(new int[] {
            10000000,
            0,
            0,
            -2147483648});
            this.nudAmount.Name = "nudAmount";
            this.nudAmount.Size = new System.Drawing.Size(120, 26);
            this.nudAmount.TabIndex = 5;
            // 
            // lblAmount
            // 
            this.lblAmount.AutoSize = true;
            this.lblAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAmount.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lblAmount.Location = new System.Drawing.Point(100, 169);
            this.lblAmount.Name = "lblAmount";
            this.lblAmount.Size = new System.Drawing.Size(69, 20);
            this.lblAmount.TabIndex = 9;
            this.lblAmount.Text = "Amount:";
            this.lblAmount.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lbNotes
            // 
            this.lbNotes.AutoSize = true;
            this.lbNotes.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNotes.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lbNotes.Location = new System.Drawing.Point(114, 210);
            this.lbNotes.Name = "lbNotes";
            this.lbNotes.Size = new System.Drawing.Size(55, 20);
            this.lbNotes.TabIndex = 10;
            this.lbNotes.Text = "Notes:";
            this.lbNotes.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txtNotes
            // 
            this.txtNotes.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtNotes.Location = new System.Drawing.Point(193, 207);
            this.txtNotes.Multiline = true;
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.Size = new System.Drawing.Size(278, 88);
            this.txtNotes.TabIndex = 6;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lblStatus.Location = new System.Drawing.Point(12, 275);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(99, 20);
            this.lblStatus.TabIndex = 12;
            this.lblStatus.Text = "Status Label";
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // frmEnterExpense
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(532, 424);
            this.Controls.Add(this.cmbPayTo);
            this.Controls.Add(this.dtpPaidDate);
            this.Controls.Add(this.lblAccount);
            this.Controls.Add(this.lblBudgetCategory);
            this.Controls.Add(this.lblPayTo);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.mnuMain);
            this.Controls.Add(this.pnlMain);
            this.MainMenuStrip = this.mnuMain;
            this.Name = "frmEnterExpense";
            this.Text = "Enter Expense";
            this.Load += new System.EventHandler(this.frmEnterExpense_Load);
            this.mnuMain.ResumeLayout(false);
            this.mnuMain.PerformLayout();
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudAmount)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mnuMain;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.ToolStripMenuItem menuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.Label lblPayTo;
        private System.Windows.Forms.Label lblBudgetCategory;
        private System.Windows.Forms.Label lblAccount;
        private System.Windows.Forms.DateTimePicker dtpPaidDate;
        private System.Windows.Forms.ComboBox cmbPayTo;
        private System.Windows.Forms.ComboBox cmbCategory;
        private System.Windows.Forms.ComboBox cmbAccount;
        private System.Windows.Forms.Button btnEnter;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Label lblAmount;
        private System.Windows.Forms.NumericUpDown nudAmount;
        private System.Windows.Forms.TextBox txtNotes;
        private System.Windows.Forms.Label lbNotes;
        private System.Windows.Forms.Label lblStatus;
    }
}

