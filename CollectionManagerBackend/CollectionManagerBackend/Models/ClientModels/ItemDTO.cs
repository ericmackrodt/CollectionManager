using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace CollectionManagerBackend.Models.ClientModels
{
    [DataContract]
    public class ItemDTO
    {
        [DataMember(Name = "id")]
        public int ItemID { get; set; }
        [DataMember(Name = "name")]
        public string Name { get; set; }
        [DataMember(Name = "year")]
        public int? Year { get; set; }
        [DataMember(Name = "description")]
        public ItemDescriptionDTO Description { get; set; }
        [DataMember(Name = "dateAcquired")]
        public DateTime? DateAcquired { get; set; }
        [DataMember(Name = "developer")]
        public string Developer { get; set; }
        [DataMember(Name = "categories")]
        public CategoryDTO[] Categories { get; set; }
        [DataMember(Name = "characteristics")]
        public ItemCharacteristicDTO[] Characteristics { get; set; }
        [DataMember(Name = "images")]
        public Dictionary<string, ItemImageDTO[]> Images { get; set; }
        [DataMember(Name = "manufacturer")]
        public string Manufacturer { get; set; }
        [DataMember(Name = "publisher")]
        public string Publisher { get; set; }
        [DataMember(Name = "youtubeVideo")]
        public string YoutubeVideo { get; set; }
        
        //public ItemDTO() { }

        //public ItemDTO(Item item)
        //{
        //    Id = item.ItemID;
        //    Name = item.Name;
        //    Year = item.Year;
        //    DateAcquired = item.DateAcquired;
        //    Developer = item.Developer;
        //    Manufacturer = item.Manufacturer;
        //    Publisher = item.Publisher;
        //    YoutubeVideo = item.YoutubeVideo;

        //    if (item.Description != null)
        //        Description = new ItemDescriptionDTO(item.Description);

        //    if (item.Categories != null && item.Categories.Any())
        //        Categories = item.Categories.Select(o => new CategoryDTO(o)).ToArray();

        //    if (item.Characteristics != null && item.Characteristics.Any())
        //        Characteristics = item.Characteristics.Select(o => new ItemCharacteristicDTO(o)).ToArray();

        //    if (item.Images != null && item.Images.Any())
        //        Images = item.Images.Select(o => new ItemImageDTO(o)).ToArray();
        //}
    }
}