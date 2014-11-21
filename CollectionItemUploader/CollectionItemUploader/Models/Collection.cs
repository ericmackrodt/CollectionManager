using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace CollectionManagerBackend.Models
{
    [DataContract]
    public partial class Collection
    {
        [DataMember(Name="id")]
        public int CollectionID { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "description")]
        public string Description { get; set; }

        [DataMember(Name = "categories")]
        public virtual ICollection<Category> Categories { get; set; }
    }
}
