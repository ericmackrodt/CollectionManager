using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace CollectionManagerBackend.Models
{
    [DataContract]
    public partial class ItemImage
    {
        [DataMember(Name = "id")]
        public int ItemImageID { get; set; }

        [DataMember(Name = "path")]
        public string Path { get; set; }

        [DataMember(Name = "item")]
        public virtual Item Item { get; set; }

        [DataMember(Name = "imageType")]
        public virtual ImageType ImageType { get; set; }
    }

    public enum ImageType
    {
        Image = 0,
        Screenshot = 1
    }
}
