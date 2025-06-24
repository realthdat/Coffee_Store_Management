using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class DAL_Account
    {
        private Connection connection = new Connection(); // Sử dụng lớp Connection được tạo trước đó

        // Lấy tất cả các tài khoản
        public List<DTO_Account> GetAllAccounts()
        {
            List<DTO_Account> accounts = new List<DTO_Account>();
            string query = "SELECT * FROM Account";
            DataTable dt = connection.SelectQuery(query);

            foreach (DataRow row in dt.Rows)
            {
                DTO_Account account = new DTO_Account
                {
                    ID = row["ID"].ToString(),
                    Username = row["Username"].ToString(),
                    PasswordHash = row["PasswordHash"].ToString(),
                    EmployeeID = row["EmployeeID"].ToString(),
                    Role = row["Role"].ToString()
                };
                accounts.Add(account);
            }

            return accounts;
        }

        // Lấy tài khoản theo Username
        public DTO_Account GetAccountByUsername(string username)
        {
            string query = "SELECT * FROM Account WHERE Username = @Username";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@Username", username)
            };
            DataTable dt = connection.SelectQuery(query, parameters);

            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                return new DTO_Account
                {
                    ID = row["ID"].ToString(),
                    Username = row["Username"].ToString(),
                    PasswordHash = row["PasswordHash"].ToString(),
                    EmployeeID = row["EmployeeID"].ToString(),
                    Role = row["Role"].ToString()
                };
            }
            return null; // Nếu không tìm thấy
        }

        // Thêm tài khoản mới
        public bool InsertAccount(DTO_Account account)
        {
            string query = "INSERT INTO Account (ID, Username, PasswordHash, EmployeeID, Role) " +
                           "VALUES (@ID, @Username, @PasswordHash, @EmployeeID, @Role)";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@ID", account.ID),
                new SqlParameter("@Username", account.Username),
                new SqlParameter("@PasswordHash", account.PasswordHash),
                new SqlParameter("@EmployeeID", account.EmployeeID),
                new SqlParameter("@Role", account.Role)
            };
            return connection.ExecuteNonQuery(query, parameters) > 0;
        }

        // Cập nhật tài khoản
        public bool UpdateAccount(DTO_Account account)
        {
            string query = "UPDATE Account SET Username = @Username, PasswordHash = @PasswordHash, " +
                           "EmployeeID = @EmployeeID, Role = @Role WHERE ID = @ID";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@ID", account.ID),
                new SqlParameter("@Username", account.Username),
                new SqlParameter("@PasswordHash", account.PasswordHash),
                new SqlParameter("@EmployeeID", account.EmployeeID),
                new SqlParameter("@Role", account.Role)
            };
            return connection.ExecuteNonQuery(query, parameters) > 0;
        }

        // Xóa tài khoản
        public bool DeleteAccount(string accountID)
        {
            string query = "DELETE FROM Account WHERE ID = @ID";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@ID", accountID)
            };
            return connection.ExecuteNonQuery(query, parameters) > 0;
        }

        // Kiểm tra đăng nhập
        public DTO_Account CheckLogin(string username, string passwordHash)
        {
            string query = "SELECT * FROM Account WHERE Username = @Username AND PasswordHash = @PasswordHash";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@Username", username),
                new SqlParameter("@PasswordHash", passwordHash)
            };

            DataTable dt = connection.SelectQuery(query, parameters);

            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                return new DTO_Account
                {
                    ID = row["ID"].ToString(),
                    Username = row["Username"].ToString(),
                    PasswordHash = row["PasswordHash"].ToString(),
                    EmployeeID = row["EmployeeID"].ToString(),
                    Role = row["Role"].ToString()
                };
            }
            return null; // Return null if login failed
        }
    }
}
