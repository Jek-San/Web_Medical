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
    public class MMedicalFacilitySchedulesController : ControllerBase
    {
        private readonly medicalContext _context;

        public MMedicalFacilitySchedulesController(medicalContext context)
        {
            _context = context;
        }

        // GET: api/MMedicalFacilitySchedules
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MMedicalFacilitySchedule>>> GetMMedicalFacilitySchedules()
        {
            return await _context.MMedicalFacilitySchedules.ToListAsync();
        }

        // GET: api/MMedicalFacilitySchedules/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MMedicalFacilitySchedule>> GetMMedicalFacilitySchedule(long id)
        {
            var mMedicalFacilitySchedule = await _context.MMedicalFacilitySchedules.FindAsync(id);

            if (mMedicalFacilitySchedule == null)
            {
                return NotFound();
            }

            return mMedicalFacilitySchedule;
        }

        // PUT: api/MMedicalFacilitySchedules/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMMedicalFacilitySchedule(long id, MMedicalFacilitySchedule mMedicalFacilitySchedule)
        {
            if (id != mMedicalFacilitySchedule.Id)
            {
                return BadRequest();
            }

            _context.Entry(mMedicalFacilitySchedule).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MMedicalFacilityScheduleExists(id))
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

        // POST: api/MMedicalFacilitySchedules
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MMedicalFacilitySchedule>> PostMMedicalFacilitySchedule(MMedicalFacilitySchedule mMedicalFacilitySchedule)
        {
            _context.MMedicalFacilitySchedules.Add(mMedicalFacilitySchedule);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMMedicalFacilitySchedule", new { id = mMedicalFacilitySchedule.Id }, mMedicalFacilitySchedule);
        }

        // DELETE: api/MMedicalFacilitySchedules/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMMedicalFacilitySchedule(long id)
        {
            var mMedicalFacilitySchedule = await _context.MMedicalFacilitySchedules.FindAsync(id);
            if (mMedicalFacilitySchedule == null)
            {
                return NotFound();
            }

            _context.MMedicalFacilitySchedules.Remove(mMedicalFacilitySchedule);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MMedicalFacilityScheduleExists(long id)
        {
            return _context.MMedicalFacilitySchedules.Any(e => e.Id == id);
        }
    }
}
