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
    public class MEducationLevelsController : ControllerBase
    {
        private readonly medicalContext _context;

        public MEducationLevelsController(medicalContext context)
        {
            _context = context;
        }

        // GET: api/MEducationLevels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MEducationLevel>>> GetMEducationLevels()
        {
            return await _context.MEducationLevels.ToListAsync();
        }

        // GET: api/MEducationLevels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MEducationLevel>> GetMEducationLevel(long id)
        {
            var mEducationLevel = await _context.MEducationLevels.FindAsync(id);

            if (mEducationLevel == null)
            {
                return NotFound();
            }

            return mEducationLevel;
        }

        // PUT: api/MEducationLevels/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMEducationLevel(long id, MEducationLevel mEducationLevel)
        {
            if (id != mEducationLevel.Id)
            {
                return BadRequest();
            }

            _context.Entry(mEducationLevel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MEducationLevelExists(id))
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

        // POST: api/MEducationLevels
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MEducationLevel>> PostMEducationLevel(MEducationLevel mEducationLevel)
        {
            _context.MEducationLevels.Add(mEducationLevel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMEducationLevel", new { id = mEducationLevel.Id }, mEducationLevel);
        }

        // DELETE: api/MEducationLevels/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMEducationLevel(long id)
        {
            var mEducationLevel = await _context.MEducationLevels.FindAsync(id);
            if (mEducationLevel == null)
            {
                return NotFound();
            }

            _context.MEducationLevels.Remove(mEducationLevel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MEducationLevelExists(long id)
        {
            return _context.MEducationLevels.Any(e => e.Id == id);
        }
    }
}
