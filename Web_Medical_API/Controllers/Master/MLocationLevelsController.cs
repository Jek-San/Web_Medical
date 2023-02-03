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
    public class MLocationLevelsController : ControllerBase
    {
        private readonly medicalContext _context;

        public MLocationLevelsController(medicalContext context)
        {
            _context = context;
        }

        // GET: api/MLocationLevels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MLocationLevel>>> GetMLocationLevels()
        {
            return await _context.MLocationLevels.ToListAsync();
        }

        // GET: api/MLocationLevels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MLocationLevel>> GetMLocationLevel(long id)
        {
            var mLocationLevel = await _context.MLocationLevels.FindAsync(id);

            if (mLocationLevel == null)
            {
                return NotFound();
            }

            return mLocationLevel;
        }

        // PUT: api/MLocationLevels/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMLocationLevel(long id, MLocationLevel mLocationLevel)
        {
            if (id != mLocationLevel.Id)
            {
                return BadRequest();
            }

            _context.Entry(mLocationLevel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MLocationLevelExists(id))
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

        // POST: api/MLocationLevels
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MLocationLevel>> PostMLocationLevel(MLocationLevel mLocationLevel)
        {
            _context.MLocationLevels.Add(mLocationLevel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMLocationLevel", new { id = mLocationLevel.Id }, mLocationLevel);
        }

        // DELETE: api/MLocationLevels/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMLocationLevel(long id)
        {
            var mLocationLevel = await _context.MLocationLevels.FindAsync(id);
            if (mLocationLevel == null)
            {
                return NotFound();
            }

            _context.MLocationLevels.Remove(mLocationLevel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MLocationLevelExists(long id)
        {
            return _context.MLocationLevels.Any(e => e.Id == id);
        }
    }
}
