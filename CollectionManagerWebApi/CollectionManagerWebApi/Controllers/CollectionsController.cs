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
    /*
    The WebApiConfig class may require additional changes to add a route for this controller. Merge these statements into the Register method of the WebApiConfig class as applicable. Note that OData URLs are case sensitive.

    using System.Web.Http.OData.Builder;
    using System.Web.Http.OData.Extensions;
    using CollectionManagerBackend.Models;
    ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
    builder.EntitySet<Collection>("Collections");
    builder.EntitySet<Category>("Categories"); 
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    public class CollectionsController : ODataController
    {
        private CollectionManagerEntities db = new CollectionManagerEntities();

        // GET: odata/Collections
        [EnableQuery]
        public IQueryable<Collection> GetCollections()
        {
            return db.Collections;
        }

        // GET: odata/Collections(5)
        [EnableQuery]
        public SingleResult<Collection> GetCollection([FromODataUri] int key)
        {
            return SingleResult.Create(db.Collections.Where(collection => collection.CollectionID == key));
        }

        // PUT: odata/Collections(5)
        public IHttpActionResult Put([FromODataUri] int key, Delta<Collection> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Collection collection = db.Collections.Find(key);
            if (collection == null)
            {
                return NotFound();
            }

            patch.Put(collection);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CollectionExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(collection);
        }

        // POST: odata/Collections
        public IHttpActionResult Post([FromBody]Collection collection)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Collections.Add(collection);
            db.SaveChanges();

            return Created(collection);
        }

        // PATCH: odata/Collections(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public IHttpActionResult Patch([FromODataUri] int key, Delta<Collection> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Collection collection = db.Collections.Find(key);
            if (collection == null)
            {
                return NotFound();
            }

            patch.Patch(collection);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CollectionExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(collection);
        }

        // DELETE: odata/Collections(5)
        public IHttpActionResult Delete([FromODataUri] int key)
        {
            Collection collection = db.Collections.Find(key);
            if (collection == null)
            {
                return NotFound();
            }

            db.Collections.Remove(collection);
            db.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }

        // GET: odata/Collections(5)/Categories
        [EnableQuery]
        public IQueryable<Category> GetCategories([FromODataUri] int key)
        {
            return db.Collections.Where(m => m.CollectionID == key).SelectMany(m => m.Categories);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CollectionExists(int key)
        {
            return db.Collections.Count(e => e.CollectionID == key) > 0;
        }
    }
}
