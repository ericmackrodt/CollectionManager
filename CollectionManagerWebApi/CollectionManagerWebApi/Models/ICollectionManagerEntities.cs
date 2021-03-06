﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace CollectionManagerWebApi.Models
{
    public interface ICollectionManagerEntities : IDisposable
    {
        DbSet<Category> Categories { get; set; }
        DbSet<Collection> Collections { get; set; }
        DbSet<Item> Items { get; set; }
        DbSet<ItemCharacteristic> ItemCharacteristics { get; set; }
        DbSet<ItemDescription> ItemDescriptions { get; set; }
        DbSet<ItemImage> ItemImages { get; set; }
        int SaveChanges();
    }
}
