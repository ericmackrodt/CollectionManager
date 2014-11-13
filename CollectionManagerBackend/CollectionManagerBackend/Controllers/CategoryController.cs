using CollectionManagerBackend.Common;
using CollectionManagerBackend.Models;
using CollectionManagerBackend.Models.ClientModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CollectionManagerBackend.Controllers
{
    public class CategoryController : BaseController<CategoryDTO>
    {
        private IMapToNew<Category, CategoryDTO> _fromCategory;
        private IMapToNew<CategoryDTO, Category> _toCategory;

        public CategoryController(
            IMapToNew<Category, CategoryDTO> fromCategory, 
            IMapToNew<CategoryDTO, Category> toCategory,
            ICollectionManagerEntities entities)
            : base (entities)
        {
            _fromCategory = fromCategory;
            _toCategory = toCategory;
        }

        public override IEnumerable<CategoryDTO> Get()
        {
            var categories = _entities.Categories;
            return categories.ToList().Select(o => _fromCategory.Map(o));
        }

        public override CategoryDTO Get(int id)
        {
            var category = _entities.Categories.FirstOrDefault(o => o.CategoryID == id);
            return _fromCategory.Map(category);
        }

        public override HttpResponseMessage Post([FromBody]CategoryDTO content)
        {
            if (!ModelState.IsValid)
                return Request.CreateResponse(HttpStatusCode.BadRequest);

            var collection = _entities.Collections.FirstOrDefault(o => o.CollectionID == content.Collection.CollectionID);

            var category = _toCategory.Map(content);
            category.Collection = collection;

            _entities.Categories.Add(category);
            _entities.SaveChanges();

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        public override HttpResponseMessage Put(int id, string value)
        {
            throw new NotImplementedException();
        }

        public override HttpResponseMessage Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
