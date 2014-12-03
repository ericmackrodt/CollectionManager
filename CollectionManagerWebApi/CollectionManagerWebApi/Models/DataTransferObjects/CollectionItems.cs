using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace CollectionManagerWebApi.Models.DataTransferObjects
{
    [DataContract]
    public class CollectionItems
    {
        [DataMember(Name = "collection")]
        public string Collection { get; set; }
        
        [DataMember(Name = "items")]
        public ItemDTO[] Items { get; set; }
    }
}