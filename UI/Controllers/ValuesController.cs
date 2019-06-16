using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity;
using Entity.Entitys;
using BLL;

namespace UI.Controllers
{
    public class ValuesController : ApiController
    {
        WorkShop work = new WorkShop();
        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return work.GetAdmins();
        }

        // GET api/values/5
        public string Get(int id)
        {
            return  "kk";
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
