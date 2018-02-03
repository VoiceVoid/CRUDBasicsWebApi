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
    public class customPlayerController : ApiController
    {
        private CrudBasicsEntities db = new CrudBasicsEntities();

        // GET: api/customPlayer
        public IQueryable<customPlayer> GetcustomPlayers()
        {
            return db.customPlayers;
        }

        // GET: api/customPlayer/5
        [ResponseType(typeof(customPlayer))]
        public IHttpActionResult GetcustomPlayer(int id)
        {
            customPlayer customPlayer = db.customPlayers.Find(id);
            if (customPlayer == null)
            {
                return NotFound();
            }

            return Ok(customPlayer);
        }

        // PUT: api/customPlayer/5
        [ResponseType(typeof(void))]
		[Route("api/putPlayer/{id}")]
		public IHttpActionResult PutcustomPlayer(int id,customPlayer customPlayer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != customPlayer.id)
            {
                return BadRequest();
            }

            db.Entry(customPlayer).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!customPlayerExists(id))
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

        // POST: api/customPlayer
        [ResponseType(typeof(customPlayer))]
        public IHttpActionResult PostcustomPlayer(customPlayer customPlayer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.customPlayers.Add(customPlayer);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = customPlayer.id }, customPlayer);
        }

		// DELETE: api/customPlayer/5
	
	
		[HttpDelete]
		[ResponseType(typeof(customPlayer))]
		[Route("api/deletePlayer/{id}")]
		public IHttpActionResult DeletecustomPlayer(int id)
        {
            customPlayer customPlayer = db.customPlayers.Find(id);
            if (customPlayer == null)
            {
                return NotFound();
            }

            db.customPlayers.Remove(customPlayer);
            db.SaveChanges();

            return Ok(customPlayer);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool customPlayerExists(int id)
        {
            return db.customPlayers.Count(e => e.id == id) > 0;
        }
    }
}