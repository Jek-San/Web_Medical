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
    public class MBiodatumsController : ControllerBase
    {
        private readonly medicalContext _context;

        public MBiodatumsController(medicalContext context)
        {
            _context = context;
        }

        // GET: api/MBiodatums
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MBiodatum>>> GetMBiodata()
        {
            return await _context.MBiodata.ToListAsync();
        }

        // GET: api/MBiodatums/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MBiodatum>> GetMBiodatum(long id)
        {
            var mBiodatum = await _context.MBiodata.FindAsync(id);

            if (mBiodatum == null)
            {
                return NotFound();
            }

            return mBiodatum;
        }

        // PUT: api/MBiodatums/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMBiodatum(long id, MBiodatum mBiodatum)
        {
            if (id != mBiodatum.Id)
            {
                return BadRequest();
            }

            _context.Entry(mBiodatum).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MBiodatumExists(id))
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

        // POST: api/MBiodatums
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MBiodatum>> PostMBiodatum(MBiodatum mBiodatum)
        {
            _context.MBiodata.Add(mBiodatum);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMBiodatum", new { id = mBiodatum.Id }, mBiodatum);
        }

        // DELETE: api/MBiodatums/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMBiodatum(long id)
        {
            var mBiodatum = await _context.MBiodata.FindAsync(id);
            if (mBiodatum == null)
            {
                return NotFound();
            }

            _context.MBiodata.Remove(mBiodatum);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MBiodatumExists(long id)
        {
            return _context.MBiodata.Any(e => e.Id == id);
        }
    }
}
