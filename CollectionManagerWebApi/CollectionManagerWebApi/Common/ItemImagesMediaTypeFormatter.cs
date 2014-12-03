using CollectionManagerWebApi.Models;
using CollectionManagerWebApi.Models.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Threading.Tasks;
using System.Web;

namespace CollectionManagerWebApi.Common
{
    //http://blog.marcinbudny.com/2014/02/sending-binary-data-along-with-rest-api.html#.VGVazPnF-ux
    public class ItemImagesMediaTypeFormatter : MediaTypeFormatter
    {
        public ItemImagesMediaTypeFormatter()
        {
            SupportedMediaTypes.Add(new System.Net.Http.Headers.MediaTypeHeaderValue("multipart/form-data"));
        }

        public override bool CanReadType(Type type)
        {
            return type == typeof(Item);
        }

        public override bool CanWriteType(Type type)
        {
            return false;
        }

        public async override Task<object> ReadFromStreamAsync(Type type, Stream readStream, HttpContent content, IFormatterLogger formatterLogger)
        {
            var provider = await content.ReadAsMultipartAsync();

            var modelContent = provider.Contents.FirstOrDefault(o => o.Headers.ContentDisposition.Name.NormalizeName() == "item");

            var imageContents = provider.Contents
                .Where(c => c.Headers.ContentDisposition.Name.NormalizeName().Matches(@"image-\d+"))
                .ToList();

            var screenshotContents = provider.Contents
                .Where(c => c.Headers.ContentDisposition.Name.NormalizeName().Matches(@"screenshot-\d+"))
                .ToList();

            var item = await modelContent.ReadAsAsync<Item>();
            item.ImageUploads = new List<ImageUploadData>();
            item.ScreenshotUploads = new List<ImageUploadData>();

            foreach (var fileContent in imageContents)
            {
                item.ImageUploads.Add(new ImageUploadData()
                {
                    ImageData = await fileContent.ReadAsByteArrayAsync(),
                    MimeType = fileContent.Headers.ContentType.MediaType,
                    FileName = fileContent.Headers.ContentDisposition.FileName.NormalizeName()
                });
            }

            foreach (var fileContent in screenshotContents)
            {
                item.ScreenshotUploads.Add(new ImageUploadData()
                {
                    ImageData = await fileContent.ReadAsByteArrayAsync(),
                    MimeType = fileContent.Headers.ContentType.MediaType,
                    FileName = fileContent.Headers.ContentDisposition.FileName.NormalizeName()
                });
            }

            return item;
        }
    }
}