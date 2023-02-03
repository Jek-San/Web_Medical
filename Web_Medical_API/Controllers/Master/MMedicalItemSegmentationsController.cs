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
    public class MMedicalItemSegmentationsController : ControllerBase
    {
        private readonly medicalContext _context;

        public MMedicalItemSegmentationsController(medicalContext context)
        {
            _context = context;
        }

        // GET: api/MMedicalItemSegmentations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MMedicalItemSegmentation>>> GetMMedicalItemSegmentations()
        {
            return await _context.MMedicalItemSegmentations.ToListAsync();
        }

        // GET: api/MMedicalItemSegmentations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MMedicalItemSegmentation>> GetMMedicalItemSegmentation(long id)
        {
            var mMedicalItemSegmentation = await _context.MMedicalItemSegmentations.FindAsync(id);

            if (mMedicalItemSegmentation == null)
            {
                return NotFound();
            }

            return mMedicalItemSegmentation;
        }

        // PUT: api/MMedicalItemSegmentations/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMMedicalItemSegmentation(long id, MMedicalItemSegmentation mMedicalItemSegmentation)
        {
            if (id != mMedicalItemSegmentation.Id)
            {
                return BadRequest();
            }

            _context.Entry(mMedicalItemSegmentation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MMedicalItemSegmentationExists(id))
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

        // POST: api/MMedicalItemSegmentations
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MMedicalItemSegmentation>> PostMMedicalItemSegmentation(MMedicalItemSegmentation mMedicalItemSegmentation)
        {
            _context.MMedicalItemSegmentations.Add(mMedicalItemSegmentation);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMMedicalItemSegmentation", new { id = mMedicalItemSegmentation.Id }, mMedicalItemSegmentation);
        }

        // DELETE: api/MMedicalItemSegmentations/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMMedicalItemSegmentation(long id)
        {
            var mMedicalItemSegmentation = await _context.MMedicalItemSegmentations.FindAsync(id);
            if (mMedicalItemSegmentation == null)
            {
                return NotFound();
            }

            _context.MMedicalItemSegmentations.Remove(mMedicalItemSegmentation);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MMedicalItemSegmentationExists(long id)
        {
            return _context.MMedicalItemSegmentations.Any(e => e.Id == id);
        }
    }
}
