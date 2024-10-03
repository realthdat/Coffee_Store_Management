using DAL;
using System;
using System.Collections.Generic;


public class BUS_Account
{
    private DAL_Account dalAccount = new DAL_Account();

    // Lấy tất cả tài khoản
    public List<DTO_Account> GetAllAccounts()
    {
        return dalAccount.GetAllAccounts();
    }

    // Lấy tài khoản theo Username
    public DTO_Account GetAccountByUsername(string username)
    {
        if (string.IsNullOrEmpty(username))
        {
            throw new Exception("Username cannot be null or empty.");
        }

        return dalAccount.GetAccountByUsername(username);
    }

    // Thêm tài khoản mới
    public void AddAccount(DTO_Account account)
    {
        // Kiểm tra tính hợp lệ của dữ liệu
        if (string.IsNullOrEmpty(account.Username) || string.IsNullOrEmpty(account.PasswordHash))
        {
            throw new Exception("Username and Password cannot be empty.");
        }

        // Gọi DAL để thêm tài khoản
        if (!dalAccount.InsertAccount(account))
        {
            throw new Exception("Error adding new account.");
        }
    }

    // Cập nhật tài khoản
    public void UpdateAccount(DTO_Account account)
    {
        // Kiểm tra tính hợp lệ của dữ liệu
        if (string.IsNullOrEmpty(account.Username) || string.IsNullOrEmpty(account.PasswordHash))
        {
            throw new Exception("Username and Password cannot be empty.");
        }

        // Gọi DAL để cập nhật tài khoản
        if (!dalAccount.UpdateAccount(account))
        {
            throw new Exception("Error updating account.");
        }
    }

    // Xóa tài khoản
    public void DeleteAccount(string accountID)
    {
        if (string.IsNullOrEmpty(accountID))
        {
            throw new Exception("Account ID cannot be null or empty.");
        }

        // Gọi DAL để xóa tài khoản
        if (!dalAccount.DeleteAccount(accountID))
        {
            throw new Exception("Error deleting account.");
        }
    }

    // Kiểm tra đăng nhập
    public DTO_Account Login(string username, string passwordHash)
    {
        // Perform basic input validation
        if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(passwordHash))
        {
            throw new Exception("Username and password cannot be empty.");
        }

        // Check login in DAL layer
        DTO_Account account = dalAccount.CheckLogin(username, passwordHash);

        if (account != null)
        {
            return account; // Return the account if login is successful
        }

        throw new Exception("Invalid username or password.");
    }
}
