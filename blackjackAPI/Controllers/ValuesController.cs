using blackjackAPI.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace blackjackAPI.Controllers
{
    [EnableCors(origins: "http://localhost:4200",headers: "*",methods: "*", SupportsCredentials = true)]
    public class ValuesController : ApiController
    {
        // GET api/values
        public IEnumerable<string> Get()
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

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
        
        [HttpPost]
        [HttpGet]
        [Route("api/data")]
        public HttpResponseMessage GetCheatData([FromBody] Card[] player, Card[] computer)
        {
            var data = "Do Not push card!";
            var json = JsonConvert.SerializeObject(data);
            //log.Error("GetData2 JsonConvert");
            return new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new ObjectContent(json.GetType(), json, Configuration.Formatters.JsonFormatter)
            };
        }
    }
}
