using System.Web.Http;

namespace civilopedia
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "Civilizations",
                routeTemplate: "civ6/{controller}/{action}/{id}",
                defaults: new { controller = "Civilizations", action = "AllCivilizations", id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: "Leaders",
                routeTemplate: "civ6/{controller}/{action}/{id}",
                defaults: new { controller = "Leaders", action = "AllLeaders", id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: "Buildings",
                routeTemplate: "civ6/{controller}/{action}/{id}",
                defaults: new { controller = "Buildings", action = "AllBuildings", id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: "Districts",
                routeTemplate: "civ6/{controller}/{action}/{id}",
                defaults: new { controller = "Districts", action = "AllDistricts", id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: "Units",
                routeTemplate: "civ6/{controller}/{action}/{id}",
                defaults: new { controller = "Units", action = "AllUnits", id = RouteParameter.Optional }
            );
        }
    }
}
