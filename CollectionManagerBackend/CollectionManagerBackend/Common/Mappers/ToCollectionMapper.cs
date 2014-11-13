using CollectionManagerBackend.Models;
using CollectionManagerBackend.Models.ClientModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CollectionManagerBackend.Common.Mappers
{
    public class ToCollectionMapper : IMapToNew<CollectionDTO, Collection>
    {
        public ToCollectionMapper()
        {
        }

        public Collection Map(CollectionDTO data)
        {
            var obj = new Collection()
            {
                CollectionID = data.CollectionID,
                Name = data.Name,
                Description = data.Description
            };

            return obj;
        }
    }
}