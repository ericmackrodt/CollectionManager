using System;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace CollectionManagerBackend.Models
{   
    [DbConfigurationType(typeof(MySql.Data.Entity.MySqlEFConfiguration))]
    public partial class CollectionManagerEntities : DbContext
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

            //modelBuilder.Entity<Category>()
            //    .Property(e => e.Name)
            //    .IsUnicode(false);

            //modelBuilder.Entity<Category>()
            //    .Property(e => e.Description)
            //    .IsUnicode(false);

            //modelBuilder.Entity<Collection>()
            //    .Property(e => e.Name)
            //    .IsUnicode(false);

            //modelBuilder.Entity<Collection>()
            //    .Property(e => e.Description)
            //    .IsUnicode(false);

            //modelBuilder.Entity<Collection>()
            //    .HasMany(e => e.Categories)
            //    .WithRequired(e => e.collection)
            //    .WillCascadeOnDelete(false);

            //modelBuilder.Entity<Item>()
            //    .Property(e => e.Name)
            //    .IsUnicode(false);

            //modelBuilder.Entity<Item>()
            //    .Property(e => e.Developer)
            //    .IsUnicode(false);

            //modelBuilder.Entity<Item>()
            //    .Property(e => e.Publisher)
            //    .IsUnicode(false);

            //modelBuilder.Entity<Item>()
            //    .Property(e => e.Manufacturer)
            //    .IsUnicode(false);

            //modelBuilder.Entity<Item>()
            //    .Property(e => e.YoutubeVideo)
            //    .IsUnicode(false);

            //modelBuilder.Entity<Item>()
            //    .HasOptional(e => e.Description)
            //    .WithRequired(e => e.Item);

            //modelBuilder.Entity<Item>()
            //    .HasMany(e => e.Images)
            //    .WithRequired(e => e.Item)
            //    .WillCascadeOnDelete(false);

            //modelBuilder.Entity<Item>()
            //    .HasMany(e => e.Categories)
            //    .WithMany(e => e.Items)
            //    .Map(m => m.ToTable("itemcategory", "collectionmanager").MapLeftKey("ItemID").MapRightKey("CategoryID"));

            //modelBuilder.Entity<Item>()
            //    .HasMany(e => e.Characteristics)
            //    .WithMany(e => e.Items)
            //    .Map(m => m.ToTable("itemcharacteristicitem", "collectionmanager").MapLeftKey("ItemID").MapRightKey("ItemID"));

            //modelBuilder.Entity<ItemCharacteristic>()
            //    .Property(e => e.Name)
            //    .IsUnicode(false);

            //modelBuilder.Entity<ItemDescription>()
            //    .Property(e => e.Content)
            //    .IsUnicode(false);

            //modelBuilder.Entity<ItemDescription>()
            //    .Property(e => e.Source)
            //    .IsUnicode(false);

            //modelBuilder.Entity<ItemDescription>()
            //    .Property(e => e.SourceUrl)
            //    .IsUnicode(false);

            //modelBuilder.Entity<ItemImage>()
            //    .Property(e => e.Path)
            //    .IsUnicode(false);

            //modelBuilder.Entity<ItemImageType>()
            //    .Property(e => e.Name)
            //    .IsUnicode(false);

            //modelBuilder.Entity<ItemImageType>()
            //    .HasMany(e => e.Images)
            //    .WithRequired(e => e.ImageType)
            //    .WillCascadeOnDelete(false);
        }
    }
}
