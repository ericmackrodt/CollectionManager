using CollectionManagerBackend.Models;
using CollectionManagerBackend.Models.ClientModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CollectionManagerBackend.Common.Mappers
{
    public class FromCollectionMapper : IMapToNew<Collection, CollectionDTO>
    {
        private IMapToNew<Category, CategoryDTO> _categoryMapper;

        public FromCollectionMapper(IMapToNew<Category, CategoryDTO> categoryMapper)
        {
            _categoryMapper = categoryMapper;
        }

        public CollectionDTO Map(Collection data)
        {
            var dto = new CollectionDTO()
            {
                CollectionID = data.CollectionID,
                Name = data.Name,
                Description = data.Description
            };

            if (data.Categories != null)
            {
                dto.Categories = data.Categories.Select(o => _categoryMapper.Map(o)).ToArray();
            }

            return dto;
        }
    }
}