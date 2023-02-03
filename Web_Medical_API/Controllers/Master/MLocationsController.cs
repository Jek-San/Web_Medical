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
    public class MLocationsController : ControllerBase
    {
        private readonly medicalContext _context;

        public MLocationsController(medicalContext context)
        {
            _context = context;
        }

        // GET: api/MLocations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MLocation>>> GetMLocations()
        {
            return await _context.MLocations.ToListAsync();
        }

        // GET: api/MLocations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MLocation>> GetMLocation(long id)
        {
            var mLocation = await _context.MLocations.FindAsync(id);

            if (mLocation == null)
            {
                return NotFound();
            }

            return mLocation;
        }

        // PUT: api/MLocations/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMLocation(long id, MLocation mLocation)
        {
            if (id != mLocation.Id)
            {
                return BadRequest();
            }

            _context.Entry(mLocation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MLocationExists(id))
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

        // POST: api/MLocations
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MLocation>> PostMLocation(MLocation mLocation)
        {
            _context.MLocations.Add(mLocation);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMLocation", new { id = mLocation.Id }, mLocation);
        }

        // DELETE: api/MLocations/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMLocation(long id)
        {
            var mLocation = await _context.MLocations.FindAsync(id);
            if (mLocation == null)
            {
                return NotFound();
            }

            _context.MLocations.Remove(mLocation);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MLocationExists(long id)
        {
            return _context.MLocations.Any(e => e.Id == id);
        }
    }
}
