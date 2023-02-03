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
    public class MBiodataAttachmentsController : ControllerBase
    {
        private readonly medicalContext _context;

        public MBiodataAttachmentsController(medicalContext context)
        {
            _context = context;
        }

        // GET: api/MBiodataAttachments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MBiodataAttachment>>> GetMBiodataAttachments()
        {
            return await _context.MBiodataAttachments.ToListAsync();
        }

        // GET: api/MBiodataAttachments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MBiodataAttachment>> GetMBiodataAttachment(long id)
        {
            var mBiodataAttachment = await _context.MBiodataAttachments.FindAsync(id);

            if (mBiodataAttachment == null)
            {
                return NotFound();
            }

            return mBiodataAttachment;
        }

        // PUT: api/MBiodataAttachments/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMBiodataAttachment(long id, MBiodataAttachment mBiodataAttachment)
        {
            if (id != mBiodataAttachment.Id)
            {
                return BadRequest();
            }

            _context.Entry(mBiodataAttachment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MBiodataAttachmentExists(id))
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

        // POST: api/MBiodataAttachments
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MBiodataAttachment>> PostMBiodataAttachment(MBiodataAttachment mBiodataAttachment)
        {
            _context.MBiodataAttachments.Add(mBiodataAttachment);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMBiodataAttachment", new { id = mBiodataAttachment.Id }, mBiodataAttachment);
        }

        // DELETE: api/MBiodataAttachments/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMBiodataAttachment(long id)
        {
            var mBiodataAttachment = await _context.MBiodataAttachments.FindAsync(id);
            if (mBiodataAttachment == null)
            {
                return NotFound();
            }

            _context.MBiodataAttachments.Remove(mBiodataAttachment);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MBiodataAttachmentExists(long id)
        {
            return _context.MBiodataAttachments.Any(e => e.Id == id);
        }
    }
}
