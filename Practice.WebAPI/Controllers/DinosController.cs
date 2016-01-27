using Practice.EF;
using Practice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Practice.WebAPI.Controllers
{
    public class DinosController : ApiController
    {
        DinoDAL db = new DinoDAL(); // calls using entity framework happen in this class

        // GET api/<controller>/5
        public Dino Get(int id)
        {
            Dino dino = db.GetDinoItem(id);
            return dino;
        }

        // GET api/<controller>
        public DinoCollection Get()
        {
            return db.GetDinoCollection();
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}