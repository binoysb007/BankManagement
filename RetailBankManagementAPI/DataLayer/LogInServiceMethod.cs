using RetailBankManagementAPI.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace RetailBankManagementAPI.DataLayer
{
    public class LogInServiceMethod
    {
        public string Login(LogInRequest ObjLogInRequest)
        {
            
           string ConnectionString = "data source=.;" + "database=Binoy;" + "Integrated Security=true";
          // string ConnectionString= "Data Source=tcp:binoyserver.database.windows.net,1433;" + "Initial Catalog=binoy;" + "User Id=Binoy;" + "Password=Malu@007;";
            SqlConnection connection = new SqlConnection(ConnectionString);
            connection.Open();
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "WebsiteLoginProcedure_s2por";
            command.Parameters.AddWithValue("@username", ObjLogInRequest.UserId);
            command.Parameters.AddWithValue("@Password", ObjLogInRequest.PassWord);
            command.Connection = connection;
            SqlDataReader Reader = command.ExecuteReader();
            LogInResponse ObjLogInResponse = new LogInResponse();
            if (Reader.Read())
            {
                ObjLogInResponse.Role = Reader["Role"].ToString();
                return ObjLogInResponse.Role;
            }
            else
            {
                ObjLogInResponse.Role= "Invalid Username/Password";
                return ObjLogInResponse.Role;
            }
        }
    }
}