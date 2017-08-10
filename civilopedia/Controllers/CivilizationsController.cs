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
using civilopedia.Models;

namespace civilopedia.Controllers
{
    public class CivilizationsController : ApiController
    {
        private civilopediaContext db = new civilopediaContext();

        // GET: civ6/Civilizations/AllCivilizations
        public IQueryable<Civilization> AllCivilizations()
        {
            return db.Civilizations;
        }

        // GET: api/Civilizations/5
        [ResponseType(typeof(Civilization))]
        public async Task<IHttpActionResult> GetCivilization(int? id)
        {
            Civilization civilization = await db.Civilizations.FindAsync(id);
            if (civilization == null)
            {
                return NotFound();
            }

            return Ok(civilization);
        }

        // PUT: api/Civilizations/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutCivilization(int id, Civilization civilization)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != civilization.Id)
            {
                return BadRequest();
            }

            db.Entry(civilization).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CivilizationExists(id))
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

        // POST: api/Civilizations
        [ResponseType(typeof(Civilization))]
        public async Task<IHttpActionResult> PostCivilization(Civilization civilization)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Civilizations.Add(civilization);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = civilization.Id }, civilization);
        }

        // DELETE: api/Civilizations/5
        [ResponseType(typeof(Civilization))]
        public async Task<IHttpActionResult> DeleteCivilization(int id)
        {
            Civilization civilization = await db.Civilizations.FindAsync(id);
            if (civilization == null)
            {
                return NotFound();
            }

            db.Civilizations.Remove(civilization);
            await db.SaveChangesAsync();

            return Ok(civilization);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CivilizationExists(int id)
        {
            return db.Civilizations.Count(e => e.Id == id) > 0;
        }
    }
}