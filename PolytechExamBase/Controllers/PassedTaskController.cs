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
    public class PassedTasksController : ControllerBase
    {

        private readonly PolytechExamBaseNewContext _context;

        public PassedTasksController(PolytechExamBaseNewContext context)
        {
            _context = context;
        }

        // GET: api/PassedTasks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PassedTasks>>> GetPassedTasks()
        {
            return await _context.PassedTasks.ToListAsync();
        }

        // GET: api/PassedTasks/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PassedTasks>> GetPassedTasks(int id)
        {
            var passed_task = await _context.PassedTasks.FindAsync(id);

            if (passed_task == null)
            {
                return NotFound();
            }

            return passed_task;
        }

        // PUT: api/PassedTasks/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPassedTasks(int id, PassedTasks passed_task)
        {
            //if (id != passed_task.PassedTasksId)
            //{
            //    return BadRequest();
            //}

            passed_task.PassedTaskId = id;

            _context.Entry(passed_task).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PassedTasksExists(id))
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

        // POST: api/PassedTasks
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<PassedTasks>> PostPassedTasks(PassedTasks passed_task)
        {
            _context.PassedTasks.Add(passed_task);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPassedTasks", new { id = passed_task.PassedTaskId }, passed_task);
        }

        // DELETE: api/PassedTasks/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PassedTasks>> DeletePassedTasks(int id)
        {
            var passed_task = await _context.PassedTasks.FindAsync(id);
            if (passed_task == null)
            {
                return NotFound();
            }

            _context.PassedTasks.Remove(passed_task);
            await _context.SaveChangesAsync();

            return passed_task;
        }

        private bool PassedTasksExists(int id)
        {
            return _context.PassedTasks.Any(e => e.PassedTaskId == id);
        }
    }
}
