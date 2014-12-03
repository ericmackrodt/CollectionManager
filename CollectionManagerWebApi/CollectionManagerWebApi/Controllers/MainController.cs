﻿using CollectionManagerWebApi.Common;
using CollectionManagerWebApi.Models;
using CollectionManagerWebApi.Models.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CollectionManagerWebApi.Controllers
{
    public class MainController : ApiController
    {
        [HttpGet]
        public ObjectResponse<CollectionItems[]> Get()
        {
            using (var db = new CollectionManagerEntities()) 
            {
                var collections = db.Collections.ToList().Select(o => new CollectionItems()
                {
                    Collection = o.Name,
                    Items = o.Categories
                        .SelectMany(c => c.Items)
                        .OrderByDescending(i => i.StandsOut)
                        .ThenBy(i => Guid.NewGuid())
                        .Take(6)
                        .Select(i => new ItemDTO()
                        {
                            Id = i.ItemID,
                            Name = i.Name,
                            Description = i.Description.Content,
                            Image = i.Images.FirstOrDefault(img => img.ImageType == ImageType.Image && img.Main).Path
                        }).ToArray()
                }).ToArray();
                return new ObjectResponse<CollectionItems[]>(collections);
            }
        }
    }
}
