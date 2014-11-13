using System;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace CollectionManagerBackend.Models
{   
    [DbConfigurationType(typeof(MySql.Data.Entity.MySqlEFConfiguration))]
    public partial class CollectionManagerEntities : DbContext, ICollectionManagerEntities
    {
        public CollectionManagerEntities()
            : base("CollectionManagerContext")
        {
        }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Collection> Collections { get; set; }
        public virtual DbSet<Item> Items { get; set; }
        public virtual DbSet<ItemCharacteristic> ItemCharacteristics { get; set; }
        public virtual DbSet<ItemDescription> ItemDescriptions { get; set; }
        public virtual DbSet<ItemImage> ItemImages { get; set; }
        public virtual DbSet<ItemImageType> ItemImageTypes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Entity<ItemDescription>()
                .HasKey(t => t.ItemDescriptionID);

            modelBuilder.Entity<Item>()
                .HasRequired(t => t.Description)
                .WithRequiredPrincipal(t => t.Item);
        }
    }
}
