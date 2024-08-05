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
    public class QuizResultsController : ControllerBase
    {
        private readonly ExamContext _context;

        public QuizResultsController(ExamContext context)
        {
            _context = context;
        }

        // GET: api/QuizResults
        [HttpGet]
        public async Task<ActionResult<IEnumerable<QuizResult>>> GetQuizResults()
        {
            return await _context.QuizResults
                .Include(qr => qr.User)
                .Include(qr => qr.QuizQuiz)
                .ToListAsync();
        }

        // GET: api/QuizResults/5
        [HttpGet("{id}")]
        public async Task<ActionResult<QuizResult>> GetQuizResult(long id)
        {
            var quizResult = await _context.QuizResults
                .Include(qr => qr.User)
                .Include(qr => qr.QuizQuiz)
                .FirstOrDefaultAsync(qr => qr.QuizResId == id);

            if (quizResult == null)
            {
                return NotFound();
            }

            return quizResult;
        }

        // PUT: api/QuizResults/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutQuizResult(long id, QuizResult quizResult)
        {
            if (id != quizResult.QuizResId)
            {
                return BadRequest();
            }

            _context.Entry(quizResult).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!QuizResultExists(id))
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

        // POST: api/QuizResults
        [HttpPost]
        public async Task<ActionResult<QuizResult>> PostQuizResult(QuizResult quizResult)
        {
            _context.QuizResults.Add(quizResult);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetQuizResult), new { id = quizResult.QuizResId }, quizResult);
        }

        // DELETE: api/QuizResults/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteQuizResult(long id)
        {
            var quizResult = await _context.QuizResults.FindAsync(id);
            if (quizResult == null)
            {
                return NotFound();
            }

            _context.QuizResults.Remove(quizResult);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool QuizResultExists(long id)
        {
            return _context.QuizResults.Any(e => e.QuizResId == id);
        }
    }
}

