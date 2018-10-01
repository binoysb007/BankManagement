using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RetailBankManagementAPI.Models
{
    public class ViewCustomerResponse
    {
        public string customer_status { get; set; }
        public string customer_message { get; set; }
        public DateTime update_date { get; set; }
        public int Customer_Id { get; set; }
        public int Customer_ssn_Id { get; set; }

        public ViewCustomerResponse(int c_id, int ssn_id, string status, string message, DateTime up_date)
        {
            // TODO: Complete member initialization
            Customer_Id = c_id;
            Customer_ssn_Id = ssn_id;
            customer_status = status;
            customer_message = message;
            update_date = up_date;
        }

        public ViewCustomerResponse() { }
    }
}