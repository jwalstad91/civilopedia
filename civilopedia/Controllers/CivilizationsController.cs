using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using civilopedia.Models;

namespace civilopedia.Controllers
{
    public class CivilizationsController : ApiController
    {
        private civilopediaContext db = new civilopediaContext();

        // GET: civ6/Civilizations
        [HttpGet]
        public IQueryable<Civilization> GetAllCivilizations()
        {
            return db.Civilizations;
        }

        // GET: civ6/Civilizations/5
        [HttpGet]
        [ResponseType(typeof(Civilization))]
        public async Task<IHttpActionResult> GetCivilization(int id)
        {
            Civilization civilization = await db.Civilizations.FindAsync(id);
            if (civilization == null)
            {
                return NotFound();
            }

            return Ok(civilization);
        }

        // GET: civ6/Civilizations/{name}
        [HttpGet]
        [ResponseType(typeof(Civilization))]
        public IHttpActionResult GetCivilization(string name)
        {
            Civilization civilization = db.Civilizations
                                          .Where(c => c.Name == name)
                                          .FirstOrDefault();
            if (civilization == null)
            {
                return NotFound();
            }

            return Ok(civilization);
        }

        // POST: civ6/Civilizations
        [HttpPost]
        [ResponseType(typeof(Civilization))]
        public async Task<IHttpActionResult> PostCivilization(Civilization civilization)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Civilizations.Add(civilization);
            await db.SaveChangesAsync();

            return CreatedAtRoute("Civilizations", new { id = civilization.Id }, civilization);
        }

        // DELETE: api/Civilizations/5
        [HttpDelete]
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

        private bool CivilizationExists(int id)
        {
            return db.Civilizations.Count(c => c.Id == id) > 0;
        }
    }
}