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
    public class MBloodGroupsController : ControllerBase
    {
        private readonly medicalContext _context;

        public MBloodGroupsController(medicalContext context)
        {
            _context = context;
        }

        // GET: api/MBloodGroups
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MBloodGroup>>> GetMBloodGroups()
        {
            return await _context.MBloodGroups.ToListAsync();
        }

        // GET: api/MBloodGroups/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MBloodGroup>> GetMBloodGroup(long id)
        {
            var mBloodGroup = await _context.MBloodGroups.FindAsync(id);

            if (mBloodGroup == null)
            {
                return NotFound();
            }

            return mBloodGroup;
        }

        // PUT: api/MBloodGroups/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMBloodGroup(long id, MBloodGroup mBloodGroup)
        {
            if (id != mBloodGroup.Id)
            {
                return BadRequest();
            }

            _context.Entry(mBloodGroup).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MBloodGroupExists(id))
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

        // POST: api/MBloodGroups
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MBloodGroup>> PostMBloodGroup(MBloodGroup mBloodGroup)
        {
            _context.MBloodGroups.Add(mBloodGroup);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMBloodGroup", new { id = mBloodGroup.Id }, mBloodGroup);
        }

        // DELETE: api/MBloodGroups/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMBloodGroup(long id)
        {
            var mBloodGroup = await _context.MBloodGroups.FindAsync(id);
            if (mBloodGroup == null)
            {
                return NotFound();
            }

            _context.MBloodGroups.Remove(mBloodGroup);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MBloodGroupExists(long id)
        {
            return _context.MBloodGroups.Any(e => e.Id == id);
        }
    }
}
