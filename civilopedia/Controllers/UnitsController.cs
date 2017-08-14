using civilopedia.Models;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace civilopedia.Controllers
{
    public class UnitsController : ApiController
    {
        private civilopediaContext db = new civilopediaContext();

        // GET: civ6/Units
        [HttpGet]
        public IQueryable<Unit> GetAllUnits()
        {
            return db.Units;
        }

        // GET: civ6/Units/{id}
        [HttpGet]
        [ResponseType(typeof(Unit))]
        public async Task<IHttpActionResult> GetUnit(int id)
        {
            Unit unit = await db.Units.FindAsync(id);
            if (unit == null)
            {
                return NotFound();
            }

            return Ok(unit);
        }

        // GET: civ6/Units/{name}
        [HttpGet]
        [ResponseType(typeof(Unit))]
        // TODO: Find a way to take advantage of async. Probably can't use LINQ with async, need to look into this.
        public async Task<IHttpActionResult> GetUnit(string name)
        {
            Unit unit = db.Units
                          .Where(u => u.Name == name)
                          .FirstOrDefault();
            if (unit == null)
            {
                return NotFound();
            }

            return Ok(unit);
        }

        // POST: civ6/Units
        [HttpPost]
        [ResponseType(typeof(Unit))]
        public async Task<IHttpActionResult> NewUnit([FromBody]Unit unit)
        {
            if (unit == null)
            {
                return BadRequest("Invalid Unit Model.");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Units.Add(unit);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (UnitExists(unit.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("Units", new { id = unit.Id }, unit);
        }

        // DELETE: civ6/Units/{id}
        [HttpDelete]
        [ResponseType(typeof(Unit))]
        public async Task<IHttpActionResult> DeleteUnit(int id)
        {
            Unit unit = await db.Units.FindAsync(id);
            if (unit == null)
            {
                return NotFound();
            }

            db.Units.Remove(unit);
            await db.SaveChangesAsync();

            return Ok(unit);
        }

        private bool UnitExists(int id)
        {
            return db.Units.Count(u => u.Id == id) > 0;
        }
    }
}
