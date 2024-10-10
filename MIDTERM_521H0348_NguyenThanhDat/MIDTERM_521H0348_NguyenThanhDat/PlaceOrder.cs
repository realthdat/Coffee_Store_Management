using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using iTextSharp.text; 
using iTextSharp.text.pdf;

namespace GUI
{
    public partial class PlaceOrder : UserControl
    {
        private BUS_Orders busOrders = new BUS_Orders();
        private BUS_OrderItem busOrderItem = new BUS_OrderItem();
        private BUS_Product busProduct = new BUS_Product();
        private BUS_Employee busEmployee = new BUS_Employee();
        private BUS_Client busClient = new BUS_Client();

        private string currentOrderID;       // Store current OrderID
        private int currentOrderItemID;      // Store current OrderItemID number
        private bool firstOrderGenerated = false;  // Flag to know when first order is generated

        public PlaceOrder()
        {
            InitializeComponent();
            SetupDataGridView();
            LoadComboBoxData();
        }

        private void LoadComboBoxData()
        {
            // Load Client Data
            List<DTO_Client> clients = busClient.GetAllClients();
            cbbClientID.DataSource = clients;
            cbbClientID.DisplayMember = "Name";  // Name of the client to display
            cbbClientID.ValueMember = "ID";      // Value to use (Client ID)

            // Load Employee Data
            List<DTO_Employee> employees = busEmployee.GetAllEmployees();
            cbbEmployeeID.DataSource = employees;
            cbbEmployeeID.DisplayMember = "Name";  // Name of the employee to display
            cbbEmployeeID.ValueMember = "ID";      // Value to use (Employee ID)

            // Load Product Data
            List<DTO_Product> products = busProduct.GetAllProducts();
            cbbProductID.DataSource = products;
            cbbProductID.DisplayMember = "Name";       // Name of the product to display
            cbbProductID.ValueMember = "ID";           // Product ID to use as the value
        }

        private void ClearForm()
        {
            txtOrderID.Clear();
            cbbClientID.SelectedIndex = -1;
            cbbEmployeeID.SelectedIndex = -1;
            nbrQuantity.Value = 1;
            nbrTotalPrice.Value = 0;
            dataGridView.Rows.Clear();
            currentOrderID = null;
            currentOrderItemID = 0;
            firstOrderGenerated = false;

        }

        private void SetupDataGridView()
        {
            // Clear existing columns if needed
            dataGridView.Columns.Clear();

            // Add columns to DataGridView
            dataGridView.Columns.Add("OrderItemID", "Order Item ID");
            dataGridView.Columns.Add("ProductID", "Product ID");
            dataGridView.Columns.Add("ProductName", "Product Name");
            dataGridView.Columns.Add("Quantity", "Quantity");
            dataGridView.Columns.Add("Price", "Price");
            dataGridView.Columns.Add("TotalPrice", "Total Price");

            // Set column auto-size
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        private void AddProductToOrder(string orderItemID, string productID, string productName, int quantity, decimal price)
        {
            // Calculate the total price for the order item
            decimal totalPrice = quantity * price;

            // Add a new row to the DataGridView
            dataGridView.Rows.Add(
                orderItemID,                           // Order Item ID (generated automatically)
                productID,                             // Product ID
                productName,                           // Product Name
                quantity,                              // Quantity
                price.ToString("F2"),                  // Price (formatted as decimal)
                totalPrice.ToString("F2")              // Total Price (formatted as decimal)
            );

            // Update the total order price (optional)
            UpdateTotalOrderPrice();
        }

        private void UpdateTotalOrderPrice()
        {
            decimal totalOrderPrice = 0;

            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                // Add the total price of each row to the total order price
                totalOrderPrice += Convert.ToDecimal(row.Cells["TotalPrice"].Value);
            }

            // Set the total order price in a NumericUpDown control (e.g., nbrTotalPrice)
            nbrTotalPrice.Value = totalOrderPrice;
        }

        private void btAdd_Click(object sender, EventArgs e)
        {

            // Check if this is the first order added in this session
            if (!firstOrderGenerated)
            {
                // Generate new OrderID and set flag that first order is generated
                currentOrderID = busOrders.GenerateNextOrderID();  // Get next OrderID from BUS
                txtOrderID.Text = currentOrderID;  // Display OrderID
                firstOrderGenerated = true;

                // Generate the initial OrderItemID from the database
                string maxOrderItemID = busOrderItem.GetMaxOrderItemID();  // Get the max OrderItemID from the database

                // Ensure a proper starting point by parsing and incrementing
                currentOrderItemID = int.Parse(maxOrderItemID.Substring(2));  // Extract numeric part of OrderItemID
            }

            // Check if a product is selected
            if (cbbProductID.SelectedValue == null || cbbProductID.Text == "")
            {
                MessageBox.Show("Please select a product.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Get product details from the form
            string productID = cbbProductID.SelectedValue.ToString();
            string productName = cbbProductID.Text;
            int quantity = (int)nbrQuantity.Value;

            // Fetch the price from BUS_Product
            decimal price = busProduct.GetProductPrice(productID);

            // Fetch the latest OrderItemID from the database
            currentOrderItemID++;  // Increment the OrderItemID
            string orderItemID = "OI" + currentOrderItemID.ToString("D4");  // Format OrderItemID as OIxxxx

            // Add the product to the order (i.e., to the DataGridView)
            AddProductToOrder(orderItemID, productID, productName, quantity, price);
        }

        private void btRemove_Click(object sender, EventArgs e)
        {
            // Check if any row is selected in the DataGridView
            if (dataGridView.SelectedRows.Count > 0)
            {
                // Show a confirmation dialog before deleting
                DialogResult result = MessageBox.Show("Are you sure you want to remove the selected product?",
                                                      "Confirm Removal",
                                                      MessageBoxButtons.YesNo,
                                                      MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    // Remove the selected row
                    dataGridView.Rows.RemoveAt(dataGridView.SelectedRows[0].Index);

                    // Update the total price after removal
                    UpdateTotalOrderPrice();
                }
                // If the user chooses 'No', do nothing
            }
            else
            {
                MessageBox.Show("Please select an item to remove.", "Remove Product", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = dataGridView.Rows[e.RowIndex];

            }
        }

        private void btPlaceOrder_Click(object sender, EventArgs e)
        {
            try
            {
                // Validate selection of client and employee
                if (cbbClientID.SelectedValue == null || cbbEmployeeID.SelectedValue == null)
                {
                    MessageBox.Show("Please select a client and an employee.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Ensure at least one product is added to the order
                if (dataGridView.Rows.Count == 0)
                {
                    MessageBox.Show("Please add at least one product to the order.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Create the order
                string clientID = cbbClientID.SelectedValue.ToString();
                string employeeID = cbbEmployeeID.SelectedValue.ToString();
                DateTime orderDate = DateTime.Now;
                decimal totalPrice = nbrTotalPrice.Value;

                // Generate the next Order ID
                string currentOrderID = busOrders.GenerateNextOrderID();

                DTO_Order order = new DTO_Order
                {
                    ID = currentOrderID,
                    ClientID = clientID,
                    EmployeeID = employeeID,
                    OrderDate = orderDate,
                    TotalPrice = totalPrice
                };

                List<DTO_OrderItem> orderItems = new List<DTO_OrderItem>();

                // Ensure unique OrderItemID generation by retrieving the max ID from the database once
                string maxOrderItemID = busOrderItem.GetMaxOrderItemID();  // Get the max OrderItemID from the database
                int currentOrderItemID = int.Parse(maxOrderItemID.Substring(2));  // Extract numeric part of OrderItemID

                foreach (DataGridViewRow row in dataGridView.Rows)
                {
                    if (row.IsNewRow) continue; // Skip empty row

                    string productID = row.Cells["ProductID"].Value.ToString();
                    int quantity = Convert.ToInt32(row.Cells["Quantity"].Value);

                    // Deduct the quantity from the stock
                    bool success = busProduct.DeductProductQuantity(productID, quantity);
                    if (!success)
                    {
                        MessageBox.Show($"Not enough stock for product ID {productID}.", "Stock Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // Generate a unique OrderItemID for each item
                    currentOrderItemID++;  // Increment the OrderItemID for each new order item
                    string orderItemID = "OI" + currentOrderItemID.ToString("D4");  // Format OrderItemID as OIxxxx

                    DTO_OrderItem orderItem = new DTO_OrderItem
                    {
                        ID = orderItemID,
                        OrderID = currentOrderID,
                        ProductID = productID,
                        Quantity = quantity
                    };

                    orderItems.Add(orderItem);
                }

                // Insert the order and the order items into the database
                if (busOrders.PlaceOrder(order, orderItems))
                {
                    BUS_Bill busBill = new BUS_Bill();
                    string newBillID = busBill.GenerateNextBillID();
                    DateTime billDate = DateTime.Now;

                    DTO_Bill bill = new DTO_Bill
                    {
                        ID = newBillID,
                        OrderID = currentOrderID,
                        ClientID = clientID,
                        EmployeeID = employeeID,
                        BillDate = billDate,
                        TotalPrice = totalPrice
                    };

                    if (busBill.InsertBill(bill))
                    {
                        // Tạo hóa đơn dưới dạng PDF
                        GenerateBillAsPDF(bill, orderItems);
                        MessageBox.Show("Order and Bill placed successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ClearForm();
                    }
                    else
                    {
                        MessageBox.Show("Order placed, but failed to generate the bill.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
                else
                {
                    MessageBox.Show("Failed to place order. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PlaceOrder_Load(object sender, EventArgs e)
        {
            nbrTotalPrice.Maximum = 10000000;
            nbrTotalPrice.Minimum = 0;

            nbrQuantity.Maximum = 10000000;
            nbrQuantity.Minimum = 0;
        }

        private void btExport_Click(object sender, EventArgs e)
        {
            try
            {
                // Initialize SaveFileDialog to save the file
                SaveFileDialog saveFileDialog = new SaveFileDialog
                {
                    Filter = "CSV file (*.csv)|*.csv",  // Only allow .csv files
                    Title = "Save Order Data as CSV",
                    FileName = "OrderData.csv"  // Default file name
                };

                // If the user clicks OK and selects a location
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Get the path of the selected file
                    string filePath = saveFileDialog.FileName;

                    // Use StringBuilder to store CSV data
                    StringBuilder csvData = new StringBuilder();

                    // Write the headers
                    foreach (DataGridViewColumn column in dataGridView.Columns)
                    {
                        csvData.Append(column.HeaderText + ",");  // Comma-separated headers
                    }
                    csvData.AppendLine();  // Newline after the header

                    // Write the data from the DataGridView rows
                    foreach (DataGridViewRow row in dataGridView.Rows)
                    {
                        if (!row.IsNewRow)  // Skip the new row placeholder
                        {
                            foreach (DataGridViewCell cell in row.Cells)
                            {
                                csvData.Append(cell.Value?.ToString() + ",");  // Append each cell value, followed by a comma
                            }
                            csvData.AppendLine();  // Newline after each row
                        }
                    }

                    // Write the CSV data to the file
                    System.IO.File.WriteAllText(filePath, csvData.ToString());

                    // Notify the user that the export was successful
                    MessageBox.Show("Order data exported successfully!", "Export Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                // Handle errors, if any
                MessageBox.Show($"Error exporting data: {ex.Message}", "Export Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GenerateBillAsPDF(DTO_Bill bill, List<DTO_OrderItem> orderItems)
        {
            // Sử dụng SaveFileDialog để người dùng chọn nơi lưu file
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "PDF file (*.pdf)|*.pdf",  // Chỉ cho phép lưu dưới định dạng .pdf
                Title = "Save Bill as PDF",
                FileName = $"Bill_{bill.ID}.pdf"  // Gợi ý tên file mặc định
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Lấy đường dẫn file mà người dùng chọn
                string filePath = saveFileDialog.FileName;

                // Fetch client and employee names
                string clientName = busClient.GetClientNameByID(bill.ClientID);
                string employeeName = busEmployee.GetEmployeeNameByID(bill.EmployeeID);

                // Create a PDF document using iTextSharp
                using (FileStream stream = new FileStream(filePath, FileMode.Create))
                {
                    iTextSharp.text.Document pdfDoc = new iTextSharp.text.Document(iTextSharp.text.PageSize.A4, 25f, 25f, 30f, 30f);
                    PdfWriter.GetInstance(pdfDoc, stream);
                    pdfDoc.Open();

                    // Add company name (optional)
                    iTextSharp.text.Paragraph companyName = new iTextSharp.text.Paragraph(".Net Engineering Company", new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 24f, iTextSharp.text.Font.BOLD));

                    companyName.Alignment = Element.ALIGN_CENTER;
                    pdfDoc.Add(companyName);

                    // Add title
                    iTextSharp.text.Paragraph title = new iTextSharp.text.Paragraph("Bill Receipt", new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 18f, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK));
                    title.Alignment = Element.ALIGN_CENTER;
                    pdfDoc.Add(title);

                    // Add some space
                    pdfDoc.Add(new Paragraph(" "));

                    // Add bill information with formatted layout
                    PdfPTable infoTable = new PdfPTable(2);
                    infoTable.HorizontalAlignment = Element.ALIGN_LEFT;
                    infoTable.SpacingBefore = 10f;
                    infoTable.SpacingAfter = 10f;
                    infoTable.WidthPercentage = 100;
                    infoTable.SetWidths(new float[] { 30f, 70f }); // Column widths

                    infoTable.AddCell(new PdfPCell(new Phrase("Bill ID:", new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 12f, iTextSharp.text.Font.BOLD))) { Border = iTextSharp.text.Rectangle.NO_BORDER });
                    infoTable.AddCell(new PdfPCell(new Phrase(bill.ID, new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 12f))) { Border = iTextSharp.text.Rectangle.NO_BORDER });

                    infoTable.AddCell(new PdfPCell(new Phrase("Client Name:", new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 12f, iTextSharp.text.Font.BOLD))) { Border = iTextSharp.text.Rectangle.NO_BORDER });
                    infoTable.AddCell(new PdfPCell(new Phrase(clientName, new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 12f))) { Border = iTextSharp.text.Rectangle.NO_BORDER });

                    infoTable.AddCell(new PdfPCell(new Phrase("Employee Name:", new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 12f, iTextSharp.text.Font.BOLD))) { Border = iTextSharp.text.Rectangle.NO_BORDER });
                    infoTable.AddCell(new PdfPCell(new Phrase(employeeName, new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 12f))) { Border = iTextSharp.text.Rectangle.NO_BORDER });

                    infoTable.AddCell(new PdfPCell(new Phrase("Bill Date:", new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 12f, iTextSharp.text.Font.BOLD))) { Border = iTextSharp.text.Rectangle.NO_BORDER });
                    infoTable.AddCell(new PdfPCell(new Phrase(bill.BillDate.ToString("dd/MM/yyyy"), new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 12f))) { Border = iTextSharp.text.Rectangle.NO_BORDER });

                    infoTable.AddCell(new PdfPCell(new Phrase("Total Price:", new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 12f, iTextSharp.text.Font.BOLD))) { Border = iTextSharp.text.Rectangle.NO_BORDER });
                    infoTable.AddCell(new PdfPCell(new Phrase(bill.TotalPrice.ToString("C2"), new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 12f))) { Border = iTextSharp.text.Rectangle.NO_BORDER });


                    pdfDoc.Add(infoTable);

                    // Add some space before the table
                    pdfDoc.Add(new Paragraph(" "));

                    // Add order items table
                    PdfPTable table = new PdfPTable(4); // 4 columns for Order Items
                    table.WidthPercentage = 100;
                    table.SetWidths(new float[] { 25f, 35f, 20f, 20f }); // Set column widths

                    // Add table headers with custom font
                    iTextSharp.text.pdf.PdfPCell cellHeader = new iTextSharp.text.pdf.PdfPCell(new iTextSharp.text.Phrase("Product ID", new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 12f, iTextSharp.text.Font.BOLD)));
                    cellHeader.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
                    table.AddCell(cellHeader);

                    cellHeader = new iTextSharp.text.pdf.PdfPCell(new iTextSharp.text.Phrase("Product Name", new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 12f, iTextSharp.text.Font.BOLD)));
                    cellHeader.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
                    table.AddCell(cellHeader);

                    cellHeader = new iTextSharp.text.pdf.PdfPCell(new iTextSharp.text.Phrase("Quantity", new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 12f, iTextSharp.text.Font.BOLD)));
                    cellHeader.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
                    table.AddCell(cellHeader);

                    cellHeader = new iTextSharp.text.pdf.PdfPCell(new iTextSharp.text.Phrase("Price", new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 12f, iTextSharp.text.Font.BOLD)));
                    cellHeader.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
                    table.AddCell(cellHeader);


                    foreach (DTO_OrderItem orderItem in orderItems)
                    {
                        // Lấy thông tin sản phẩm dựa trên ProductID
                        DTO_Product product = busProduct.GetProductByID(orderItem.ProductID);

                        // Kiểm tra xem sản phẩm có tồn tại không
                        if (product != null)
                        {
                            // Thêm thông tin sản phẩm vào bảng PDF
                            table.AddCell(new iTextSharp.text.pdf.PdfPCell(new iTextSharp.text.Phrase(orderItem.ProductID, new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 12f))));
                            table.AddCell(new iTextSharp.text.pdf.PdfPCell(new iTextSharp.text.Phrase(product.Name, new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 12f))));
                            table.AddCell(new iTextSharp.text.pdf.PdfPCell(new iTextSharp.text.Phrase(orderItem.Quantity.ToString(), new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 12f))));
                            table.AddCell(new iTextSharp.text.pdf.PdfPCell(new iTextSharp.text.Phrase((product.Price * orderItem.Quantity).ToString("F2"), new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 12f))));
                        }
                        else
                        {
                            // Xử lý trường hợp không tìm thấy sản phẩm
                            table.AddCell(new iTextSharp.text.pdf.PdfPCell(new iTextSharp.text.Phrase("Unknown Product", new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 12f))));
                            table.AddCell(new iTextSharp.text.pdf.PdfPCell(new iTextSharp.text.Phrase("-", new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 12f))));
                            table.AddCell(new iTextSharp.text.pdf.PdfPCell(new iTextSharp.text.Phrase(orderItem.Quantity.ToString(), new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 12f))));
                            table.AddCell(new iTextSharp.text.pdf.PdfPCell(new iTextSharp.text.Phrase("-", new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 12f))));
                        }
                    }

                    pdfDoc.Add(table);

                    // Add thank you note
                    pdfDoc.Add(new iTextSharp.text.Paragraph(" "));
                    iTextSharp.text.Paragraph thankYouNote = new iTextSharp.text.Paragraph("Thank you for your business!", new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 14f, iTextSharp.text.Font.BOLDITALIC));
                    thankYouNote.Alignment = iTextSharp.text.Element.ALIGN_CENTER;
                    pdfDoc.Add(thankYouNote);

                    // Close the document
                    pdfDoc.Close();
                }

                MessageBox.Show($"Bill generated and saved to {filePath}", "Bill Generated", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                // Notify if user cancels the file save process
                MessageBox.Show("File saving was canceled.", "Save Canceled", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }



        private void btCancel_Click(object sender, EventArgs e)
        {
            ClearForm();
        }
    }
}
