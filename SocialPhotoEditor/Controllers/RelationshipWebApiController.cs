using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SocialPhotoEditor.Controllers
{
    public class RelationshipWebApiController : ApiController
    {
        // GET: api/RelationshipWebApi
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/RelationshipWebApi/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/RelationshipWebApi
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/RelationshipWebApi/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/RelationshipWebApi/5
        public void Delete(int id)
        {
        }
    }
}
