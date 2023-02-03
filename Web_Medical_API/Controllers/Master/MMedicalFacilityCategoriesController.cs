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
    public class MMedicalFacilityCategoriesController : ControllerBase
    {
        private readonly medicalContext _context;

        public MMedicalFacilityCategoriesController(medicalContext context)
        {
            _context = context;
        }

        // GET: api/MMedicalFacilityCategories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MMedicalFacilityCategory>>> GetMMedicalFacilityCategories()
        {
            return await _context.MMedicalFacilityCategories.ToListAsync();
        }

        // GET: api/MMedicalFacilityCategories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MMedicalFacilityCategory>> GetMMedicalFacilityCategory(long id)
        {
            var mMedicalFacilityCategory = await _context.MMedicalFacilityCategories.FindAsync(id);

            if (mMedicalFacilityCategory == null)
            {
                return NotFound();
            }

            return mMedicalFacilityCategory;
        }

        // PUT: api/MMedicalFacilityCategories/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMMedicalFacilityCategory(long id, MMedicalFacilityCategory mMedicalFacilityCategory)
        {
            if (id != mMedicalFacilityCategory.Id)
            {
                return BadRequest();
            }

            _context.Entry(mMedicalFacilityCategory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MMedicalFacilityCategoryExists(id))
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

        // POST: api/MMedicalFacilityCategories
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MMedicalFacilityCategory>> PostMMedicalFacilityCategory(MMedicalFacilityCategory mMedicalFacilityCategory)
        {
            _context.MMedicalFacilityCategories.Add(mMedicalFacilityCategory);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMMedicalFacilityCategory", new { id = mMedicalFacilityCategory.Id }, mMedicalFacilityCategory);
        }

        // DELETE: api/MMedicalFacilityCategories/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMMedicalFacilityCategory(long id)
        {
            var mMedicalFacilityCategory = await _context.MMedicalFacilityCategories.FindAsync(id);
            if (mMedicalFacilityCategory == null)
            {
                return NotFound();
            }

            _context.MMedicalFacilityCategories.Remove(mMedicalFacilityCategory);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MMedicalFacilityCategoryExists(long id)
        {
            return _context.MMedicalFacilityCategories.Any(e => e.Id == id);
        }
    }
}
