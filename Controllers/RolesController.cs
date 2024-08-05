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
    public class RolesController : ControllerBase
    {
        private readonly ExamContext _context;

        public RolesController(ExamContext context)
        {
            _context = context;
        }

        // GET: api/Roles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Role>>> GetRoles()
        {
            return await _context.Roles.ToListAsync();
        }

        // GET: api/Roles/5
        [HttpGet("{roleName}")]
        public async Task<ActionResult<Role>> GetRole(string roleName)
        {
            var role = await _context.Roles.FindAsync(roleName);

            if (role == null)
            {
                return NotFound();
            }

            return role;
        }

        // PUT: api/Roles/5
        [HttpPut("{roleName}")]
        public async Task<IActionResult> PutRole(string roleName, Role role)
        {
            if (roleName != role.RoleName)
            {
                return BadRequest();
            }

            _context.Entry(role).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RoleExists(roleName))
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

        // POST: api/Roles
        [HttpPost]
        public async Task<ActionResult<Role>> PostRole(Role role)
        {
            _context.Roles.Add(role);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetRole), new { roleName = role.RoleName }, role);
        }

        // DELETE: api/Roles/5
        [HttpDelete("{roleName}")]
        public async Task<IActionResult> DeleteRole(string roleName)
        {
            var role = await _context.Roles.FindAsync(roleName);
            if (role == null)
            {
                return NotFound();
            }

            _context.Roles.Remove(role);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RoleExists(string roleName)
        {
            return _context.Roles.Any(e => e.RoleName == roleName);
        }
    }
}

