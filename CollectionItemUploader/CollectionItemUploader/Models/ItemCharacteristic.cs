using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace CollectionManagerBackend.Models
{
    [DataContract]
    public partial class ItemCharacteristic
    {
        [DataMember(Name="id")]
        public int ItemCharacteristicID { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "items")]
        public virtual ICollection<Item> Items { get; set; }

        [IgnoreDataMember]
        public bool IsSelected { get; set; }
    }
}
