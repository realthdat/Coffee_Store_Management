namespace GUI
{
    partial class Dashboard
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
            chartTotalBills = new FastReport.DataVisualization.Charting.Chart();
            chartTotalPrice = new FastReport.DataVisualization.Charting.Chart();
            button1 = new Button();
            label1 = new Label();
            label2 = new Label();
            button2 = new Button();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            ((System.ComponentModel.ISupportInitialize)chartTotalBills).BeginInit();
            ((System.ComponentModel.ISupportInitialize)chartTotalPrice).BeginInit();
            SuspendLayout();
            // 
            // chartTotalBills
            // 
            chartTotalBills.Location = new Point(18, 39);
            chartTotalBills.Name = "chartTotalBills";
            chartTotalBills.Size = new Size(354, 453);
            chartTotalBills.TabIndex = 1;
            chartTotalBills.Text = "chart1";
            // 
            // chartTotalPrice
            // 
            chartTotalPrice.Location = new Point(401, 39);
            chartTotalPrice.Name = "chartTotalPrice";
            chartTotalPrice.Size = new Size(347, 453);
            chartTotalPrice.TabIndex = 2;
            chartTotalPrice.Text = "chart2";
            // 
            // button1
            // 
            button1.BackColor = Color.Orange;
            button1.Location = new Point(50, 437);
            button1.Name = "button1";
            button1.Size = new Size(31, 22);
            button1.TabIndex = 2;
            button1.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = SystemColors.Control;
            label1.Location = new Point(87, 441);
            label1.Name = "label1";
            label1.Size = new Size(65, 15);
            label1.TabIndex = 3;
            label1.Text = "Today's bill";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(87, 467);
            label2.Name = "label2";
            label2.Size = new Size(51, 15);
            label2.TabIndex = 5;
            label2.Text = "Total bill";
            // 
            // button2
            // 
            button2.BackColor = Color.FromArgb(0, 122, 204);
            button2.Location = new Point(50, 463);
            button2.Name = "button2";
            button2.Size = new Size(31, 22);
            button2.TabIndex = 4;
            button2.UseVisualStyleBackColor = false;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 11.25F);
            label3.Location = new Point(96, 502);
            label3.Name = "label3";
            label3.Size = new Size(210, 20);
            label3.TabIndex = 6;
            label3.Text = "Invoice Quantity Bills Pie Chart";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 11.25F);
            label4.Location = new Point(473, 502);
            label4.Name = "label4";
            label4.Size = new Size(224, 20);
            label4.TabIndex = 7;
            label4.Text = "Store Income Statistics Bar Chart";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(330, 0);
            label5.Name = "label5";
            label5.Size = new Size(103, 21);
            label5.TabIndex = 8;
            label5.Text = "DASHBOARD";
            // 
            // Dashboard
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(button2);
            Controls.Add(label1);
            Controls.Add(button1);
            Controls.Add(chartTotalPrice);
            Controls.Add(chartTotalBills);
            Name = "Dashboard";
            Size = new Size(779, 544);
            ((System.ComponentModel.ISupportInitialize)chartTotalBills).EndInit();
            ((System.ComponentModel.ISupportInitialize)chartTotalPrice).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private FastReport.DataVisualization.Charting.Chart chartTotalBills;
        private FastReport.DataVisualization.Charting.Chart chartTotalPrice;
        private Button button1;
        private Label label1;
        private Label label2;
        private Button button2;
        private Label label3;
        private Label label4;
        private Label label5;
    }
}
