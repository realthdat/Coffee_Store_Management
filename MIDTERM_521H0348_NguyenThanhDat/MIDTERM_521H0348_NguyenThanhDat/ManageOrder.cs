using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Text;

namespace GUI
{
    public partial class ManageOrder : UserControl
    {

        private BUS_Orders busOrders = new BUS_Orders();
        private BUS_OrderItem busOrderItems = new BUS_OrderItem();

        public ManageOrder()
        {
            InitializeComponent();
            LoadOrdersData();
        }

        private void LoadOrdersData()
        {
            var ordersWithItems = busOrders.GetAllOrdersWithItems(); // Assuming this method combines order and item details
            dataGridView.DataSource = ordersWithItems;
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridView.AutoResizeColumns();
        }

        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView.Rows[e.RowIndex];

                // Set the TextBox values based on the selected row
                txtOrderItemID.Text = row.Cells["OrderItemID"].Value.ToString();
                txtOrderID.Text = row.Cells["OrderID"].Value.ToString();
                txtEmployeeID.Text = row.Cells["EmployeeID"].Value.ToString();
                txtClientID.Text = row.Cells["ClientID"].Value.ToString();
                txtProductID.Text = row.Cells["ProductID"].Value.ToString();
                txtProductName.Text = row.Cells["ProductName"].Value.ToString();
                txtQuantity.Text = row.Cells["Quantity"].Value.ToString();
                txtTotalPrice.Text = row.Cells["TotalPrice"].Value.ToString();
                dtpOrderDate.Value = Convert.ToDateTime(row.Cells["OrderDate"].Value);
            }
        }

        private void btExport_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView.Rows.Count > 0) // Check if the DataGridView contains data
                {
                    SaveFileDialog sfd = new SaveFileDialog();
                    sfd.Filter = "CSV (*.csv)|*.csv";
                    sfd.FileName = "OrdersExport.csv";

                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        // Create a new file stream to write the CSV file
                        using (StreamWriter sw = new StreamWriter(sfd.FileName, false, Encoding.UTF8))
                        {
                            // Write the header line
                            string[] header = dataGridView.Columns.Cast<DataGridViewColumn>()
                                               .Select(column => column.HeaderText).ToArray();
                            sw.WriteLine(string.Join(",", header));

                            // Write data rows
                            foreach (DataGridViewRow row in dataGridView.Rows)
                            {
                                if (!row.IsNewRow)
                                {
                                    string[] rowData = row.Cells.Cast<DataGridViewCell>()
                                                       .Select(cell => cell.Value?.ToString() ?? string.Empty).ToArray();
                                    sw.WriteLine(string.Join(",", rowData));
                                }
                            }
                        }

                        MessageBox.Show("CSV file has been successfully saved!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("No data to export.", "Export Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            LoadOrdersData();
        }
    }
}
