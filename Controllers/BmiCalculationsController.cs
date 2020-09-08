using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BmiBeregner.Data;
using BmiBeregner.Models;

namespace BmiBeregner.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class BmiCalculationsController : ControllerBase
    {
        private readonly BmiBeregnerContext _context;

        public BmiCalculationsController(BmiBeregnerContext context)
        {
            _context = context;
        }

        // GET: api/BmiCalculations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BmiCalculation>>> GetBmiCalculation()
        {
            return await _context.BmiCalculation.ToListAsync();
        }

        // GET: api/BmiCalculations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BmiCalculation>> GetBmiCalculation(int id)
        {
            var bmiCalculation = await _context.BmiCalculation.FindAsync(id);

            if (bmiCalculation == null)
            {
                return NotFound();
            }

            return bmiCalculation;
        }

        // PUT: api/BmiCalculations/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBmiCalculation(int id, BmiCalculation bmiCalculation)
        {
            if (id != bmiCalculation.ID)
            {
                return BadRequest();
            }

            _context.Entry(bmiCalculation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BmiCalculationExists(id))
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

        // POST: api/BmiCalculations
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<BmiCalculation>> PostBmiCalculation(BmiCalculation bmiCalculation)
        {
            _context.BmiCalculation.Add(bmiCalculation);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBmiCalculation", new { id = bmiCalculation.ID }, bmiCalculation);
        }

        // DELETE: api/BmiCalculations/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<BmiCalculation>> DeleteBmiCalculation(int id)
        {
            var bmiCalculation = await _context.BmiCalculation.FindAsync(id);
            if (bmiCalculation == null)
            {
                return NotFound();
            }

            _context.BmiCalculation.Remove(bmiCalculation);
            await _context.SaveChangesAsync();

            return bmiCalculation;
        }

        private bool BmiCalculationExists(int id)
        {
            return _context.BmiCalculation.Any(e => e.ID == id);
        }
    }
}
