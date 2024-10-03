using MIDTERM_521H0348_NguyenThanhDat;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class MainForm : Form
    {
        private string currentUserName;

        public MainForm(string userName)
        {
            InitializeComponent();

            currentUserName = userName; // Nhận tên người dùng từ màn hình đăng nhập
            lblWelcome.Text = $"Welcome {currentUserName},"; // Hiển thị lời chào người dùng


            panelContent.Controls.Clear();
            Dashboard dashboardControl = new Dashboard();
            dashboardControl.Dock = DockStyle.Fill; 
            panelContent.Controls.Add(dashboardControl);
            LoadUserControl(dashboardControl);


        }

        private void btEmployee_Click(object sender, EventArgs e)
        {
            // Clear any existing controls in the panel
            panelContent.Controls.Clear();

            // Create and add the EmployeeUserControl to the panel
            ManageEmployee employeeControl = new ManageEmployee();
            employeeControl.Dock = DockStyle.Fill;  // Optional: Makes the control fill the panel
            panelContent.Controls.Add(employeeControl);

            LoadUserControl(employeeControl);
        }

        private void LoadUserControl(UserControl control)
        {
            // Clear any existing controls in the panel or container
            panelContent.Controls.Clear();

            // Add the new UserControl to the panel or container
            control.Dock = DockStyle.Fill;
            panelContent.Controls.Add(control);

            // Resize the MainForm based on the UserControl's size
            ResizeMainForm(control);
        }

        private void ResizeMainForm(UserControl control)
        {
            // Calculate the new size for the MainForm based on the UserControl's size
            int newWidth = control.Width + (this.Width - this.ClientSize.Width);  // Adjust for form borders
            int newHeight = control.Height + (this.Height - this.ClientSize.Height);  // Adjust for form borders

            // Optionally, you can add padding to ensure a little space around the UserControl
            newWidth += 20;
            newHeight += 20;

            // Set the new size of MainForm
            this.Size = new Size(newWidth, newHeight);
        }

        private void btClient_Click(object sender, EventArgs e)
        {
            // Clear any existing controls in the panel
            panelContent.Controls.Clear();

            ManageClient clientControl = new ManageClient();
            clientControl.Dock = DockStyle.Fill;  // Optional: Makes the control fill the panel
            panelContent.Controls.Add(clientControl);

            LoadUserControl(clientControl);
        }

        private void btProduct_Click(object sender, EventArgs e)
        {
            // Clear any existing controls in the panel
            panelContent.Controls.Clear();

            ManageProduct productControl = new ManageProduct();
            productControl.Dock = DockStyle.Fill;  // Optional: Makes the control fill the panel
            panelContent.Controls.Add(productControl);

            LoadUserControl(productControl);
        }

        private void btPlaceOrder_Click(object sender, EventArgs e)
        {
            // Clear any existing controls in the panel
            panelContent.Controls.Clear();

            PlaceOrder placeOrderControl = new PlaceOrder();
            placeOrderControl.Dock = DockStyle.Fill;  // Optional: Makes the control fill the panel
            panelContent.Controls.Add(placeOrderControl);

            LoadUserControl(placeOrderControl);
        }

        private void btBill_Click(object sender, EventArgs e)
        {
            // Clear any existing controls in the panel
            panelContent.Controls.Clear();

            ManageBill manageBillControl = new ManageBill();
            manageBillControl.Dock = DockStyle.Fill;  // Optional: Makes the control fill the panel
            panelContent.Controls.Add(manageBillControl);

            LoadUserControl(manageBillControl);
        }

        private void btOrder_Click(object sender, EventArgs e)
        {
            // Clear any existing controls in the panel
            panelContent.Controls.Clear();

            ManageOrder manageOrderControl = new ManageOrder();
            manageOrderControl.Dock = DockStyle.Fill;  // Optional: Makes the control fill the panel
            panelContent.Controls.Add(manageOrderControl);

            LoadUserControl(manageOrderControl);
        }

        private void pbLogout_Click(object sender, EventArgs e)
        {
            // Confirm logout
            DialogResult result = MessageBox.Show("Are you sure you want to log out?", "Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                this.Hide(); // Ẩn MainForm hiện tại
                Login loginForm = new Login(); // Tạo lại LoginForm (giả sử bạn có form đăng nhập)
                loginForm.Show(); // Hiển thị lại LoginForm để đăng nhập
            }
        }

        private void ptbExit_Click(object sender, EventArgs e)
        {
            // Confirm before closing the application
            DialogResult result = MessageBox.Show("Are you sure you want to close the application?",
                                                  "Close Application",
                                                  MessageBoxButtons.YesNo,
                                                  MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Application.Exit(); // Đóng toàn bộ ứng dụng
            }
        }

        private void btDashboard_Click(object sender, EventArgs e)
        {
            // Clear any existing controls in the panel
            panelContent.Controls.Clear();

            Dashboard dashboardControl = new Dashboard();
            dashboardControl.Dock = DockStyle.Fill;  // Optional: Makes the control fill the panel
            panelContent.Controls.Add(dashboardControl);

            LoadUserControl(dashboardControl);
        }
    }
}
