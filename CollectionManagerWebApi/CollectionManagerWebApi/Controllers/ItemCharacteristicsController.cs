using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.ModelBinding;
using System.Web.OData;
using System.Web.OData.Routing;
using CollectionManagerBackend.Models;

namespace CollectionManagerWebApi.Controllers
{
    public class ItemCharacteristicsController : ODataController
    {
        private CollectionManagerEntities db = new CollectionManagerEntities();

        // GET: odata/ItemCharacteristics
        [EnableQuery]
        public IQueryable<ItemCharacteristic> GetItemCharacteristics()
        {
            return db.ItemCharacteristics;
        }

        // GET: odata/ItemCharacteristics(5)
        [EnableQuery]
        public SingleResult<ItemCharacteristic> GetItemCharacteristic([FromODataUri] int key)
        {
            return SingleResult.Create(db.ItemCharacteristics.Where(itemCharacteristic => itemCharacteristic.ItemCharacteristicID == key));
        }

        // PUT: odata/ItemCharacteristics(5)
        public IHttpActionResult Put([FromODataUri] int key, Delta<ItemCharacteristic> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            ItemCharacteristic itemCharacteristic = db.ItemCharacteristics.Find(key);
            if (itemCharacteristic == null)
            {
                return NotFound();
            }

            patch.Put(itemCharacteristic);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ItemCharacteristicExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(itemCharacteristic);
        }

        // POST: odata/ItemCharacteristics
        public IHttpActionResult Post(ItemCharacteristic itemCharacteristic)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ItemCharacteristics.Add(itemCharacteristic);
            db.SaveChanges();

            return Created(itemCharacteristic);
        }

        // PATCH: odata/ItemCharacteristics(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public IHttpActionResult Patch([FromODataUri] int key, Delta<ItemCharacteristic> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            ItemCharacteristic itemCharacteristic = db.ItemCharacteristics.Find(key);
            if (itemCharacteristic == null)
            {
                return NotFound();
            }

            patch.Patch(itemCharacteristic);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ItemCharacteristicExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(itemCharacteristic);
        }

        // DELETE: odata/ItemCharacteristics(5)
        public IHttpActionResult Delete([FromODataUri] int key)
        {
            ItemCharacteristic itemCharacteristic = db.ItemCharacteristics.Find(key);
            if (itemCharacteristic == null)
            {
                return NotFound();
            }

            db.ItemCharacteristics.Remove(itemCharacteristic);
            db.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }

        // GET: odata/ItemCharacteristics(5)/Items
        [EnableQuery]
        public IQueryable<Item> GetItems([FromODataUri] int key)
        {
            return db.ItemCharacteristics.Where(m => m.ItemCharacteristicID == key).SelectMany(m => m.Items);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ItemCharacteristicExists(int key)
        {
            return db.ItemCharacteristics.Count(e => e.ItemCharacteristicID == key) > 0;
        }
    }
}
