using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace CollectionManagerBackend.Models
{
    [DataContract]
    public partial class ItemImageType
    {
        [DataMember(Name="id")]
        public int ItemImageTypeID { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "images")]
        public virtual ICollection<ItemImage> Images { get; set; }
    }
}
