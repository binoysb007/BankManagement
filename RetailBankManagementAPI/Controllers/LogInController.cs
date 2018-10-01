using RetailBankManagementAPI.DataLayer;
using RetailBankManagementAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RetailBankManagementAPI.Controllers
{
    public class LogInController : ApiController
    {
        [HttpPost]
        public string BankLogIn(LogInRequest ObjLogInRequest)
        {
            LogInServiceMethod ObjLogInServiceMethod = new LogInServiceMethod();
           
            string Role= ObjLogInServiceMethod.Login(ObjLogInRequest);
            return Role;
        }
    }
}
