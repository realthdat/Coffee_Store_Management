namespace GUI
{
    partial class ManageProduct
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
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            txtProductID = new TextBox();
            label2 = new Label();
            txtProductname = new TextBox();
            label1 = new Label();
            btExport = new Button();
            btCancel = new Button();
            btDelete = new Button();
            btSave = new Button();
            btEdit = new Button();
            btAdd = new Button();
            dataGridView = new DataGridView();
            nbrPrice = new NumericUpDown();
            nbrQuantity = new NumericUpDown();
            richtxtDescription = new RichTextBox();
            btReturn = new Button();
            label10 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nbrPrice).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nbrQuantity).BeginInit();
            SuspendLayout();
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(263, 416);
            label5.Name = "label5";
            label5.Size = new Size(53, 15);
            label5.TabIndex = 78;
            label5.Text = "Quantity";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(30, 416);
            label4.Name = "label4";
            label4.Size = new Size(33, 15);
            label4.TabIndex = 77;
            label4.Text = "Price";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(494, 346);
            label3.Name = "label3";
            label3.Size = new Size(67, 15);
            label3.TabIndex = 75;
            label3.Text = "Description";
            // 
            // txtProductID
            // 
            txtProductID.Location = new Point(30, 373);
            txtProductID.Name = "txtProductID";
            txtProductID.ReadOnly = true;
            txtProductID.Size = new Size(198, 23);
            txtProductID.TabIndex = 74;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(30, 346);
            label2.Name = "label2";
            label2.Size = new Size(63, 15);
            label2.TabIndex = 73;
            label2.Text = "Product ID";
            // 
            // txtProductname
            // 
            txtProductname.Location = new Point(263, 373);
            txtProductname.Name = "txtProductname";
            txtProductname.Size = new Size(198, 23);
            txtProductname.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(263, 346);
            label1.Name = "label1";
            label1.Size = new Size(84, 15);
            label1.TabIndex = 71;
            label1.Text = "Product Name";
            // 
            // btExport
            // 
            btExport.Location = new Point(502, 522);
            btExport.Name = "btExport";
            btExport.Size = new Size(98, 35);
            btExport.TabIndex = 9;
            btExport.Text = "Export CSV";
            btExport.UseVisualStyleBackColor = true;
            btExport.Click += btExport_Click;
            // 
            // btCancel
            // 
            btCancel.Location = new Point(620, 522);
            btCancel.Name = "btCancel";
            btCancel.Size = new Size(98, 35);
            btCancel.TabIndex = 10;
            btCancel.Text = "Cancel";
            btCancel.UseVisualStyleBackColor = true;
            btCancel.Click += btCancel_Click;
            // 
            // btDelete
            // 
            btDelete.Location = new Point(384, 522);
            btDelete.Name = "btDelete";
            btDelete.Size = new Size(98, 35);
            btDelete.TabIndex = 8;
            btDelete.Text = "Delete";
            btDelete.UseVisualStyleBackColor = true;
            btDelete.Click += btDelete_Click;
            // 
            // btSave
            // 
            btSave.Location = new Point(266, 522);
            btSave.Name = "btSave";
            btSave.Size = new Size(98, 35);
            btSave.TabIndex = 7;
            btSave.Text = "Save";
            btSave.UseVisualStyleBackColor = true;
            btSave.Click += btSave_Click;
            // 
            // btEdit
            // 
            btEdit.Location = new Point(148, 522);
            btEdit.Name = "btEdit";
            btEdit.Size = new Size(98, 35);
            btEdit.TabIndex = 6;
            btEdit.Text = "Edit";
            btEdit.UseVisualStyleBackColor = true;
            btEdit.Click += btEdit_Click;
            // 
            // btAdd
            // 
            btAdd.Location = new Point(30, 522);
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
            dataGridView.Location = new Point(28, 32);
            dataGridView.Name = "dataGridView";
            dataGridView.Size = new Size(702, 288);
            dataGridView.TabIndex = 64;
            dataGridView.CellContentClick += dataGridView_CellContentClick;
            // 
            // nbrPrice
            // 
            nbrPrice.Location = new Point(30, 444);
            nbrPrice.Name = "nbrPrice";
            nbrPrice.Size = new Size(198, 23);
            nbrPrice.TabIndex = 3;
            // 
            // nbrQuantity
            // 
            nbrQuantity.Location = new Point(263, 444);
            nbrQuantity.Name = "nbrQuantity";
            nbrQuantity.Size = new Size(198, 23);
            nbrQuantity.TabIndex = 4;
            // 
            // richtxtDescription
            // 
            richtxtDescription.Location = new Point(494, 373);
            richtxtDescription.Name = "richtxtDescription";
            richtxtDescription.Size = new Size(222, 96);
            richtxtDescription.TabIndex = 2;
            richtxtDescription.Text = "";
            // 
            // btReturn
            // 
            btReturn.Location = new Point(655, 32);
            btReturn.Name = "btReturn";
            btReturn.Size = new Size(75, 23);
            btReturn.TabIndex = 84;
            btReturn.Text = "Return";
            btReturn.UseVisualStyleBackColor = true;
            btReturn.Visible = false;
            btReturn.Click += btReturn_Click;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label10.Location = new Point(286, 0);
            label10.Name = "label10";
            label10.Size = new Size(196, 21);
            label10.TabIndex = 113;
            label10.Text = "Product Data Management";
            // 
            // ManageProduct
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(label10);
            Controls.Add(richtxtDescription);
            Controls.Add(nbrQuantity);
            Controls.Add(nbrPrice);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(txtProductID);
            Controls.Add(label2);
            Controls.Add(txtProductname);
            Controls.Add(label1);
            Controls.Add(btExport);
            Controls.Add(btCancel);
            Controls.Add(btDelete);
            Controls.Add(btSave);
            Controls.Add(btEdit);
            Controls.Add(btAdd);
            Controls.Add(dataGridView);
            Controls.Add(btReturn);
            Name = "ManageProduct";
            Size = new Size(759, 589);
            Load += ManageProduct_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
            ((System.ComponentModel.ISupportInitialize)nbrPrice).EndInit();
            ((System.ComponentModel.ISupportInitialize)nbrQuantity).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label5;
        private Label label4;
        private TextBox txtEmail;
        private Label label3;
        private TextBox txtProductID;
        private Label label2;
        private TextBox txtProductname;
        private Label label1;
        private Button btExport;
        private Button btCancel;
        private Button btDelete;
        private Button btSave;
        private Button btEdit;
        private Button btAdd;
        private DataGridView dataGridView;
        private NumericUpDown nbrPrice;
        private NumericUpDown nbrQuantity;
        private RichTextBox richtxtDescription;
        private Button btReturn;
        private Label label10;
    }
}
