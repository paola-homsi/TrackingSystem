using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Dispatcher;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Castle.Windsor;
using TrackingSystem.WebApp.App_Start;
using TrackingSystem.WebApp.CastleDI;

namespace TrackingSystem.WebApp
{
    public class MvcApplication : System.Web.HttpApplication
    {
        private readonly IWindsorContainer container;
        public MvcApplication()
        {
            this.container =
                new WindsorContainer().Install(new DependencyInstaller());
        }
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            //WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            GlobalConfiguration.Configuration.Services.Replace(
                typeof(IHttpControllerActivator),
                new WindsorActivator(this.container));
        }
    }
}
