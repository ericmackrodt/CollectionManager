using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using CollectionManagerBackend.Models;
using System.Web.OData.Extensions;
using System.Web.OData.Builder;
using System.Web.OData.Routing;
//using System.Web.Http.OData.Routing;
//using System.Web.Http.OData.Builder;
//using System.Web.Http.OData.Extensions;

namespace CollectionManagerWebApi
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
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            ODataModelBuilder builder = new ODataConventionModelBuilder();
            builder.EntitySet<Collection>("Collections");
            builder.EntitySet<Category>("Categories");
            builder.EntitySet<Item>("Items");
            builder.EntitySet<ItemCharacteristic>("ItemCharacteristics");
            builder.EntitySet<ItemDescription>("ItemDescriptions");
            builder.EntitySet<ItemImage>("ItemImages");
            builder.EntitySet<ItemImageType>("ItemImageTypes");

            //var it = builder.StructuralTypes.First(o => o.ClrType == typeof(Item));
            //it.AddProperty(typeof(Item).GetProperty("DateAcquiredOffset"));
            //var item = builder.EntityType<Item>();
            //item.Ignore(t => t.DateAcquired);

            config.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
        }
    }
}
