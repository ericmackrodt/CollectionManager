using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace CollectionManagerBackend.Models.ClientModels
{
    [DataContract]
    public class CategoryDTO
    {
        [DataMember(Name = "description")]
        public string Description { get; set; }

        [DataMember(Name = "name")]
        [Required]
        public string Name { get; set; }

        [DataMember(Name = "id")]
        public int CategoryID { get; set; }

        [DataMember(Name = "collection")]
        [Required]
        public CollectionDTO Collection { get; set; }
    }
}
