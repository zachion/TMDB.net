using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace TMDB.net
{
    public class RouteConfig
    {

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
            name: "Default",
            url: "{controller}/{action}",
            defaults: new { controller = "Home", action = "Index" }
        );

            routes.MapRoute(
                name: "Popular",
                url: "Popular/{page}/",
                defaults: new { controller = "Popular", action = "Index", page = "" },
                constraints: new { page = @"^[0-9]+$" }
            );


            routes.MapRoute(
                name: "Paging",
                url: "{controller}/{action}/{page}",
                defaults: new { controller = "Home", action = "Index", page = "" },
                constraints: new { page = @"^[0-9]+$" }
            );

        }

    }
}
