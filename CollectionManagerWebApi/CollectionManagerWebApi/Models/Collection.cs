using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;
using System.Runtime.Serialization;

namespace CollectionManagerBackend.Models
{
    //[Table("collectionmanager.collection")]
    [DataContract]
    public partial class Collection
    {
        [DataMember(Name="id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CollectionID { get; set; }

        [Required]
        [StringLength(256)]
        [DataMember(Name = "name")]
        public string Name { get; set; }

        [StringLength(1000)]
        [DataMember(Name = "description")]
        public string Description { get; set; }

        [DataMember(Name = "categories")]
        public virtual ICollection<Category> Categories { get; set; }
    }
}
