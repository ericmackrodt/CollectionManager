using CollectionManagerWebApi.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ImagePostTester
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var client = new HttpClient()) using (var content = new MultipartFormDataContent())
            {
                var item = new Item()
                {
                    Name = "Fuckup",
                    Description = new ItemDescription()
                    {
                        Content = "The content",
                        Source = "wikipedia",
                        SourceUrl = "SourceUrl"
                    },
                    Developer = "Microsoft",
                    Year = 1999,
                    Manufacturer = "Fuker"
                };

                var multipartContent = new MultipartFormDataContent();

                var jsonContent = new StringContent(JsonConvert.SerializeObject(item), Encoding.UTF8, "application/json");
                multipartContent.Add(jsonContent, "item");

                var file1 = @"C:\Users\Eric\Pictures\Bing Wallpaper\AutumnSquirrel.jpg";
                var imageContent1 = new ByteArrayContent(File.ReadAllBytes(file1));
                imageContent1.Headers.ContentType = new MediaTypeHeaderValue("image/jpg");
                multipartContent.Add(imageContent1, "image-1", file1);

                var file2 = @"C:\Users\Eric\Pictures\Bing Wallpaper\BavariaStatue.jpg";
                var imageContent2 = new ByteArrayContent(File.ReadAllBytes(file2));
                imageContent2.Headers.ContentType = new MediaTypeHeaderValue("image/jpg");
                multipartContent.Add(imageContent2, "image-2", file2);

                var imageContent3 = new ByteArrayContent(File.ReadAllBytes(file1));
                imageContent3.Headers.ContentType = new MediaTypeHeaderValue("image/jpg");
                multipartContent.Add(imageContent3, "screenshot-1", file1);

                var imageContent4 = new ByteArrayContent(File.ReadAllBytes(file2));
                imageContent4.Headers.ContentType = new MediaTypeHeaderValue("image/jpg");
                multipartContent.Add(imageContent4, "screenshot-2", file2);

                var result = client.PostAsync("http://localhost/CollectionManagerWebApi/odata/Items", multipartContent).Result;
                Console.WriteLine(result.StatusCode); 
                Console.ReadLine();
            }
        }
    }
}
