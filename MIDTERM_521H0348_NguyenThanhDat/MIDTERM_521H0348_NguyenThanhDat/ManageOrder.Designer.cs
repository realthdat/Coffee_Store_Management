namespace GUI
{
    partial class ManageOrder
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
            txtOrderItemID = new TextBox();
            label6 = new Label();
            btCancel = new Button();
            btExport = new Button();
            dataGridView = new DataGridView();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            label4 = new Label();
            txtProductName = new TextBox();
            txtQuantity = new TextBox();
            label5 = new Label();
            txtTotalPrice = new TextBox();
            label7 = new Label();
            dtpOrderDate = new DateTimePicker();
            label8 = new Label();
            label9 = new Label();
            txtEmployeeID = new TextBox();
            txtClientID = new TextBox();
            txtProductID = new TextBox();
            txtOrderID = new TextBox();
            label10 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            SuspendLayout();
            // 
            // txtOrderItemID
            // 
            txtOrderItemID.Location = new Point(99, 287);
            txtOrderItemID.Name = "txtOrderItemID";
            txtOrderItemID.ReadOnly = true;
            txtOrderItemID.Size = new Size(193, 23);
            txtOrderItemID.TabIndex = 95;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(20, 290);
            label6.Name = "label6";
            label6.Size = new Size(78, 15);
            label6.TabIndex = 94;
            label6.Text = "Order Item ID";
            // 
            // btCancel
            // 
            btCancel.Location = new Point(144, 505);
            btCancel.Name = "btCancel";
            btCancel.Size = new Size(98, 35);
            btCancel.TabIndex = 2;
            btCancel.Text = "Cancel";
            btCancel.UseVisualStyleBackColor = true;
            btCancel.Click += btCancel_Click;
            // 
            // btExport
            // 
            btExport.Location = new Point(26, 505);
            btExport.Name = "btExport";
            btExport.Size = new Size(98, 35);
            btExport.TabIndex = 1;
            btExport.Text = "Export CSV";
            btExport.UseVisualStyleBackColor = true;
            btExport.Click += btExport_Click;
            // 
            // dataGridView
            // 
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView.Location = new Point(21, 22);
            dataGridView.Name = "dataGridView";
            dataGridView.Size = new Size(699, 234);
            dataGridView.TabIndex = 84;
            dataGridView.CellContentClick += dataGridView_CellContentClick;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(346, 290);
            label3.Name = "label3";
            label3.Size = new Size(63, 15);
            label3.TabIndex = 83;
            label3.Text = "Product ID";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(20, 428);
            label2.Name = "label2";
            label2.Size = new Size(52, 15);
            label2.TabIndex = 81;
            label2.Text = "Client ID";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(20, 382);
            label1.Name = "label1";
            label1.Size = new Size(73, 15);
            label1.TabIndex = 79;
            label1.Text = "Employee ID";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(346, 335);
            label4.Name = "label4";
            label4.Size = new Size(84, 15);
            label4.TabIndex = 97;
            label4.Text = "Product Name";
            // 
            // txtProductName
            // 
            txtProductName.Location = new Point(436, 331);
            txtProductName.Name = "txtProductName";
            txtProductName.ReadOnly = true;
            txtProductName.Size = new Size(193, 23);
            txtProductName.TabIndex = 98;
            // 
            // txtQuantity
            // 
            txtQuantity.Location = new Point(436, 379);
            txtQuantity.Name = "txtQuantity";
            txtQuantity.ReadOnly = true;
            txtQuantity.Size = new Size(193, 23);
            txtQuantity.TabIndex = 100;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(346, 383);
            label5.Name = "label5";
            label5.Size = new Size(53, 15);
            label5.TabIndex = 99;
            label5.Text = "Quantity";
            // 
            // txtTotalPrice
            // 
            txtTotalPrice.Location = new Point(436, 425);
            txtTotalPrice.Name = "txtTotalPrice";
            txtTotalPrice.ReadOnly = true;
            txtTotalPrice.Size = new Size(193, 23);
            txtTotalPrice.TabIndex = 102;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(346, 429);
            label7.Name = "label7";
            label7.Size = new Size(61, 15);
            label7.TabIndex = 101;
            label7.Text = "Total Price";
            // 
            // dtpOrderDate
            // 
            dtpOrderDate.Enabled = false;
            dtpOrderDate.Location = new Point(436, 475);
            dtpOrderDate.Name = "dtpOrderDate";
            dtpOrderDate.Size = new Size(193, 23);
            dtpOrderDate.TabIndex = 103;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(346, 479);
            label8.Name = "label8";
            label8.Size = new Size(63, 15);
            label8.TabIndex = 104;
            label8.Text = "Order date";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(20, 335);
            label9.Name = "label9";
            label9.Size = new Size(51, 15);
            label9.TabIndex = 106;
            label9.Text = "Order ID";
            // 
            // txtEmployeeID
            // 
            txtEmployeeID.Location = new Point(99, 379);
            txtEmployeeID.Name = "txtEmployeeID";
            txtEmployeeID.ReadOnly = true;
            txtEmployeeID.Size = new Size(193, 23);
            txtEmployeeID.TabIndex = 107;
            // 
            // txtClientID
            // 
            txtClientID.Location = new Point(99, 425);
            txtClientID.Name = "txtClientID";
            txtClientID.ReadOnly = true;
            txtClientID.Size = new Size(193, 23);
            txtClientID.TabIndex = 108;
            // 
            // txtProductID
            // 
            txtProductID.Location = new Point(436, 287);
            txtProductID.Name = "txtProductID";
            txtProductID.ReadOnly = true;
            txtProductID.Size = new Size(193, 23);
            txtProductID.TabIndex = 109;
            // 
            // txtOrderID
            // 
            txtOrderID.Location = new Point(99, 331);
            txtOrderID.Name = "txtOrderID";
            txtOrderID.ReadOnly = true;
            txtOrderID.Size = new Size(193, 23);
            txtOrderID.TabIndex = 110;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label10.Location = new Point(283, -2);
            label10.Name = "label10";
            label10.Size = new Size(147, 21);
            label10.TabIndex = 112;
            label10.Text = "Order Data Viewing";
            // 
            // ManageOrder
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(label10);
            Controls.Add(txtOrderID);
            Controls.Add(txtProductID);
            Controls.Add(txtClientID);
            Controls.Add(txtEmployeeID);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(dtpOrderDate);
            Controls.Add(txtTotalPrice);
            Controls.Add(label7);
            Controls.Add(txtQuantity);
            Controls.Add(label5);
            Controls.Add(txtProductName);
            Controls.Add(label4);
            Controls.Add(txtOrderItemID);
            Controls.Add(label6);
            Controls.Add(btCancel);
            Controls.Add(btExport);
            Controls.Add(dataGridView);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "ManageOrder";
            Size = new Size(742, 569);
            ((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtOrderItemID;
        private Label label6;
        private Button btCancel;
        private Button btExport;
        private DataGridView dataGridView;
        private Label label3;
        private Label label2;
        private Label label1;
        private Label label4;
        private TextBox txtProductName;
        private TextBox txtQuantity;
        private Label label5;
        private TextBox txtTotalPrice;
        private Label label7;
        private DateTimePicker dtpOrderDate;
        private Label label8;
        private Label label9;
        private TextBox txtEmployeeID;
        private TextBox txtClientID;
        private TextBox txtProductID;
        private TextBox txtOrderID;
        private Label label10;
    }
}
