using Broadcaster;
using CollectionItemUploader.Common;
using CollectionItemUploader.Common.ApiClient;
using CollectionItemUploader.Common.Events;
using CollectionItemUploader.Models.DataTransferObjects;
using CollectionManagerBackend.Models;
using GongSolutions.Wpf.DragDrop;
using MVVMBasic;
using MVVMBasic.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace CollectionItemUploader.ViewModels
{
    public class ItemViewModel : BaseViewModel
    {
        private readonly IApiClient _apiClient;
        private readonly IBroadcaster _broadcaster;

        private Item _item;
        public Item Item
        {
            get
            {
                if (_item == null)
                    _item = new Item();
                return _item;
            }
            set
            {
                _item = value;
                NotifyChanged();
            }
        }

        private Collection _selectedCollection;
        public Collection SelectedCollection
        {
            get { return _selectedCollection; }
            set
            {
                _selectedCollection = value;
                NotifyChanged();
            }
        }

        private ObservableCollection<ItemCharacteristic> _itemCharacteristics;
        public ObservableCollection<ItemCharacteristic> ItemCharacteristics
        {
            get { return _itemCharacteristics; }
            set
            {
                _itemCharacteristics = value;
                NotifyChanged();
            }
        }

        private ImageDragAndDropCollection _images;
        public ImageDragAndDropCollection Images
        {
            get
            {
                if (_images == null)
                    _images = new ImageDragAndDropCollection();

                return _images;
            }
            set
            {
                _images = value;
                NotifyChanged();
            }
        }

        private ImageDragAndDropCollection _screenshots;
        public ImageDragAndDropCollection Screenshots
        {
            get
            {
                if (_screenshots == null)
                    _screenshots = new ImageDragAndDropCollection();

                return _screenshots;
            }
            set
            {
                _screenshots = value;
                NotifyChanged();
            }
        }

        private string _newCharacteristic;
        public string NewCharacteristic
        {
            get { return _newCharacteristic; }
            set
            {
                _newCharacteristic = value;
                NotifyChanged();
            }
        }

        private ICommand _saveItemCommand;
        public ICommand SaveItemCommand
        {
            get { return _saveItemCommand; }
        }

        private ICommand _loadInitialDataCommand;
        public ICommand LoadInitialDataCommand
        {
            get { return _loadInitialDataCommand; }
        }

        private ICommand _newCharacteristicCommand;
        public ICommand NewCharacteristicCommand
        {
            get { return _newCharacteristicCommand; }
        }

        public ItemViewModel(IBroadcaster broadcaster, IApiClient apiClient)
        {
            _broadcaster = broadcaster;
            _apiClient = apiClient;

            _broadcaster.Event<CollectionSelectedEvent>().Subscribe(CollectionSelected);

            _saveItemCommand = new AsyncRelayCommand<Item>(SaveItem);
            _loadInitialDataCommand = new AsyncRelayCommand(LoadData);
            _newCharacteristicCommand = new RelayCommand(AddNewCharacteristic);
        }

        public override async Task LoadData(object arg)
        {
            var characteristics = await _apiClient.GetCharacteristics();
            ItemCharacteristics = new ObservableCollection<ItemCharacteristic>(characteristics);
            IsDataLoaded = true;
        }

        private void AddNewCharacteristic(object obj)
        {
            if (string.IsNullOrWhiteSpace(NewCharacteristic)) return;

            if (ItemCharacteristics.Any(o => o.Name.ToLower() == NewCharacteristic.ToLower()))
                return;

            ItemCharacteristics.Insert(0, new ItemCharacteristic()
            {
                Name = NewCharacteristic,
                IsSelected = true
            });

            NewCharacteristic = null;
        }

        private async Task SaveItem(Item arg)
        {
            var selectedCharacteristics = ItemCharacteristics.Where(o => o.IsSelected);
            if (!selectedCharacteristics.Any()) return;

            var selectedCategories = SelectedCollection.Categories.Where(o => o.IsSelected);
            if (!selectedCategories.Any()) return;

            var images = Images.ToArray();
            if (!images.Any()) return;

            var screenshots = Screenshots.ToArray();

            Item.Characteristics = selectedCharacteristics.ToList();
            Item.Categories = selectedCategories.ToList();

            await _apiClient.AddItem(Item, images, screenshots);
        }

        private void CollectionSelected(Collection obj)
        {
            SelectedCollection = obj;
        }
    }
}
