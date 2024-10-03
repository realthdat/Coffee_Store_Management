using System;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class Connection
    {
        // Hardcode the connection string here
        private readonly string connectionString = "Data Source=DATDEV;Initial Catalog=PiStoreManagement;Persist Security Info=True;User ID=DatDev;Password=123456";

        // Method to get the SqlConnection
        private SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }

        // Method to execute SELECT queries and return a DataTable with parameter support
        public DataTable SelectQuery(string query, SqlParameter[] parameters = null)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(query, conn);

                    // Add parameters if provided
                    if (parameters != null)
                    {
                        cmd.Parameters.AddRange(parameters);
                    }

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                }
            }
            catch (Exception ex)
            {
                // Handle the exception (you can log this error if needed)
                throw new Exception("Error executing SELECT query: " + ex.Message);
            }
            return dt;
        }

        // Method to execute INSERT, UPDATE, DELETE queries with parameter support
        public int ExecuteNonQuery(string query, SqlParameter[] parameters = null)
        {
            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(query, conn);

                    // Add parameters if provided
                    if (parameters != null)
                    {
                        cmd.Parameters.AddRange(parameters);
                    }

                    return cmd.ExecuteNonQuery();  // Returns the number of rows affected
                }
            }
            catch (Exception ex)
            {
                // Handle the exception (you can log this error if needed)
                throw new Exception("Error executing Non-Query: " + ex.Message);
            }
        }

        // Method to execute a query and return a single value (e.g., for aggregate functions) with parameter support
        public object ExecuteScalar(string query, SqlParameter[] parameters = null)
        {
            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(query, conn);

                    // Add parameters if provided
                    if (parameters != null)
                    {
                        cmd.Parameters.AddRange(parameters);
                    }

                    return cmd.ExecuteScalar();  // Returns a single value (first column of the first row)
                }
            }
            catch (Exception ex)
            {
                // Handle the exception (you can log this error if needed)
                throw new Exception("Error executing Scalar query: " + ex.Message);
            }
        }
    }
}
