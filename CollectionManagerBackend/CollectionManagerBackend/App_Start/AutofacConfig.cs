using Autofac;
using Autofac.Integration.WebApi;
using CollectionManagerBackend.Common;
using CollectionManagerBackend.Common.Mappers;
using CollectionManagerBackend.Models;
using CollectionManagerBackend.Models.ClientModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;

namespace CollectionManagerBackend
{
    public static class AutofacConfig
    {
        public static void Configure()
        {
            var builder = new ContainerBuilder();

            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            builder.RegisterType<CollectionManagerEntities>().As<ICollectionManagerEntities>();

            //Mappers
            builder.RegisterType<FromCollectionMapper>().As<IMapToNew<Collection, CollectionDTO>>();
            builder.RegisterType<ToCollectionMapper>().As<IMapToNew<CollectionDTO, Collection>>();
            builder.RegisterType<FromCategoryMapper>().As<IMapToNew<Category, CategoryDTO>>();
            builder.RegisterType<ToCategoryMapper>().As<IMapToNew<CategoryDTO, Category>>();
            builder.RegisterType<FromItemMapper>().As<IMapToNew<Item, ItemDTO>>();

            var container = builder.Build();
            var resolver = new AutofacWebApiDependencyResolver(container);
            GlobalConfiguration.Configuration.DependencyResolver = resolver;
        }
    }
}