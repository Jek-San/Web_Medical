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
    public class MSpecializationsController : ControllerBase
    {
        private readonly medicalContext _context;

        public MSpecializationsController(medicalContext context)
        {
            _context = context;
        }

        // GET: api/MSpecializations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MSpecialization>>> GetMSpecializations()
        {
            return await _context.MSpecializations.ToListAsync();
        }

        // GET: api/MSpecializations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MSpecialization>> GetMSpecialization(long id)
        {
            var mSpecialization = await _context.MSpecializations.FindAsync(id);

            if (mSpecialization == null)
            {
                return NotFound();
            }

            return mSpecialization;
        }

        // PUT: api/MSpecializations/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMSpecialization(long id, MSpecialization mSpecialization)
        {
            if (id != mSpecialization.Id)
            {
                return BadRequest();
            }

            _context.Entry(mSpecialization).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MSpecializationExists(id))
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

        // POST: api/MSpecializations
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MSpecialization>> PostMSpecialization(MSpecialization mSpecialization)
        {
            _context.MSpecializations.Add(mSpecialization);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMSpecialization", new { id = mSpecialization.Id }, mSpecialization);
        }

        // DELETE: api/MSpecializations/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMSpecialization(long id)
        {
            var mSpecialization = await _context.MSpecializations.FindAsync(id);
            if (mSpecialization == null)
            {
                return NotFound();
            }

            _context.MSpecializations.Remove(mSpecialization);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MSpecializationExists(long id)
        {
            return _context.MSpecializations.Any(e => e.Id == id);
        }
    }
}
