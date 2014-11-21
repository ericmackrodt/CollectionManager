using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace CollectionManagerBackend.Models
{
    [DataContract]
    public partial class ItemDescription
    {
        [DataMember(Name = "id")]
        public long ItemDescriptionID { get; set; }

        [DataMember(Name = "content")]
        public string Content { get; set; }

        [DataMember(Name = "source")]
        public string Source { get; set; }

        [DataMember(Name = "sourceUrl")]
        public string SourceUrl { get; set; }

        [DataMember(Name = "item")]
        public virtual Item Item { get; set; }
    }
}
