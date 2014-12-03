using CollectionManagerWebApi.Models;
using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;

namespace CollectionManagerWebApi.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<CollectionManagerEntities>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(CollectionManagerEntities context)
        {
            if (!context.Collections.Any())
            {
                context.Collections.Add(new Collection() { Name = "Software" });
                context.Collections.Add(new Collection() { Name = "Diversos" });
                context.Collections.Add(new Collection() { Name = "Processadores" });
            }
        }
    }
}
