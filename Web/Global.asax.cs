using Autofac;
using Autofac.Integration.Mvc;
using Domain.Dtos.AutomapperConfig;
using Domain.Models;
using Domain.Services;
using System.Linq;
using System.Reflection;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            AutoMapperConfig.Configure();

            var container = ConfigureAutofac();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }

        private IContainer ConfigureAutofac()
        {
            var builder = new ContainerBuilder();

            // Register your MVC controllers. (MvcApplication is the name of
            // the class in Global.asax.)
            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            // OPTIONAL: Register model binders that require DI.
            builder.RegisterModelBinders(typeof(MvcApplication).Assembly);
            builder.RegisterModelBinderProvider();

            // OPTIONAL: Register web abstractions like HttpContextBase.
            builder.RegisterModule<AutofacWebTypesModule>();

            // OPTIONAL: Enable property injection in view pages.
            builder.RegisterSource(new ViewRegistrationSource());

            // OPTIONAL: Enable property injection into action filters.
            builder.RegisterFilterProvider();

            // REGISTER SERVICES
            builder.RegisterAssemblyTypes(Assembly.Load(nameof(Domain)))
                .Where(t => t.Namespace.Contains("Services"))
                .As(t => t.GetInterfaces().FirstOrDefault(i => i.Name == $"I{t.Name}"));

            builder.RegisterType<WideWorldImportersEntities>()
                .InstancePerLifetimeScope();

            //builder.RegisterInstance(StaticDataService.Instance).ExternallyOwned();

            // Set the dependency resolver to be Autofac.
            return builder.Build();
        }
    }
}
