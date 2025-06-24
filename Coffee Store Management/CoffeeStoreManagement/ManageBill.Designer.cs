namespace GUI
{
    partial class ManageBill
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
            btCancel = new Button();
            btExport = new Button();
            btRemove = new Button();
            btAdd = new Button();
            dataGridView = new DataGridView();
            label3 = new Label();
            dtpBilldate = new DateTimePicker();
            txtBillID = new TextBox();
            label6 = new Label();
            label4 = new Label();
            label1 = new Label();
            cbbOrderID = new ComboBox();
            label2 = new Label();
            cbbClientID = new ComboBox();
            label7 = new Label();
            cbbEmployeeID = new ComboBox();
            nbrTotalPrice = new NumericUpDown();
            btShow = new Button();
            label5 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nbrTotalPrice).BeginInit();
            SuspendLayout();
            // 
            // btCancel
            // 
            btCancel.Location = new Point(533, 470);
            btCancel.Name = "btCancel";
            btCancel.Size = new Size(98, 35);
            btCancel.TabIndex = 10;
            btCancel.Text = "Cancel";
            btCancel.UseVisualStyleBackColor = true;
            btCancel.Click += btCancel_Click;
            // 
            // btExport
            // 
            btExport.Location = new Point(287, 470);
            btExport.Name = "btExport";
            btExport.Size = new Size(98, 35);
            btExport.TabIndex = 8;
            btExport.Text = "Export CSV";
            btExport.UseVisualStyleBackColor = true;
            btExport.Click += btExport_Click;
            // 
            // btRemove
            // 
            btRemove.Location = new Point(164, 470);
            btRemove.Name = "btRemove";
            btRemove.Size = new Size(98, 35);
            btRemove.TabIndex = 7;
            btRemove.Text = "Remove";
            btRemove.UseVisualStyleBackColor = true;
            btRemove.Click += btRemove_Click;
            // 
            // btAdd
            // 
            btAdd.Location = new Point(41, 470);
            btAdd.Name = "btAdd";
            btAdd.Size = new Size(98, 35);
            btAdd.TabIndex = 6;
            btAdd.Text = "Add";
            btAdd.UseVisualStyleBackColor = true;
            btAdd.Click += btAdd_Click;
            // 
            // dataGridView
            // 
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView.Location = new Point(21, 39);
            dataGridView.Name = "dataGridView";
            dataGridView.Size = new Size(681, 227);
            dataGridView.TabIndex = 84;
            dataGridView.CellContentClick += dataGridView_CellContentClick;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(408, 346);
            label3.Name = "label3";
            label3.Size = new Size(50, 15);
            label3.TabIndex = 83;
            label3.Text = "Bill Date";
            // 
            // dtpBilldate
            // 
            dtpBilldate.Location = new Point(488, 342);
            dtpBilldate.Name = "dtpBilldate";
            dtpBilldate.Size = new Size(195, 23);
            dtpBilldate.TabIndex = 4;
            dtpBilldate.ValueChanged += dtpBilldate_ValueChanged;
            // 
            // txtBillID
            // 
            txtBillID.Location = new Point(104, 298);
            txtBillID.Name = "txtBillID";
            txtBillID.ReadOnly = true;
            txtBillID.Size = new Size(195, 23);
            txtBillID.TabIndex = 106;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(26, 302);
            label6.Name = "label6";
            label6.Size = new Size(37, 15);
            label6.TabIndex = 105;
            label6.Text = "Bill ID";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(407, 391);
            label4.Name = "label4";
            label4.Size = new Size(61, 15);
            label4.TabIndex = 102;
            label4.Text = "Total Price";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(407, 302);
            label1.Name = "label1";
            label1.Size = new Size(51, 15);
            label1.TabIndex = 100;
            label1.Text = "Order ID";
            // 
            // cbbOrderID
            // 
            cbbOrderID.FormattingEnabled = true;
            cbbOrderID.Location = new Point(488, 298);
            cbbOrderID.Name = "cbbOrderID";
            cbbOrderID.Size = new Size(195, 23);
            cbbOrderID.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(24, 391);
            label2.Name = "label2";
            label2.Size = new Size(52, 15);
            label2.TabIndex = 98;
            label2.Text = "Client ID";
            // 
            // cbbClientID
            // 
            cbbClientID.FormattingEnabled = true;
            cbbClientID.Location = new Point(103, 387);
            cbbClientID.Name = "cbbClientID";
            cbbClientID.Size = new Size(195, 23);
            cbbClientID.TabIndex = 2;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(25, 346);
            label7.Name = "label7";
            label7.Size = new Size(73, 15);
            label7.TabIndex = 96;
            label7.Text = "Employee ID";
            // 
            // cbbEmployeeID
            // 
            cbbEmployeeID.FormattingEnabled = true;
            cbbEmployeeID.Location = new Point(104, 342);
            cbbEmployeeID.Name = "cbbEmployeeID";
            cbbEmployeeID.Size = new Size(195, 23);
            cbbEmployeeID.TabIndex = 1;
            // 
            // nbrTotalPrice
            // 
            nbrTotalPrice.Location = new Point(488, 387);
            nbrTotalPrice.Name = "nbrTotalPrice";
            nbrTotalPrice.Size = new Size(195, 23);
            nbrTotalPrice.TabIndex = 5;
            // 
            // btShow
            // 
            btShow.Location = new Point(410, 470);
            btShow.Name = "btShow";
            btShow.Size = new Size(98, 35);
            btShow.TabIndex = 9;
            btShow.Text = "Show all";
            btShow.UseVisualStyleBackColor = true;
            btShow.Click += btShow_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(277, 0);
            label5.Name = "label5";
            label5.Size = new Size(169, 21);
            label5.TabIndex = 109;
            label5.Text = "Managing Invoice Data";
            // 
            // ManageBill
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(label5);
            Controls.Add(btShow);
            Controls.Add(nbrTotalPrice);
            Controls.Add(txtBillID);
            Controls.Add(label6);
            Controls.Add(label4);
            Controls.Add(label1);
            Controls.Add(cbbOrderID);
            Controls.Add(label2);
            Controls.Add(cbbClientID);
            Controls.Add(label7);
            Controls.Add(cbbEmployeeID);
            Controls.Add(dtpBilldate);
            Controls.Add(btCancel);
            Controls.Add(btExport);
            Controls.Add(btRemove);
            Controls.Add(btAdd);
            Controls.Add(dataGridView);
            Controls.Add(label3);
            Name = "ManageBill";
            Size = new Size(723, 544);
            Load += ManageBill_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
            ((System.ComponentModel.ISupportInitialize)nbrTotalPrice).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btCancel;
        private Button btExport;
        private Button btRemove;
        private Button btAdd;
        private DataGridView dataGridView;
        private Label label3;
        private DateTimePicker dtpBilldate;
        private TextBox txtBillID;
        private Label label6;
        private Label label4;
        private Label label1;
        private ComboBox cbbOrderID;
        private Label label2;
        private ComboBox cbbClientID;
        private Label label7;
        private ComboBox cbbEmployeeID;
        private NumericUpDown nbrTotalPrice;
        private Button btShow;
        private Label label5;
    }
}
