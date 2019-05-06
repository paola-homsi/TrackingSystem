using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using TrackingSystem.Service.Contracts;

namespace TrackingSystem.WebApp.Controllers
{
    public class CustomerController : ApiController
    {
        ICustomerService customerService;
        public CustomerController(ICustomerService customerService)
        {
            this.customerService = customerService;
        }
        [System.Web.Http.HttpPost]
        public string GetCustomers()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(customerService.GetAllCustomers());
        }

    }
}