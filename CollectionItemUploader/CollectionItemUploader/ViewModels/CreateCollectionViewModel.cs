using Broadcaster;
using CollectionItemUploader.Common.ApiClient;
using CollectionItemUploader.Common.Events;
using CollectionManagerBackend.Models;
using MVVMBasic;
using MVVMBasic.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CollectionItemUploader.ViewModels
{
    public class CreateCollectionViewModel : BaseViewModel
    {
        public event EventHandler OnCreated;

        private IBroadcaster _broadcaster;
        private IApiClient _apiClient;

        private Collection _collection;
        public Collection Collection
        {
            get
            {
                if (_collection == null)
                    _collection = new Collection();

                return _collection;
            }
            set
            {
                _collection = value;
                NotifyChanged();
            }
        }

        private ICommand _saveCollectionCommand;
        public ICommand SaveCollectionCommand
        {
            get { return _saveCollectionCommand; }
        }

        public CreateCollectionViewModel(IBroadcaster broadcaster, IApiClient apiClient)
        {
            _broadcaster = broadcaster;
            _apiClient = apiClient;

            _saveCollectionCommand = new AsyncRelayCommand(SaveCollection);
        }

        private async Task SaveCollection(object arg)
        {
            await _apiClient.AddCollection(Collection);
            _broadcaster.Event<CollectionCreatedEvent>().Broadcast(Collection);

            if (OnCreated != null)
                OnCreated(this, new EventArgs());
        }
    }
}
