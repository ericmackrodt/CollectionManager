using CollectionManagerBackend.Models;
using CollectionManagerBackend.Models.ClientModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CollectionManagerBackend.Common.Mappers
{
    public class ToCategoryMapper : IMapToNew<CategoryDTO, Category>
    {
        public ToCategoryMapper()
        {
        }

        public Category Map(CategoryDTO data)
        {
            var obj = new Category()
            {
                CategoryID = data.CategoryID,
                Name = data.Name,
                Description = data.Description
            };

            return obj;
        }
    }
}