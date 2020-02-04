using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace GuiltyPleasures
{
    public static class WebApiConfig
    {

        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();


            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}/{searchString}/{filterString}/{quantity}/{searchString1}",
                defaults: new { id = RouteParameter.Optional , searchString=RouteParameter.Optional, filterString = RouteParameter.Optional, quantity= RouteParameter.Optional, searchString1 = RouteParameter.Optional }
            );



        }
    }
}
