using System.Web.Mvc;
using System.Web.Routing;

namespace IdentitySample
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {


            //routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //routes.MapRoute(
            //    name: "Default",
            //    url: "{controller}/{action}/{id}",
            //    defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
            //    namespaces: new[] { "GWA.WEB1.Controllers" }
            //);


            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute(
               "Default",                                              // Route name
               "{controller}/{action}/{id}",                           // URL with parameters
               new { controller = "Home", action = "Index", id = "" }  // Parameter defaults
           );


            //routes.MapRoute(
           //"Default", // Route name
           //"{controller}/{action}/{id}", // URL with parameters
           //new { controller = "Product", action = "Index", id = UrlParameter.Optional },
           //new string[] { "GWA.WEB1.Controllers.Products" });

            //routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //routes.MapRoute(
            //    name: "Default",
            //    url: "{controller}/{action}/{id}",
            //    defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            //);




        }
    }
}