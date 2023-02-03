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
    public class MCustomerRelationsController : ControllerBase
    {
        private readonly medicalContext _context;

        public MCustomerRelationsController(medicalContext context)
        {
            _context = context;
        }

        // GET: api/MCustomerRelations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MCustomerRelation>>> GetMCustomerRelations()
        {
            return await _context.MCustomerRelations.ToListAsync();
        }

        // GET: api/MCustomerRelations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MCustomerRelation>> GetMCustomerRelation(long id)
        {
            var mCustomerRelation = await _context.MCustomerRelations.FindAsync(id);

            if (mCustomerRelation == null)
            {
                return NotFound();
            }

            return mCustomerRelation;
        }

        // PUT: api/MCustomerRelations/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMCustomerRelation(long id, MCustomerRelation mCustomerRelation)
        {
            if (id != mCustomerRelation.Id)
            {
                return BadRequest();
            }

            _context.Entry(mCustomerRelation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MCustomerRelationExists(id))
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

        // POST: api/MCustomerRelations
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MCustomerRelation>> PostMCustomerRelation(MCustomerRelation mCustomerRelation)
        {
            _context.MCustomerRelations.Add(mCustomerRelation);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMCustomerRelation", new { id = mCustomerRelation.Id }, mCustomerRelation);
        }

        // DELETE: api/MCustomerRelations/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMCustomerRelation(long id)
        {
            var mCustomerRelation = await _context.MCustomerRelations.FindAsync(id);
            if (mCustomerRelation == null)
            {
                return NotFound();
            }

            _context.MCustomerRelations.Remove(mCustomerRelation);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MCustomerRelationExists(long id)
        {
            return _context.MCustomerRelations.Any(e => e.Id == id);
        }
    }
}
