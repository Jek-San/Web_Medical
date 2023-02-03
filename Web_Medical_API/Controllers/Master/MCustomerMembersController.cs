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
    public class MCustomerMembersController : ControllerBase
    {
        private readonly medicalContext _context;

        public MCustomerMembersController(medicalContext context)
        {
            _context = context;
        }

        // GET: api/MCustomerMembers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MCustomerMember>>> GetMCustomerMembers()
        {
            return await _context.MCustomerMembers.ToListAsync();
        }

        // GET: api/MCustomerMembers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MCustomerMember>> GetMCustomerMember(long id)
        {
            var mCustomerMember = await _context.MCustomerMembers.FindAsync(id);

            if (mCustomerMember == null)
            {
                return NotFound();
            }

            return mCustomerMember;
        }

        // PUT: api/MCustomerMembers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMCustomerMember(long id, MCustomerMember mCustomerMember)
        {
            if (id != mCustomerMember.Id)
            {
                return BadRequest();
            }

            _context.Entry(mCustomerMember).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MCustomerMemberExists(id))
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

        // POST: api/MCustomerMembers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MCustomerMember>> PostMCustomerMember(MCustomerMember mCustomerMember)
        {
            _context.MCustomerMembers.Add(mCustomerMember);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMCustomerMember", new { id = mCustomerMember.Id }, mCustomerMember);
        }

        // DELETE: api/MCustomerMembers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMCustomerMember(long id)
        {
            var mCustomerMember = await _context.MCustomerMembers.FindAsync(id);
            if (mCustomerMember == null)
            {
                return NotFound();
            }

            _context.MCustomerMembers.Remove(mCustomerMember);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MCustomerMemberExists(long id)
        {
            return _context.MCustomerMembers.Any(e => e.Id == id);
        }
    }
}
