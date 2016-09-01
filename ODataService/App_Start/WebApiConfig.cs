using System.Web.Http;
using Microsoft.Owin.Security.OAuth;
using System.Web.OData.Builder;
using ODataService.Models;
using System.Web.OData.Extensions;
using System.Web.OData;
using ODataService.Controllers;

namespace ODataService
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            // Configure Web API to use only bearer token authentication.
            config.SuppressDefaultHostAuthentication();
            config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));

            // Web API routes
            config.MapHttpAttributeRoutes();

            // OData configs
            var builder = new ODataConventionModelBuilder();
            builder.EntitySet<MyODataModel>(GetControllerNameOf<MyODataModelController>());

            builder.ComplexType<MyComplexType>();

            // Map OData routes
            config.MapODataServiceRoute(
                routeName: "ODataRoute",
                routePrefix: "odata",
                model: builder.GetEdmModel());

            // Add default route
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }

        public static string GetControllerNameOf<TController>()
            where TController : ODataController
        {
            return typeof(TController).Name.Replace("Controller", "");
        }
    }
}
