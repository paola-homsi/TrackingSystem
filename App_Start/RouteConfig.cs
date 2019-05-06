using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace TrackingSystem.WebApp
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
            
            routes.MapRoute(
                name: "CustomerVehicles",
                url: "C_api/{action}/{id}/",
                defaults: new { controller = "Vehicle", action = "FilterVehiclesByCustomer", id = 1 }
            );
            routes.MapRoute(
                name: "Vehicle",
                url: "api/{controller}/",
                defaults: new { controller = "Vehicle", action = "GetVehicles" }
            );
            
            routes.MapRoute(
                name: "Customer",
                url: "api/{controller}/{action}/",
                defaults: new { controller = "Customer", action = "GetCustomers" }
            );
            routes.MapRoute(
                name: "Status",
                url: "api/{controller}/{action}/",
                defaults: new { controller = "Status", action = "GetStatuses" }
            );
            routes.MapRoute(
                name: "StatusV",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Status", action = "GetStatusVehicles" }
            );
        }
    }
}
