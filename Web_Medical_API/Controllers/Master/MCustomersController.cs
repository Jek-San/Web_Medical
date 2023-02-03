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
    public class MCustomersController : ControllerBase
    {
        private readonly medicalContext _context;

        public MCustomersController(medicalContext context)
        {
            _context = context;
        }

        // GET: api/MCustomers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MCustomer>>> GetMCustomers()
        {
            return await _context.MCustomers.ToListAsync();
        }

        // GET: api/MCustomers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MCustomer>> GetMCustomer(long id)
        {
            var mCustomer = await _context.MCustomers.FindAsync(id);

            if (mCustomer == null)
            {
                return NotFound();
            }

            return mCustomer;
        }

        // PUT: api/MCustomers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMCustomer(long id, MCustomer mCustomer)
        {
            if (id != mCustomer.Id)
            {
                return BadRequest();
            }

            _context.Entry(mCustomer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MCustomerExists(id))
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

        // POST: api/MCustomers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MCustomer>> PostMCustomer(MCustomer mCustomer)
        {
            _context.MCustomers.Add(mCustomer);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMCustomer", new { id = mCustomer.Id }, mCustomer);
        }

        // DELETE: api/MCustomers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMCustomer(long id)
        {
            var mCustomer = await _context.MCustomers.FindAsync(id);
            if (mCustomer == null)
            {
                return NotFound();
            }

            _context.MCustomers.Remove(mCustomer);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MCustomerExists(long id)
        {
            return _context.MCustomers.Any(e => e.Id == id);
        }
    }
}
