using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using civilopedia.Models;

namespace civilopedia.Controllers
{
    public class LeadersController : ApiController
    {
        private civilopediaContext db = new civilopediaContext();

        // GET: civ6/Leaders
        [HttpGet]
        public IQueryable<Leader> GetAllLeaders()
        {
            return db.Leaders;
        }

        // GET: civ6/Leaders/5
        [HttpGet]
        [ResponseType(typeof(Leader))]
        public async Task<IHttpActionResult> GetLeader(int id)
        {
            Leader leader = await db.Leaders.FindAsync(id);
            if (leader == null)
            {
                return NotFound();
            }

            return Ok(leader);
        }

        // GET: civ6/Leaders/Gandhi
        [HttpGet]
        [ResponseType(typeof(Leader))]
        public IHttpActionResult GetLeader(string name)
        {
            Leader leader = db.Leaders
                              .Where(l => l.Name == name)
                              .FirstOrDefault();
            if (leader == null)
            {
                return NotFound();
            }

            return Ok(leader);
        }

        // POST: civ6/Leaders
        [HttpPost]
        [ResponseType(typeof(Leader))]
        public async Task<IHttpActionResult> PostLeader(Leader leader)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Leaders.Add(leader);
            await db.SaveChangesAsync();

            return CreatedAtRoute("Leaders", new { id = leader.Id }, leader);
        }

        // DELETE: api/Leaders/5
        [HttpDelete]
        [ResponseType(typeof(Leader))]
        public async Task<IHttpActionResult> DeleteLeader(int id)
        {
            Leader leader = await db.Leaders.FindAsync(id);
            if (leader == null)
            {
                return NotFound();
            }

            db.Leaders.Remove(leader);
            await db.SaveChangesAsync();

            return Ok(leader);
        }

        private bool LeaderExists(int id)
        {
            return db.Leaders.Count(l => l.Id == id) > 0;
        }
    }
}