using DAL;
using System;
using System.Collections.Generic;
using System.Data;

public class BUS_Orders
{
    private DAL_Orders dalOrders = new DAL_Orders();
    private DAL_OrderItem dalOrderItem = new DAL_OrderItem();

    // Get all orders
    public List<DTO_Order> GetAllOrders()
    {
        return dalOrders.GetAllOrders();
    }

    // Get order by ID
    public DTO_Order GetOrderByID(string orderID)
    {
        if (string.IsNullOrEmpty(orderID))
        {
            throw new Exception("Order ID cannot be null or empty.");
        }
        return dalOrders.GetOrderByID(orderID);
    }

    // Add a new order
    public void AddOrder(DTO_Order order)
    {
        // Validate order data
        if (string.IsNullOrEmpty(order.ID) || order.TotalPrice <= 0)
        {
            throw new Exception("Invalid order data.");
        }

        // Call DAL to add the order
        if (!dalOrders.InsertOrder(order))
        {
            throw new Exception("Error adding new order.");
        }
    }

    // Update an existing order
    public void UpdateOrder(DTO_Order order)
    {
        // Validate order data
        if (string.IsNullOrEmpty(order.ID) || order.TotalPrice <= 0)
        {
            throw new Exception("Invalid order data.");
        }

        // Call DAL to update the order
        if (!dalOrders.UpdateOrder(order))
        {
            throw new Exception("Error updating order.");
        }
    }

    // Delete an order
    public void DeleteOrder(string orderID)
    {
        if (string.IsNullOrEmpty(orderID))
        {
            throw new Exception("Order ID cannot be null or empty.");
        }

        // Call DAL to delete the order
        if (!dalOrders.DeleteOrder(orderID))
        {
            throw new Exception("Error deleting order.");
        }
    }

    // Insert an order with multiple items
    public bool PlaceOrder(DTO_Order order, List<DTO_OrderItem> orderItems)
    {
        bool success = dalOrders.InsertOrder(order);
        if (success)
        {
            foreach (var item in orderItems)
            {
                success = dalOrderItem.InsertOrderItem(item);
                if (!success) break; // Stop if any item fails to insert
            }
        }
        return success;
    }

    // Generate the next OrderID
    public string GenerateNextOrderID()
    {
        // Get the last OrderID from the DAL
        string lastOrderID = dalOrders.GetLastOrderID();

        if (lastOrderID == null)
        {
            // If no orders exist, start from O0001
            return "O0001";
        }

        // Extract the numeric part of the OrderID (e.g., 0001 from O0001)
        int numericPart = int.Parse(lastOrderID.Substring(1));

        // Increment the numeric part by 1
        numericPart++;

        // Format the new OrderID with leading zeros (e.g., O0002, O0010, etc.)
        return "O" + numericPart.ToString("D4");
    }

    public string GetMaxOrderID()
    {
        return dalOrders.GetMaxOrderID();
    }

    public DataTable GetAllOrdersWithItems()
    {
        return dalOrders.GetAllOrdersWithItems();
    }

}
