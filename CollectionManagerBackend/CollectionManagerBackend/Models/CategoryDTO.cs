using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CollectionManagerBackend.Models
{
    public class CategoryDTO
    {
        public string Description { get; set; }

        public string Name { get; set; }

        public int Id { get; set; }

        public CategoryDTO() { }

        public CategoryDTO(Category category)
        {
            Id = category.CategoryID;
            Name = category.Name;
            Description = category.Description;
        }
    }
}
