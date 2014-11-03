using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CollectionManagerBackend.Models
{
    public class DatabaseInitializer : DropCreateDatabaseIfModelChanges<CollectionManagerEntities>
    {
        protected override void Seed(CollectionManagerEntities context)
        {
            var collection = new Collection()
            {
                Name = "Software"
            };

            context.Collections.Add(collection);

            context.SaveChanges();
        }
    }
}