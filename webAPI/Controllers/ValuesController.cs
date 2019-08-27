using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace webAPI.Controllers
{
    //[EnableCors(origins: "http://localhost:4200", headers: "*", methods:"*")]
    [Authorize]
    public class ValuesController : ApiController
    {
        // GET api/values
        [HttpGet]
        public IEnumerable<string> myGet()
        {
            return new string[] { "value1", "value2" };
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

        [Route("api/myCustomRoute")]
        public void Post_new([FromBody]string value)
        {
        }

        //public void Post_new([FromBody]string value)
        //{
        //}

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
