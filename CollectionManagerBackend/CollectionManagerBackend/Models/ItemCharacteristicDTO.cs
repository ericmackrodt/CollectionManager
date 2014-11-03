using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CollectionManagerBackend.Models
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
