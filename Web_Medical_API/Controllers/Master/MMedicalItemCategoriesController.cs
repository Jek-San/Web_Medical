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
    public class MMedicalItemCategoriesController : ControllerBase
    {
        private readonly medicalContext _context;

        public MMedicalItemCategoriesController(medicalContext context)
        {
            _context = context;
        }

        // GET: api/MMedicalItemCategories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MMedicalItemCategory>>> GetMMedicalItemCategories()
        {
            return await _context.MMedicalItemCategories.ToListAsync();
        }

        // GET: api/MMedicalItemCategories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MMedicalItemCategory>> GetMMedicalItemCategory(long id)
        {
            var mMedicalItemCategory = await _context.MMedicalItemCategories.FindAsync(id);

            if (mMedicalItemCategory == null)
            {
                return NotFound();
            }

            return mMedicalItemCategory;
        }

        // PUT: api/MMedicalItemCategories/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMMedicalItemCategory(long id, MMedicalItemCategory mMedicalItemCategory)
        {
            if (id != mMedicalItemCategory.Id)
            {
                return BadRequest();
            }

            _context.Entry(mMedicalItemCategory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MMedicalItemCategoryExists(id))
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

        // POST: api/MMedicalItemCategories
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MMedicalItemCategory>> PostMMedicalItemCategory(MMedicalItemCategory mMedicalItemCategory)
        {
            _context.MMedicalItemCategories.Add(mMedicalItemCategory);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMMedicalItemCategory", new { id = mMedicalItemCategory.Id }, mMedicalItemCategory);
        }

        // DELETE: api/MMedicalItemCategories/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMMedicalItemCategory(long id)
        {
            var mMedicalItemCategory = await _context.MMedicalItemCategories.FindAsync(id);
            if (mMedicalItemCategory == null)
            {
                return NotFound();
            }

            _context.MMedicalItemCategories.Remove(mMedicalItemCategory);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MMedicalItemCategoryExists(long id)
        {
            return _context.MMedicalItemCategories.Any(e => e.Id == id);
        }
    }
}
