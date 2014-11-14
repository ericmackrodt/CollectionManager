using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CollectionManagerWebApi.Models.DataTransferObjects
{
    public class ImageUploadData
    {
        public string FileName { get; set; }

        public string MimeType { get; set; }

        public byte[] ImageData { get; set; }
    }
}