using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RetailBankManagementAPI.Models
{
    public class UpdateCustomerRequest
    {
        public int Customer_Id { get; set; }
        public int Customer_ssn_Id { get; set; }
        public string Customer_Name { get; set; }
        public int Customer_Age { get; set; }
        public string Customer_Address { get; set; }
        public string Customer_State { get; set; }
        public string Customer_City { get; set; }
        public DateTime DOB { get; set; }
    }
}