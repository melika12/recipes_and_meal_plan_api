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
    public class RequestRecipeIngredientsController : ControllerBase
    {
        private readonly RequestRecipeIngredientContext _context;

        public RequestRecipeIngredientsController(RequestRecipeIngredientContext context)
        {
            _context = context;
        }

        // GET: api/RequestRecipeIngredients
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RequestRecipeIngredient>>> GetRequestRecipeIngredients()
        {
            return await _context.RequestRecipeIngredients.ToListAsync();
        }

        // GET: api/RequestRecipeIngredients/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RequestRecipeIngredient>> GetRequestRecipeIngredient(int id)
        {
            var requestRecipeIngredient = await _context.RequestRecipeIngredients.FindAsync(id);

            if (requestRecipeIngredient == null)
            {
                return NotFound();
            }

            return requestRecipeIngredient;
        }

        // PUT: api/RequestRecipeIngredients/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRequestRecipeIngredient(int id, RequestRecipeIngredient requestRecipeIngredient)
        {
            if (id != requestRecipeIngredient.Id)
            {
                return BadRequest();
            }

            _context.Entry(requestRecipeIngredient).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RequestRecipeIngredientExists(id))
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

        // POST: api/RequestRecipeIngredients
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<RequestRecipeIngredient>> PostRequestRecipeIngredient(RequestRecipeIngredient requestRecipeIngredient)
        {
            _context.RequestRecipeIngredients.Add(requestRecipeIngredient);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRequestRecipeIngredient", new { id = requestRecipeIngredient.Id }, requestRecipeIngredient);
        }

        // DELETE: api/RequestRecipeIngredients/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRequestRecipeIngredient(int id)
        {
            var requestRecipeIngredient = await _context.RequestRecipeIngredients.FindAsync(id);
            if (requestRecipeIngredient == null)
            {
                return NotFound();
            }

            _context.RequestRecipeIngredients.Remove(requestRecipeIngredient);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RequestRecipeIngredientExists(int id)
        {
            return _context.RequestRecipeIngredients.Any(e => e.Id == id);
        }
    }
}
