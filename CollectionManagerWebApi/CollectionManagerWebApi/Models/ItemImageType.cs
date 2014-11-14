using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;
using System.Runtime.Serialization;

namespace CollectionManagerBackend.Models
{
    [DataContract]
    public partial class ItemImageType
    {
        [DataMember(Name="id")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ItemImageTypeID { get; set; }

        [Required]
        [StringLength(100)]
        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "images")]
        public virtual ICollection<ItemImage> Images { get; set; }
    }
}
