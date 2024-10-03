using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class DAL_Product
    {
        private Connection connection = new Connection(); // Assuming this is your connection class

        // Get all products
        public List<DTO_Product> GetAllProducts()
        {
            List<DTO_Product> products = new List<DTO_Product>();
            string query = "SELECT * FROM Product";
            DataTable dt = connection.SelectQuery(query);

            foreach (DataRow row in dt.Rows)
            {
                DTO_Product product = new DTO_Product
                {
                    ID = row["ID"].ToString(),
                    Name = row["Name"].ToString(),
                    Description = row["Description"].ToString(),
                    Price = Convert.ToDecimal(row["Price"]),
                    Quantity = Convert.ToInt32(row["Quantity"])
                };
                products.Add(product);
            }

            return products;
        }

        // Insert a new product
        public bool InsertProduct(DTO_Product product)
        {
            string query = "INSERT INTO Product (ID, Name, Description, Price, Quantity) VALUES (@ID, @Name, @Description, @Price, @Quantity)";
            SqlParameter[] parameters = new SqlParameter[]
            {
            new SqlParameter("@ID", product.ID),
            new SqlParameter("@Name", product.Name),
            new SqlParameter("@Description", product.Description),
            new SqlParameter("@Price", product.Price),
            new SqlParameter("@Quantity", product.Quantity)
            };

            return connection.ExecuteNonQuery(query, parameters) > 0;
        }

        // Update an existing product
        public bool UpdateProduct(DTO_Product product)
        {
            string query = "UPDATE Product SET Name = @Name, Description = @Description, Price = @Price, Quantity = @Quantity WHERE ID = @ID";
            SqlParameter[] parameters = new SqlParameter[]
            {
            new SqlParameter("@ID", product.ID),
            new SqlParameter("@Name", product.Name),
            new SqlParameter("@Description", product.Description),
            new SqlParameter("@Price", product.Price),
            new SqlParameter("@Quantity", product.Quantity)
            };

            return connection.ExecuteNonQuery(query, parameters) > 0;
        }

        // Delete a product
        public bool DeleteProduct(string productID)
        {
            string query = "DELETE FROM Product WHERE ID = @ID";
            SqlParameter[] parameters = new SqlParameter[]
            {
            new SqlParameter("@ID", productID)
            };

            return connection.ExecuteNonQuery(query, parameters) > 0;
        }

        // Get the last ProductID for auto-generation of new IDs
        public string GetLastProductID()
        {
            string query = "SELECT TOP 1 ID FROM Product ORDER BY ID DESC";
            DataTable dt = connection.SelectQuery(query);

            if (dt.Rows.Count > 0)
            {
                return dt.Rows[0]["ID"].ToString();
            }
            return null;
        }

        // Get the price of a product by its ProductID
        public decimal GetProductPrice(string productID)
        {
            string query = "SELECT Price FROM Product WHERE ID = @ProductID";
            SqlParameter[] parameters = new SqlParameter[]
            {
            new SqlParameter("@ProductID", productID)
            };

            DataTable dt = connection.SelectQuery(query, parameters);

            if (dt.Rows.Count > 0)
            {
                return Convert.ToDecimal(dt.Rows[0]["Price"]);
            }
            else
            {
                throw new Exception("Product not found.");
            }
        }

        public DTO_Product GetProductByID(string productID)
        {
            string query = "SELECT * FROM Product WHERE ID = @ID";
            SqlParameter[] parameters = new SqlParameter[]
            {
        new SqlParameter("@ID", productID)
            };

            DataTable dt = connection.SelectQuery(query, parameters);

            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];

                // Create a DTO_Product object based on the fetched row
                DTO_Product product = new DTO_Product
                {
                    ID = row["ID"].ToString(),
                    Name = row["Name"].ToString(),
                    Description = row["Description"].ToString(),
                    Price = Convert.ToDecimal(row["Price"]),
                    Quantity = Convert.ToInt32(row["Quantity"])
                };

                return product;
            }

            // If no product is found with the provided ID, return null
            return null;
        }

        public bool DoesProductExist(string productID)
        {
            string query = "SELECT COUNT(*) FROM Product WHERE ID = @ID";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@ID", productID)
            };
            int count = (int)connection.ExecuteScalar(query, parameters);  // Executes a query and returns the first column of the first row
            return count > 0;  // Return true if employee exists, false otherwise
        }

    }
}
