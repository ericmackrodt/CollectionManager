using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CollectionManagerBackend.Models
{
    public class ItemImageDTO
    {
        public int Id { get; set; }

        public string Path { get; set; }

        public ItemImageTypeDTO Type { get; set; }

        public ItemImageDTO() { }

        public ItemImageDTO(ItemImage image)
        {
            Id = image.ItemImageID;
            Path = image.Path;
            Type = new ItemImageTypeDTO(image.ImageType);
        }
    }
}
