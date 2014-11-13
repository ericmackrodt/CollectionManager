namespace CollectionManagerBackend.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    //[Table("collectionmanager.category")]
    public partial class Category
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CategoryID { get; set; }

        [Required]
        [StringLength(256)]
        public string Name { get; set; }

        [StringLength(1000)]
        public string Description { get; set; }

        [Required]
        [ForeignKey("Collection")]
        public int CollectionID { get; set; }

        public virtual Collection Collection { get; set; }

        public virtual ICollection<Item> Items { get; set; }
    }
}
