using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace EconomizeMais
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            var json = config.Formatters.JsonFormatter;
            json.SerializerSettings.PreserveReferencesHandling = Newtonsoft.Json.PreserveReferencesHandling.Objects;
            config.Formatters.Remove(config.Formatters.XmlFormatter);


            //var formatters = GlobalConfiguration.Configuration.Formatters;
            //formatters.Remove(formatters.XmlFormatter);
        }
    }
}
