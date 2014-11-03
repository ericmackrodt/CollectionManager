namespace CollectionManagerBackend.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("collectionmanager.itemimagetype")]
    public partial class ItemImageType
    {
        public ItemImageType()
        {
            Images = new HashSet<ItemImage>();
        }

        public int ItemImageTypeID { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        public virtual ICollection<ItemImage> Images { get; set; }
    }
}
