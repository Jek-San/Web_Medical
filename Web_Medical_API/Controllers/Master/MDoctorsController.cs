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
    public class MDoctorsController : ControllerBase
    {
        private readonly medicalContext _context;

        public MDoctorsController(medicalContext context)
        {
            _context = context;
        }

        // GET: api/MDoctors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MDoctor>>> GetMDoctors()
        {
            return await _context.MDoctors.ToListAsync();
        }

        // GET: api/MDoctors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MDoctor>> GetMDoctor(long id)
        {
            var mDoctor = await _context.MDoctors.FindAsync(id);

            if (mDoctor == null)
            {
                return NotFound();
            }

            return mDoctor;
        }

        // PUT: api/MDoctors/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMDoctor(long id, MDoctor mDoctor)
        {
            if (id != mDoctor.Id)
            {
                return BadRequest();
            }

            _context.Entry(mDoctor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MDoctorExists(id))
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

        // POST: api/MDoctors
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MDoctor>> PostMDoctor(MDoctor mDoctor)
        {
            _context.MDoctors.Add(mDoctor);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMDoctor", new { id = mDoctor.Id }, mDoctor);
        }

        // DELETE: api/MDoctors/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMDoctor(long id)
        {
            var mDoctor = await _context.MDoctors.FindAsync(id);
            if (mDoctor == null)
            {
                return NotFound();
            }

            _context.MDoctors.Remove(mDoctor);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MDoctorExists(long id)
        {
            return _context.MDoctors.Any(e => e.Id == id);
        }
    }
}
