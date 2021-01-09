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
    public class MarksController : ControllerBase
    {

        private readonly PolytechExamBaseNewContext _context;

        public MarksController(PolytechExamBaseNewContext context)
        {
            _context = context;
        }

        // GET: api/Marks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Marks>>> GetMarks()
        {
            return await _context.Marks.ToListAsync();
        }

        // GET: api/Marks/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Marks>> GetMarks(long id)
        {
            var mark = await _context.Marks.FindAsync(id);

            if (mark == null)
            {
                return NotFound();
            }

            return mark;
        }

        // PUT: api/Marks/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMarks(long id, Marks mark)
        {
            //if (id != mark.MarksId)
            //{
            //    return BadRequest();
            //}

            mark.MarkId = id;

            _context.Entry(mark).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MarksExists(id))
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

        // POST: api/Marks
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Marks>> PostMarks(Marks mark)
        {
            _context.Marks.Add(mark);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMarks", new { id = mark.MarkId }, mark);
        }

        // DELETE: api/Marks/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Marks>> DeleteMarks(long id)
        {
            var mark = await _context.Marks.FindAsync(id);
            if (mark == null)
            {
                return NotFound();
            }

            _context.Marks.Remove(mark);
            await _context.SaveChangesAsync();

            return mark;
        }

        private bool MarksExists(long id)
        {
            return _context.Marks.Any(e => e.MarkId == id);
        }
    }
}
