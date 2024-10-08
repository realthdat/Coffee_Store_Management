using DAL;
using System;
using System.Collections.Generic;

public class BUS_Product
{
    private DAL_Product dalProduct = new DAL_Product();

    // Get all products
    public List<DTO_Product> GetAllProducts()
    {
        return dalProduct.GetAllProducts();
    }

    // Add a new product
    public bool AddProduct(DTO_Product product)
    {
        return dalProduct.InsertProduct(product);
    }

    // Update an existing product
    public bool UpdateProduct(DTO_Product product)
    {
        return dalProduct.UpdateProduct(product);
    }

    // Delete a product
    public bool DeleteProduct(string productID)
    {
        return dalProduct.DeleteProduct(productID);
    }

    // Generate a new Product ID based on the last one
    public string GenerateNewProductID()
    {
        string lastID = dalProduct.GetLastProductID();
        if (lastID == null)
        {
            return "P0001";
        }

        // Extract the numeric part of the ID and increment it
        int numericPart = int.Parse(lastID.Substring(1)) + 1;
        return "P" + numericPart.ToString("D4"); // Format with leading zeros
    }

    // Get the price of a product by its ProductID
    public decimal GetProductPrice(string productID)
    {
        return dalProduct.GetProductPrice(productID);
    }


    public bool DeductProductQuantity(string productID, int quantity)
    {
        // Get the current quantity of the product from the database
        DTO_Product product = dalProduct.GetProductByID(productID);

        if (product.Quantity >= quantity)
        {
            // Deduct the quantity
            product.Quantity -= quantity;

            // Update the product in the database
            return dalProduct.UpdateProduct(product);
        }
        else
        {
            // Not enough stock
            return false;
        }
    }
    public DTO_Product GetProductByID(string productID)
    {
        return dalProduct.GetProductByID(productID);
    }

    public bool Exists(string productID)
    {
        return dalProduct.DoesProductExist(productID); // Check if the product exists in the database
    }
}
