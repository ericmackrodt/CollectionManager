using Broadcaster;
using CollectionItemUploader.Common.ApiClient;
using CollectionItemUploader.Common.Events;
using CollectionManagerBackend.Models;
using MVVMBasic;
using MVVMBasic.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CollectionItemUploader.ViewModels
{
    public class CategorySelectionViewModel : BaseViewModel
    {
        private readonly IApiClient _apiClient;
        private readonly IBroadcaster _broadcaster;

        private ObservableCollection<Collection> _collections;
        public ObservableCollection<Collection> Collections
        {
            get { return _collections; }
            set
            {
                _collections = value;
                NotifyChanged();
            }
        }

        private ObservableCollection<Category> _categories;
        public ObservableCollection<Category> Categories
        {
            get { return _categories; }
            set
            {
                _categories = value;
                NotifyChanged();
            }
        }

        private ICommand _selectCollectionCommand;
        public ICommand SelectCollectionCommand
        {
            get { return _selectCollectionCommand; }
        }

        private ICommand _selectCategoryCommand;
        public ICommand SelectCategoryCommand
        {
            get { return _selectCategoryCommand; }
        }

        public CategorySelectionViewModel(IApiClient apiClient, IBroadcaster broadcaster)
        {
            _apiClient = apiClient;
            _broadcaster = broadcaster;

            _selectCollectionCommand = new AsyncRelayCommand<Collection>(SelectCollection);
            _selectCategoryCommand = new RelayCommand<Category>(SelectCategory);
        }

        private void SelectCategory(Category arg)
        {
            _broadcaster.Event<CategorySelectedEvent>().Broadcast(arg);
        }

        private async Task SelectCollection(Collection arg)
        {
            var categories = await _apiClient.GetCategories(arg.CollectionID);
            Categories = new ObservableCollection<Category>(categories);
            arg.Categories = categories.ToArray();
            _broadcaster.Event<CollectionSelectedEvent>().Broadcast(arg);
        }

        public override async Task LoadData(object arg)
        {
            var collections = await _apiClient.GetCollections();
            Collections = new ObservableCollection<Collection>(collections);
        }
    }
}
