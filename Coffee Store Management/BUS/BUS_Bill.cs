using DAL;
using System;
using System.Collections.Generic;

public class BUS_Bill
{
    private DAL_Bill dalBill = new DAL_Bill();

    // Lấy tất cả hóa đơn
    public List<DTO_Bill> GetAllBills()
    {
        return dalBill.GetAllBills();
    }

    // Lấy hóa đơn theo ID
    public DTO_Bill GetBillByID(string billID)
    {
        if (string.IsNullOrEmpty(billID))
        {
            throw new Exception("Bill ID cannot be null or empty.");
        }

        return dalBill.GetBillByID(billID);
    }

    public bool InsertBill(DTO_Bill bill)
    {
        // Call the DAL layer's InsertBill method to insert the bill into the database
        return dalBill.InsertBill(bill.ID, bill.OrderID, bill.ClientID, bill.EmployeeID, bill.BillDate, bill.TotalPrice);
    }

    // Thêm hóa đơn mới
    public void AddBill(DTO_Bill bill)
    {
        // Kiểm tra tính hợp lệ của dữ liệu
        if (string.IsNullOrEmpty(bill.ID) || bill.TotalPrice <= 0)
        {
            throw new Exception("Invalid bill data.");
        }

        // Call the DAL to insert the bill, now that InsertBill returns a bool
        bool isInserted = dalBill.InsertBill(bill.ID, bill.OrderID, bill.ClientID, bill.EmployeeID, bill.BillDate, bill.TotalPrice);

        if (!isInserted)
        {
            throw new Exception("Error adding new bill.");
        }
    }

    // Cập nhật hóa đơn
    public void UpdateBill(DTO_Bill bill)
    {
        // Kiểm tra tính hợp lệ của dữ liệu
        if (string.IsNullOrEmpty(bill.ID) || bill.TotalPrice <= 0)
        {
            throw new Exception("Invalid bill data.");
        }

        // Gọi DAL để cập nhật hóa đơn
        if (!dalBill.UpdateBill(bill))
        {
            throw new Exception("Error updating bill.");
        }
    }

    // Xóa hóa đơn
    public bool DeleteBill(string billID)
    {
        if (string.IsNullOrEmpty(billID))
        {
            throw new Exception("Bill ID cannot be null or empty.");
        }

        // Call DAL to delete the bill and return the result
        return dalBill.DeleteBill(billID);
    }

    // Generate next Bill ID
    public string GenerateNextBillID()
    {
        // Fetch the maximum existing BillID from the DAL
        string lastBillID = dalBill.GetMaxBillID();

        if (string.IsNullOrEmpty(lastBillID))
        {
            // If no BillID exists, start with the first ID
            return "B0001";
        }

        // Extract the numeric part from the BillID (e.g., "0010" from "B0010")
        int numericPart = int.Parse(lastBillID.Substring(1));

        // Increment the numeric part by 1
        numericPart++;

        // Format the new BillID as Bxxxx (e.g., B0011)
        string newBillID = "B" + numericPart.ToString("D4");

        return newBillID;
    }

    // Method to get total bills by a specific date
    public int GetTotalBillsByDate(DateTime date)
    {
        return dalBill.GetTotalBillsByDate(date);
    }

    // Method to get total bills for all time
    public int GetTotalBillsAllTime()
    {
        return dalBill.GetTotalBillsAllTime();
    }

    // Method to get total price by a specific date
    public decimal GetTotalPriceByDate(DateTime date)
    {
        return dalBill.GetTotalPriceByDate(date);
    }

    // Method to get total price for all time
    public decimal GetTotalPriceAllTime()
    {
        return dalBill.GetTotalPriceAllTime();
    }
}
