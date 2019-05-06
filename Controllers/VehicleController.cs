using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Xml;
using TrackingSystem.DAL.Contracts;
using TrackingSystem.Model.Entities;
using TrackingSystem.Service.Contracts;
using TrackingSystem.Service.Implementations;
using TrackingSystem.WebApp.CastleDI;

namespace TrackingSystem.WebApp.Controllers
{
    public class VehicleController : ApiController
    {
        private IVehicleService VehicleService;
        public VehicleController(IVehicleService vehicleService)
        {
            this.VehicleService = vehicleService;
        }
        [System.Web.Http.HttpPost]
        public string Index()
        {
            var x = VehicleService.GetVehicles(); 
            return JsonConvert.SerializeObject(x, Newtonsoft.Json.Formatting.Indented,
                    new JsonSerializerSettings
                    {
                        ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                    });
        }
        [System.Web.Http.HttpPost]
        public string FilterVehiclesByCustomer(int id)
        {
            var x = VehicleService.GetVehicleWithSpecificCustomer(id);
            return JsonConvert.SerializeObject(x, Newtonsoft.Json.Formatting.Indented, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
        }
        
    }
}
