using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PolytechExamBase.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PolytechExamBase.Controllers
{
    [EnableCors("myAllowSpecificOrigins")]
    [Route("api/[controller]")]
    [ApiController]
    public class DbusersController : ControllerBase
    {

        private readonly PolytechExamBaseNewContext _context;

        public DbusersController(PolytechExamBaseNewContext context)
        {
            _context = context;
        }

        // GET: api/Dbusers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Dbusers>>> GetUser()
        {
            return await _context.Dbusers.ToListAsync();
        }

        // GET: api/Dbusers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Dbusers>> GetUser(int id)
        {
            var user = await _context.Dbusers.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        // PUT: api/Dbusers/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(int id, Dbusers user)
        {
            //if (id != user.IdUser)
            //{
            //    return BadRequest();
            //}

            user.FuckingUserId = id;

            _context.Entry(user).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Dbusers
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Dbusers>> PostUser(Dbusers user)
        {
            _context.Dbusers.Add(user);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUser", new { id = user.FuckingUserId }, user);
        }

        // DELETE: api/Dbusers/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Dbusers>> DeleteUser(int id)
        {
            var user = await _context.Dbusers.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _context.Dbusers.Remove(user);
            await _context.SaveChangesAsync();

            return user;
        }

        private bool UserExists(int id)
        {
            return _context.Dbusers.Any(e => e.FuckingUserId == id);
        }
    }
}
