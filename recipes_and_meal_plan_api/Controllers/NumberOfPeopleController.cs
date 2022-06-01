using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using recipes_and_meal_plan_api.Models;

namespace recipes_and_meal_plan_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NumberOfPeopleController : ControllerBase
    {
        private readonly NumberOfPeopleContext _context;

        public NumberOfPeopleController(NumberOfPeopleContext context)
        {
            _context = context;
        }

        // GET: api/NumberOfPeople
        [HttpGet]
        public async Task<ActionResult<IEnumerable<NumberOfPeople>>> GetNumberOfPeople()
        {
            return await _context.NumberOfPeople.ToListAsync();
        }

        // GET: api/NumberOfPeople/5
        [HttpGet("{id}")]
        public async Task<ActionResult<NumberOfPeople>> GetNumberOfPeople(int id)
        {
            var numberOfPeople = await _context.NumberOfPeople.FindAsync(id);

            if (numberOfPeople == null)
            {
                return NotFound();
            }

            return numberOfPeople;
        }

        // PUT: api/NumberOfPeople/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNumberOfPeople(int id, NumberOfPeople numberOfPeople)
        {
            if (id != numberOfPeople.Id)
            {
                return BadRequest();
            }

            _context.Entry(numberOfPeople).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NumberOfPeopleExists(id))
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

        // POST: api/NumberOfPeople
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<NumberOfPeople>> PostNumberOfPeople(NumberOfPeople numberOfPeople)
        {
            _context.NumberOfPeople.Add(numberOfPeople);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetNumberOfPeople", new { id = numberOfPeople.Id }, numberOfPeople);
        }

        // DELETE: api/NumberOfPeople/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNumberOfPeople(int id)
        {
            var numberOfPeople = await _context.NumberOfPeople.FindAsync(id);
            if (numberOfPeople == null)
            {
                return NotFound();
            }

            _context.NumberOfPeople.Remove(numberOfPeople);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool NumberOfPeopleExists(int id)
        {
            return _context.NumberOfPeople.Any(e => e.Id == id);
        }
    }
}
