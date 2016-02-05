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
        DinoDAL dal = new DinoDAL(); // calls using entity framework happen in this class

        // GET api/<controller>/5
        public Dino Get(int id)
        {
            Dino dino = dal.GetDinoItem(id);
            return dino;
        }

        // GET api/<controller>
        public DinoCollection Get()
        {
            return dal.GetDinoCollection();
        }

        // POST api/<controller>
        public void Post([FromBody]Dino dinoToSave)
        {
            dal.SaveDino(dinoToSave);
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]Dino dinoToUpdate)
        {
            dal.UpdateDino(dinoToUpdate);
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
            dal.DeleteDino(id);
        }
    }
}