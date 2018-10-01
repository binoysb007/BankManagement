using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RetailBankManagementAPI.Models
{
    public class LogInRequest
    {
        public string UserId { get; set; }
        public string PassWord { get; set; }
    }
}