using CollectionManagerBackend.Common;
using CollectionManagerBackend.Models;
using CollectionManagerBackend.Models.ClientModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.OData;

namespace CollectionManagerBackend.Controllers
{
    public class CollectionController : BaseController<CollectionDTO>
    {
        private IMapToNew<Collection, CollectionDTO> _fromCollection;
        private IMapToNew<CollectionDTO, Collection> _toCollection;

        public CollectionController(
            ICollectionManagerEntities entities,
            IMapToNew<Collection, CollectionDTO> fromCollection,
            IMapToNew<CollectionDTO, Collection> toCollection)
            : base (entities)
        {
            _fromCollection = fromCollection;
            _toCollection = toCollection;
        }

        public override IEnumerable<CollectionDTO> Get()
        {
            var collections = _entities.Collections;
            return collections.ToList().Select(o => _fromCollection.Map(o));
        }

        public override CollectionDTO Get(int id)
        {
            var collection = _entities.Collections.FirstOrDefault(o => o.CollectionID == id);
            return _fromCollection.Map(collection);
        }

        public override HttpResponseMessage Post([FromBody]CollectionDTO content)
        {
            if (!ModelState.IsValid)
                return Request.CreateResponse(HttpStatusCode.BadRequest);

            var collection = _toCollection.Map(content);

            _entities.Collections.Add(collection);
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
