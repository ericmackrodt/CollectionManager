using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace CollectionManagerBackend.Models
{
    public partial class Item
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ItemID { get; set; }

        [Required]
        [StringLength(500)]
        public string Name { get; set; }

        public int? Year { get; set; }

        [StringLength(100)]
        public string Developer { get; set; }

        [StringLength(100)]
        public string Publisher { get; set; }

        [StringLength(100)]
        public string Manufacturer { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? DateAcquired { get; set; }

        [StringLength(500)]
        public string YoutubeVideo { get; set; }

        public virtual ItemDescription Description { get; set; }

        public virtual ICollection<ItemImage> Images { get; set; }

        public virtual ICollection<Category> Categories { get; set; }

        public virtual ICollection<ItemCharacteristic> Characteristics { get; set; }
    }
}
