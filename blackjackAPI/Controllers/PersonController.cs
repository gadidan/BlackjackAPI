using blackjackAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace blackjackAPI.Controllers
{
    [RoutePrefix("Api/Person")]
    public class PersonController : ApiController
    {
        blackjackEntities db = new blackjackEntities();
        [HttpGet]
        [Route("AllPersons")]
        public IQueryable<GetPersons_Result> GetPersons()
        {
            try
            {
                return db.GetPersons().AsQueryable();
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet]
        [Route("GetPersonById/{personId}")]
        public IHttpActionResult GetEmaployeeById(string personId)
        {
            var person = new GetPersonById_Result();
            int id = Convert.ToInt32(personId);
            try
            {
                person = db.GetPersonById(id).FirstOrDefault();
                if (db == null)
                {
                    return NotFound();
                }

            }
            catch (Exception)
            {
                throw;
            }

            return Ok(person);
        }

        [HttpPost]
        [Route("InsertPerson")]
        public IHttpActionResult PostPerson(Person data)
        {

            var res = -1;
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                res = db.InsertPerson(data.FirstName, 
                            data.LastName,
                            data.Address,
                            data.City,
                            data.phone.Value);
                //db.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }

            return Ok(res);
        }

        [HttpPut]
        [Route("UpdatePerson")]
        public IHttpActionResult PutPerson(Person person)
        {
            var res = -1;
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                res = db.UpdatePerson(person.Id,
                            person.FirstName,
                            person.LastName,
                            person.Address,
                            person.City,
                            person.phone.Value);
                //db.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }

            return Ok(res);
        }

        [HttpDelete]
        [Route("DeletePerson")]
        public IHttpActionResult DeletePerson(int id)
        {
            GetPersons_Result person = db.GetPersons().Where(s => s.Id == id).FirstOrDefault();
            if (person == null)
            {
                return NotFound();
            }

            db.DeletePerson(id);
            //db.SaveChanges();

            return Ok(person);
        }
    }
}
