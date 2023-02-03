using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web_Medical_API.models;

namespace Web_Medical_API.Controllers.Master
{
    [Route("api/[controller]")]
    [ApiController]
    public class MMenuRolesController : ControllerBase
    {
        private readonly medicalContext _context;

        public MMenuRolesController(medicalContext context)
        {
            _context = context;
        }

        // GET: api/MMenuRoles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MMenuRole>>> GetMMenuRoles()
        {
            return await _context.MMenuRoles.ToListAsync();
        }

        // GET: api/MMenuRoles/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MMenuRole>> GetMMenuRole(long id)
        {
            var mMenuRole = await _context.MMenuRoles.FindAsync(id);

            if (mMenuRole == null)
            {
                return NotFound();
            }

            return mMenuRole;
        }

        // PUT: api/MMenuRoles/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMMenuRole(long id, MMenuRole mMenuRole)
        {
            if (id != mMenuRole.Id)
            {
                return BadRequest();
            }

            _context.Entry(mMenuRole).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MMenuRoleExists(id))
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

        // POST: api/MMenuRoles
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MMenuRole>> PostMMenuRole(MMenuRole mMenuRole)
        {
            _context.MMenuRoles.Add(mMenuRole);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMMenuRole", new { id = mMenuRole.Id }, mMenuRole);
        }

        // DELETE: api/MMenuRoles/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMMenuRole(long id)
        {
            var mMenuRole = await _context.MMenuRoles.FindAsync(id);
            if (mMenuRole == null)
            {
                return NotFound();
            }

            _context.MMenuRoles.Remove(mMenuRole);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MMenuRoleExists(long id)
        {
            return _context.MMenuRoles.Any(e => e.Id == id);
        }
    }
}
