using ODataService.Models;
using System.Web.Http;
using System.Web.OData.Builder;
using System.Web.OData.Extensions;

namespace ODataService
{
    public class ODataConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // OData configs
            var builder = new ODataConventionModelBuilder();
            builder.EntitySet<MyODataModel>("MyODataModel");

            // Map OData routes
            config.MapODataServiceRoute(
                routeName: "ODataRoute",
                routePrefix: "odata",
                model: builder.GetEdmModel());
        }
    }
}