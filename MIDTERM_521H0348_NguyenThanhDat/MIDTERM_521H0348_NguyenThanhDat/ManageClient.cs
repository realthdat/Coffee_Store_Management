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
    public partial class ManageClient : UserControl
    {

        private BUS_Client busClient = new BUS_Client();

        public ManageClient()
        {
            InitializeComponent();
            LoadClientData();
        }

        void disable()
        {
            txtFullname.Enabled = false;
            txtEmail.Enabled = false;
            txtPhonenumber.Enabled = false;
            txtAddress.Enabled = false;
        }

        void enable()
        {
            txtFullname.Enabled = true;
            txtEmail.Enabled = true;
            txtPhonenumber.Enabled = true;
            txtAddress.Enabled = true;
        }

        void clearField()
        {
            // Optionally, clear the fields for new input
            txtFullname.Clear();
            txtEmail.Clear();
            txtPhonenumber.Clear();
            txtAddress.Clear();
        }

        private void LoadClientData()
        {
            // Load client data from the business layer
            dataGridView.DataSource = busClient.GetAllClients();

            // Set the DataGridView columns to auto-fit the content
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            // Optionally, resize the columns based on the content
            dataGridView.AutoResizeColumns();

            dataGridView.Columns["ID"].HeaderText = "Client ID";
            dataGridView.Columns["Name"].HeaderText = "Full Name";
            dataGridView.Columns["Email"].HeaderText = "Email";
            dataGridView.Columns["Phone"].HeaderText = "Phone No";
            dataGridView.Columns["Address"].HeaderText = "Address";
        }

        private void btAdd_Click(object sender, EventArgs e)
        {
            // Enable input fields for adding a new client
            enable();

            // Clear input fields to allow entering new client data
            clearField();

            // Generate a new Client ID
            string newClientID = busClient.GenerateNewClientID();

            // Display the generated Client ID
            txtClientID.Text = newClientID;
        }

        private void btEdit_Click(object sender, EventArgs e)
        {
            // Check if a row is selected in the DataGridView
            if (dataGridView.SelectedRows.Count > 0)
            {
                // Enable the input fields to allow editing
                enable();

                // Get the selected row
                DataGridViewRow selectedRow = dataGridView.SelectedRows[0];

                // Populate the textboxes with the data from the selected client
                txtClientID.Text = selectedRow.Cells["ID"].Value.ToString();
                txtFullname.Text = selectedRow.Cells["Name"].Value.ToString();
                txtEmail.Text = selectedRow.Cells["Email"].Value.ToString();
                txtPhonenumber.Text = selectedRow.Cells["Phone"].Value.ToString();
                txtAddress.Text = selectedRow.Cells["Address"].Value.ToString();

                // Disable the ClientID textbox to prevent editing the ID
                txtClientID.Enabled = false; // We generally don't allow editing of primary keys
            }
            else
            {
                // Show a message if no row is selected
                MessageBox.Show("Please select a client to edit.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btSave_Click(object sender, EventArgs e)
        {
            try
            {
                // Ensure the required fields are filled out
                if (string.IsNullOrEmpty(txtFullname.Text) || string.IsNullOrEmpty(txtEmail.Text) ||
                    string.IsNullOrEmpty(txtPhonenumber.Text) || string.IsNullOrEmpty(txtAddress.Text))
                {
                    MessageBox.Show("Please fill out all fields before saving.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Create a DTO_Client object with the updated or new values
                DTO_Client client = new DTO_Client
                {
                    ID = txtClientID.Text,  // Use the existing or newly generated ClientID
                    Name = txtFullname.Text,
                    Email = txtEmail.Text,
                    Phone = txtPhonenumber.Text,
                    Address = txtAddress.Text
                };

                bool isUpdating = busClient.Exists(client.ID); // Check if we're updating an existing client or adding a new one
                bool success;

                if (isUpdating)
                {
                    // Update existing client
                    success = busClient.UpdateClient(client);
                }
                else
                {
                    // Add new client
                    success = busClient.AddClient(client);
                }

                // Handle the result
                if (success)
                {
                    if (isUpdating)
                    {
                        MessageBox.Show("Client updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("New client added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    LoadClientData(); // Refresh the client data in the DataGridView
                    disable(); // Disable input fields after saving
                }
                else
                {
                    MessageBox.Show("Failed to save client. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btDelete_Click(object sender, EventArgs e)
        {
            // Ensure a row is selected in the DataGridView
            if (dataGridView.SelectedRows.Count > 0)
            {
                // Get the selected row
                DataGridViewRow selectedRow = dataGridView.SelectedRows[0];
                string clientID = selectedRow.Cells["ID"].Value.ToString();

                // Ask for confirmation before deleting
                DialogResult result = MessageBox.Show($"Are you sure you want to delete the client with ID: {clientID}?",
                                                      "Delete Confirmation",
                                                      MessageBoxButtons.YesNo,
                                                      MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    // Call the business layer to delete the client
                    bool success = busClient.DeleteClient(clientID);

                    if (success)
                    {
                        MessageBox.Show("Client deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadClientData(); // Refresh the DataGridView to show the updated data
                    }
                    else
                    {
                        MessageBox.Show("Failed to delete client. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                // Show a message if no client is selected
                MessageBox.Show("Please select a client to delete.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            LoadClientData();
            clearField();
        }

        private void btExport_Click(object sender, EventArgs e)
        {
            try
            {
                // Create a SaveFileDialog to allow the user to choose where to save the CSV file
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "CSV file (*.csv)|*.csv";
                saveFileDialog.Title = "Save Client Data as CSV";
                saveFileDialog.FileName = "ClientData.csv";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Get all client data from the business layer
                    List<DTO_Client> clients = busClient.GetAllClients();

                    // StringBuilder to create CSV format
                    StringBuilder csvContent = new StringBuilder();
                    csvContent.AppendLine("ID,FullName,Email,Phone,Address");  // CSV Header

                    // Loop through each client and create a line in the CSV
                    foreach (var client in clients)
                    {
                        csvContent.AppendLine($"{client.ID},{client.Name},{client.Email},{client.Phone},{client.Address}");
                    }

                    // Write the content to a CSV file
                    File.WriteAllText(saveFileDialog.FileName, csvContent.ToString());

                    // Inform the user that the export was successful
                    MessageBox.Show("Client data exported successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                // Handle any exceptions that occur during file writing
                MessageBox.Show($"Error exporting CSV: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Ensure the click is on a valid row, not the header or empty row
            if (e.RowIndex >= 0)
            {
                // Get the selected row
                DataGridViewRow selectedRow = dataGridView.Rows[e.RowIndex];

                // Populate the textboxes with the data from the selected row
                txtClientID.Text = selectedRow.Cells["ID"].Value.ToString();
                txtFullname.Text = selectedRow.Cells["Name"].Value.ToString();
                txtEmail.Text = selectedRow.Cells["Email"].Value.ToString();
                txtPhonenumber.Text = selectedRow.Cells["Phone"].Value.ToString();
                txtAddress.Text = selectedRow.Cells["Address"].Value.ToString();

                // Enable the textboxes if you want to allow editing of the data
                enable();
            }
        }
    }
}
