using Autofac;
using CollectionItemUploader.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Broadcaster;
using CollectionItemUploader.Common.ApiClient;

namespace CollectionItemUploader.ViewModels
{
    public class ViewModelLocator
    {
        private readonly IContainer _container;

        public ViewModelLocator()
        {
            var containerBuilder = new ContainerBuilder();

            containerBuilder.RegisterType<ApiClient>().As<IApiClient>();
            containerBuilder.RegisterType<BroadcastContainer>().As<IBroadcaster>().SingleInstance();

            containerBuilder.RegisterType<MainViewModel>();
            containerBuilder.RegisterType<ItemViewModel>();
            containerBuilder.RegisterType<ItemListViewModel>();
            containerBuilder.RegisterType<CategorySelectionViewModel>();

            _container = containerBuilder.Build();
        }

        public CategorySelectionViewModel CategoryViewModel
        {
            get { return _container.Resolve<CategorySelectionViewModel>(); }
        }

        public ItemListViewModel ItemListViewModel
        {
            get { return _container.Resolve<ItemListViewModel>(); }
        }

        public ItemViewModel ItemViewModel
        {
            get { return _container.Resolve<ItemViewModel>(); }
        }
    }
}
