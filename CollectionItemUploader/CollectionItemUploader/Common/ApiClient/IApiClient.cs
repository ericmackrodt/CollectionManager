using CollectionItemUploader.Models.DataTransferObjects;
using CollectionManagerBackend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionItemUploader.Common.ApiClient
{
    public interface IApiClient
    {
        Task<IEnumerable<Collection>> GetCollections();
        Task<IEnumerable<Category>> GetCategories(int collectionId);
        Task<IEnumerable<Item>> GetItems(int categoryId);
        Task<IEnumerable<ItemCharacteristic>> GetCharacteristics();
        Task AddItem(Item item, ImageData[] images, ImageData[] screenshots);
    }
}
