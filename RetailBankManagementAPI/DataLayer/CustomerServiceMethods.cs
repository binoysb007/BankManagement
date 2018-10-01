using RetailBankManagementAPI.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace RetailBankManagementAPI.DataLayer
{
    public class CustomerServiceMethods
    {
        public int AddCustomer(CreateCustomerRequest ObjCreateCustomerRequest)
        {
            try
            {
                DateTime date = DateTime.Now;
               
                string connectionstring = "data source=.;" + "database=Binoy;" + "Integrated Security=true";
                SqlConnection connection = new SqlConnection(connectionstring);
                connection.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_addCustomer_s2por";
                cmd.Connection = connection;
                cmd.Parameters.AddWithValue("@Customer_SSN_ID", ObjCreateCustomerRequest.Customer_ssn_Id);
                cmd.Parameters.AddWithValue("@Customer_Name", ObjCreateCustomerRequest.Customer_Name);
                cmd.Parameters.AddWithValue("@Customer_Age", ObjCreateCustomerRequest.Customer_Age);
                cmd.Parameters.AddWithValue("@Customer_Address", ObjCreateCustomerRequest.Customer_Address);
                cmd.Parameters.AddWithValue("@Customer_State", ObjCreateCustomerRequest.Customer_State);
                cmd.Parameters.AddWithValue("@Customer_City", ObjCreateCustomerRequest.Customer_City);
                cmd.Parameters.AddWithValue("@date", date);
                cmd.Parameters.AddWithValue("@Customer_ID", 0);
                cmd.Parameters["@Customer_ID"].Direction = ParameterDirection.Output;

                int Rowaffected = cmd.ExecuteNonQuery();
                connection.Close();
                CreateCustomerResponse ObjCreateCustomerResponse = new CreateCustomerResponse();
                if (Rowaffected > 0)
                {
                    ObjCreateCustomerResponse.CustomerID= Convert.ToInt32(cmd.Parameters["@Customer_ID"].Value);
                    return ObjCreateCustomerResponse.CustomerID;
                }
                else
                {
                    return 0;
                }
            }
            catch (SqlException e)
            {
                return 1;
            }

        }

        public List<ViewCustomerResponse> ViewAllCustomer()
        {
            
            string connectionstring = "data source=.;" + "database=Binoy;" + "Integrated Security=true";
            SqlConnection connection = new SqlConnection(connectionstring);
            connection.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "View_Customer_StatusAll_s2por_procedure";
            cmd.Connection = connection;
            List<ViewCustomerResponse> clist = new List<ViewCustomerResponse>();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                int c_id = Convert.ToInt32(reader["Customer_ID"]);
                int ssn_id = Convert.ToInt32(reader["Customer_SSNID"]);
                string status = reader["Status"].ToString();
                string message = reader["Message"].ToString();
                DateTime up_date = Convert.ToDateTime(reader["Last_Updated"]);
                ViewCustomerResponse cus = new ViewCustomerResponse(c_id, ssn_id, status, message, up_date);
                clist.Add(cus);
            }
            connection.Close();
            return (clist);
        }

        public string UpdateCustomerMethod(UpdateCustomerRequest ObjUpdateCustomerRequest)
        {
            DateTime date = DateTime.Now;
            
            string connectionstring = "data source=.;" + "database=Binoy;" + "Integrated Security=true";
            SqlConnection connection = new SqlConnection(connectionstring);
            connection.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "updatecustomer_s2por";
            cmd.Connection = connection;
            cmd.Parameters.AddWithValue("@Customer_ID", ObjUpdateCustomerRequest.Customer_Id);
            cmd.Parameters.AddWithValue("@Customer_SSN_ID", ObjUpdateCustomerRequest.Customer_ssn_Id);
            cmd.Parameters.AddWithValue("@Customer_Name", ObjUpdateCustomerRequest.Customer_Name);
            cmd.Parameters.AddWithValue("@Customer_Age", ObjUpdateCustomerRequest.Customer_Age);
            cmd.Parameters.AddWithValue("@Customer_Address", ObjUpdateCustomerRequest.Customer_Address);
            cmd.Parameters.AddWithValue("@Customer_State", ObjUpdateCustomerRequest.Customer_State);
            cmd.Parameters.AddWithValue("@Customer_City", ObjUpdateCustomerRequest.Customer_City);
            cmd.Parameters.AddWithValue("@Update_date", date);
            string result = cmd.ExecuteNonQuery().ToString();
            connection.Close();
            return result;
        }

        public int DeleteCustomerMethod(CreateCustomerResponse ObjCreateCustomerResponse)
        {
            try
            {
                
                string connectionstring = "data source=.;" + "database=Binoy;" + "Integrated Security=true";
                SqlConnection connection = new SqlConnection(connectionstring);

                connection.Open();
                SqlCommand command = new SqlCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "sp_deletecustomer14_s2por";
                command.Connection = connection;
                command.Parameters.AddWithValue("@customerid", ObjCreateCustomerResponse.CustomerID);
                command.Parameters.AddWithValue("@count", 0);
                int rowAffected = command.ExecuteNonQuery();
                connection.Close();
                if (rowAffected > 0)
                {
                    return 1;
                }
                else
                {
                    return 2;
                }
            }
            catch (Exception e)
            {
                return 0;
            }

        }

        public int CheckCustomer(CheckCustomerRequest ObjCheckCustomerRequest)
        {
            
            string connectionstring = "data source=.;" + "database=Binoy;" + "Integrated Security=true";
            SqlConnection connection = new SqlConnection(connectionstring);
            connection.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_checkCustomer_s2por";
            cmd.Connection = connection;
            cmd.Parameters.AddWithValue("@id", ObjCheckCustomerRequest.Id);
            cmd.Parameters.AddWithValue("@count", 0);
            cmd.Parameters.AddWithValue("@name", ObjCheckCustomerRequest.Name);
            cmd.Parameters["@count"].Direction = ParameterDirection.Output;
            int check = cmd.ExecuteNonQuery();
            connection.Close();
            CheckCustomerResponse ObjCheckCustomerResponse = new CheckCustomerResponse();
            return ObjCheckCustomerResponse.Count =(Convert.ToInt32(cmd.Parameters["@count"].Value));
        }
    }
}