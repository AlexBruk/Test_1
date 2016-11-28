using Autofac;
using Autofac.Integration.Mvc;
using Test_1.Controllers;
using Test_1.Services;

namespace Test_1
{
    public class InjectionConfig
    {
        public static void RegisterDependencies()
        {
            var builder = new ContainerBuilder();

            builder.RegisterControllers(typeof(DetailsController).Assembly);
            builder.RegisterControllers(typeof(StoreKeeperController).Assembly);

            builder.RegisterType<DetailsService>().AsImplementedInterfaces().InstancePerHttpRequest();
            builder.RegisterType<StoreKeeperService>().AsImplementedInterfaces().InstancePerHttpRequest();
            var container = builder.Build();


            System.Web.Mvc.DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}