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
    [RoutePrefix("api/Customer")]
    public class CustomerController : ApiController
    {
        [HttpPost]
        [Route("CreateCustomer")]
        public int CreateCustomer(CreateCustomerRequest ObjCreateCustomerRequest)
        {
            CustomerServiceMethods ObjCustomerServiceMethods = new CustomerServiceMethods();

            int CustomerId = ObjCustomerServiceMethods.AddCustomer(ObjCreateCustomerRequest);
            return CustomerId;
        }

        [HttpPost]
        [Route("UpdateCustomer")]
        public string UpdateCustomer(UpdateCustomerRequest ObjUpdateCustomerRequest)
        {
            CustomerServiceMethods ObjCustomerServiceMethods = new CustomerServiceMethods();

            string CustomerId = ObjCustomerServiceMethods.UpdateCustomerMethod(ObjUpdateCustomerRequest);
            return CustomerId;
        }

        [HttpPost]
        [Route("DeleteCustomer")]
        public int DeleteCustomer(CreateCustomerResponse ObjCreateCustomerResponse)
        {
            CustomerServiceMethods ObjCustomerServiceMethods = new CustomerServiceMethods();

            int Result = ObjCustomerServiceMethods.DeleteCustomerMethod(ObjCreateCustomerResponse);
            return Result;
        }

        [HttpPost]
        [Route("CheckCustomer")]
        public int CheckCustomer(CheckCustomerRequest ObjCheckCustomerRequest)
        {
            CustomerServiceMethods ObjCustomerServiceMethods = new CustomerServiceMethods();

            int Count = ObjCustomerServiceMethods.CheckCustomer(ObjCheckCustomerRequest);
            return Count;
        }



        [HttpGet]
        
        public List<ViewCustomerResponse> ViewCustomer()
        {
            CustomerServiceMethods ObjCustomerServiceMethods = new CustomerServiceMethods();
            List<ViewCustomerResponse> CustomerList=ObjCustomerServiceMethods.ViewAllCustomer();
            return CustomerList;
        }

        
    }
}
