using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace CollectionManagerBackend.Models
{
    [DataContract]
    public partial class Item
    {
        [DataMember(Name = "id")]
        public int ItemID { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "year")]
        public int? Year { get; set; }

        [DataMember(Name = "developer")]
        public string Developer { get; set; }

        [DataMember(Name = "publisher")]
        public string Publisher { get; set; }

        [DataMember(Name = "manufacturer")]
        public string Manufacturer { get; set; }

        [DataMember(Name = "youtubeVideo")]
        public string YoutubeVideo { get; set; }

        [DataMember(Name = "standsOut")]
        public bool StandsOut { get; set; }

        private ItemDescription _description;
        [DataMember(Name = "description")]
        public virtual ItemDescription Description
        {
            get
            {
                if (_description == null)
                    _description = new ItemDescription();
                return _description;
            }
            set { _description = value; }
        }

        [DataMember(Name = "images")]
        public virtual ICollection<ItemImage> Images { get; set; }

        [DataMember(Name = "categories")]
        public virtual ICollection<Category> Categories { get; set; }

        [DataMember(Name = "characteristics")]
        public virtual ICollection<ItemCharacteristic> Characteristics { get; set; }
    }
}
