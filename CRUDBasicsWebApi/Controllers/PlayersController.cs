using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using CRUDBasicsWebApi.Models;

namespace CRUDBasicsWebApi.Controllers
{
    public class PlayersController : ApiController
    {
        private CrudBasicsEntities db = new CrudBasicsEntities();



		// GET: api/Players
		public IQueryable<playerAverage> GetplayerAverages()
        {
            return db.playerAverages;
        }

		// GET: api/Players
		[Route("api/player2")]
		public IQueryable<playerAverage> GetplayerAveragesWithoutDot()
		{
			
			return db.playerAverages;
		}

		// GET: api/Players/5
		[ResponseType(typeof(playerAverage))]
        public IHttpActionResult GetplayerAverage(int id)
        {
            playerAverage playerAverage = db.playerAverages.Find(id);
            if (playerAverage == null)
            {
                return NotFound();
            }

            return Ok(playerAverage);
        }

        // PUT: api/Players/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutplayerAverage(int id, playerAverage playerAverage)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != playerAverage.id)
            {
                return BadRequest();
            }

            db.Entry(playerAverage).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!playerAverageExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Players
        [ResponseType(typeof(playerAverage))]
        public IHttpActionResult PostplayerAverage(playerAverage playerAverage)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.playerAverages.Add(playerAverage);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = playerAverage.id }, playerAverage);
        }

        // DELETE: api/Players/5
        [ResponseType(typeof(playerAverage))]
        public IHttpActionResult DeleteplayerAverage(int id)
        {
            playerAverage playerAverage = db.playerAverages.Find(id);
            if (playerAverage == null)
            {
                return NotFound();
            }

            db.playerAverages.Remove(playerAverage);
            db.SaveChanges();

            return Ok(playerAverage);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool playerAverageExists(int id)
        {
            return db.playerAverages.Count(e => e.id == id) > 0;
        }
    }
}