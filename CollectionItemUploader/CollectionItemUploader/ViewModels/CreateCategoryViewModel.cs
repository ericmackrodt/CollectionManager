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
    public class CreateCategoryViewModel : BaseViewModel
    {
        public event EventHandler OnCreated;

        private IBroadcaster _broadcaster;
        //private IApiClient _apiClient;

        private Category _category;
        public Category Category
        {
            get
            {
                if (_category == null)
                    _category = new Category();

                return _category;
            }
            set
            {
                _category = value;
                NotifyChanged();
            }
        }

        private ICommand _saveCategoryCommand;
        public ICommand SaveCategoryCommand
        {
            get { return _saveCategoryCommand; }
        }

        public CreateCategoryViewModel(IBroadcaster broadcaster)
        {
            _broadcaster = broadcaster;
            //_apiClient = apiClient;

            _saveCategoryCommand = new RelayCommand(SaveCategory);
        }

        private void SaveCategory(object arg)
        {
            _broadcaster.Event<CreateCategoryEvent>().Broadcast(Category);

            if (OnCreated != null)
                OnCreated(this, new EventArgs());
        }
    }
}
