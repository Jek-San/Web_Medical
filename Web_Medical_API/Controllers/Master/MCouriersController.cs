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
    public class MCouriersController : ControllerBase
    {
        private readonly medicalContext _context;

        public MCouriersController(medicalContext context)
        {
            _context = context;
        }

        // GET: api/MCouriers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MCourier>>> GetMCouriers()
        {
            return await _context.MCouriers.ToListAsync();
        }

        // GET: api/MCouriers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MCourier>> GetMCourier(long id)
        {
            var mCourier = await _context.MCouriers.FindAsync(id);

            if (mCourier == null)
            {
                return NotFound();
            }

            return mCourier;
        }

        // PUT: api/MCouriers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMCourier(long id, MCourier mCourier)
        {
            if (id != mCourier.Id)
            {
                return BadRequest();
            }

            _context.Entry(mCourier).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MCourierExists(id))
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

        // POST: api/MCouriers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MCourier>> PostMCourier(MCourier mCourier)
        {
            _context.MCouriers.Add(mCourier);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMCourier", new { id = mCourier.Id }, mCourier);
        }

        // DELETE: api/MCouriers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMCourier(long id)
        {
            var mCourier = await _context.MCouriers.FindAsync(id);
            if (mCourier == null)
            {
                return NotFound();
            }

            _context.MCouriers.Remove(mCourier);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MCourierExists(long id)
        {
            return _context.MCouriers.Any(e => e.Id == id);
        }
    }
}
