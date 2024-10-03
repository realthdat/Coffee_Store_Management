namespace GUI
{
    partial class ManageEmployee
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dataGridView = new DataGridView();
            btAdd = new Button();
            btEdit = new Button();
            btSave = new Button();
            btDelete = new Button();
            btCancel = new Button();
            btExport = new Button();
            label1 = new Label();
            txtFullname = new TextBox();
            txtEmployeeID = new TextBox();
            label2 = new Label();
            txtEmail = new TextBox();
            label3 = new Label();
            label4 = new Label();
            txtAddress = new TextBox();
            label5 = new Label();
            label6 = new Label();
            txtPhonenumber = new TextBox();
            nbrSalary = new NumericUpDown();
            label7 = new Label();
            dtpickerHireDate = new DateTimePicker();
            label8 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nbrSalary).BeginInit();
            SuspendLayout();
            // 
            // dataGridView
            // 
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView.Location = new Point(26, 24);
            dataGridView.Name = "dataGridView";
            dataGridView.Size = new Size(735, 288);
            dataGridView.TabIndex = 0;
            dataGridView.CellContentClick += dataGridView_CellContentClick;
            // 
            // btAdd
            // 
            btAdd.Location = new Point(31, 566);
            btAdd.Name = "btAdd";
            btAdd.Size = new Size(98, 35);
            btAdd.TabIndex = 7;
            btAdd.Text = "Add";
            btAdd.UseVisualStyleBackColor = true;
            btAdd.Click += btAdd_Click;
            // 
            // btEdit
            // 
            btEdit.Location = new Point(149, 566);
            btEdit.Name = "btEdit";
            btEdit.Size = new Size(98, 35);
            btEdit.TabIndex = 8;
            btEdit.Text = "Edit";
            btEdit.UseVisualStyleBackColor = true;
            btEdit.Click += btEdit_Click;
            // 
            // btSave
            // 
            btSave.Location = new Point(267, 566);
            btSave.Name = "btSave";
            btSave.Size = new Size(98, 35);
            btSave.TabIndex = 9;
            btSave.Text = "Save";
            btSave.UseVisualStyleBackColor = true;
            btSave.Click += btSave_Click;
            // 
            // btDelete
            // 
            btDelete.Location = new Point(385, 566);
            btDelete.Name = "btDelete";
            btDelete.Size = new Size(98, 35);
            btDelete.TabIndex = 10;
            btDelete.Text = "Delete";
            btDelete.UseVisualStyleBackColor = true;
            btDelete.Click += btDelete_Click;
            // 
            // btCancel
            // 
            btCancel.Location = new Point(621, 566);
            btCancel.Name = "btCancel";
            btCancel.Size = new Size(98, 35);
            btCancel.TabIndex = 12;
            btCancel.Text = "Cancel";
            btCancel.UseVisualStyleBackColor = true;
            btCancel.Click += btCancel_Click;
            // 
            // btExport
            // 
            btExport.Location = new Point(503, 566);
            btExport.Name = "btExport";
            btExport.Size = new Size(98, 35);
            btExport.TabIndex = 11;
            btExport.Text = "Export CSV";
            btExport.UseVisualStyleBackColor = true;
            btExport.Click += btExport_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(261, 338);
            label1.Name = "label1";
            label1.Size = new Size(61, 15);
            label1.TabIndex = 7;
            label1.Text = "Full Name";
            // 
            // txtFullname
            // 
            txtFullname.Location = new Point(261, 365);
            txtFullname.Name = "txtFullname";
            txtFullname.Size = new Size(198, 23);
            txtFullname.TabIndex = 1;
            // 
            // txtEmployeeID
            // 
            txtEmployeeID.Location = new Point(28, 365);
            txtEmployeeID.Name = "txtEmployeeID";
            txtEmployeeID.ReadOnly = true;
            txtEmployeeID.Size = new Size(198, 23);
            txtEmployeeID.TabIndex = 10;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(28, 338);
            label2.Name = "label2";
            label2.Size = new Size(73, 15);
            label2.TabIndex = 9;
            label2.Text = "Employee ID";
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(494, 365);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(198, 23);
            txtEmail.TabIndex = 2;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(492, 338);
            label3.Name = "label3";
            label3.Size = new Size(36, 15);
            label3.TabIndex = 11;
            label3.Text = "Email";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(28, 408);
            label4.Name = "label4";
            label4.Size = new Size(88, 15);
            label4.TabIndex = 13;
            label4.Text = "Phone Number";
            // 
            // txtAddress
            // 
            txtAddress.Location = new Point(261, 435);
            txtAddress.Name = "txtAddress";
            txtAddress.Size = new Size(198, 23);
            txtAddress.TabIndex = 4;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(261, 408);
            label5.Name = "label5";
            label5.Size = new Size(49, 15);
            label5.TabIndex = 15;
            label5.Text = "Address";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(494, 408);
            label6.Name = "label6";
            label6.Size = new Size(38, 15);
            label6.TabIndex = 17;
            label6.Text = "Salary";
            // 
            // txtPhonenumber
            // 
            txtPhonenumber.Location = new Point(28, 435);
            txtPhonenumber.Name = "txtPhonenumber";
            txtPhonenumber.Size = new Size(198, 23);
            txtPhonenumber.TabIndex = 3;
            // 
            // nbrSalary
            // 
            nbrSalary.ImeMode = ImeMode.NoControl;
            nbrSalary.Location = new Point(494, 436);
            nbrSalary.Margin = new Padding(3, 2, 3, 2);
            nbrSalary.Name = "nbrSalary";
            nbrSalary.Size = new Size(198, 23);
            nbrSalary.TabIndex = 5;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(28, 494);
            label7.Name = "label7";
            label7.Size = new Size(56, 15);
            label7.TabIndex = 44;
            label7.Text = "Hire Date";
            // 
            // dtpickerHireDate
            // 
            dtpickerHireDate.Location = new Point(90, 488);
            dtpickerHireDate.Name = "dtpickerHireDate";
            dtpickerHireDate.Size = new Size(200, 23);
            dtpickerHireDate.TabIndex = 6;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label8.Location = new Point(248, 0);
            label8.Name = "label8";
            label8.Size = new Size(260, 21);
            label8.TabIndex = 111;
            label8.Text = "Employee Information Management";
            // 
            // ManageEmployee
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(label8);
            Controls.Add(dtpickerHireDate);
            Controls.Add(label7);
            Controls.Add(nbrSalary);
            Controls.Add(txtPhonenumber);
            Controls.Add(label6);
            Controls.Add(txtAddress);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(txtEmail);
            Controls.Add(label3);
            Controls.Add(txtEmployeeID);
            Controls.Add(label2);
            Controls.Add(txtFullname);
            Controls.Add(label1);
            Controls.Add(btExport);
            Controls.Add(btCancel);
            Controls.Add(btDelete);
            Controls.Add(btSave);
            Controls.Add(btEdit);
            Controls.Add(btAdd);
            Controls.Add(dataGridView);
            Name = "ManageEmployee";
            Size = new Size(793, 645);
            Load += ManageEmployee_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
            ((System.ComponentModel.ISupportInitialize)nbrSalary).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView;
        private Button btAdd;
        private Button btEdit;
        private Button btSave;
        private Button btDelete;
        private Button btCancel;
        private Button btExport;
        private Label label1;
        private TextBox txtFullname;
        private TextBox txtEmployeeID;
        private Label label2;
        private TextBox txtEmail;
        private Label label3;
        private Label label4;
        private TextBox txtAddress;
        private Label label5;
        private Label label6;
        private TextBox txtPhonenumber;
        private NumericUpDown nbrSalary;
        private Label label7;
        private DateTimePicker dtpickerHireDate;
        private Label label8;
    }
}
