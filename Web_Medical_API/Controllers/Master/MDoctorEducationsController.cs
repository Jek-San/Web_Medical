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
    public class MDoctorEducationsController : ControllerBase
    {
        private readonly medicalContext _context;

        public MDoctorEducationsController(medicalContext context)
        {
            _context = context;
        }

        // GET: api/MDoctorEducations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MDoctorEducation>>> GetMDoctorEducations()
        {
            return await _context.MDoctorEducations.ToListAsync();
        }

        // GET: api/MDoctorEducations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MDoctorEducation>> GetMDoctorEducation(long id)
        {
            var mDoctorEducation = await _context.MDoctorEducations.FindAsync(id);

            if (mDoctorEducation == null)
            {
                return NotFound();
            }

            return mDoctorEducation;
        }

        // PUT: api/MDoctorEducations/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMDoctorEducation(long id, MDoctorEducation mDoctorEducation)
        {
            if (id != mDoctorEducation.Id)
            {
                return BadRequest();
            }

            _context.Entry(mDoctorEducation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MDoctorEducationExists(id))
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

        // POST: api/MDoctorEducations
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MDoctorEducation>> PostMDoctorEducation(MDoctorEducation mDoctorEducation)
        {
            _context.MDoctorEducations.Add(mDoctorEducation);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMDoctorEducation", new { id = mDoctorEducation.Id }, mDoctorEducation);
        }

        // DELETE: api/MDoctorEducations/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMDoctorEducation(long id)
        {
            var mDoctorEducation = await _context.MDoctorEducations.FindAsync(id);
            if (mDoctorEducation == null)
            {
                return NotFound();
            }

            _context.MDoctorEducations.Remove(mDoctorEducation);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MDoctorEducationExists(long id)
        {
            return _context.MDoctorEducations.Any(e => e.Id == id);
        }
    }
}
