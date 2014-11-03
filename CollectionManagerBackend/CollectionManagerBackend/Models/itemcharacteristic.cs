using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace CollectionManagerBackend.Models
{
    public partial class ItemCharacteristic
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ItemCharacteristicID { get; set; }

        [Required]
        [StringLength(150)]
        public string Name { get; set; }

        public virtual ICollection<Item> Items { get; set; }
    }
}
