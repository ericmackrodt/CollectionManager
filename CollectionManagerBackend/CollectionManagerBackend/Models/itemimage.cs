namespace CollectionManagerBackend.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("collectionmanager.itemimage")]
    public partial class ItemImage
    {
        public int ItemImageID { get; set; }

        [Required]
        [StringLength(500)]
        public string Path { get; set; }

        public int ItemImageTypeID { get; set; }

        [Column(TypeName = "uint")]
        public long ItemID { get; set; }

        public virtual Item Item { get; set; }

        public virtual ItemImageType ImageType { get; set; }
    }
}
