using CollectionManagerBackend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CollectionManagerBackend.Controllers
{
    public class ValuesController : ApiController
    {
        

        // GET api/values
        public IEnumerable<string> Get()
        {
            using (var ent = new CollectionManagerEntities())
            {
                var collection = new Collection()
                {
                    Name = "Software"
                };

                var els = ent.Collections.ToList();

                ent.Collections.Add(collection);

                //var category = new Category()
                //{
                //    Name = "Microsoft"
                //};

                //collection.Categories.Add(category);

                //var item = new Item()
                //{
                //    DateAcquired = DateTime.Now,
                //    Developer = "Microsoft",
                //    Manufacturer = "Microsoft",
                //    Name = "Microsoft Windows 95",
                //    Publisher = "Microsoft",
                //    Year = 1995
                //};

                //category.Items.Add(item);

                //ent.Collections.Add(collection);

                ent.SaveChanges();
            };
            return null;
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}