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
    public partial class ManageProduct : UserControl
    {

        private BUS_Product busProduct = new BUS_Product();

        public ManageProduct()
        {
            InitializeComponent();
            LoadProductData();
        }

        void disable()
        {
            txtProductname.Enabled = false;
            richtxtDescription.Enabled = false;
            nbrPrice.Enabled = false;
            nbrQuantity.Enabled = false;
        }

        void enable()
        {
            txtProductname.Enabled = true;
            richtxtDescription.Enabled = true;
            nbrPrice.Enabled = true;
            nbrQuantity.Enabled = true;
        }

        void clearFields()
        {
            txtProductname.Clear();
            richtxtDescription.Clear();
            nbrPrice.Value = 0;
            nbrQuantity.Value = 0;
        }

        void LoadProductData()
        {
            // Assuming you have an instance of your business logic layer (BUS_Product)
            dataGridView.DataSource = busProduct.GetAllProducts();

            // Optionally format columns in DataGridView if needed
            dataGridView.Columns["ID"].HeaderText = "Product ID";
            dataGridView.Columns["Name"].HeaderText = "Product Name";
            dataGridView.Columns["Description"].HeaderText = "Description";
            dataGridView.Columns["Price"].HeaderText = "Price";
            dataGridView.Columns["Quantity"].HeaderText = "Quantity";

            // Set AutoSizeMode for each column, except for Description
            dataGridView.Columns["ID"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView.Columns["Name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView.Columns["Price"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView.Columns["Quantity"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            // Set a fixed width for the Description column
            dataGridView.Columns["Description"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dataGridView.Columns["Description"].Width = 320; // Set desired fixed width for the description

            // Optionally adjust the auto-sizing for the other columns
            dataGridView.AutoResizeColumns(); // Adjust column widths to fit data
        }


        private void btAdd_Click(object sender, EventArgs e)
        {
            // Enable input fields for adding a new product
            enable();

            // Clear input fields to allow entering new product data
            clearFields();

            // Generate a new Product ID
            string newProductID = busProduct.GenerateNewProductID();

            // Set the generated Product ID to the txtProductID (readonly)
            txtProductID.Text = newProductID;

        }

        private void btEdit_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count > 0)
            {
                // Enable the input fields for editing
                enable();

                // Get the selected row from the DataGridView
                DataGridViewRow selectedRow = dataGridView.SelectedRows[0];

                // Populate the form fields with the selected product's data
                txtProductID.Text = selectedRow.Cells["ID"].Value.ToString();
                txtProductname.Text = selectedRow.Cells["Name"].Value.ToString();
                richtxtDescription.Text = selectedRow.Cells["Description"].Value.ToString();
                nbrPrice.Value = Convert.ToDecimal(selectedRow.Cells["Price"].Value);
                nbrQuantity.Value = Convert.ToInt32(selectedRow.Cells["Quantity"].Value);

                // Disable the ProductID field to prevent editing
                txtProductID.Enabled = false;
            }
            else
            {
                MessageBox.Show("Please select a product to edit.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btSave_Click(object sender, EventArgs e)
        {
            try
            {
                // Validate that required fields are filled
                if (string.IsNullOrEmpty(txtProductname.Text) || nbrPrice.Value <= 0 || nbrQuantity.Value < 0)
                {
                    MessageBox.Show("Please fill out all required fields (Product Name, Price, Quantity).", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Create a DTO_Product object with the form values
                DTO_Product product = new DTO_Product
                {
                    ID = txtProductID.Text,  // The Product ID is already generated and used for editing
                    Name = txtProductname.Text,
                    Description = richtxtDescription.Text,
                    Price = nbrPrice.Value,
                    Quantity = (int)nbrQuantity.Value
                };

                bool isUpdating = busProduct.Exists(product.ID); // Check if the product already exists
                bool success;

                if (!isUpdating)  // This is a new product
                {
                    success = busProduct.AddProduct(product);
                }
                else  // This is an existing product
                {
                    success = busProduct.UpdateProduct(product);
                }

                // Handle the result of the save operation
                if (success)
                {
                    if (isUpdating)
                    {
                        MessageBox.Show("Product updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("New product added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    LoadProductData();  // Refresh the DataGridView with the latest data
                    disable();          // Disable the input fields after saving
                }
                else
                {
                    MessageBox.Show("Failed to save the product. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                // Handle any exceptions that occur during the save process
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
                string productID = selectedRow.Cells["ID"].Value.ToString();

                // Ask for confirmation before deleting
                DialogResult result = MessageBox.Show($"Are you sure you want to delete the product with ID: {productID}?",
                                                      "Delete Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    // Call the business layer to delete the product
                    bool success = busProduct.DeleteProduct(productID);

                    if (success)
                    {
                        MessageBox.Show("Product deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadProductData(); // Refresh the DataGridView to show updated data
                    }
                    else
                    {
                        MessageBox.Show("Failed to delete product. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                // Show a message if no row is selected
                MessageBox.Show("Please select a product to delete.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            LoadProductData();
            clearFields();
        }

        private void btExport_Click(object sender, EventArgs e)
        {
            try
            {
                // Create a SaveFileDialog to let the user select the file destination
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "CSV file (*.csv)|*.csv";
                saveFileDialog.Title = "Save Product Data as CSV";
                saveFileDialog.FileName = "ProductData.csv";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Get all products from the business layer
                    List<DTO_Product> products = busProduct.GetAllProducts();

                    // Create a StringBuilder to hold CSV content
                    StringBuilder csvContent = new StringBuilder();

                    // Write the CSV header
                    csvContent.AppendLine("Product ID,Product Name,Description,Price,Quantity");

                    // Write product data as CSV rows
                    foreach (var product in products)
                    {
                        csvContent.AppendLine($"{product.ID},{product.Name},{product.Description},{product.Price},{product.Quantity}");
                    }

                    // Write the CSV content to the selected file
                    File.WriteAllText(saveFileDialog.FileName, csvContent.ToString());

                    // Inform the user that the export was successful
                    MessageBox.Show("Product data exported successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                // Handle any exceptions that occur during the export process
                MessageBox.Show($"Error exporting CSV: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ManageProduct_Load(object sender, EventArgs e)
        {
            nbrPrice.Minimum = 0;
            nbrPrice.Maximum = 10000000;

            nbrQuantity.Minimum = 0;
            nbrQuantity.Maximum = 10000000;
        }

        private void btReturn_Click(object sender, EventArgs e)
        {
            // error button
        }

        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Ensure the user is not clicking on the header row
            if (e.RowIndex >= 0)
            {
                // Get the currently selected row
                DataGridViewRow selectedRow = dataGridView.Rows[e.RowIndex];

                // Set the values of the form controls based on the selected row
                txtProductID.Text = selectedRow.Cells["ID"].Value.ToString();              // Product ID
                txtProductname.Text = selectedRow.Cells["Name"].Value.ToString();          // Product Name
                richtxtDescription.Text = selectedRow.Cells["Description"].Value.ToString(); // Description
                nbrPrice.Value = Convert.ToDecimal(selectedRow.Cells["Price"].Value);       // Price
                nbrQuantity.Value = Convert.ToInt32(selectedRow.Cells["Quantity"].Value);   // Quantity

                // Optionally set the focus to the first control, e.g., txtProductName
                txtProductname.Focus();
            }
        }
    }
}
