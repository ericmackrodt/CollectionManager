using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CollectionManagerBackend.Models
{
    public class ItemDTO
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public int? Year { get; set; }
        public ItemDescriptionDTO Description { get; set; }
        public DateTime? DateAcquired { get; set; }
        public string Developer { get; set; }
        public CategoryDTO[] Categories { get; set; }
        public ItemCharacteristicDTO[] Characteristics { get; set; }
        public ItemImageDTO[] Images { get; set; }
        public string Manufacturer { get; set; }
        public string Publisher { get; set; }
        public string YoutubeVideo { get; set; }
        
        public ItemDTO() { }

        public ItemDTO(Item item)
        {
            Id = item.ItemID;
            Name = item.Name;
            Year = item.Year;
            DateAcquired = item.DateAcquired;
            Developer = item.Developer;
            Manufacturer = item.Manufacturer;
            Publisher = item.Publisher;
            YoutubeVideo = item.YoutubeVideo;

            if (item.Description != null)
                Description = new ItemDescriptionDTO(item.Description);

            if (item.Categories != null && item.Categories.Any())
                Categories = item.Categories.Select(o => new CategoryDTO(o)).ToArray();

            if (item.Characteristics != null && item.Characteristics.Any())
                Characteristics = item.Characteristics.Select(o => new ItemCharacteristicDTO(o)).ToArray();

            if (item.Images != null && item.Images.Any())
                Images = item.Images.Select(o => new ItemImageDTO(o)).ToArray();
        }
    }
}