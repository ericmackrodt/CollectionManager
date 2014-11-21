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
    public class ItemsController : ODataController
    {
        private CollectionManagerEntities db = new CollectionManagerEntities();

        // GET: odata/Items
        [EnableQuery]
        public IQueryable<Item> GetItems()
        {
            return db.Items;
        }

        // GET: odata/Items(5)
        [EnableQuery]
        public SingleResult<Item> GetItem([FromODataUri] int key)
        {
            return SingleResult.Create(db.Items.Where(item => item.ItemID == key));
        }

        // PUT: odata/Items(5)
        public IHttpActionResult Put([FromODataUri] int key, Delta<Item> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Item item = db.Items.Find(key);
            if (item == null)
            {
                return NotFound();
            }

            patch.Put(item);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ItemExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(item);
        }

        // POST: odata/Items
        public IHttpActionResult Post(Item item)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            foreach (var category in item.Categories)
            {
                db.Categories.Attach(category);
            }

            foreach (var characteristic in item.Characteristics)
            {
                if (characteristic.ItemCharacteristicID != 0 && db.ItemCharacteristics.Any(o => o.ItemCharacteristicID == characteristic.ItemCharacteristicID))
                    db.ItemCharacteristics.Attach(characteristic);
            }

            db.Items.Add(item);
            db.SaveChanges();

            return Created(item);
        }

        // PATCH: odata/Items(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public IHttpActionResult Patch([FromODataUri] int key, Delta<Item> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Item item = db.Items.Find(key);
            if (item == null)
            {
                return NotFound();
            }

            patch.Patch(item);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ItemExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(item);
        }

        // DELETE: odata/Items(5)
        public IHttpActionResult Delete([FromODataUri] int key)
        {
            Item item = db.Items.Find(key);
            if (item == null)
            {
                return NotFound();
            }

            db.Items.Remove(item);
            db.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }

        // GET: odata/Items(5)/Categories
        [EnableQuery]
        public IQueryable<Category> GetCategories([FromODataUri] int key)
        {
            return db.Items.Where(m => m.ItemID == key).SelectMany(m => m.Categories);
        }

        // GET: odata/Items(5)/Characteristics
        [EnableQuery]
        public IQueryable<ItemCharacteristic> GetCharacteristics([FromODataUri] int key)
        {
            return db.Items.Where(m => m.ItemID == key).SelectMany(m => m.Characteristics);
        }

        // GET: odata/Items(5)/Description
        [EnableQuery]
        public SingleResult<ItemDescription> GetDescription([FromODataUri] int key)
        {
            return SingleResult.Create(db.Items.Where(m => m.ItemID == key).Select(m => m.Description));
        }

        // GET: odata/Items(5)/Images
        [EnableQuery]
        public IQueryable<ItemImage> GetImages([FromODataUri] int key)
        {
            return db.Items.Where(m => m.ItemID == key).SelectMany(m => m.Images);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ItemExists(int key)
        {
            return db.Items.Count(e => e.ItemID == key) > 0;
        }
    }
}
