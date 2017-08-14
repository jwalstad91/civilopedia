using civilopedia.Models;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace civilopedia.Controllers
{
    public class DistrictsController : ApiController
    {
        private civilopediaContext db = new civilopediaContext();

        // GET: civ6/Districts
        [HttpGet]
        public IQueryable<District> GetAllDistricts()
        {
            return db.Districts;
        }

        // GET: civ6/Districts/{id}
        [HttpGet]
        [ResponseType(typeof(District))]
        public async Task<IHttpActionResult> GetDistrict(int id)
        {
            District district = await db.Districts.FindAsync(id);
            if (district == null)
            {
                return NotFound();
            }

            return Ok(district);
        }

        // GET: civ6/Districts/{name}
        [HttpGet]
        [ResponseType(typeof(District))]
        public IHttpActionResult GetDistrict(string name)
        {
            District district = db.Districts
                                  .Where(d => d.Name == name)
                                  .FirstOrDefault();
            if (district == null)
            {
                return NotFound();
            }

            return Ok(district);
        }

        // POST: civ6/Districts
        [HttpPost]
        [ResponseType(typeof(District))]
        public async Task<IHttpActionResult> NewDistrict([FromBody]District district)
        {
            if (district == null)
            {
                return BadRequest("Invalid District Model.");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Districts.Add(district);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (DistrictExists(district.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("Districts", new { id = district.Id }, district);
        }

        // DELETE: civ6/Districts/5
        [HttpDelete]
        [ResponseType(typeof(District))]
        public async Task<IHttpActionResult> DeleteDistrict(int id)
        {
            District district = await db.Districts.FindAsync(id);
            if (district == null)
            {
                return NotFound();
            }

            db.Districts.Remove(district);
            await db.SaveChangesAsync();

            return Ok(district);
        }

        private bool DistrictExists(int id)
        {
            return db.Districts.Count(d => d.Id == id) > 0;
        }
    }
}
