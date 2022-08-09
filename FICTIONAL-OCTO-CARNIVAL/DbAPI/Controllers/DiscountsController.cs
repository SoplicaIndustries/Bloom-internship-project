﻿using System;
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
    public class DiscountsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public DiscountsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Discounts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Discounts>>> GetDiscounts()
        {
          if (_context.Discounts == null)
          {
              return NotFound();
          }
            return await _context.Discounts.ToListAsync();
        }

        // GET: api/Discounts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Discounts>> GetDiscounts(int id)
        {
          if (_context.Discounts == null)
          {
              return NotFound();
          }
            var discounts = await _context.Discounts.FindAsync(id);

            if (discounts == null)
            {
                return NotFound();
            }

            return discounts;
        }

        // PUT: api/Discounts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDiscounts(int id, Discounts discounts)
        {
            if (id != discounts.Id)
            {
                return BadRequest();
            }

            _context.Entry(discounts).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DiscountsExists(id))
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

        // POST: api/Discounts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Discounts>> PostDiscounts(Discounts discounts)
        {
          if (_context.Discounts == null)
          {
              return Problem("Entity set 'ApplicationDbContext.Discounts'  is null.");
          }
            _context.Discounts.Add(discounts);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDiscounts", new { id = discounts.Id }, discounts);
        }

        // DELETE: api/Discounts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDiscounts(int id)
        {
            if (_context.Discounts == null)
            {
                return NotFound();
            }
            var discounts = await _context.Discounts.FindAsync(id);
            if (discounts == null)
            {
                return NotFound();
            }

            _context.Discounts.Remove(discounts);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DiscountsExists(int id)
        {
            return (_context.Discounts?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
