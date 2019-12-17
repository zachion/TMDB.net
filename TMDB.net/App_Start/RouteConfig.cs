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
            url: "{controller}/{action}/{id}",
            defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional, page = 1 }
        );

            routes.MapRoute(
                name: "Popular",
                url: "Popular/{page}/",
                defaults: new { controller = "Popular", action = "Index", page = "" },
                constraints: new { page = @"^[0-9]+$" }
            );

            routes.MapRoute(
                name: "Person",
                url: "Person/{id}/",
                defaults: new { controller = "Person", action = "GetPerson", id = "" },
                constraints: new { id = @"^[0-9]+$" }
            );

            routes.MapRoute(
                 name: "TmdbApi",
                 url: "TmdbApi/{id}/",
                 defaults: new { controller = "TmdbApi", action = "GetPerson", id = "" },
                 constraints: new { id = @"^[0-9]+$" }
             );

            routes.MapRoute(
                name: "TmdbApiPaging",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                constraints: new { page = @"^[0-9]+$" }
            );

        }

    }
}
