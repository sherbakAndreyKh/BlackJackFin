using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using BlackJack.Dependency.Config;
using Microsoft.Owin;
using Owin;
using Autofac;
using Autofac.Integration.Mvc;

[assembly: OwinStartup(typeof(BlackJack.UI.Startup))]

namespace BlackJack.UI
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            log4net.Config.XmlConfigurator.Configure();

            var builder = new ContainerBuilder();
            builder.RegisterControllers(typeof(Startup).Assembly).PropertiesAutowired();
            builder.RegisterModule(new AutofacConfig("DefaultConnection"));
            var container = builder.Build();

            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));          
        } 
    }
}
