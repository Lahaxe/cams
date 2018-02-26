using System.Web.Mvc;
using System.Web.Routing;

namespace cams
{
    /// <summary>
    /// Defines the API route configuration.
    /// </summary>
    public class RouteConfig
    {
        /// <summary>
        /// Registers the default routes.
        /// </summary>
        /// <param name="routes">The routes.</param>
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}