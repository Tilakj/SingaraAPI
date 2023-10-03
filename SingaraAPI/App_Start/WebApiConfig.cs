//using Microsoft.AspNetCore.Cors;
using System.Net.Http.Formatting;
using System.Web.Http;
using System.Web.Http.Cors;

namespace SingaraAPI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            var cors = new EnableCorsAttribute("*", "*", "*"); // Allow requests from any origin, any header, and any method (not recommended for production)
            config.EnableCors(cors);
            // Web API routes
            config.Formatters.Clear(); // Remove other formatters
            config.Formatters.Add(new JsonMediaTypeFormatter());
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
