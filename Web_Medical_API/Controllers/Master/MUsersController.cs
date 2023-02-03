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
    public class MUsersController : ControllerBase
    {
        private readonly medicalContext _context;

        public MUsersController(medicalContext context)
        {
            _context = context;
        }

        // GET: api/MUsers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MUser>>> GetMUsers()
        {
            return await _context.MUsers.ToListAsync();
        }

        // GET: api/MUsers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MUser>> GetMUser(long id)
        {
            var mUser = await _context.MUsers.FindAsync(id);

            if (mUser == null)
            {
                return NotFound();
            }

            return mUser;
        }

        // PUT: api/MUsers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMUser(long id, MUser mUser)
        {
            if (id != mUser.Id)
            {
                return BadRequest();
            }

            _context.Entry(mUser).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MUserExists(id))
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

        // POST: api/MUsers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MUser>> PostMUser(MUser mUser)
        {
            _context.MUsers.Add(mUser);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMUser", new { id = mUser.Id }, mUser);
        }

        // DELETE: api/MUsers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMUser(long id)
        {
            var mUser = await _context.MUsers.FindAsync(id);
            if (mUser == null)
            {
                return NotFound();
            }

            _context.MUsers.Remove(mUser);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MUserExists(long id)
        {
            return _context.MUsers.Any(e => e.Id == id);
        }
    }
}
