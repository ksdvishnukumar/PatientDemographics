using PDAPI.App_Start;
using System.Web.Http;
using System.Web.Http.Cors;

namespace PDAPI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            StructuremapWebApi.Start();

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            ); ;
            EnableCorsAttribute cors = new EnableCorsAttribute("http://localhost:42030", "*", "GET,POST,PUT");
            config.EnableCors(cors);
        }
    }
}
