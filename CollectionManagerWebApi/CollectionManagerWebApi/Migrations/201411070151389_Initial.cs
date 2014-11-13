namespace CollectionManagerWebApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Category",
                c => new
                    {
                        CategoryID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 256),
                        Description = c.String(maxLength: 1000),
                        Collection_CollectionID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CategoryID)
                .ForeignKey("dbo.Collection", t => t.Collection_CollectionID, cascadeDelete: true)
                .Index(t => t.Collection_CollectionID);
            
            CreateTable(
                "dbo.Collection",
                c => new
                    {
                        CollectionID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 256),
                        Description = c.String(maxLength: 1000),
                    })
                .PrimaryKey(t => t.CollectionID);
            
            CreateTable(
                "dbo.Item",
                c => new
                    {
                        ItemID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 500),
                        Year = c.Int(),
                        Developer = c.String(maxLength: 100),
                        Publisher = c.String(maxLength: 100),
                        Manufacturer = c.String(maxLength: 100),
                        DateAcquired = c.DateTime(),
                        YoutubeVideo = c.String(maxLength: 500),
                    })
                .PrimaryKey(t => t.ItemID);
            
            CreateTable(
                "dbo.ItemCharacteristic",
                c => new
                    {
                        ItemCharacteristicID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 150),
                    })
                .PrimaryKey(t => t.ItemCharacteristicID);
            
            CreateTable(
                "dbo.ItemDescription",
                c => new
                    {
                        ItemDescriptionID = c.Long(nullable: false, identity: true),
                        Content = c.String(nullable: false, maxLength: 2000),
                        Source = c.String(maxLength: 100),
                        SourceUrl = c.String(maxLength: 1000),
                        Item_ItemID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ItemDescriptionID)
                .ForeignKey("dbo.Item", t => t.Item_ItemID)
                .Index(t => t.Item_ItemID);
            
            CreateTable(
                "dbo.ItemImage",
                c => new
                    {
                        ItemImageID = c.Int(nullable: false, identity: true),
                        Path = c.String(nullable: false, maxLength: 500),
                        ItemImageTypeID = c.Int(nullable: false),
                        Item_ItemID = c.Int(),
                    })
                .PrimaryKey(t => t.ItemImageID)
                .ForeignKey("dbo.ItemImageType", t => t.ItemImageTypeID, cascadeDelete: true)
                .ForeignKey("dbo.Item", t => t.Item_ItemID)
                .Index(t => t.ItemImageTypeID)
                .Index(t => t.Item_ItemID);
            
            CreateTable(
                "dbo.ItemImageType",
                c => new
                    {
                        ItemImageTypeID = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.ItemImageTypeID);
            
            CreateTable(
                "dbo.ItemCategory",
                c => new
                    {
                        Item_ItemID = c.Int(nullable: false),
                        Category_CategoryID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Item_ItemID, t.Category_CategoryID })
                .ForeignKey("dbo.Item", t => t.Item_ItemID, cascadeDelete: true)
                .ForeignKey("dbo.Category", t => t.Category_CategoryID, cascadeDelete: true)
                .Index(t => t.Item_ItemID)
                .Index(t => t.Category_CategoryID);
            
            CreateTable(
                "dbo.ItemCharacteristicItem",
                c => new
                    {
                        ItemCharacteristic_ItemCharacteristicID = c.Int(nullable: false),
                        Item_ItemID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ItemCharacteristic_ItemCharacteristicID, t.Item_ItemID })
                .ForeignKey("dbo.ItemCharacteristic", t => t.ItemCharacteristic_ItemCharacteristicID, cascadeDelete: true)
                .ForeignKey("dbo.Item", t => t.Item_ItemID, cascadeDelete: true)
                .Index(t => t.ItemCharacteristic_ItemCharacteristicID)
                .Index(t => t.Item_ItemID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ItemImage", "Item_ItemID", "dbo.Item");
            DropForeignKey("dbo.ItemImage", "ItemImageTypeID", "dbo.ItemImageType");
            DropForeignKey("dbo.ItemDescription", "Item_ItemID", "dbo.Item");
            DropForeignKey("dbo.ItemCharacteristicItem", "Item_ItemID", "dbo.Item");
            DropForeignKey("dbo.ItemCharacteristicItem", "ItemCharacteristic_ItemCharacteristicID", "dbo.ItemCharacteristic");
            DropForeignKey("dbo.ItemCategory", "Category_CategoryID", "dbo.Category");
            DropForeignKey("dbo.ItemCategory", "Item_ItemID", "dbo.Item");
            DropForeignKey("dbo.Category", "Collection_CollectionID", "dbo.Collection");
            DropIndex("dbo.ItemCharacteristicItem", new[] { "Item_ItemID" });
            DropIndex("dbo.ItemCharacteristicItem", new[] { "ItemCharacteristic_ItemCharacteristicID" });
            DropIndex("dbo.ItemCategory", new[] { "Category_CategoryID" });
            DropIndex("dbo.ItemCategory", new[] { "Item_ItemID" });
            DropIndex("dbo.ItemImage", new[] { "Item_ItemID" });
            DropIndex("dbo.ItemImage", new[] { "ItemImageTypeID" });
            DropIndex("dbo.ItemDescription", new[] { "Item_ItemID" });
            DropIndex("dbo.Category", new[] { "Collection_CollectionID" });
            DropTable("dbo.ItemCharacteristicItem");
            DropTable("dbo.ItemCategory");
            DropTable("dbo.ItemImageType");
            DropTable("dbo.ItemImage");
            DropTable("dbo.ItemDescription");
            DropTable("dbo.ItemCharacteristic");
            DropTable("dbo.Item");
            DropTable("dbo.Collection");
            DropTable("dbo.Category");
        }
    }
}
