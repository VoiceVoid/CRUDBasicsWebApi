using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using CRUDBasicsWebApi.Models;

namespace CRUDBasicsWebApi.Controllers
{
    public class seasonsController : ApiController
    {
        private CrudBasicsEntities db = new CrudBasicsEntities();


		[Route("api/seasons/{id}")]
		public IQueryable<playersSeason> GettblPlayerSeasons(string id)
		{
			return db.playersSeasons.Where(m => m.Player == id).OrderBy(x => x.Year);
		}
		// GET: api/seasons
		public IQueryable<playersSeason> GetplayersSeasons()
        {
            return db.playersSeasons;
        }

        // GET: api/seasons/5
        [ResponseType(typeof(playersSeason))]
        public async Task<IHttpActionResult> GetplayersSeason(short id)
        {
            playersSeason playersSeason = await db.playersSeasons.FindAsync(id);
            if (playersSeason == null)
            {
                return NotFound();
            }

            return Ok(playersSeason);
        }

        // PUT: api/seasons/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutplayersSeason(short id, playersSeason playersSeason)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != playersSeason.Id)
            {
                return BadRequest();
            }

            db.Entry(playersSeason).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!playersSeasonExists(id))
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

        // POST: api/seasons
        [ResponseType(typeof(playersSeason))]
        public async Task<IHttpActionResult> PostplayersSeason(playersSeason playersSeason)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.playersSeasons.Add(playersSeason);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = playersSeason.Id }, playersSeason);
        }

        // DELETE: api/seasons/5
        [ResponseType(typeof(playersSeason))]
        public async Task<IHttpActionResult> DeleteplayersSeason(short id)
        {
            playersSeason playersSeason = await db.playersSeasons.FindAsync(id);
            if (playersSeason == null)
            {
                return NotFound();
            }

            db.playersSeasons.Remove(playersSeason);
            await db.SaveChangesAsync();

            return Ok(playersSeason);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool playersSeasonExists(short id)
        {
            return db.playersSeasons.Count(e => e.Id == id) > 0;
        }
    }
}