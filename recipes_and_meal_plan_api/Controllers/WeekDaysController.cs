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
    public class WeekDaysController : ControllerBase
    {
        private readonly WeekDaysContext _context;

        public WeekDaysController(WeekDaysContext context)
        {
            _context = context;
        }

        // GET: api/WeekDays
        [HttpGet]
        public async Task<ActionResult<IEnumerable<WeekDays>>> GetWeekDays()
        {
            return await _context.WeekDays.ToListAsync();
        }

        // GET: api/WeekDays/5
        [HttpGet("{id}")]
        public async Task<ActionResult<WeekDays>> GetWeekDays(int id)
        {
            var weekDays = await _context.WeekDays.FindAsync(id);

            if (weekDays == null)
            {
                return NotFound();
            }

            return weekDays;
        }

        // PUT: api/WeekDays/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWeekDays(int id, WeekDays weekDays)
        {
            if (id != weekDays.Id)
            {
                return BadRequest();
            }

            _context.Entry(weekDays).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WeekDaysExists(id))
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

        // POST: api/WeekDays
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<WeekDays>> PostWeekDays(WeekDays weekDays)
        {
            _context.WeekDays.Add(weekDays);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetWeekDays), new { id = weekDays.Id }, weekDays);
        }

        // DELETE: api/WeekDays/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWeekDays(int id)
        {
            var weekDays = await _context.WeekDays.FindAsync(id);
            if (weekDays == null)
            {
                return NotFound();
            }

            _context.WeekDays.Remove(weekDays);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool WeekDaysExists(int id)
        {
            return _context.WeekDays.Any(e => e.Id == id);
        }
    }
}
