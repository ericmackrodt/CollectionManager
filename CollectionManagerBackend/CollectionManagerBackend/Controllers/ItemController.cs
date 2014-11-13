using CollectionManagerBackend.Common;
using CollectionManagerBackend.Models;
using CollectionManagerBackend.Models.ClientModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.OData;

namespace CollectionManagerBackend.Controllers
{
    public class ItemController : BaseController<ItemDTO>
    {
        private IMapToNew<Item, ItemDTO> _fromItem;
        private IMapToNew<ItemDTO, Item> _toItem;

        public ItemController(
            ICollectionManagerEntities entities,
            IMapToNew<Item, ItemDTO> fromItem,
            IMapToNew<ItemDTO, Item> toItem)
            : base (entities)
        {
            _fromItem = fromItem;
            _toItem = toItem;
        }

        public override IEnumerable<ItemDTO> Get()
        {
            var items = _entities.Items.ToArray();
            return items.Select(o => _fromItem.Map(o));
        }

        public override ItemDTO Get(int id)
        {
            var item = _entities.Items.FirstOrDefault(o => o.ItemID == id);
            return _fromItem.Map(item);
        }

        public override HttpResponseMessage Post([FromBody]ItemDTO content)
        {
            if (!ModelState.IsValid)
                return Request.CreateResponse(HttpStatusCode.BadRequest);

            var item = _toItem.Map(content);


            _entities.Items.Add(item);
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
