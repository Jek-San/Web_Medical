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
    public class MMenusController : ControllerBase
    {
        private readonly medicalContext _context;

        public MMenusController(medicalContext context)
        {
            _context = context;
        }

        // GET: api/MMenus
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MMenu>>> GetMMenus()
        {
            return await _context.MMenus.ToListAsync();
        }

        // GET: api/MMenus/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MMenu>> GetMMenu(long id)
        {
            var mMenu = await _context.MMenus.FindAsync(id);

            if (mMenu == null)
            {
                return NotFound();
            }

            return mMenu;
        }

        // PUT: api/MMenus/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMMenu(long id, MMenu mMenu)
        {
            if (id != mMenu.Id)
            {
                return BadRequest();
            }

            _context.Entry(mMenu).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MMenuExists(id))
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

        // POST: api/MMenus
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MMenu>> PostMMenu(MMenu mMenu)
        {
            _context.MMenus.Add(mMenu);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMMenu", new { id = mMenu.Id }, mMenu);
        }

        // DELETE: api/MMenus/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMMenu(long id)
        {
            var mMenu = await _context.MMenus.FindAsync(id);
            if (mMenu == null)
            {
                return NotFound();
            }

            _context.MMenus.Remove(mMenu);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MMenuExists(long id)
        {
            return _context.MMenus.Any(e => e.Id == id);
        }
    }
}
