using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace CreateCVOnline
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "LandingPage", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "ViewCV",
                url:"{controller}/{action}/{Username}",
                defaults: new { controller = "Candidate", action="Index", Username=UrlParameter.Optional}
                );
            routes.MapRoute(
                name: "Download",
                url: "{controller}/{action}/{url}",
                defaults: new { controller = "Candidate", action = "Download", url = UrlParameter.Optional }
                );
        }
    }
}
