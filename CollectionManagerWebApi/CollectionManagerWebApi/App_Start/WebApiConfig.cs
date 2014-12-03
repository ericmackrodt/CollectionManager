using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.OData.Extensions;
using System.Web.OData.Builder;
using System.Web.OData.Routing;
using CollectionManagerWebApi.Common;
using Microsoft.OData.Edm.Library;
using Microsoft.OData.Edm;
using CollectionManagerWebApi.Models;
using System.Net.Http.Formatting;

namespace CollectionManagerWebApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Formatters.Add(new ItemImagesMediaTypeFormatter());

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

            var edmModel = builder.GetEdmModel();

            var collections = (EdmEntitySet)edmModel.EntityContainer.FindEntitySet("Collections");
            var items = (EdmEntitySet)edmModel.EntityContainer.FindEntitySet("Items");
            var itemType = (EdmEntityType)edmModel.FindDeclaredType(typeof(Item).FullName);
            var collectionType = (EdmEntityType)edmModel.FindDeclaredType(typeof(Collection).FullName);

            var partsProperty = new EdmNavigationPropertyInfo();
            partsProperty.TargetMultiplicity = EdmMultiplicity.Many;
            partsProperty.Target = itemType;
            partsProperty.ContainsTarget = false;
            partsProperty.OnDelete = EdmOnDeleteAction.None;
            partsProperty.Name = "items";

            collections.AddNavigationTarget(collectionType.AddUnidirectionalNavigation(partsProperty), items);


            //var it = builder.StructuralTypes.First(o => o.ClrType == typeof(Item));
            //it.AddProperty(typeof(Item).GetProperty("DateAcquiredOffset"));
            //var item = builder.EntityType<Item>();
            //item.Ignore(t => t.DateAcquired);

            config.MapODataServiceRoute("odata", "odata", edmModel);
        }
    }
}
