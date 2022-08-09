using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DbAPI.Data;
using DbAPI.Models;

namespace DbAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UnitsOfUsagesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public UnitsOfUsagesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/UnitsOfUsages
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UnitsOfUsage>>> GetUnitsOfUsage()
        {
          if (_context.UnitsOfUsage == null)
          {
              return NotFound();
          }
            return await _context.UnitsOfUsage.ToListAsync();
        }

        // GET: api/UnitsOfUsages/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UnitsOfUsage>> GetUnitsOfUsage(int id)
        {
          if (_context.UnitsOfUsage == null)
          {
              return NotFound();
          }
            var unitsOfUsage = await _context.UnitsOfUsage.FindAsync(id);

            if (unitsOfUsage == null)
            {
                return NotFound();
            }

            return unitsOfUsage;
        }

        // PUT: api/UnitsOfUsages/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUnitsOfUsage(int id, UnitsOfUsage unitsOfUsage)
        {
            if (id != unitsOfUsage.Id)
            {
                return BadRequest();
            }

            _context.Entry(unitsOfUsage).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UnitsOfUsageExists(id))
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

        // POST: api/UnitsOfUsages
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<UnitsOfUsage>> PostUnitsOfUsage(UnitsOfUsage unitsOfUsage)
        {
          if (_context.UnitsOfUsage == null)
          {
              return Problem("Entity set 'ApplicationDbContext.UnitsOfUsage'  is null.");
          }
            _context.UnitsOfUsage.Add(unitsOfUsage);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUnitsOfUsage", new { id = unitsOfUsage.Id }, unitsOfUsage);
        }

        // DELETE: api/UnitsOfUsages/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUnitsOfUsage(int id)
        {
            if (_context.UnitsOfUsage == null)
            {
                return NotFound();
            }
            var unitsOfUsage = await _context.UnitsOfUsage.FindAsync(id);
            if (unitsOfUsage == null)
            {
                return NotFound();
            }

            _context.UnitsOfUsage.Remove(unitsOfUsage);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UnitsOfUsageExists(int id)
        {
            return (_context.UnitsOfUsage?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
