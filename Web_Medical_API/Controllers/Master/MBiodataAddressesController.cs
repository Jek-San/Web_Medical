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
    public class MBiodataAddressesController : ControllerBase
    {
        private readonly medicalContext _context;

        public MBiodataAddressesController(medicalContext context)
        {
            _context = context;
        }

        // GET: api/MBiodataAddresses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MBiodataAddress>>> GetMBiodataAddresses()
        {
            return await _context.MBiodataAddresses.ToListAsync();
        }

        // GET: api/MBiodataAddresses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MBiodataAddress>> GetMBiodataAddress(long id)
        {
            var mBiodataAddress = await _context.MBiodataAddresses.FindAsync(id);

            if (mBiodataAddress == null)
            {
                return NotFound();
            }

            return mBiodataAddress;
        }

        // PUT: api/MBiodataAddresses/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMBiodataAddress(long id, MBiodataAddress mBiodataAddress)
        {
            if (id != mBiodataAddress.Id)
            {
                return BadRequest();
            }

            _context.Entry(mBiodataAddress).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MBiodataAddressExists(id))
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

        // POST: api/MBiodataAddresses
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MBiodataAddress>> PostMBiodataAddress(MBiodataAddress mBiodataAddress)
        {
            _context.MBiodataAddresses.Add(mBiodataAddress);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMBiodataAddress", new { id = mBiodataAddress.Id }, mBiodataAddress);
        }

        // DELETE: api/MBiodataAddresses/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMBiodataAddress(long id)
        {
            var mBiodataAddress = await _context.MBiodataAddresses.FindAsync(id);
            if (mBiodataAddress == null)
            {
                return NotFound();
            }

            _context.MBiodataAddresses.Remove(mBiodataAddress);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MBiodataAddressExists(long id)
        {
            return _context.MBiodataAddresses.Any(e => e.Id == id);
        }
    }
}
