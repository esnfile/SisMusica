using ENT.pessoa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace sismus.Controllers
{
    public class ValuesController : ApiController
    {
        // GET: api/Cargo
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Cargo/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Cargo
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Cargo/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Cargo/5
        public void Delete(int id)
        {
        }
    }
}
