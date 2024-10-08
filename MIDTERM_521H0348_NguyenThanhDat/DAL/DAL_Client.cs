using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class DAL_Client
    {
        private Connection connection = new Connection(); // Sử dụng lớp Connection được tạo trước đó

        // Lấy tất cả khách hàng
        public List<DTO_Client> GetAllClients()
        {
            List<DTO_Client> clients = new List<DTO_Client>();
            string query = "SELECT * FROM Client";
            DataTable dt = connection.SelectQuery(query);

            foreach (DataRow row in dt.Rows)
            {
                DTO_Client client = new DTO_Client
                {
                    ID = row["ID"].ToString(),
                    Name = row["Name"].ToString(),
                    Email = row["Email"].ToString(),
                    Phone = row["Phone"].ToString(),
                    Address = row["Address"].ToString()
                };
                clients.Add(client);
            }

            return clients;
        }

        // Lấy khách hàng theo ID
        public DTO_Client GetClientByID(string clientID)
        {
            string query = "SELECT * FROM Client WHERE ID = @ID";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@ID", clientID)
            };
            DataTable dt = connection.SelectQuery(query, parameters);

            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                return new DTO_Client
                {
                    ID = row["ID"].ToString(),
                    Name = row["Name"].ToString(),
                    Email = row["Email"].ToString(),
                    Phone = row["Phone"].ToString(),
                    Address = row["Address"].ToString()
                };
            }
            return null; // Nếu không tìm thấy
        }

        // Thêm khách hàng mới
        public bool InsertClient(DTO_Client client)
        {
            string query = "INSERT INTO Client (ID, Name, Email, Phone, Address) VALUES (@ID, @Name, @Email, @Phone, @Address)";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@ID", client.ID),
                new SqlParameter("@Name", client.Name),
                new SqlParameter("@Email", client.Email),
                new SqlParameter("@Phone", client.Phone),
                new SqlParameter("@Address", client.Address)
            };

            // Return true if the insert operation affects at least one row (i.e., insertion was successful)
            return connection.ExecuteNonQuery(query, parameters) > 0;
        }

        // Cập nhật khách hàng
        public bool UpdateClient(DTO_Client client)
        {
            string query = "UPDATE Client SET Name = @Name, Email = @Email, Phone = @Phone, Address = @Address WHERE ID = @ID";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@ID", client.ID),
                new SqlParameter("@Name", client.Name),
                new SqlParameter("@Email", client.Email),
                new SqlParameter("@Phone", client.Phone),
                new SqlParameter("@Address", client.Address)
            };

            // Return true if the update was successful (affected rows > 0)
            return connection.ExecuteNonQuery(query, parameters) > 0;
        }

        // Xóa khách hàng
        public bool DeleteClient(string clientID)
        {
            string query = "DELETE FROM Client WHERE ID = @ID";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@ID", clientID)
            };

            // Return true if the deletion was successful (affected rows > 0)
            return connection.ExecuteNonQuery(query, parameters) > 0;
        }

        public string GetLastClientID()
        {
            string query = "SELECT TOP 1 ID FROM Client ORDER BY ID DESC";
            DataTable dt = connection.SelectQuery(query);

            if (dt.Rows.Count > 0)
            {
                // Return the last ClientID
                return dt.Rows[0]["ID"].ToString();
            }

            return null;  // Return null if no clients exist
        }

        public bool DoesClientExist(string clientID)
        {
            string query = "SELECT COUNT(*) FROM Client WHERE ID = @ID";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@ID", clientID)
            };
            int count = (int)connection.ExecuteScalar(query, parameters);  // Executes a query and returns the first column of the first row
            return count > 0;  // Return true if employee exists, false otherwise
        }

        public string GetClientNameByID(string clientID)
        {
            string query = "SELECT Name FROM Client WHERE ID = @ID";
            SqlParameter[] parameters = new SqlParameter[]
            {
            new SqlParameter("@ID", clientID)
            };

            DataTable dt = connection.SelectQuery(query, parameters);

            if (dt.Rows.Count > 0)
            {
                return dt.Rows[0]["Name"].ToString();  // Trả về tên của khách hàng
            }
            return null;  // Trả về null nếu không tìm thấy khách hàng
        }
    }
}
