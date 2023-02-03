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
    public class MPaymentMethodsController : ControllerBase
    {
        private readonly medicalContext _context;

        public MPaymentMethodsController(medicalContext context)
        {
            _context = context;
        }

        // GET: api/MPaymentMethods
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MPaymentMethod>>> GetMPaymentMethods()
        {
            return await _context.MPaymentMethods.ToListAsync();
        }

        // GET: api/MPaymentMethods/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MPaymentMethod>> GetMPaymentMethod(long id)
        {
            var mPaymentMethod = await _context.MPaymentMethods.FindAsync(id);

            if (mPaymentMethod == null)
            {
                return NotFound();
            }

            return mPaymentMethod;
        }

        // PUT: api/MPaymentMethods/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMPaymentMethod(long id, MPaymentMethod mPaymentMethod)
        {
            if (id != mPaymentMethod.Id)
            {
                return BadRequest();
            }

            _context.Entry(mPaymentMethod).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MPaymentMethodExists(id))
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

        // POST: api/MPaymentMethods
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MPaymentMethod>> PostMPaymentMethod(MPaymentMethod mPaymentMethod)
        {
            _context.MPaymentMethods.Add(mPaymentMethod);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMPaymentMethod", new { id = mPaymentMethod.Id }, mPaymentMethod);
        }

        // DELETE: api/MPaymentMethods/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMPaymentMethod(long id)
        {
            var mPaymentMethod = await _context.MPaymentMethods.FindAsync(id);
            if (mPaymentMethod == null)
            {
                return NotFound();
            }

            _context.MPaymentMethods.Remove(mPaymentMethod);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MPaymentMethodExists(long id)
        {
            return _context.MPaymentMethods.Any(e => e.Id == id);
        }
    }
}
