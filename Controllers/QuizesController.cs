using Microsoft.AspNetCore.Mvc;
using ExamWebApplication4.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamWebApplication4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuizesController : ControllerBase
    {
        private readonly ExamContext _context;

        public QuizesController(ExamContext context)
        {
            _context = context;
        }

        // GET: api/Quizes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Quize>>> GetQuizes()
        {
            return await _context.Quizes
                .Include(q => q.CategoryCat)
                .Include(q => q.Questions)
                .Include(q => q.QuizResults)
                .ToListAsync();
        }

        // GET: api/Quizes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Quize>> GetQuize(long id)
        {
            var quize = await _context.Quizes
                .Include(q => q.CategoryCat)
                .Include(q => q.Questions)
                .Include(q => q.QuizResults)
                .FirstOrDefaultAsync(q => q.QuizId == id);

            if (quize == null)
            {
                return NotFound();
            }

            return quize;
        }

        // PUT: api/Quizes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutQuize(long id, Quize quize)
        {
            if (id != quize.QuizId)
            {
                return BadRequest();
            }

            _context.Entry(quize).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!QuizeExists(id))
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

        // POST: api/Quizes
        [HttpPost]
        public async Task<ActionResult<Quize>> PostQuize(Quize quize)
        {
            _context.Quizes.Add(quize);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetQuize), new { id = quize.QuizId }, quize);
        }

        // DELETE: api/Quizes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteQuize(long id)
        {
            var quize = await _context.Quizes.FindAsync(id);
            if (quize == null)
            {
                return NotFound();
            }

            _context.Quizes.Remove(quize);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool QuizeExists(long id)
        {
            return _context.Quizes.Any(e => e.QuizId == id);
        }
    }
}

