using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace CollectionManagerBackend.Models
{
    public partial class ItemDescription
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ItemDescriptionID { get; set; }

        [Required]
        [StringLength(2000)]
        public string Content { get; set; }

        [StringLength(100)]
        public string Source { get; set; }

        [StringLength(1000)]
        public string SourceUrl { get; set; }

        public virtual Item Item { get; set; }
    }
}
