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
    public class MRolesController : ControllerBase
    {
        private readonly medicalContext _context;

        public MRolesController(medicalContext context)
        {
            _context = context;
        }

        // GET: api/MRoles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MRole>>> GetMRoles()
        {
            return await _context.MRoles.ToListAsync();
        }

        // GET: api/MRoles/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MRole>> GetMRole(long id)
        {
            var mRole = await _context.MRoles.FindAsync(id);

            if (mRole == null)
            {
                return NotFound();
            }

            return mRole;
        }

        // PUT: api/MRoles/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMRole(long id, MRole mRole)
        {
            if (id != mRole.Id)
            {
                return BadRequest();
            }

            _context.Entry(mRole).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MRoleExists(id))
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

        // POST: api/MRoles
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MRole>> PostMRole(MRole mRole)
        {
            _context.MRoles.Add(mRole);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMRole", new { id = mRole.Id }, mRole);
        }

        // DELETE: api/MRoles/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMRole(long id)
        {
            var mRole = await _context.MRoles.FindAsync(id);
            if (mRole == null)
            {
                return NotFound();
            }

            _context.MRoles.Remove(mRole);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MRoleExists(long id)
        {
            return _context.MRoles.Any(e => e.Id == id);
        }
    }
}
