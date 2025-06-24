using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class DAL_OrderItem
    {
        private Connection connection = new Connection(); // Sử dụng lớp Connection đã tạo trước đó

        // Lấy tất cả các mục trong đơn hàng
        public List<DTO_OrderItem> GetAllOrderItems()
        {
            List<DTO_OrderItem> orderItems = new List<DTO_OrderItem>();
            string query = "SELECT * FROM OrderItem";
            DataTable dt = connection.SelectQuery(query);

            foreach (DataRow row in dt.Rows)
            {
                DTO_OrderItem orderItem = new DTO_OrderItem
                {
                    ID = row["ID"].ToString(),
                    OrderID = row["OrderID"].ToString(),
                    ProductID = row["ProductID"].ToString(),
                    Quantity = Convert.ToInt32(row["Quantity"])
                };
                orderItems.Add(orderItem);
            }

            return orderItems;
        }

        // Lấy mục trong đơn hàng theo OrderID
        public List<DTO_OrderItem> GetOrderItemsByOrderID(string orderID)
        {
            List<DTO_OrderItem> orderItems = new List<DTO_OrderItem>();
            string query = "SELECT * FROM OrderItem WHERE OrderID = @OrderID";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@OrderID", orderID)
            };
            DataTable dt = connection.SelectQuery(query, parameters);

            foreach (DataRow row in dt.Rows)
            {
                DTO_OrderItem orderItem = new DTO_OrderItem
                {
                    ID = row["ID"].ToString(),
                    OrderID = row["OrderID"].ToString(),
                    ProductID = row["ProductID"].ToString(),
                    Quantity = Convert.ToInt32(row["Quantity"])
                };
                orderItems.Add(orderItem);
            }

            return orderItems;
        }

        // Insert an order item
        public bool InsertOrderItem(DTO_OrderItem orderItem)
        {
            string query = "INSERT INTO OrderItem (ID, OrderID, ProductID, Quantity) " +
                           "VALUES (@ID, @OrderID, @ProductID, @Quantity)";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@ID", orderItem.ID),
                new SqlParameter("@OrderID", orderItem.OrderID),
                new SqlParameter("@ProductID", orderItem.ProductID),
                new SqlParameter("@Quantity", orderItem.Quantity)
            };
            return connection.ExecuteNonQuery(query, parameters) > 0;
        }

        // Cập nhật mục trong đơn hàng
        public bool UpdateOrderItem(DTO_OrderItem orderItem)
        {
            string query = "UPDATE OrderItem SET OrderID = @OrderID, ProductID = @ProductID, " +
                           "Quantity = @Quantity WHERE ID = @ID";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@ID", orderItem.ID),
                new SqlParameter("@OrderID", orderItem.OrderID),
                new SqlParameter("@ProductID", orderItem.ProductID),
                new SqlParameter("@Quantity", orderItem.Quantity)
            };
            return connection.ExecuteNonQuery(query, parameters) > 0;
        }

        // Xóa mục khỏi đơn hàng
        public bool DeleteOrderItem(string orderItemID)
        {
            string query = "DELETE FROM OrderItem WHERE ID = @ID";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@ID", orderItemID)
            };
            return connection.ExecuteNonQuery(query, parameters) > 0;
        }

        // Get the last OrderItemID
        public string GetLastOrderItemID()
        {
            string query = "SELECT TOP 1 ID FROM OrderItem ORDER BY ID DESC";
            DataTable dt = connection.SelectQuery(query);

            if (dt.Rows.Count > 0)
            {
                return dt.Rows[0]["ID"].ToString();
            }
            return null;  // Return null if there are no order items
        }

        // Lấy OrderItemID lớn nhất trong bảng OrderItem
        public string GetMaxOrderItemID()
        {
            string query = "SELECT MAX(ID) FROM OrderItem";
            DataTable dt = connection.SelectQuery(query);

            if (dt.Rows.Count > 0 && dt.Rows[0][0] != DBNull.Value)
            {
                return dt.Rows[0][0].ToString();
            }
            return null; // Trả về null nếu không có OrderItem nào
        }
    }
}
