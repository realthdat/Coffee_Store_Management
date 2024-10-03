namespace GUI
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            btEmployee = new Button();
            btClient = new Button();
            btOrder = new Button();
            btProduct = new Button();
            btBill = new Button();
            btPlaceOrder = new Button();
            panelContent = new Panel();
            lblWelcome = new Label();
            pbLogout = new PictureBox();
            ptbExit = new PictureBox();
            btDashboard = new Button();
            ((System.ComponentModel.ISupportInitialize)pbLogout).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ptbExit).BeginInit();
            SuspendLayout();
            // 
            // btEmployee
            // 
            btEmployee.Location = new Point(97, 27);
            btEmployee.Name = "btEmployee";
            btEmployee.Size = new Size(80, 34);
            btEmployee.TabIndex = 2;
            btEmployee.Text = "Employee";
            btEmployee.UseVisualStyleBackColor = true;
            btEmployee.Click += btEmployee_Click;
            // 
            // btClient
            // 
            btClient.Location = new Point(182, 27);
            btClient.Name = "btClient";
            btClient.Size = new Size(80, 34);
            btClient.TabIndex = 3;
            btClient.Text = "Client";
            btClient.UseVisualStyleBackColor = true;
            btClient.Click += btClient_Click;
            // 
            // btOrder
            // 
            btOrder.Location = new Point(437, 27);
            btOrder.Name = "btOrder";
            btOrder.Size = new Size(80, 34);
            btOrder.TabIndex = 6;
            btOrder.Text = "Order";
            btOrder.UseVisualStyleBackColor = true;
            btOrder.Click += btOrder_Click;
            // 
            // btProduct
            // 
            btProduct.Location = new Point(267, 27);
            btProduct.Name = "btProduct";
            btProduct.Size = new Size(80, 34);
            btProduct.TabIndex = 4;
            btProduct.Text = "Product";
            btProduct.UseVisualStyleBackColor = true;
            btProduct.Click += btProduct_Click;
            // 
            // btBill
            // 
            btBill.Location = new Point(522, 27);
            btBill.Name = "btBill";
            btBill.Size = new Size(80, 34);
            btBill.TabIndex = 7;
            btBill.Text = "Bill";
            btBill.UseVisualStyleBackColor = true;
            btBill.Click += btBill_Click;
            // 
            // btPlaceOrder
            // 
            btPlaceOrder.Location = new Point(352, 27);
            btPlaceOrder.Name = "btPlaceOrder";
            btPlaceOrder.Size = new Size(80, 34);
            btPlaceOrder.TabIndex = 5;
            btPlaceOrder.Text = "Place Order";
            btPlaceOrder.UseVisualStyleBackColor = true;
            btPlaceOrder.Click += btPlaceOrder_Click;
            // 
            // panelContent
            // 
            panelContent.Location = new Point(12, 78);
            panelContent.Name = "panelContent";
            panelContent.Size = new Size(790, 669);
            panelContent.TabIndex = 7;
            // 
            // lblWelcome
            // 
            lblWelcome.AutoSize = true;
            lblWelcome.Font = new Font("Segoe UI", 12F);
            lblWelcome.Location = new Point(637, 40);
            lblWelcome.Name = "lblWelcome";
            lblWelcome.Size = new Size(113, 21);
            lblWelcome.TabIndex = 8;
            lblWelcome.Text = "Welcome User,";
            // 
            // pbLogout
            // 
            pbLogout.Image = (Image)resources.GetObject("pbLogout.Image");
            pbLogout.Location = new Point(787, 41);
            pbLogout.Name = "pbLogout";
            pbLogout.Size = new Size(20, 20);
            pbLogout.SizeMode = PictureBoxSizeMode.Zoom;
            pbLogout.TabIndex = 9;
            pbLogout.TabStop = false;
            pbLogout.Click += pbLogout_Click;
            // 
            // ptbExit
            // 
            ptbExit.Image = (Image)resources.GetObject("ptbExit.Image");
            ptbExit.Location = new Point(785, 4);
            ptbExit.Name = "ptbExit";
            ptbExit.Size = new Size(25, 25);
            ptbExit.SizeMode = PictureBoxSizeMode.Zoom;
            ptbExit.TabIndex = 10;
            ptbExit.TabStop = false;
            ptbExit.Click += ptbExit_Click;
            // 
            // btDashboard
            // 
            btDashboard.Location = new Point(12, 27);
            btDashboard.Name = "btDashboard";
            btDashboard.Size = new Size(80, 34);
            btDashboard.TabIndex = 1;
            btDashboard.Text = "Dashboard";
            btDashboard.UseVisualStyleBackColor = true;
            btDashboard.Click += btDashboard_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(814, 456);
            ControlBox = false;
            Controls.Add(btDashboard);
            Controls.Add(ptbExit);
            Controls.Add(pbLogout);
            Controls.Add(lblWelcome);
            Controls.Add(btBill);
            Controls.Add(btPlaceOrder);
            Controls.Add(panelContent);
            Controls.Add(btEmployee);
            Controls.Add(btOrder);
            Controls.Add(btClient);
            Controls.Add(btProduct);
            FormBorderStyle = FormBorderStyle.None;
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Pi Store Management System";
            ((System.ComponentModel.ISupportInitialize)pbLogout).EndInit();
            ((System.ComponentModel.ISupportInitialize)ptbExit).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btEmployee;
        private Button btClient;
        private Button btOrder;
        private Button btProduct;
        private Button btBill;
        private Button btPlaceOrder;
        private Panel panelContent;
        private Label lblWelcome;
        private PictureBox pbLogout;
        private PictureBox ptbExit;
        private Button btDashboard;
    }
}