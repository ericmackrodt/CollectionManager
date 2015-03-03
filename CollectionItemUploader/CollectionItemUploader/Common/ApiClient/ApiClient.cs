using CollectionItemUploader.Models.DataTransferObjects;
using CollectionManagerBackend.Models;
using HttpClientHelpers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace CollectionItemUploader.Common.ApiClient
{
    public class ApiClient : IApiClient
    {
        private readonly string _baseUrl = "http://localhost/CollectionManagerWebApi/";

        public async Task<IEnumerable<Collection>> GetCollections()
        {
            return await GetRequest<Collection[]>("odata/Collections");
        }

        public async Task<IEnumerable<Category>> GetCategories(int collectionId)
        {
            return await GetRequest<Category[]>(string.Format("odata/Collections({0})/categories", collectionId));
        }

        public async Task<IEnumerable<Item>> GetItems(int categoryId)
        {
            return await GetRequest<Item[]>(string.Format("odata/Categories({0})/items", categoryId));
        }

        public async Task<IEnumerable<ItemCharacteristic>> GetCharacteristics()
        {
            return await GetRequest<ItemCharacteristic[]>("odata/ItemCharacteristics");
        }

        public async Task AddItem(Item item, ImageData[] images, ImageData[] screenshots)
        {
            var multipartContent = new MultipartFormDataContent();

            var jsonContent = new StringContent(JsonConvert.SerializeObject(item), Encoding.UTF8, "application/json");
            multipartContent.Add(jsonContent, "item");

            foreach (var image in images)
            {
                var imageContent = new ByteArrayContent(image.Content);
                imageContent.Headers.ContentType = new MediaTypeHeaderValue(image.MimeType);
                multipartContent.Add(imageContent, string.Concat("image-", Array.FindIndex(images, o => o.FileName == image.FileName)), image.FileName);
            }

            foreach (var image in screenshots)
            {
                var imageContent = new ByteArrayContent(image.Content);
                imageContent.Headers.ContentType = new MediaTypeHeaderValue(image.MimeType);
                multipartContent.Add(imageContent, string.Concat("screenshot-", Array.FindIndex(screenshots, o => o.FileName == image.FileName)), image.FileName);
            }

            await PostRequest("odata/Items", multipartContent);
        }

        public async Task AddCollection(Collection collection)
        {
            var settings = new JsonSerializerSettings()
            {
                NullValueHandling = NullValueHandling.Ignore
            };
            var jsonContent = new StringContent(JsonConvert.SerializeObject(collection, settings), Encoding.UTF8, "application/json");
            await PostRequest("odata/Collections", jsonContent);
        }

        public async Task AddCategory(Category category)
        {
            await PostJson("odata/Categories", category);
        }

        private async Task PostJson(string url, object content)
        {
            var settings = new JsonSerializerSettings()
            {
                NullValueHandling = NullValueHandling.Ignore
            };
            var jsonContent = new StringContent(JsonConvert.SerializeObject(content, settings), Encoding.UTF8, "application/json");
            await PostRequest(url, jsonContent);
        }

        private async Task PostRequest(string url, HttpContent content)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri(_baseUrl);
            var response = await client.PostAsync(url, content);
            response.EnsureSuccessStatusCode();
        }

        private async Task<T> GetRequest<T>(string url)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri(_baseUrl);
            var response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<ODataResponse<T>>(content).Value;
        }
    }
}
