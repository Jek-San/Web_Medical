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
    public class MBanksController : ControllerBase
    {
        private readonly medicalContext _context;

        public MBanksController(medicalContext context)
        {
            _context = context;
        }

        // GET: api/MBanks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MBank>>> GetMBanks()
        {
            return await _context.MBanks.ToListAsync();
        }

        // GET: api/MBanks/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MBank>> GetMBank(long id)
        {
            var mBank = await _context.MBanks.FindAsync(id);

            if (mBank == null)
            {
                return NotFound();
            }

            return mBank;
        }

        // PUT: api/MBanks/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMBank(long id, MBank mBank)
        {
            if (id != mBank.Id)
            {
                return BadRequest();
            }

            _context.Entry(mBank).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MBankExists(id))
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

        // POST: api/MBanks
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MBank>> PostMBank(MBank mBank)
        {
            _context.MBanks.Add(mBank);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMBank", new { id = mBank.Id }, mBank);
        }

        // DELETE: api/MBanks/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMBank(long id)
        {
            var mBank = await _context.MBanks.FindAsync(id);
            if (mBank == null)
            {
                return NotFound();
            }

            _context.MBanks.Remove(mBank);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MBankExists(long id)
        {
            return _context.MBanks.Any(e => e.Id == id);
        }
    }
}
