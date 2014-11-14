using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;
using System.Runtime.Serialization;

namespace CollectionManagerBackend.Models
{
    [DataContract]
    public partial class ItemCharacteristic
    {
        [DataMember(Name="id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ItemCharacteristicID { get; set; }

        [DataMember(Name = "name")]
        [Required]
        [StringLength(150)]
        public string Name { get; set; }

        [DataMember(Name = "items")]
        public virtual ICollection<Item> Items { get; set; }
    }
}
