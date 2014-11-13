using CollectionManagerBackend.Models;
using CollectionManagerBackend.Models.ClientModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CollectionManagerBackend.Common.Mappers
{
    public class FromCategoryMapper : IMapToNew<Category, CategoryDTO>
    {
        public FromCategoryMapper()
        {
        }

        public CategoryDTO Map(Category data)
        {
            var dto = new CategoryDTO()
            {
                CategoryID = data.CategoryID,
                Name = data.Name,
                Description = data.Description
            };

            return dto;
        }
    }
}