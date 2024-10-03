using DAL;
using System;
using System.Collections.Generic;

public class BUS_Employee
{
    private DAL_Employee dalEmployee = new DAL_Employee();

    // Get all employees
    public List<DTO_Employee> GetAllEmployees()
    {
        try
        {
            return dalEmployee.GetAllEmployees();
        }
        catch (Exception ex)
        {
            // Log or handle exception if needed
            throw new Exception("Error retrieving employee list.", ex);
        }
    }

    // Get employee by ID
    public DTO_Employee GetEmployeeByID(string employeeID)
    {
        if (string.IsNullOrEmpty(employeeID))
        {
            throw new Exception("Employee ID cannot be null or empty.");
        }

        try
        {
            return dalEmployee.GetEmployeeByID(employeeID);
        }
        catch (Exception ex)
        {
            // Handle or log exception
            throw new Exception("Error retrieving employee details.", ex);
        }
    }

    // Add a new employee
    public bool AddEmployee(DTO_Employee employee)
    {
        // Validate the employee data
        if (string.IsNullOrEmpty(employee.Name))
        {
            throw new Exception("Employee Name cannot be empty.");
        }

        if (employee.Salary < 0)
        {
            throw new Exception("Salary cannot be negative.");
        }

        try
        {
            // Auto-generate Employee ID if not provided
            if (string.IsNullOrEmpty(employee.ID))
            {
                employee.ID = GenerateNewEmployeeID();
            }

            // Call DAL to add employee
            return dalEmployee.InsertEmployee(employee);
        }
        catch (Exception ex)
        {
            // Handle or log exception
            throw new Exception("Error adding new employee.", ex);
        }
    }

    // Update an existing employee
    public bool UpdateEmployee(DTO_Employee employee)
    {
        // Validate the employee data
        if (string.IsNullOrEmpty(employee.ID) || string.IsNullOrEmpty(employee.Name))
        {
            throw new Exception("Employee ID and Name cannot be empty.");
        }

        if (employee.Salary < 0)
        {
            throw new Exception("Salary cannot be negative.");
        }

        try
        {
            // Call DAL to update employee
            return dalEmployee.UpdateEmployee(employee);
        }
        catch (Exception ex)
        {
            // Handle or log exception
            throw new Exception("Error updating employee.", ex);
        }
    }

    // Delete an employee
    public bool DeleteEmployee(string employeeID)
    {
        if (string.IsNullOrEmpty(employeeID))
        {
            throw new Exception("Employee ID cannot be null or empty.");
        }

        try
        {
            // Call DAL to delete employee
            return dalEmployee.DeleteEmployee(employeeID);
        }
        catch (Exception ex)
        {
            // Handle or log exception
            throw new Exception("Error deleting employee.", ex);
        }
    }

    // Generate new employee ID by incrementing the last employee ID
    public string GenerateNewEmployeeID()
    {
        try
        {
            // Retrieve the last Employee ID from the DAL
            string lastID = dalEmployee.GetLastEmployeeID();

            if (lastID == null)
            {
                // If no employee exists, return the first ID
                return "E0001";
            }

            // Extract the numeric part from the last ID (e.g., "0001" from "E0001")
            int numericPart = int.Parse(lastID.Substring(1));

            // Increment the numeric part by 1
            numericPart++;

            // Format the new ID with leading zeros (e.g., "E0011")
            string newID = "E" + numericPart.ToString("D4");

            return newID;
        }
        catch (Exception ex)
        {
            throw new Exception("Error generating new employee ID.", ex);
        }
    }

    public bool Exists(string employeeID)
    {
        // Call DAO layer to check if employee exists in the database
        return dalEmployee.DoesEmployeeExist(employeeID);
    }
}
