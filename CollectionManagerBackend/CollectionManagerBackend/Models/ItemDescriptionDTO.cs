using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CollectionManagerBackend.Models
{
    public class ItemDescriptionDTO
    {
        public string Content { get; set; }
        public string Source { get; set; }
        public string SourceUrl { get; set; }

        //public ItemDescriptionDTO(ItemDescription itemDescription)
        //{
        //    Content = itemDescription.Content;
        //    Source = itemDescription.Source;
        //    SourceUrl = itemDescription.SourceUrl;
        //}
    }
}