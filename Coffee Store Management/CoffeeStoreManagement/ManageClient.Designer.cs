namespace GUI
{
    partial class ManageClient
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
            txtPhonenumber = new TextBox();
            txtAddress = new TextBox();
            label5 = new Label();
            label4 = new Label();
            txtEmail = new TextBox();
            label3 = new Label();
            txtClientID = new TextBox();
            label2 = new Label();
            txtFullname = new TextBox();
            label1 = new Label();
            btExport = new Button();
            btCancel = new Button();
            btDelete = new Button();
            btSave = new Button();
            btEdit = new Button();
            btAdd = new Button();
            dataGridView = new DataGridView();
            label6 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            SuspendLayout();
            // 
            // txtPhonenumber
            // 
            txtPhonenumber.Location = new Point(28, 433);
            txtPhonenumber.Name = "txtPhonenumber";
            txtPhonenumber.Size = new Size(198, 23);
            txtPhonenumber.TabIndex = 3;
            // 
            // txtAddress
            // 
            txtAddress.Location = new Point(261, 433);
            txtAddress.Name = "txtAddress";
            txtAddress.Size = new Size(198, 23);
            txtAddress.TabIndex = 4;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(261, 406);
            label5.Name = "label5";
            label5.Size = new Size(49, 15);
            label5.TabIndex = 60;
            label5.Text = "Address";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(28, 406);
            label4.Name = "label4";
            label4.Size = new Size(88, 15);
            label4.TabIndex = 59;
            label4.Text = "Phone Number";
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(494, 363);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(198, 23);
            txtEmail.TabIndex = 2;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(492, 336);
            label3.Name = "label3";
            label3.Size = new Size(36, 15);
            label3.TabIndex = 57;
            label3.Text = "Email";
            // 
            // txtClientID
            // 
            txtClientID.Location = new Point(28, 363);
            txtClientID.Name = "txtClientID";
            txtClientID.ReadOnly = true;
            txtClientID.Size = new Size(198, 23);
            txtClientID.TabIndex = 56;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(28, 336);
            label2.Name = "label2";
            label2.Size = new Size(52, 15);
            label2.TabIndex = 55;
            label2.Text = "Client ID";
            // 
            // txtFullname
            // 
            txtFullname.Location = new Point(261, 363);
            txtFullname.Name = "txtFullname";
            txtFullname.Size = new Size(198, 23);
            txtFullname.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(261, 336);
            label1.Name = "label1";
            label1.Size = new Size(61, 15);
            label1.TabIndex = 53;
            label1.Text = "Full Name";
            // 
            // btExport
            // 
            btExport.Location = new Point(500, 512);
            btExport.Name = "btExport";
            btExport.Size = new Size(98, 35);
            btExport.TabIndex = 9;
            btExport.Text = "Export CSV";
            btExport.UseVisualStyleBackColor = true;
            btExport.Click += btExport_Click;
            // 
            // btCancel
            // 
            btCancel.Location = new Point(618, 512);
            btCancel.Name = "btCancel";
            btCancel.Size = new Size(98, 35);
            btCancel.TabIndex = 10;
            btCancel.Text = "Cancel";
            btCancel.UseVisualStyleBackColor = true;
            btCancel.Click += btCancel_Click;
            // 
            // btDelete
            // 
            btDelete.Location = new Point(382, 512);
            btDelete.Name = "btDelete";
            btDelete.Size = new Size(98, 35);
            btDelete.TabIndex = 8;
            btDelete.Text = "Delete";
            btDelete.UseVisualStyleBackColor = true;
            btDelete.Click += btDelete_Click;
            // 
            // btSave
            // 
            btSave.Location = new Point(264, 512);
            btSave.Name = "btSave";
            btSave.Size = new Size(98, 35);
            btSave.TabIndex = 7;
            btSave.Text = "Save";
            btSave.UseVisualStyleBackColor = true;
            btSave.Click += btSave_Click;
            // 
            // btEdit
            // 
            btEdit.Location = new Point(146, 512);
            btEdit.Name = "btEdit";
            btEdit.Size = new Size(98, 35);
            btEdit.TabIndex = 6;
            btEdit.Text = "Edit";
            btEdit.UseVisualStyleBackColor = true;
            btEdit.Click += btEdit_Click;
            // 
            // btAdd
            // 
            btAdd.Location = new Point(28, 512);
            btAdd.Name = "btAdd";
            btAdd.Size = new Size(98, 35);
            btAdd.TabIndex = 5;
            btAdd.Text = "Add";
            btAdd.UseVisualStyleBackColor = true;
            btAdd.Click += btAdd_Click;
            // 
            // dataGridView
            // 
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView.Location = new Point(26, 22);
            dataGridView.Name = "dataGridView";
            dataGridView.Size = new Size(702, 288);
            dataGridView.TabIndex = 46;
            dataGridView.CellContentClick += dataGridView_CellContentClick;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.Location = new Point(261, -2);
            label6.Name = "label6";
            label6.Size = new Size(260, 21);
            label6.TabIndex = 110;
            label6.Text = "Customer Information Management";
            // 
            // ManageClient
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(label6);
            Controls.Add(txtPhonenumber);
            Controls.Add(txtAddress);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(txtEmail);
            Controls.Add(label3);
            Controls.Add(txtClientID);
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
            Name = "ManageClient";
            Size = new Size(759, 589);
            ((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtPhonenumber;
        private TextBox txtAddress;
        private Label label5;
        private Label label4;
        private TextBox txtEmail;
        private Label label3;
        private TextBox txtClientID;
        private Label label2;
        private TextBox txtFullname;
        private Label label1;
        private Button btExport;
        private Button btCancel;
        private Button btDelete;
        private Button btSave;
        private Button btEdit;
        private Button btAdd;
        private DataGridView dataGridView;
        private Label label6;
    }
}
