using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;
using System.Runtime.Serialization;

namespace CollectionManagerBackend.Models
{
    [DataContract]
    public partial class ItemImage
    {
        [DataMember(Name = "id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ItemImageID { get; set; }

        [Required]
        [StringLength(500)]
        [DataMember(Name = "path")]
        public string Path { get; set; }

        [DataMember(Name = "item")]
        public virtual Item Item { get; set; }

        [DataMember(Name = "imageType")]
        public virtual ItemImageType ImageType { get; set; }
    }
}
