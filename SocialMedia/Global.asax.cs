using SocialMedia.Services;
using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Reflection;
using SimpleInjector.Integration.Web.Mvc;

namespace SocialMedia
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            var container = new Container();

            container.Register<ISecurityService, SecurityService>();
            container.RegisterMvcControllers(Assembly.GetExecutingAssembly());
            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
        }
    }
}
