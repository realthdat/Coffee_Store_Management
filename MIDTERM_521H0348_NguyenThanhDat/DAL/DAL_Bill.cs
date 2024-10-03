using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class DAL_Bill
    {
        private Connection connection = new Connection(); // Sử dụng lớp Connection đã tạo trước đó

        // Lấy tất cả hóa đơn
        public List<DTO_Bill> GetAllBills()
        {
            List<DTO_Bill> bills = new List<DTO_Bill>();
            string query = "SELECT * FROM Bill";
            DataTable dt = connection.SelectQuery(query);

            foreach (DataRow row in dt.Rows)
            {
                DTO_Bill bill = new DTO_Bill
                {
                    ID = row["ID"].ToString(),
                    OrderID = row["OrderID"].ToString(),
                    ClientID = row["ClientID"].ToString(),
                    EmployeeID = row["EmployeeID"].ToString(),
                    BillDate = Convert.ToDateTime(row["BillDate"]),
                    TotalPrice = Convert.ToDecimal(row["TotalPrice"])
                };
                bills.Add(bill);
            }

            return bills;
        }

        // Lấy hóa đơn theo ID
        public DTO_Bill GetBillByID(string billID)
        {
            string query = "SELECT * FROM Bill WHERE ID = @ID";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@ID", billID)
            };
            DataTable dt = connection.SelectQuery(query, parameters);

            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                return new DTO_Bill
                {
                    ID = row["ID"].ToString(),
                    OrderID = row["OrderID"].ToString(),
                    ClientID = row["ClientID"].ToString(),
                    EmployeeID = row["EmployeeID"].ToString(),
                    BillDate = Convert.ToDateTime(row["BillDate"]),
                    TotalPrice = Convert.ToDecimal(row["TotalPrice"])
                };
            }
            return null; // Nếu không tìm thấy
        }

        // Insert a new bill
        public bool InsertBill(string billID, string orderID, string clientID, string employeeID, DateTime billDate, decimal totalPrice)
        {
            string query = "INSERT INTO Bill (ID, OrderID, ClientID, EmployeeID, BillDate, TotalPrice) " +
                           "VALUES (@ID, @OrderID, @ClientID, @EmployeeID, @BillDate, @TotalPrice)";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@ID", billID),
                new SqlParameter("@OrderID", orderID),
                new SqlParameter("@ClientID", clientID),
                new SqlParameter("@EmployeeID", employeeID),
                new SqlParameter("@BillDate", billDate),
                new SqlParameter("@TotalPrice", totalPrice)
                    };
            return connection.ExecuteNonQuery(query, parameters) > 0;
        }

        // Cập nhật hóa đơn
        public bool UpdateBill(DTO_Bill bill)
        {
            try
            {
                string query = "UPDATE Bill SET OrderID = @OrderID, ClientID = @ClientID, EmployeeID = @EmployeeID, " +
                               "BillDate = @BillDate, TotalPrice = @TotalPrice WHERE ID = @ID";
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@ID", bill.ID),
                    new SqlParameter("@OrderID", bill.OrderID),
                    new SqlParameter("@ClientID", bill.ClientID),
                    new SqlParameter("@EmployeeID", bill.EmployeeID),
                    new SqlParameter("@BillDate", bill.BillDate),
                    new SqlParameter("@TotalPrice", bill.TotalPrice)
                };
                return connection.ExecuteNonQuery(query, parameters) > 0;
            }
            catch (Exception ex)
            {
                // Handle the exception properly (log it, rethrow it, etc.)
                throw new Exception("Error updating bill: " + ex.Message);
            }
        }

        // Xóa hóa đơn
        public bool DeleteBill(string billID)
        {
            string query = "DELETE FROM Bill WHERE ID = @ID";
            SqlParameter[] parameters = new SqlParameter[]
            {
                 new SqlParameter("@ID", billID)
            };

            // Check if any rows were affected (i.e., a bill was deleted)
            return connection.ExecuteNonQuery(query, parameters) > 0;
        }

        // Get the maximum BillID
        public string GetMaxBillID()
        {
            try
            {
                string query = "SELECT MAX(ID) FROM Bill";
                DataTable dt = connection.SelectQuery(query);
                if (dt.Rows.Count > 0 && dt.Rows[0][0] != DBNull.Value)
                {
                    return dt.Rows[0][0].ToString();
                }
                return null;
            }
            catch (Exception ex)
            {
                // Handle the exception properly (log it, rethrow it, etc.)
                throw new Exception("Error getting maximum Bill ID: " + ex.Message);
            }
        }

        // Method to get total bills by a specific date
        public int GetTotalBillsByDate(DateTime date)
        {
            string query = "SELECT COUNT(*) FROM Bill WHERE BillDate = @BillDate";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@BillDate", date)
            };

            // Execute the query and return the result
            DataTable dt = connection.SelectQuery(query, parameters);
            if (dt.Rows.Count > 0)
            {
                return Convert.ToInt32(dt.Rows[0][0]); // Return the count of bills
            }
            return 0;
        }

        // Method to get total bills for all time
        public int GetTotalBillsAllTime()
        {
            string query = "SELECT COUNT(*) FROM Bill";

            // Execute the query and return the result
            DataTable dt = connection.SelectQuery(query);
            if (dt.Rows.Count > 0)
            {
                return Convert.ToInt32(dt.Rows[0][0]); // Return the count of bills
            }
            return 0;
        }

        // Method to get total price by a specific date
        public decimal GetTotalPriceByDate(DateTime date)
        {
            string query = "SELECT SUM(TotalPrice) FROM Bill WHERE BillDate = @BillDate";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@BillDate", date)
            };

            // Execute the query and return the result
            DataTable dt = connection.SelectQuery(query, parameters);
            if (dt.Rows.Count > 0 && dt.Rows[0][0] != DBNull.Value)
            {
                return Convert.ToDecimal(dt.Rows[0][0]); // Return the total price
            }
            return 0; // If no bills, return 0
        }

        // Method to get total price for all time
        public decimal GetTotalPriceAllTime()
        {
            string query = "SELECT SUM(TotalPrice) FROM Bill";

            // Execute the query and return the result
            DataTable dt = connection.SelectQuery(query);
            if (dt.Rows.Count > 0 && dt.Rows[0][0] != DBNull.Value)
            {
                return Convert.ToDecimal(dt.Rows[0][0]); // Return the total price
            }
            return 0; // If no bills, return 0
        }
    }
}
