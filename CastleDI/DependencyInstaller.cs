using Castle.MicroKernel.Registration;
using Castle.MicroKernel.Registration.Lifestyle;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TrackingSystem.Common.Contracts;
using TrackingSystem.Common.Implementations;
using TrackingSystem.DAL.Contracts;
using TrackingSystem.DAL.Implementations;
using TrackingSystem.Service.Contracts;
using System.Web.Http.Controllers;
using Castle.Facilities.TypedFactory;
using TrackingSystem.Service.Implementations;

namespace TrackingSystem.WebApp.CastleDI
{
    public class DependencyInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                        Component.For<ILogService>().ImplementedBy<LogService>(),

                        Component.For<IDatabaseFactory>().ImplementedBy<DatabaseFactory>(),

                        Component.For<IUnitOfWork>().ImplementedBy<UnitOfWork>(),
                        Component.For<IVehicleService>().ImplementedBy<VehicleService>(),
                        Component.For<ICustomerService>().ImplementedBy<CustomerService>(),
                        Component.For<IStatusService>().ImplementedBy<StatusService>(),

                        Classes.FromThisAssembly().BasedOn<IHttpController>().LifestyleTransient(),

                        Classes.FromAssemblyNamed("TrackingSystem.Service")
                            .Where(type => type.Name.EndsWith("Service")).WithServiceAllInterfaces(),

                        Classes.FromAssemblyNamed("TrackingSystem.Repository")
                            .Where(type => type.Name.EndsWith("Repository")).WithServiceAllInterfaces()
                        );
        }

    }
}