using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using TrackingSystem.Service.Contracts;

namespace TrackingSystem.WebApp.Controllers
{
    public class StatusController : ApiController
    {
        IStatusService statusService;
        IVehicleService vehicleService;
        public StatusController(IStatusService statusService, IVehicleService vehicleService)
        {
            this.statusService = statusService;
            this.vehicleService = vehicleService;
        }
        [System.Web.Http.HttpPost]
        public string GetStatuses()
        {
            return JsonConvert.SerializeObject(statusService.GetStatuses(), Formatting.Indented,new JsonSerializerSettings() {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
        }
        [System.Web.Http.HttpPost]
        public string GetStatusVehicles(int status)
        {
            var v = vehicleService.GetVehicleWithSpecificStatus(status);
            return JsonConvert.SerializeObject(v, Formatting.Indented, new JsonSerializerSettings()
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
        }
    }
}