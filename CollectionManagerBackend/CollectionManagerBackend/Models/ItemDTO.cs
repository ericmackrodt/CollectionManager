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

        public ItemDTO(Item item)
        {
            Id = item.ItemID;
            Name = item.Name;
            Year = item.Year;

            //if (item.Description != null)
            //    Description = new ItemDescriptionDTO(item.Description);
        }
    }
}