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
            context.Collections.Add(new Collection() { Name = "Software" });
            context.Collections.Add(new Collection() { Name = "Diversos" });
            context.Collections.Add(new Collection() { Name = "Processadores" });

            context.ItemImageTypes.Add(new ItemImageType() { ItemImageTypeID = 1, Name = "Photo" });
            context.ItemImageTypes.Add(new ItemImageType() { ItemImageTypeID = 2, Name = "Screenshot" });

            context.SaveChanges();
        }
    }
}