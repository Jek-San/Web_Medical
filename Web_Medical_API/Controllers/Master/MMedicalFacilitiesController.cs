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
    public class MMedicalFacilitiesController : ControllerBase
    {
        private readonly medicalContext _context;

        public MMedicalFacilitiesController(medicalContext context)
        {
            _context = context;
        }

        // GET: api/MMedicalFacilities
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MMedicalFacility>>> GetMMedicalFacilities()
        {
            return await _context.MMedicalFacilities.ToListAsync();
        }

        // GET: api/MMedicalFacilities/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MMedicalFacility>> GetMMedicalFacility(long id)
        {
            var mMedicalFacility = await _context.MMedicalFacilities.FindAsync(id);

            if (mMedicalFacility == null)
            {
                return NotFound();
            }

            return mMedicalFacility;
        }

        // PUT: api/MMedicalFacilities/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMMedicalFacility(long id, MMedicalFacility mMedicalFacility)
        {
            if (id != mMedicalFacility.Id)
            {
                return BadRequest();
            }

            _context.Entry(mMedicalFacility).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MMedicalFacilityExists(id))
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

        // POST: api/MMedicalFacilities
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MMedicalFacility>> PostMMedicalFacility(MMedicalFacility mMedicalFacility)
        {
            _context.MMedicalFacilities.Add(mMedicalFacility);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMMedicalFacility", new { id = mMedicalFacility.Id }, mMedicalFacility);
        }

        // DELETE: api/MMedicalFacilities/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMMedicalFacility(long id)
        {
            var mMedicalFacility = await _context.MMedicalFacilities.FindAsync(id);
            if (mMedicalFacility == null)
            {
                return NotFound();
            }

            _context.MMedicalFacilities.Remove(mMedicalFacility);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MMedicalFacilityExists(long id)
        {
            return _context.MMedicalFacilities.Any(e => e.Id == id);
        }
    }
}
