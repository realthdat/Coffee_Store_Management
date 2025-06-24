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
    public partial class ManageBill : UserControl
    {

        private BUS_Orders busOrder = new BUS_Orders();
        private BUS_OrderItem busOrderItem = new BUS_OrderItem();
        private BUS_Product busProduct = new BUS_Product();
        private BUS_Employee busEmployee = new BUS_Employee();
        private BUS_Client busClient = new BUS_Client();
        private BUS_Bill busBill = new BUS_Bill();

        public ManageBill()
        {
            InitializeComponent();
            LoadComboBoxData();
            LoadBillData();
        }

        private void LoadComboBoxData()
        {
            // Load Order Data
            List<DTO_Order> orders = busOrder.GetAllOrders();
            cbbOrderID.DataSource = orders;
            cbbOrderID.DisplayMember = "ID";    // Display Order ID
            cbbOrderID.ValueMember = "ID";      // Value to use (Order ID)

            // Load Employee Data
            List<DTO_Employee> employees = busEmployee.GetAllEmployees();
            cbbEmployeeID.DataSource = employees;
            cbbEmployeeID.DisplayMember = "Name";  // Name of the employee to display
            cbbEmployeeID.ValueMember = "ID";      // Value to use (Employee ID)

            // Load Client Data
            List<DTO_Client> clients = busClient.GetAllClients();
            cbbClientID.DataSource = clients;
            cbbClientID.DisplayMember = "Name";  // Name of the client to display
            cbbClientID.ValueMember = "ID";      // Value to use (Client ID)
        }

        private void ClearForm()
        {
            txtBillID.Clear();
            cbbOrderID.SelectedIndex = -1;
            cbbEmployeeID.SelectedIndex = -1;
            cbbClientID.SelectedIndex = -1;
            dtpBilldate.Value = DateTime.Now;  // Reset to current date
            nbrTotalPrice.Value = 0;           // Reset price
        }

        private void LoadBillData()
        {
            dataGridView.DataSource = busBill.GetAllBills();  // Fetch all bills from the database

            // Ensure the correct column names are being set
            dataGridView.Columns["ID"].HeaderText = "Bill ID";
            dataGridView.Columns["OrderID"].HeaderText = "Order ID";
            dataGridView.Columns["ClientID"].HeaderText = "Client ID";
            dataGridView.Columns["EmployeeID"].HeaderText = "Employee ID";
            dataGridView.Columns["BillDate"].HeaderText = "Bill Date";
            dataGridView.Columns["TotalPrice"].HeaderText = "Total Price";

            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells; // Auto-fit columns
        }

        private void LoadBillDataByDate(DateTime selectedDate)
        {
            // Get all bills from the database
            List<DTO_Bill> allBills = busBill.GetAllBills();

            // Filter the bills by the selected date
            List<DTO_Bill> filteredBills = allBills.Where(bill => bill.BillDate.Date == selectedDate.Date).ToList();

            // Bind the filtered bills to the DataGridView
            dataGridView.DataSource = filteredBills;

            // Optionally format the DataGridView columns
            if (dataGridView.Columns.Count > 0)
            {
                dataGridView.Columns["ID"].HeaderText = "Bill ID";
                dataGridView.Columns["OrderID"].HeaderText = "Order ID";
                dataGridView.Columns["ClientID"].HeaderText = "Client ID";
                dataGridView.Columns["EmployeeID"].HeaderText = "Employee ID";
                dataGridView.Columns["BillDate"].HeaderText = "Bill Date";
                dataGridView.Columns["TotalPrice"].HeaderText = "Total Price";
            }

            // Adjust the column sizes
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }


        private void btAdd_Click(object sender, EventArgs e)
        {

            // Generate a new Bill ID
            string newBillID = busBill.GenerateNextBillID();
            txtBillID.Text = newBillID; // Display the new BillID

            try
            {
                // Validate ComboBox selections and total price
                if (cbbOrderID.SelectedValue == null || cbbEmployeeID.SelectedValue == null || cbbClientID.SelectedValue == null || nbrTotalPrice.Value <= 0)
                {
                    MessageBox.Show("Please fill out all required fields (Order, Employee, Client, and Total Price).", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Get values from ComboBoxes
                string orderID = cbbOrderID.SelectedValue?.ToString();
                string employeeID = cbbEmployeeID.SelectedValue?.ToString();
                string clientID = cbbClientID.SelectedValue?.ToString();
                DateTime billDate = dtpBilldate.Value;
                decimal totalPrice = nbrTotalPrice.Value;

                // Create a new DTO_Bill object
                DTO_Bill bill = new DTO_Bill
                {
                    ID = newBillID,
                    OrderID = orderID,
                    ClientID = clientID,
                    EmployeeID = employeeID,
                    BillDate = billDate,
                    TotalPrice = totalPrice
                };

                // Insert the bill using the business layer
                bool success = busBill.InsertBill(bill);

                if (success)
                {
                    MessageBox.Show("Bill added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadBillData(); // Refresh bill data after adding
                    ClearForm(); // Clear the form for new input
                }
                else
                {
                    MessageBox.Show("Failed to add bill. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btRemove_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count > 0)
            {
                // Get the selected Bill ID
                string billID = dataGridView.SelectedRows[0].Cells["ID"].Value.ToString();

                // Confirm before deletion
                DialogResult result = MessageBox.Show("Are you sure you want to delete this bill?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    // Delete the selected bill
                    bool success = busBill.DeleteBill(billID);

                    if (success)
                    {
                        MessageBox.Show("Bill removed successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadBillData(); // Refresh the grid after deletion
                    }
                    else
                    {
                        MessageBox.Show("Failed to remove bill. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a bill to remove.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void ManageBill_Load(object sender, EventArgs e)
        {

            LoadBillData();

            nbrTotalPrice.Maximum = 10000000;
            nbrTotalPrice.Minimum = 0;

            // Generate a new Bill ID
            string newBillID = busBill.GenerateNextBillID();
            txtBillID.Text = newBillID; // Display the new BillID
        }

        private void dtpBilldate_ValueChanged(object sender, EventArgs e)
        {
            // Get the selected date from the DateTimePicker
            DateTime selectedDate = dtpBilldate.Value;

            // Load and filter the bills based on the selected date
            LoadBillDataByDate(selectedDate);
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void btExport_Click(object sender, EventArgs e)
        {
            // Create and configure SaveFileDialog
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "CSV file (*.csv)|*.csv";
            saveFileDialog.Title = "Export Bill Data to CSV";
            saveFileDialog.FileName = "BillData.csv";  // Default file name

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // Open the file for writing
                    using (System.IO.StreamWriter file = new System.IO.StreamWriter(saveFileDialog.FileName))
                    {
                        // Write the header row (column names)
                        string header = "";
                        for (int i = 0; i < dataGridView.Columns.Count; i++)
                        {
                            header += dataGridView.Columns[i].HeaderText;
                            if (i < dataGridView.Columns.Count - 1)
                                header += ",";  // Add comma between columns
                        }
                        file.WriteLine(header);

                        // Write the data rows
                        foreach (DataGridViewRow row in dataGridView.Rows)
                        {
                            if (!row.IsNewRow)
                            {
                                string rowData = "";
                                for (int i = 0; i < dataGridView.Columns.Count; i++)
                                {
                                    rowData += row.Cells[i].Value?.ToString();  // Add cell data
                                    if (i < dataGridView.Columns.Count - 1)
                                        rowData += ",";  // Add comma between columns
                                }
                                file.WriteLine(rowData);  // Write row data to file
                            }
                        }
                    }

                    // Inform the user that the export was successful
                    MessageBox.Show("Data exported successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    // Handle any errors that occur during the export process
                    MessageBox.Show($"An error occurred while exporting data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btShow_Click(object sender, EventArgs e)
        {
            LoadBillData();
        }

        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }
    }
}
