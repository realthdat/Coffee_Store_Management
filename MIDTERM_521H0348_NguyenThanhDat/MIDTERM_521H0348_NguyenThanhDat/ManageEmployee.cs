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
    public partial class ManageEmployee : UserControl
    {

        private BUS_Employee busEmployee = new BUS_Employee();

        public ManageEmployee()
        {
            InitializeComponent();
            LoadEmployeeData();
        }

        void disable()
        {
            txtFullname.Enabled = false;
            txtEmail.Enabled = false;
            txtPhonenumber.Enabled = false;
            txtAddress.Enabled = false;
            nbrSalary.Enabled = false;
            dtpickerHireDate.Enabled = false;
        }

        void enable()
        {
            txtFullname.Enabled = true;
            txtEmail.Enabled = true;
            txtPhonenumber.Enabled = true;
            txtAddress.Enabled = true;
            nbrSalary.Enabled = true;
            dtpickerHireDate.Enabled = true;
        }

        void clearField()
        {
            // Optionally, clear the fields for new input
            txtFullname.Clear();
            txtEmail.Clear();
            txtPhonenumber.Clear();
            txtAddress.Clear();
            nbrSalary.Value = 0; // Or set a default value
            dtpickerHireDate.Value = DateTime.Now;
        }

        private void LoadEmployeeData()
        {
            // Load employee data from the business layer
            dataGridView.DataSource = busEmployee.GetAllEmployees();

            // Set the DataGridView columns to auto-fit the content
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            // Optionally, resize the columns based on the content
            dataGridView.AutoResizeColumns();

            dataGridView.Columns["ID"].HeaderText = "Employee ID";
            dataGridView.Columns["Name"].HeaderText = "Full Name";
            dataGridView.Columns["Email"].HeaderText = "Email";
            dataGridView.Columns["Phone"].HeaderText = "Phone No";
            dataGridView.Columns["Address"].HeaderText = "Address";
            dataGridView.Columns["Salary"].HeaderText = "Salary (USD)";
            dataGridView.Columns["HireDate"].HeaderText = "Hire Date";
        }

        private void btAdd_Click(object sender, EventArgs e)
        {
            enable();
            clearField();

            // Generate a new Employee ID
            string newEmployeeID = busEmployee.GenerateNewEmployeeID();

            // Display 
            txtEmployeeID.Text = newEmployeeID;

            // Validate inputs before proceeding (basic example)
            //if (string.IsNullOrEmpty(txtFullname.Text) || string.IsNullOrEmpty(txtEmail.Text) ||
            //    string.IsNullOrEmpty(txtPhonenumber.Text) || string.IsNullOrEmpty(txtAddress.Text))
            //{
            //    MessageBox.Show("Please fill out all fields before adding a new employee.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}

            //// Create a new employee DTO with input values
            //DTO_Employee employee = new DTO_Employee
            //{
            //    ID = newEmployeeID,
            //    Name = txtFullname.Text,
            //    Email = txtEmail.Text,
            //    Phone = txtPhonenumber.Text,
            //    Address = txtAddress.Text,
            //    Salary = nbrSalary.Value,
            //    HireDate = dtpickerHireDate.Value
            //};

            // Add employee and check for success
            //bool success = busEmployee.AddEmployee(employee);

            //if (success)
            //{
            //    MessageBox.Show($"Employee added successfully with ID: {newEmployeeID}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    LoadEmployeeData(); // Refresh employee data after adding
            //}
            //else
            //{
            //    MessageBox.Show("Failed to add employee. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }

        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Ensure the click is on a valid row, not on header or empty row
            if (e.RowIndex >= 0)
            {
                // Get the selected row
                DataGridViewRow row = dataGridView.Rows[e.RowIndex];

                // Fill the textboxes with the data from the selected row
                txtEmployeeID.Text = row.Cells["ID"].Value.ToString();
                txtFullname.Text = row.Cells["Name"].Value.ToString();
                txtEmail.Text = row.Cells["Email"].Value.ToString();
                txtPhonenumber.Text = row.Cells["Phone"].Value.ToString();
                txtAddress.Text = row.Cells["Address"].Value.ToString();
                nbrSalary.Value = Convert.ToDecimal(row.Cells["Salary"].Value);
                dtpickerHireDate.Value = Convert.ToDateTime(row.Cells["HireDate"].Value);
            }
        }

        private void btEdit_Click(object sender, EventArgs e)
        {
            // Check if a row is selected in the DataGridView
            if (dataGridView.SelectedRows.Count > 0)
            {
                // Enable the textboxes and input controls for editing
                enable();

                // Get the selected row (assuming single selection mode)
                DataGridViewRow selectedRow = dataGridView.SelectedRows[0];

                // Fill the textboxes and other controls with the selected employee's data
                txtEmployeeID.Text = selectedRow.Cells["ID"].Value.ToString();
                txtFullname.Text = selectedRow.Cells["Name"].Value.ToString();
                txtEmail.Text = selectedRow.Cells["Email"].Value.ToString();
                txtPhonenumber.Text = selectedRow.Cells["Phone"].Value.ToString();
                txtAddress.Text = selectedRow.Cells["Address"].Value.ToString();
                nbrSalary.Value = Convert.ToDecimal(selectedRow.Cells["Salary"].Value);
                dtpickerHireDate.Value = Convert.ToDateTime(selectedRow.Cells["HireDate"].Value);

                // Optionally focus on the first field for the user to start editing
                txtFullname.Focus();
            }
            else
            {
                // Show a message if no row is selected
                MessageBox.Show("Please select an employee to edit.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void ManageEmployee_Load(object sender, EventArgs e)
        {
            nbrSalary.Minimum = 0;         // Minimum salary (e.g., 0)
            nbrSalary.Maximum = 10000000;   // Maximum salary (e.g., 10,000,000)
        }

        private void btSave_Click(object sender, EventArgs e)
        {
            try
            {
                // Validate that the essential fields are not empty
                if (string.IsNullOrEmpty(txtFullname.Text) || string.IsNullOrEmpty(txtEmail.Text) ||
                    string.IsNullOrEmpty(txtPhonenumber.Text) || string.IsNullOrEmpty(txtAddress.Text))
                {
                    MessageBox.Show("Please fill out all fields before saving.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Create a DTO_Employee object with the current form values
                DTO_Employee employee = new DTO_Employee
                {
                    ID = txtEmployeeID.Text,  // ID is generated when adding, or kept the same when editing
                    Name = txtFullname.Text,
                    Email = txtEmail.Text,
                    Phone = txtPhonenumber.Text,
                    Address = txtAddress.Text,
                    Salary = nbrSalary.Value,
                    HireDate = dtpickerHireDate.Value
                };

                // Check if we're adding or updating based on the employee ID
                bool isUpdating = busEmployee.Exists(txtEmployeeID.Text); // Check if employee exists
                bool success;

                if (isUpdating)
                {
                    // Update if the employee exists
                    success = busEmployee.UpdateEmployee(employee);
                }
                else
                {
                    // Add if the employee is new
                    success = busEmployee.AddEmployee(employee);
                }

                // Handle the result with specific messages
                if (success)
                {
                    if (isUpdating)
                    {
                        MessageBox.Show("Employee updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("New employee added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    LoadEmployeeData();  // Refresh the employee data grid
                    disable();  // Disable the form fields
                }
                else
                {
                    MessageBox.Show("Failed to save employee.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btDelete_Click(object sender, EventArgs e)
        {
            // Ensure a row is selected in the DataGridView
            if (dataGridView.SelectedRows.Count > 0)
            {
                // Get the selected row
                DataGridViewRow selectedRow = dataGridView.SelectedRows[0];
                string employeeID = selectedRow.Cells["ID"].Value.ToString();

                // Ask for confirmation before deleting
                DialogResult result = MessageBox.Show($"Are you sure you want to delete employee with ID: {employeeID}?",
                                                      "Delete Confirmation",
                                                      MessageBoxButtons.YesNo,
                                                      MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    // Call the BUS layer to delete the employee
                    bool success = busEmployee.DeleteEmployee(employeeID);

                    if (success)
                    {
                        MessageBox.Show("Employee deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadEmployeeData();  // Refresh the DataGridView to show the updated data
                    }
                    else
                    {
                        MessageBox.Show("Failed to delete employee. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                // Show a message if no employee is selected
                MessageBox.Show("Please select an employee to delete.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btExport_Click(object sender, EventArgs e)
        {
            try
            {
                // Create a SaveFileDialog to allow the user to choose where to save the CSV file
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "CSV file (*.csv)|*.csv";
                saveFileDialog.Title = "Save Employee Data as CSV";
                saveFileDialog.FileName = "EmployeeData.csv";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Get all employee data from the BUS layer
                    List<DTO_Employee> employees = busEmployee.GetAllEmployees();

                    // StringBuilder to create CSV format
                    StringBuilder csvContent = new StringBuilder();
                    csvContent.AppendLine("ID,FullName,Email,Phone,Address,Salary,HireDate");  // CSV Header

                    // Loop through each employee and create a line in the CSV
                    foreach (var employee in employees)
                    {
                        csvContent.AppendLine($"{employee.ID},{employee.Name},{employee.Email},{employee.Phone},{employee.Address},{employee.Salary},{employee.HireDate.ToString("yyyy-MM-dd")}");
                    }

                    // Write the content to a CSV file
                    File.WriteAllText(saveFileDialog.FileName, csvContent.ToString());

                    MessageBox.Show("Employee data exported successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error exporting CSV: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            LoadEmployeeData();
            clearField();
        }


    }
}
