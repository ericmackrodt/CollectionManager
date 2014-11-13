using CollectionManagerBackend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace CollectionManagerBackend.Controllers
{
    public abstract class BaseController<T> : ApiController
    {
        protected ICollectionManagerEntities _entities;

        public BaseController(ICollectionManagerEntities entities)
        {
            _entities = entities;
        }

        protected override void Initialize(System.Web.Http.Controllers.HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
        }

        public abstract IEnumerable<T> Get();
        public abstract T Get(int id);
        public abstract HttpResponseMessage Post([FromBody]T content);
        public abstract HttpResponseMessage Put(int id, [FromBody]string value);
        public abstract HttpResponseMessage Delete(int id);

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _entities.Dispose();
            }

            base.Dispose(disposing);
        }
    }
}