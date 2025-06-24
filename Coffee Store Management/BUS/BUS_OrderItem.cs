using DAL;
using System;
using System.Collections.Generic;

public class BUS_OrderItem
{
    private DAL_OrderItem dalOrderItem = new DAL_OrderItem();

    // Lấy tất cả các mục trong đơn hàng
    public List<DTO_OrderItem> GetAllOrderItems()
    {
        return dalOrderItem.GetAllOrderItems();
    }

    // Lấy mục theo OrderID
    public List<DTO_OrderItem> GetOrderItemsByOrderID(string orderID)
    {
        if (string.IsNullOrEmpty(orderID))
        {
            throw new Exception("Order ID cannot be null or empty.");
        }

        return dalOrderItem.GetOrderItemsByOrderID(orderID);
    }

    // Thêm mục mới vào đơn hàng
    public void AddOrderItem(DTO_OrderItem orderItem)
    {
        // Kiểm tra tính hợp lệ của dữ liệu
        if (string.IsNullOrEmpty(orderItem.ID) || string.IsNullOrEmpty(orderItem.OrderID) || string.IsNullOrEmpty(orderItem.ProductID) || orderItem.Quantity <= 0)
        {
            throw new Exception("Invalid order item data.");
        }

        // Gọi DAL để thêm mục
        if (!dalOrderItem.InsertOrderItem(orderItem))
        {
            throw new Exception("Error adding order item.");
        }
    }

    // Cập nhật mục trong đơn hàng
    public void UpdateOrderItem(DTO_OrderItem orderItem)
    {
        // Kiểm tra tính hợp lệ của dữ liệu
        if (string.IsNullOrEmpty(orderItem.ID) || string.IsNullOrEmpty(orderItem.OrderID) || string.IsNullOrEmpty(orderItem.ProductID) || orderItem.Quantity <= 0)
        {
            throw new Exception("Invalid order item data.");
        }

        // Gọi DAL để cập nhật mục
        if (!dalOrderItem.UpdateOrderItem(orderItem))
        {
            throw new Exception("Error updating order item.");
        }
    }

    // Xóa mục khỏi đơn hàng
    public void DeleteOrderItem(string orderItemID)
    {
        if (string.IsNullOrEmpty(orderItemID))
        {
            throw new Exception("Order item ID cannot be null or empty.");
        }

        // Gọi DAL để xóa mục
        if (!dalOrderItem.DeleteOrderItem(orderItemID))
        {
            throw new Exception("Error deleting order item.");
        }
    }

    public string GenerateNextOrderItemID()
    {
        // Get the last OrderItemID from the DAL
        string lastOrderItemID = dalOrderItem.GetLastOrderItemID();

        if (lastOrderItemID == null)
        {
            // If no order items exist, start from OI0001
            return "OI0001";
        }

        // Extract the numeric part of the OrderItemID (e.g., 0001 from OI0001)
        int numericPart = int.Parse(lastOrderItemID.Substring(2));

        // Increment the numeric part by 1
        numericPart++;

        // Format the new OrderItemID with leading zeros (e.g., OI0002, OI0010, etc.)
        return "OI" + numericPart.ToString("D4");
    }

    public string GetMaxOrderItemID()
    {
        return dalOrderItem.GetMaxOrderItemID();
    }
}
