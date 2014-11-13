using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CollectionManagerBackend.Models.ClientModels
{
    public class ItemCharacteristicDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ItemCharacteristicDTO() { }

        public ItemCharacteristicDTO(ItemCharacteristic characteristic)
        {
            Id = characteristic.ItemCharacteristicID;
            Name = characteristic.Name;
        }
    }
}
