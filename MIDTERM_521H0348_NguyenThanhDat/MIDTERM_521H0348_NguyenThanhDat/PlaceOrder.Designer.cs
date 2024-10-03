namespace GUI
{
    partial class PlaceOrder
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
            cbbEmployeeID = new ComboBox();
            label1 = new Label();
            label2 = new Label();
            cbbClientID = new ComboBox();
            label3 = new Label();
            cbbProductID = new ComboBox();
            dataGridView = new DataGridView();
            nbrTotalPrice = new NumericUpDown();
            label4 = new Label();
            label5 = new Label();
            nbrQuantity = new NumericUpDown();
            btCancel = new Button();
            btExport = new Button();
            btPlaceOrder = new Button();
            btRemove = new Button();
            btAdd = new Button();
            label6 = new Label();
            txtOrderID = new TextBox();
            label10 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nbrTotalPrice).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nbrQuantity).BeginInit();
            SuspendLayout();
            // 
            // cbbEmployeeID
            // 
            cbbEmployeeID.FormattingEnabled = true;
            cbbEmployeeID.Location = new Point(98, 316);
            cbbEmployeeID.Name = "cbbEmployeeID";
            cbbEmployeeID.Size = new Size(169, 23);
            cbbEmployeeID.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(19, 320);
            label1.Name = "label1";
            label1.Size = new Size(73, 15);
            label1.TabIndex = 1;
            label1.Text = "Employee ID";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(19, 372);
            label2.Name = "label2";
            label2.Size = new Size(52, 15);
            label2.TabIndex = 3;
            label2.Text = "Client ID";
            // 
            // cbbClientID
            // 
            cbbClientID.FormattingEnabled = true;
            cbbClientID.Location = new Point(98, 368);
            cbbClientID.Name = "cbbClientID";
            cbbClientID.Size = new Size(169, 23);
            cbbClientID.TabIndex = 2;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(345, 270);
            label3.Name = "label3";
            label3.Size = new Size(63, 15);
            label3.TabIndex = 5;
            label3.Text = "Product ID";
            // 
            // cbbProductID
            // 
            cbbProductID.FormattingEnabled = true;
            cbbProductID.Location = new Point(426, 266);
            cbbProductID.Name = "cbbProductID";
            cbbProductID.Size = new Size(169, 23);
            cbbProductID.TabIndex = 3;
            // 
            // dataGridView
            // 
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView.Location = new Point(20, 22);
            dataGridView.Name = "dataGridView";
            dataGridView.Size = new Size(681, 217);
            dataGridView.TabIndex = 6;
            dataGridView.CellContentClick += dataGridView_CellContentClick;
            // 
            // nbrTotalPrice
            // 
            nbrTotalPrice.Enabled = false;
            nbrTotalPrice.Location = new Point(426, 368);
            nbrTotalPrice.Name = "nbrTotalPrice";
            nbrTotalPrice.ReadOnly = true;
            nbrTotalPrice.Size = new Size(169, 23);
            nbrTotalPrice.TabIndex = 7;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(345, 372);
            label4.Name = "label4";
            label4.Size = new Size(61, 15);
            label4.TabIndex = 8;
            label4.Text = "Total Price";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(345, 320);
            label5.Name = "label5";
            label5.Size = new Size(53, 15);
            label5.TabIndex = 10;
            label5.Text = "Quantity";
            // 
            // nbrQuantity
            // 
            nbrQuantity.Location = new Point(426, 316);
            nbrQuantity.Name = "nbrQuantity";
            nbrQuantity.Size = new Size(169, 23);
            nbrQuantity.TabIndex = 4;
            // 
            // btCancel
            // 
            btCancel.Location = new Point(512, 453);
            btCancel.Name = "btCancel";
            btCancel.Size = new Size(98, 35);
            btCancel.TabIndex = 9;
            btCancel.Text = "Cancel";
            btCancel.UseVisualStyleBackColor = true;
            btCancel.Click += btCancel_Click;
            // 
            // btExport
            // 
            btExport.Location = new Point(394, 453);
            btExport.Name = "btExport";
            btExport.Size = new Size(98, 35);
            btExport.TabIndex = 8;
            btExport.Text = "Export CSV";
            btExport.UseVisualStyleBackColor = true;
            btExport.Click += btExport_Click;
            // 
            // btPlaceOrder
            // 
            btPlaceOrder.Location = new Point(276, 453);
            btPlaceOrder.Name = "btPlaceOrder";
            btPlaceOrder.Size = new Size(98, 35);
            btPlaceOrder.TabIndex = 7;
            btPlaceOrder.Text = "Place Order";
            btPlaceOrder.UseVisualStyleBackColor = true;
            btPlaceOrder.Click += btPlaceOrder_Click;
            // 
            // btRemove
            // 
            btRemove.Location = new Point(158, 453);
            btRemove.Name = "btRemove";
            btRemove.Size = new Size(98, 35);
            btRemove.TabIndex = 6;
            btRemove.Text = "Remove";
            btRemove.UseVisualStyleBackColor = true;
            btRemove.Click += btRemove_Click;
            // 
            // btAdd
            // 
            btAdd.Location = new Point(40, 453);
            btAdd.Name = "btAdd";
            btAdd.Size = new Size(98, 35);
            btAdd.TabIndex = 5;
            btAdd.Text = "Add";
            btAdd.UseVisualStyleBackColor = true;
            btAdd.Click += btAdd_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(20, 270);
            label6.Name = "label6";
            label6.Size = new Size(75, 15);
            label6.TabIndex = 76;
            label6.Text = "OrderItem ID";
            // 
            // txtOrderID
            // 
            txtOrderID.Location = new Point(98, 266);
            txtOrderID.Name = "txtOrderID";
            txtOrderID.ReadOnly = true;
            txtOrderID.Size = new Size(169, 23);
            txtOrderID.TabIndex = 77;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label10.Location = new Point(211, 0);
            label10.Name = "label10";
            label10.Size = new Size(297, 21);
            label10.TabIndex = 114;
            label10.Text = "Place Order based on Customer Requests";
            // 
            // PlaceOrder
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(label10);
            Controls.Add(txtOrderID);
            Controls.Add(label6);
            Controls.Add(btCancel);
            Controls.Add(btExport);
            Controls.Add(btPlaceOrder);
            Controls.Add(btRemove);
            Controls.Add(btAdd);
            Controls.Add(label5);
            Controls.Add(nbrQuantity);
            Controls.Add(label4);
            Controls.Add(nbrTotalPrice);
            Controls.Add(dataGridView);
            Controls.Add(label3);
            Controls.Add(cbbProductID);
            Controls.Add(label2);
            Controls.Add(cbbClientID);
            Controls.Add(label1);
            Controls.Add(cbbEmployeeID);
            Name = "PlaceOrder";
            Size = new Size(723, 544);
            Load += PlaceOrder_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
            ((System.ComponentModel.ISupportInitialize)nbrTotalPrice).EndInit();
            ((System.ComponentModel.ISupportInitialize)nbrQuantity).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cbbEmployeeID;
        private Label label1;
        private Label label2;
        private ComboBox cbbClientID;
        private Label label3;
        private ComboBox cbbProductID;
        private DataGridView dataGridView;
        private NumericUpDown nbrTotalPrice;
        private Label label4;
        private Label label5;
        private NumericUpDown nbrQuantity;
        private Button btCancel;
        private Button btExport;
        private Button btPlaceOrder;
        private Button btRemove;
        private Button btAdd;
        private Label label6;
        private TextBox txtOrderID;
        private Label label10;
    }
}
