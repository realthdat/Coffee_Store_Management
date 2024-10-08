using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace DAL
{
    public class DAL_Employee
    {
        private Connection connection = new Connection(); // Assume this is your database connection class

        // Get all employees from the database
        public List<DTO_Employee> GetAllEmployees()
        {
            List<DTO_Employee> employees = new List<DTO_Employee>();
            string query = "SELECT * FROM Employee";
            DataTable dt = connection.SelectQuery(query);

            foreach (DataRow row in dt.Rows)
            {
                DTO_Employee employee = new DTO_Employee
                {
                    ID = row["ID"].ToString(),
                    Name = row["Name"].ToString(),
                    Email = row["Email"].ToString(),
                    Phone = row["Phone"].ToString(),
                    Address = row["Address"].ToString(),
                    Salary = Convert.ToDecimal(row["Salary"]),
                    HireDate = Convert.ToDateTime(row["HireDate"])
                };
                employees.Add(employee);
            }

            return employees;
        }

        // Get a single employee by their ID
        public DTO_Employee GetEmployeeByID(string employeeID)
        {
            string query = "SELECT * FROM Employee WHERE ID = @ID";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@ID", employeeID)
            };
            DataTable dt = connection.SelectQuery(query, parameters);

            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                return new DTO_Employee
                {
                    ID = row["ID"].ToString(),
                    Name = row["Name"].ToString(),
                    Email = row["Email"].ToString(),
                    Phone = row["Phone"].ToString(),
                    Address = row["Address"].ToString(),
                    Salary = Convert.ToDecimal(row["Salary"]),
                    HireDate = Convert.ToDateTime(row["HireDate"])
                };
            }

            return null; // Return null if not found
        }

        // Insert a new employee into the database
        public bool InsertEmployee(DTO_Employee employee)
        {
            string query = "INSERT INTO Employee (ID, Name, Email, Phone, Address, Salary, HireDate) " +
                           "VALUES (@ID, @Name, @Email, @Phone, @Address, @Salary, @HireDate)";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@ID", employee.ID),
                new SqlParameter("@Name", employee.Name),
                new SqlParameter("@Email", employee.Email),
                new SqlParameter("@Phone", employee.Phone),
                new SqlParameter("@Address", employee.Address),
                new SqlParameter("@Salary", employee.Salary),
                new SqlParameter("@HireDate", employee.HireDate)
            };
            return connection.ExecuteNonQuery(query, parameters) > 0;
        }

        // Update an employee in the database
        public bool UpdateEmployee(DTO_Employee employee)
        {
            string query = "UPDATE Employee SET Name = @Name, Email = @Email, Phone = @Phone, " +
                           "Address = @Address, Salary = @Salary, HireDate = @HireDate WHERE ID = @ID";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@ID", employee.ID),
                new SqlParameter("@Name", employee.Name),
                new SqlParameter("@Email", employee.Email),
                new SqlParameter("@Phone", employee.Phone),
                new SqlParameter("@Address", employee.Address),
                new SqlParameter("@Salary", employee.Salary),
                new SqlParameter("@HireDate", employee.HireDate)
            };
            return connection.ExecuteNonQuery(query, parameters) > 0;
        }

        // Delete an employee from the database by ID
        public bool DeleteEmployee(string employeeID)
        {
            string query = "DELETE FROM Employee WHERE ID = @ID";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@ID", employeeID)
            };
            return connection.ExecuteNonQuery(query, parameters) > 0;
        }

        // Retrieve the last employee ID for auto-generation of the next employee ID
        public string GetLastEmployeeID()
        {
            string query = "SELECT TOP 1 ID FROM Employee ORDER BY ID DESC";
            DataTable dt = connection.SelectQuery(query);

            if (dt.Rows.Count > 0)
            {
                // Return the last Employee ID
                return dt.Rows[0]["ID"].ToString();
            }

            return null;  // Return null if no employees exist
        }

        public bool DoesEmployeeExist(string employeeID)
        {
            string query = "SELECT COUNT(*) FROM Employee WHERE ID = @ID";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@ID", employeeID)
            };
            int count = (int)connection.ExecuteScalar(query, parameters);  // Executes a query and returns the first column of the first row
            return count > 0;  // Return true if employee exists, false otherwise
        }

        public string GetEmployeeNameByID(string employeeID)
        {
            string query = "SELECT Name FROM Employee WHERE ID = @ID";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@ID", employeeID)
            };

            DataTable dt = connection.SelectQuery(query, parameters);

            if (dt.Rows.Count > 0)
            {
                return dt.Rows[0]["Name"].ToString();  // Trả về tên của nhân viên
            }
            return null;  // Trả về null nếu không tìm thấy nhân viên
        }
    }
}
