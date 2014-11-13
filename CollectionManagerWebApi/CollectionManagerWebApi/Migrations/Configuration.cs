namespace CollectionManagerWebApi.Migrations
{
    using CollectionManagerBackend.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<CollectionManagerBackend.Models.CollectionManagerEntities>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(CollectionManagerBackend.Models.CollectionManagerEntities context)
        {
            //context.Collections.Add(new Collection() { Name = "Software" });
            //context.Collections.Add(new Collection() { Name = "Diversos" });
            //context.Collections.Add(new Collection() { Name = "Processadores" });

            //context.ItemImageTypes.Add(new ItemImageType() { ItemImageTypeID = 1, Name = "Photo" });
            //context.ItemImageTypes.Add(new ItemImageType() { ItemImageTypeID = 2, Name = "Screenshot" });
        }
    }
}
