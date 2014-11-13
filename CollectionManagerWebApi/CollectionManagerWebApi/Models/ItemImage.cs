using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace CollectionManagerBackend.Models
{
    public partial class ItemImage
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ItemImageID { get; set; }

        [Required]
        [StringLength(500)]
        public string Path { get; set; }

        public int ItemImageTypeID { get; set; }

        public virtual Item Item { get; set; }

        public virtual ItemImageType ImageType { get; set; }
    }
}
