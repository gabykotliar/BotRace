using System.Web.Http;

using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Web
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            SetupJsonSerialization(config);

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional });
        }

        private static void SetupJsonSerialization(HttpConfiguration config)
        {
            var settings = config.Formatters.JsonFormatter.SerializerSettings;

            // TODO: maybe remove this for production
            // make it easier to read for humans 
            settings.Formatting = Formatting.Indented;

            // make the app generate camelCase property names for json object to meet javascript standards
            settings.ContractResolver = new CamelCasePropertyNamesContractResolver();
        }
    }
}
