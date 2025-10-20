namespace BankingManagementSystem
{
    partial class EmployeeLoanForm
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
            this.lblLoginTime = new System.Windows.Forms.Label();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnLoanStatus = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dGVLoan = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel4 = new System.Windows.Forms.Panel();
            this.txtPrincipalAmount = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.namelbl = new System.Windows.Forms.Label();
            this.btnLogout = new System.Windows.Forms.Button();
            this.btnSettings = new System.Windows.Forms.Button();
            this.btnLoan = new System.Windows.Forms.Button();
            this.btnCustomer = new System.Windows.Forms.Button();
            this.btnDashboard = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.txtType = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtId = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dGVLoan)).BeginInit();
            this.panel4.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel5.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblLoginTime
            // 
            this.lblLoginTime.AutoSize = true;
            this.lblLoginTime.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLoginTime.ForeColor = System.Drawing.Color.White;
            this.lblLoginTime.Location = new System.Drawing.Point(506, 0);
            this.lblLoginTime.Name = "lblLoginTime";
            this.lblLoginTime.Size = new System.Drawing.Size(0, 21);
            this.lblLoginTime.TabIndex = 58;
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackColor = System.Drawing.Color.Gold;
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Font = new System.Drawing.Font("Segoe UI", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefresh.ForeColor = System.Drawing.Color.Black;
            this.btnRefresh.Location = new System.Drawing.Point(216, 4);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(110, 36);
            this.btnRefresh.TabIndex = 68;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.Gold;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("Segoe UI", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.ForeColor = System.Drawing.Color.Black;
            this.btnDelete.Location = new System.Drawing.Point(116, 4);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(78, 36);
            this.btnDelete.TabIndex = 67;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnLoanStatus);
            this.panel2.Controls.Add(this.btnRefresh);
            this.panel2.Controls.Add(this.btnDelete);
            this.panel2.Controls.Add(this.btnNew);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(538, 47);
            this.panel2.TabIndex = 0;
            // 
            // btnLoanStatus
            // 
            this.btnLoanStatus.BackColor = System.Drawing.Color.Gold;
            this.btnLoanStatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLoanStatus.Font = new System.Drawing.Font("Segoe UI", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoanStatus.ForeColor = System.Drawing.Color.Black;
            this.btnLoanStatus.Location = new System.Drawing.Point(344, 4);
            this.btnLoanStatus.Name = "btnLoanStatus";
            this.btnLoanStatus.Size = new System.Drawing.Size(125, 36);
            this.btnLoanStatus.TabIndex = 69;
            this.btnLoanStatus.Text = "Loan Status";
            this.btnLoanStatus.UseVisualStyleBackColor = false;
            this.btnLoanStatus.Click += new System.EventHandler(this.btnLoanStatus_Click);
            // 
            // btnNew
            // 
            this.btnNew.BackColor = System.Drawing.Color.Gold;
            this.btnNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNew.Font = new System.Drawing.Font("Segoe UI", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNew.ForeColor = System.Drawing.Color.Black;
            this.btnNew.Location = new System.Drawing.Point(16, 3);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(78, 36);
            this.btnNew.TabIndex = 66;
            this.btnNew.Text = "New";
            this.btnNew.UseVisualStyleBackColor = false;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.Gold;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.Black;
            this.btnSave.Location = new System.Drawing.Point(21, 4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(78, 36);
            this.btnSave.TabIndex = 69;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnSave);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(547, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(244, 47);
            this.panel3.TabIndex = 1;
            // 
            // dGVLoan
            // 
            this.dGVLoan.AllowUserToAddRows = false;
            this.dGVLoan.AllowUserToDeleteRows = false;
            this.dGVLoan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGVLoan.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3});
            this.dGVLoan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dGVLoan.Location = new System.Drawing.Point(0, 0);
            this.dGVLoan.Name = "dGVLoan";
            this.dGVLoan.ReadOnly = true;
            this.dGVLoan.RowHeadersWidth = 51;
            this.dGVLoan.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dGVLoan.Size = new System.Drawing.Size(538, 245);
            this.dGVLoan.TabIndex = 0;
            this.dGVLoan.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dGVLoan_CellClick);
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "L_Id";
            this.Column1.HeaderText = "ID";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 125;
            // 
            // Column2
            // 
            this.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column2.DataPropertyName = "L_Type";
            this.Column2.HeaderText = "Loan Type";
            this.Column2.MinimumWidth = 6;
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column3.DataPropertyName = "L_MaximumAmount";
            this.Column3.HeaderText = "Maximum Amount";
            this.Column3.MinimumWidth = 6;
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.dGVLoan);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(3, 56);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(538, 245);
            this.panel4.TabIndex = 2;
            // 
            // txtPrincipalAmount
            // 
            this.txtPrincipalAmount.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPrincipalAmount.Location = new System.Drawing.Point(21, 154);
            this.txtPrincipalAmount.Name = "txtPrincipalAmount";
            this.txtPrincipalAmount.Size = new System.Drawing.Size(215, 25);
            this.txtPrincipalAmount.TabIndex = 69;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel6);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(794, 134);
            this.panel1.TabIndex = 0;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.namelbl);
            this.panel6.Controls.Add(this.btnLogout);
            this.panel6.Controls.Add(this.btnSettings);
            this.panel6.Controls.Add(this.btnLoan);
            this.panel6.Controls.Add(this.btnCustomer);
            this.panel6.Controls.Add(this.btnDashboard);
            this.panel6.Controls.Add(this.label6);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(0, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(794, 134);
            this.panel6.TabIndex = 56;
            // 
            // namelbl
            // 
            this.namelbl.AutoSize = true;
            this.namelbl.BackColor = System.Drawing.Color.RoyalBlue;
            this.namelbl.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.namelbl.ForeColor = System.Drawing.Color.White;
            this.namelbl.Location = new System.Drawing.Point(40, 27);
            this.namelbl.Name = "namelbl";
            this.namelbl.Size = new System.Drawing.Size(283, 37);
            this.namelbl.TabIndex = 54;
            this.namelbl.Text = "Welcome,  Employee";
            // 
            // btnLogout
            // 
            this.btnLogout.BackColor = System.Drawing.Color.Gold;
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogout.ForeColor = System.Drawing.Color.Black;
            this.btnLogout.Location = new System.Drawing.Point(597, 80);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(120, 45);
            this.btnLogout.TabIndex = 59;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // btnSettings
            // 
            this.btnSettings.BackColor = System.Drawing.Color.Gold;
            this.btnSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSettings.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSettings.ForeColor = System.Drawing.Color.Black;
            this.btnSettings.Location = new System.Drawing.Point(467, 80);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(120, 45);
            this.btnSettings.TabIndex = 58;
            this.btnSettings.Text = "Settings";
            this.btnSettings.UseVisualStyleBackColor = false;
            this.btnSettings.Click += new System.EventHandler(this.btnSettings_Click);
            // 
            // btnLoan
            // 
            this.btnLoan.BackColor = System.Drawing.Color.Gold;
            this.btnLoan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLoan.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoan.ForeColor = System.Drawing.Color.Black;
            this.btnLoan.Location = new System.Drawing.Point(337, 80);
            this.btnLoan.Name = "btnLoan";
            this.btnLoan.Size = new System.Drawing.Size(120, 45);
            this.btnLoan.TabIndex = 1;
            this.btnLoan.Text = "Loan";
            this.btnLoan.UseVisualStyleBackColor = false;
            this.btnLoan.Click += new System.EventHandler(this.btnLoan_Click);
            // 
            // btnCustomer
            // 
            this.btnCustomer.BackColor = System.Drawing.Color.Gold;
            this.btnCustomer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCustomer.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCustomer.ForeColor = System.Drawing.Color.Black;
            this.btnCustomer.Location = new System.Drawing.Point(207, 80);
            this.btnCustomer.Name = "btnCustomer";
            this.btnCustomer.Size = new System.Drawing.Size(120, 45);
            this.btnCustomer.TabIndex = 53;
            this.btnCustomer.Text = "Customers";
            this.btnCustomer.UseVisualStyleBackColor = false;
            this.btnCustomer.Click += new System.EventHandler(this.btnCustomer_Click);
            // 
            // btnDashboard
            // 
            this.btnDashboard.BackColor = System.Drawing.Color.Gold;
            this.btnDashboard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDashboard.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDashboard.ForeColor = System.Drawing.Color.Black;
            this.btnDashboard.Location = new System.Drawing.Point(77, 80);
            this.btnDashboard.Name = "btnDashboard";
            this.btnDashboard.Size = new System.Drawing.Size(120, 45);
            this.btnDashboard.TabIndex = 56;
            this.btnDashboard.Text = "Dashboard";
            this.btnDashboard.UseVisualStyleBackColor = false;
            this.btnDashboard.Click += new System.EventHandler(this.btnDashboard_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(515, -6);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(0, 21);
            this.label6.TabIndex = 55;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(515, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 21);
            this.label1.TabIndex = 55;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.txtPrincipalAmount);
            this.panel5.Controls.Add(this.label4);
            this.panel5.Controls.Add(this.txtType);
            this.panel5.Controls.Add(this.label3);
            this.panel5.Controls.Add(this.txtId);
            this.panel5.Controls.Add(this.label2);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(547, 56);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(244, 245);
            this.panel5.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(18, 133);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(128, 17);
            this.label4.TabIndex = 68;
            this.label4.Text = "Maximum Amount:";
            // 
            // txtType
            // 
            this.txtType.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtType.Location = new System.Drawing.Point(23, 106);
            this.txtType.Name = "txtType";
            this.txtType.Size = new System.Drawing.Size(213, 25);
            this.txtType.TabIndex = 67;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(18, 84);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 17);
            this.label3.TabIndex = 66;
            this.label3.Text = "Type:";
            // 
            // txtId
            // 
            this.txtId.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtId.Location = new System.Drawing.Point(21, 58);
            this.txtId.Name = "txtId";
            this.txtId.ReadOnly = true;
            this.txtId.Size = new System.Drawing.Size(215, 25);
            this.txtId.TabIndex = 63;
            this.txtId.Text = "Auto Generated";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(18, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 17);
            this.label2.TabIndex = 61;
            this.label2.Text = "ID:";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 140F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 66.66666F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(800, 450);
            this.tableLayoutPanel1.TabIndex = 59;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 250F));
            this.tableLayoutPanel2.Controls.Add(this.panel5, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.panel4, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.panel3, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.panel2, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 143);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 53F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(794, 304);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // EmployeeLoanForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.RoyalBlue;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblLoginTime);
            this.Controls.Add(this.tableLayoutPanel1);
            this.MaximizeBox = false;
            this.Name = "EmployeeLoanForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Loan Type Management";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.EmployeeLoanForm_FormClosing);
            this.Load += new System.EventHandler(this.EmployeeLoanForm_Load);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dGVLoan)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblLoginTime;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridView dGVLoan;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TextBox txtPrincipalAmount;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtType;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label namelbl;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Button btnSettings;
        private System.Windows.Forms.Button btnLoan;
        private System.Windows.Forms.Button btnCustomer;
        private System.Windows.Forms.Button btnDashboard;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnLoanStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
    }
}