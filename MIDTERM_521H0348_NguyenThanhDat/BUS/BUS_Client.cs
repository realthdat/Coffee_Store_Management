using DAL;
using System;
using System.Collections.Generic;

public class BUS_Client
{
    private DAL_Client dalClient = new DAL_Client();

    // Lấy tất cả khách hàng
    public List<DTO_Client> GetAllClients()
    {
        return dalClient.GetAllClients();
    }

    // Lấy khách hàng theo ID
    public DTO_Client GetClientByID(string clientID)
    {
        if (string.IsNullOrEmpty(clientID))
        {
            throw new Exception("Client ID cannot be null or empty.");
        }

        return dalClient.GetClientByID(clientID);
    }

    // Thêm khách hàng mới
    public bool AddClient(DTO_Client client)
    {
        // Add validation if necessary
        if (string.IsNullOrEmpty(client.Name) || string.IsNullOrEmpty(client.Email))
        {
            throw new Exception("Client Name and Email are required.");
        }

        // Call the DAL to insert the client into the database
        return dalClient.InsertClient(client);  // This returns a boolean indicating success or failure
    }

    // Cập nhật khách hàng
    public bool UpdateClient(DTO_Client client)
    {
        // Validate the input data if needed
        if (string.IsNullOrEmpty(client.ID) || string.IsNullOrEmpty(client.Name) || string.IsNullOrEmpty(client.Email))
        {
            throw new Exception("Client ID, Name, and Email cannot be empty.");
        }

        // Call DAL to update the client
        return dalClient.UpdateClient(client);
    }

    // Xóa khách hàng
    public bool DeleteClient(string clientID)
    {
        if (string.IsNullOrEmpty(clientID))
        {
            throw new Exception("Client ID cannot be empty.");
        }

        // Call the DAL to delete the client
        return dalClient.DeleteClient(clientID);
    }

    public string GenerateNewClientID()
    {
        // Retrieve the last ClientID from the DAL
        string lastID = dalClient.GetLastClientID();

        if (lastID == null)
        {
            // If no client exists, return the first ID
            return "C0001";
        }

        // Extract the numeric part from the last ID (e.g., "0001" from "C0001")
        int numericPart = int.Parse(lastID.Substring(1));

        // Increment the numeric part by 1
        numericPart++;

        // Format the new ID with leading zeros (e.g., "C0011")
        string newID = "C" + numericPart.ToString("D4");

        return newID;
    }

    // Hàm lấy tên khách hàng theo ID
    public string GetClientNameByID(string clientID)
    {
        if (string.IsNullOrEmpty(clientID))
        {
            throw new Exception("Client ID cannot be null or empty.");
        }

        return dalClient.GetClientNameByID(clientID);
    }

    public bool Exists(string clientID)
    {
        return dalClient.DoesClientExist(clientID); // Implement this in DAL_Client
    }

}
