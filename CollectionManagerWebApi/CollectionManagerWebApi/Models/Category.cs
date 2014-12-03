using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;
using System.Runtime.Serialization;

namespace CollectionManagerWebApi.Models
{
    //[Table("collectionmanager.category")]
    [DataContract]
    public partial class Category
    {
        [DataMember(Name = "id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CategoryID { get; set; }

        [Required]
        [StringLength(256)]
        [DataMember(Name = "name")]
        public string Name { get; set; }

        [StringLength(1000)]
        [DataMember(Name = "description")]
        public string Description { get; set; }

        [DataMember(Name = "collection")]
        public virtual Collection Collection { get; set; }

        [DataMember(Name = "items")]
        public virtual ICollection<Item> Items { get; set; }
    }
}
