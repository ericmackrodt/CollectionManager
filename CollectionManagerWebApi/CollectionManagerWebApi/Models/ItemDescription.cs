using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;
using System.Runtime.Serialization;

namespace CollectionManagerBackend.Models
{
    [DataContract]
    public partial class ItemDescription
    {
        [DataMember(Name = "id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ItemDescriptionID { get; set; }

        [Required]
        [StringLength(2000)]
        [DataMember(Name = "content")]
        public string Content { get; set; }

        [StringLength(100)]
        [DataMember(Name = "source")]
        public string Source { get; set; }

        [StringLength(1000)]
        [DataMember(Name = "sourceUrl")]
        public string SourceUrl { get; set; }

        [DataMember(Name = "item")]
        public virtual Item Item { get; set; }
    }
}
