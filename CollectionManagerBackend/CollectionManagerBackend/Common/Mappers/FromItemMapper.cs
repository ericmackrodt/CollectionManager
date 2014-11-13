using CollectionManagerBackend.Models;
using CollectionManagerBackend.Models.ClientModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CollectionManagerBackend.Common.Mappers
{
    public class FromItemMapper : IMapToNew<Item, ItemDTO>
    {
        public ItemDTO Map(Item data)
        {
            var dto = new ItemDTO()
            {
                ItemID = data.ItemID,
                Name = data.Name,
                DateAcquired = data.DateAcquired,
                Developer = data.Developer,
                Publisher = data.Publisher,
                Manufacturer = data.Manufacturer,
                Year = data.Year,
                YoutubeVideo = data.YoutubeVideo
            };

            if (data.Description != null)
                dto.Description = new ItemDescriptionDTO()
                {
                    Content = data.Description.Content,
                    Source = data.Description.Source,
                    SourceUrl = data.Description.SourceUrl
                };

            if (data.Characteristics != null)
                dto.Characteristics = data.Characteristics.Select(o => new ItemCharacteristicDTO()
                {
                    Id = o.ItemCharacteristicID,
                    Name = o.Name
                }).ToArray();

            if (data.Images != null)
            {
                dto.Images = data.Images.GroupBy(o => o.ImageType).ToDictionary(o => o.Key.Name, o => o.Select(x => new ItemImageDTO()
                {
                    Id = x.ItemImageID,
                    Path = x.Path
                }).ToArray());
            }

            return dto;
        }
    }
}