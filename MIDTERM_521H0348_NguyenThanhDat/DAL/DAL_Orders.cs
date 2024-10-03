using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

public class DAL_Orders
{
    private Connection connection = new Connection();  // Replace with your connection class

    // Get all orders
    public List<DTO_Order> GetAllOrders()
    {
        List<DTO_Order> orders = new List<DTO_Order>();
        string query = "SELECT * FROM Orders";
        DataTable dt = connection.SelectQuery(query);

        foreach (DataRow row in dt.Rows)
        {
            DTO_Order order = new DTO_Order
            {
                ID = row["ID"].ToString(),
                ClientID = row["ClientID"].ToString(),
                EmployeeID = row["EmployeeID"].ToString(),
                OrderDate = Convert.ToDateTime(row["OrderDate"]),
                TotalPrice = Convert.ToDecimal(row["TotalPrice"])
            };
            orders.Add(order);
        }

        return orders;
    }

    // Get a single order by ID
    public DTO_Order GetOrderByID(string orderID)
    {
        string query = "SELECT * FROM Orders WHERE ID = @ID";
        SqlParameter[] parameters = new SqlParameter[]
        {
            new SqlParameter("@ID", orderID)
        };
        DataTable dt = connection.SelectQuery(query, parameters);

        if (dt.Rows.Count > 0)
        {
            DataRow row = dt.Rows[0];
            return new DTO_Order
            {
                ID = row["ID"].ToString(),
                ClientID = row["ClientID"].ToString(),
                EmployeeID = row["EmployeeID"].ToString(),
                OrderDate = Convert.ToDateTime(row["OrderDate"]),
                TotalPrice = Convert.ToDecimal(row["TotalPrice"])
            };
        }
        return null;
    }

    // Insert a new order
    public bool InsertOrder(DTO_Order order)
    {
        string query = "INSERT INTO Orders (ID, ClientID, EmployeeID, OrderDate, TotalPrice) " +
                       "VALUES (@ID, @ClientID, @EmployeeID, @OrderDate, @TotalPrice)";
        SqlParameter[] parameters = new SqlParameter[]
        {
            new SqlParameter("@ID", order.ID),
            new SqlParameter("@ClientID", order.ClientID),
            new SqlParameter("@EmployeeID", order.EmployeeID),
            new SqlParameter("@OrderDate", order.OrderDate),
            new SqlParameter("@TotalPrice", order.TotalPrice)
        };
        return connection.ExecuteNonQuery(query, parameters) > 0;
    }

    // Update an existing order
    public bool UpdateOrder(DTO_Order order)
    {
        string query = "UPDATE Orders SET ClientID = @ClientID, EmployeeID = @EmployeeID, OrderDate = @OrderDate, " +
                       "TotalPrice = @TotalPrice WHERE ID = @ID";
        SqlParameter[] parameters = new SqlParameter[]
        {
            new SqlParameter("@ID", order.ID),
            new SqlParameter("@ClientID", order.ClientID),
            new SqlParameter("@EmployeeID", order.EmployeeID),
            new SqlParameter("@OrderDate", order.OrderDate),
            new SqlParameter("@TotalPrice", order.TotalPrice)
        };
        return connection.ExecuteNonQuery(query, parameters) > 0;
    }

    // Delete an order
    public bool DeleteOrder(string orderID)
    {
        string query = "DELETE FROM Orders WHERE ID = @ID";
        SqlParameter[] parameters = new SqlParameter[]
        {
            new SqlParameter("@ID", orderID)
        };
        return connection.ExecuteNonQuery(query, parameters) > 0;
    }

    // Get the last OrderID
    public string GetLastOrderID()
    {
        string query = "SELECT TOP 1 ID FROM Orders ORDER BY ID DESC";
        DataTable dt = connection.SelectQuery(query);

        if (dt.Rows.Count > 0)
        {
            return dt.Rows[0]["ID"].ToString();
        }
        return null;  // Return null if there are no orders
    }

    public string GetMaxOrderID()
    {
        string query = "SELECT MAX(ID) FROM Orders";
        DataTable dt = connection.SelectQuery(query);

        if (dt.Rows.Count > 0 && dt.Rows[0][0] != DBNull.Value)
        {
            return dt.Rows[0][0].ToString();
        }
        return null; // Trả về null nếu không có Order nào
    }

    public DataTable GetAllOrdersWithItems()
    {
        string query = @"
                SELECT 
                    oi.ID AS OrderItemID,
                    o.ID AS OrderID,
                    o.ClientID,
                    o.EmployeeID,
                    oi.ProductID,
                    p.Name AS ProductName,
                    oi.Quantity,
                    o.TotalPrice,
                    o.OrderDate
                FROM Orders o
                INNER JOIN OrderItem oi ON o.ID = oi.OrderID
                INNER JOIN Product p ON oi.ProductID = p.ID";

        return connection.SelectQuery(query);
    }
}
