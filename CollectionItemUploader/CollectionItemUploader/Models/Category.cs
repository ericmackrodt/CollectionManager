using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace CollectionManagerBackend.Models
{
    [DataContract]
    public partial class Category
    {
        [DataMember(Name = "id")]
        public int CategoryID { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "description")]
        public string Description { get; set; }

        [DataMember(Name = "collection")]
        public virtual Collection Collection { get; set; }

        [DataMember(Name = "items")]
        public virtual ICollection<Item> Items { get; set; }

        [IgnoreDataMember]
        public bool IsSelected { get; set; }
    }
}
