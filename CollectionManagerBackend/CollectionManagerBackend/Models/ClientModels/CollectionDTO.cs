using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace CollectionManagerBackend.Models.ClientModels
{
    [DataContract]
    public class CollectionDTO
    {
        [DataMember(Name = "id")]
        public int CollectionID { get; set; }
        [DataMember(Name = "name")]
        public string Name { get; set; }
        [DataMember(Name = "description")]
        public string Description { get; set; }
        [DataMember(Name = "categories")]
        public CategoryDTO[] Categories { get; set; }
    }
}