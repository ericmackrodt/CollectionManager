using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CollectionManagerBackend.Models.ClientModels
{
    public class ItemImageTypeDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ItemImageTypeDTO() { }

        public ItemImageTypeDTO(ItemImageType itemImageType)
        {
            Id = itemImageType.ItemImageTypeID;
            Name = itemImageType.Name;
        }
    }
}
