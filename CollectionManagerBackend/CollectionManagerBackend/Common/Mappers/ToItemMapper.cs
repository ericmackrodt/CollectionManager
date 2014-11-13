using CollectionManagerBackend.Models;
using CollectionManagerBackend.Models.ClientModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CollectionManagerBackend.Common.Mappers
{
    public class ToItemMapper : IMapToNew<ItemDTO, Item>
    {
        public Item Map(ItemDTO data)
        {
            var obj = new Item()
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
                obj.Description = new ItemDescription()
                {
                    Content = data.Description.Content,
                    Source = data.Description.Source,
                    SourceUrl = data.Description.SourceUrl
                };

            if (data.Characteristics != null)
                obj.Characteristics = data.Characteristics.Select(o => new ItemCharacteristic()
                {
                    ItemCharacteristicID = o.Id,
                    Name = o.Name
                }).ToArray();

            return obj;
        }
    }
}