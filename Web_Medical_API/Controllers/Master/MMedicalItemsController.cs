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
    public class MMedicalItemsController : ControllerBase
    {
        private readonly medicalContext _context;

        public MMedicalItemsController(medicalContext context)
        {
            _context = context;
        }

        // GET: api/MMedicalItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MMedicalItem>>> GetMMedicalItems()
        {
            return await _context.MMedicalItems.ToListAsync();
        }

        // GET: api/MMedicalItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MMedicalItem>> GetMMedicalItem(long id)
        {
            var mMedicalItem = await _context.MMedicalItems.FindAsync(id);

            if (mMedicalItem == null)
            {
                return NotFound();
            }

            return mMedicalItem;
        }

        // PUT: api/MMedicalItems/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMMedicalItem(long id, MMedicalItem mMedicalItem)
        {
            if (id != mMedicalItem.Id)
            {
                return BadRequest();
            }

            _context.Entry(mMedicalItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MMedicalItemExists(id))
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

        // POST: api/MMedicalItems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MMedicalItem>> PostMMedicalItem(MMedicalItem mMedicalItem)
        {
            _context.MMedicalItems.Add(mMedicalItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMMedicalItem", new { id = mMedicalItem.Id }, mMedicalItem);
        }

        // DELETE: api/MMedicalItems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMMedicalItem(long id)
        {
            var mMedicalItem = await _context.MMedicalItems.FindAsync(id);
            if (mMedicalItem == null)
            {
                return NotFound();
            }

            _context.MMedicalItems.Remove(mMedicalItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MMedicalItemExists(long id)
        {
            return _context.MMedicalItems.Any(e => e.Id == id);
        }
    }
}
