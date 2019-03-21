using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;

namespace KFC.Red.DBate.WebAPI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {

            // Enable CORS for the Vue App
            //EnableCorsAttribute cors = new EnableCorsAttribute("http://localhost/client", "*", "*");
            //EnableCorsAttribute cors = new EnableCorsAttribute("http://localhost:8080", "*", "*");
            //EnableCorsAttribute cors = new EnableCorsAttribute("https://dbate.azurewebsites.net/client", "*", "*");

            config.EnableCors();


            // Set JSON formatter as default one and remove XmlFormatter
            var jsonFormatter = config.Formatters.JsonFormatter;
            jsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();

            // Remove the XML formatter
            config.Formatters.Remove(config.Formatters.XmlFormatter);
            jsonFormatter.SerializerSettings.DateTimeZoneHandling = Newtonsoft.Json.DateTimeZoneHandling.Utc;

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
