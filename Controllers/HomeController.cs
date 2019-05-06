using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrackingSystem.Model.Entities;
using TrackingSystem.Service.Contracts;

namespace TrackingSystem.WebApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public string GetRes()
        {
            return "WORKED!";
        }

    }
}