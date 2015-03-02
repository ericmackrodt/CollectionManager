using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace CollectionManagerWebApi.Models.DataTransferObjects
{
    [DataContract]
    public class ItemDTO
    {
        [DataMember(Name = "id")]
        public int Id { get; set; }
        [DataMember(Name = "name")]
        public string Name { get; set; }
        [DataMember(Name = "description")]
        public string Description { get; set; }
        [DataMember(Name = "image")]
        public string Image { get; set; }
        [DataMember(Name = "characteristics")]
        public string[] Characteristics { get; set; }
    }
}