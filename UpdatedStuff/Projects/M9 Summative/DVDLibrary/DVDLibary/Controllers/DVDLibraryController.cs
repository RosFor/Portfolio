using DVDLibrary.Data;
using DVDLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace DVDLibary.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class DVDLibraryController : ApiController
    {        
        iDVDRepository repo;
        public DVDLibraryController()
        {
            repo = DVDLibraryFactory.GetRepository();
        }

        // GET api/<controller>
        [Route("dvds")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetAll()
        {
            List<DVD> found = repo.GetAllDVDs();
            if (found == null)
            {
                return NotFound();
            }
            return Ok(found);
        }

        // GET api/<controller>/5
        [Route("dvd/{id}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult Get(int id)
        {
            DVD found = repo.GetByID(id);

            if (found == null)
            {
                return NotFound();
            }

            return Ok(found);
        }
        // GET api/<controller>
        [Route("dvds/title/{title}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetTitle(string title)
        {
            List<DVD> found = repo.GetByTitle(title);

            if (found == null)
            {
                return NotFound();
            }

            return Ok(found);
        }
        // GET api/<controller>
        [Route("dvds/year/{releaseYear}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetYear(int releaseYear)
        {
            List<DVD> found = repo.GetByReleaseYear(releaseYear);

            if (found == null)
            {
                return NotFound();
            }

            return Ok(found);
        }
        // GET api/<controller>
        [Route("dvds/director/{director}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetDirector(string director)
        {
            List<DVD> found = repo.GetByDirector(director);

            if (found == null)
            {
                return NotFound();
            }

            return Ok(found);
        }
        // GET api/<controller>
        [Route("dvds/rating/{rating}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetRating(string rating)
        {
            List<DVD> found = repo.GetByRating(rating);

            if (found == null)
            {
                return NotFound();
            }

            return Ok(found);
        }

        // POST api/<controller>
        [Route("dvd")]
        [AcceptVerbs("POST")]
        public IHttpActionResult Add(DVD dvd)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            repo.Insert(dvd);
            return Created($"dvd/{dvd.id}", dvd);
        }

        // PUT api/<controller>/5
        [Route("dvd/{id}")]
        [AcceptVerbs("PUT")]
        public void Update(int id, DVD dvd)
        {
            repo.Update(dvd);
        }

        // DELETE api/<controller>/5
        [Route("dvd/{id}")]
        [AcceptVerbs("DELETE")]
        public void Delete(int id)
        {
            repo.Delete(id);
        }
    }
}