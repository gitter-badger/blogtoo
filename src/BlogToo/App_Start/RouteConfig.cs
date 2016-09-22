using System.Web.Mvc;
using System.Web.Routing;

namespace BlogToo
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Error",
                url: "Error/{httpStatusCode}",
                defaults: new { controller = "Error", action = "Error", httpStatusCode = UrlParameter.Optional }
                );

            routes.MapRoute(
                name: "Resource",
                url: "Resource/{*path}",
                defaults: new { controller = "Resource", action = "File", path = UrlParameter.Optional }
                );

            routes.MapRoute(
                name: "Default",
                url: "{*permalink}",
                defaults: new { controller = "Default", action = "DynamicRenderer", permalink = "Index" }
            );
        }
    }
}
