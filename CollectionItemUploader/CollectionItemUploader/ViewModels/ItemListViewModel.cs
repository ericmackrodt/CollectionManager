using Broadcaster;
using CollectionItemUploader.Common.ApiClient;
using CollectionItemUploader.Common.Events;
using CollectionManagerBackend.Models;
using MVVMBasic;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionItemUploader.ViewModels
{
    public class ItemListViewModel : BaseViewModel
    {
        private readonly IBroadcaster _broadcaster;
        private readonly IApiClient _apiClient;
        private Category _selectedCategory;

        private ObservableCollection<Item> _items;
        public ObservableCollection<Item> Items
        {
            get { return _items; }
            set
            {
                _items = value;
                NotifyChanged();
            }
        }

        public ItemListViewModel(IBroadcaster broadcaster, IApiClient apiClient)
        {
            _broadcaster = broadcaster;
            _apiClient = apiClient;

            _broadcaster.Event<CategorySelectedEvent>().Subscribe(CategorySelected);
        }

        //It's an async event handler
        //It shouldn't propagate exceptions to the broadcaster
        private async void CategorySelected(Category obj)
        {
            if (obj == null)
            {
                Items = null;
                return;
            }

            _selectedCategory = obj;
            var items = await _apiClient.GetItems(obj.CategoryID);
            Items = new ObservableCollection<Item>(items);
        }
    }
}
