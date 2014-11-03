using CollectionManagerBackend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Controllers;

namespace CollectionManagerBackend.Controllers
{
    public class ItemController : ApiController
    {
        private CollectionManagerEntities collectionData;

        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);

            collectionData = new CollectionManagerEntities();
        }

        // GET api/item
        public IEnumerable<ItemDTO> Get()
        {
            return collectionData.Items.Select(o => new ItemDTO(o));
            //return null;
        }

        // GET api/item/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/item
        public void Post([FromBody]string value)
        {
        }

        // PUT api/item/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/item/5
        public void Delete(int id)
        {
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            collectionData.Dispose();
        }
    }
}
