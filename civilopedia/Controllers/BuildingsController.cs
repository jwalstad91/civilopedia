using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using civilopedia.Models;

namespace civilopedia.Controllers
{
    public class BuildingsController : ApiController
    {
        private civilopediaContext db = new civilopediaContext();

        // GET: civ6/Buildings
        [HttpGet]
        public IQueryable<Building> GetAllBuildings()
        {
            return db.Buildings;
        }

        // GET: civ6/Buildings/5
        [HttpGet]
        [ResponseType(typeof(Building))]
        public async Task<IHttpActionResult> GetBuilding(int id)
        {
            Building building = await db.Buildings.FindAsync(id);
            if (building == null)
            {
                return NotFound();
            }

            return Ok(building);
        }

        // GET: civ6/Buildings/{name}
        [HttpGet]
        [ResponseType(typeof(Building))]
        public IHttpActionResult GetBuilding(string name)
        {
            Building building = db.Buildings
                                  .Where(b => b.Name == name)
                                  .FirstOrDefault();
            if (building == null)
            {
                return NotFound();
            }

            return Ok(building);
        }

        // POST: civ6/Buildings
        [HttpPost]
        [ResponseType(typeof(Building))]
        public async Task<IHttpActionResult> PostBuilding(Building building)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Buildings.Add(building);
            await db.SaveChangesAsync();

            return CreatedAtRoute("Buildings", new { id = building.Id }, building);
        }

        // DELETE: civ6/Buildings/5
        [HttpDelete]
        [ResponseType(typeof(Building))]
        public async Task<IHttpActionResult> DeleteBuilding(int id)
        {
            Building building = await db.Buildings.FindAsync(id);
            if (building == null)
            {
                return NotFound();
            }

            db.Buildings.Remove(building);
            await db.SaveChangesAsync();

            return Ok(building);
        }

        private bool BuildingExists(int id)
        {
            return db.Buildings.Count(b => b.Id == id) > 0;
        }
    }
}