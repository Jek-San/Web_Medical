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
    public class MCourierTypesController : ControllerBase
    {
        private readonly medicalContext _context;

        public MCourierTypesController(medicalContext context)
        {
            _context = context;
        }

        // GET: api/MCourierTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MCourierType>>> GetMCourierTypes()
        {
            return await _context.MCourierTypes.ToListAsync();
        }

        // GET: api/MCourierTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MCourierType>> GetMCourierType(long id)
        {
            var mCourierType = await _context.MCourierTypes.FindAsync(id);

            if (mCourierType == null)
            {
                return NotFound();
            }

            return mCourierType;
        }

        // PUT: api/MCourierTypes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMCourierType(long id, MCourierType mCourierType)
        {
            if (id != mCourierType.Id)
            {
                return BadRequest();
            }

            _context.Entry(mCourierType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MCourierTypeExists(id))
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

        // POST: api/MCourierTypes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MCourierType>> PostMCourierType(MCourierType mCourierType)
        {
            _context.MCourierTypes.Add(mCourierType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMCourierType", new { id = mCourierType.Id }, mCourierType);
        }

        // DELETE: api/MCourierTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMCourierType(long id)
        {
            var mCourierType = await _context.MCourierTypes.FindAsync(id);
            if (mCourierType == null)
            {
                return NotFound();
            }

            _context.MCourierTypes.Remove(mCourierType);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MCourierTypeExists(long id)
        {
            return _context.MCourierTypes.Any(e => e.Id == id);
        }
    }
}
