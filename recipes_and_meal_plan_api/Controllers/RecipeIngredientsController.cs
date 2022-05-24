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
    public class RecipeIngredientsController : ControllerBase
    {
        private readonly RecipeIngredientsContext _context;

        public RecipeIngredientsController(RecipeIngredientsContext context)
        {
            _context = context;
        }

        // GET: api/RecipeIngredients
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RecipeIngredients>>> GetRecipeIngredints()
        {
            return await _context.RecipeIngredients.ToListAsync();
        }

        // GET: api/RecipeIngredients/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RecipeIngredients>> GetRecipeIngredients(int id)
        {
            var recipeIngredients = await _context.RecipeIngredients.FindAsync(id);

            if (recipeIngredients == null)
            {
                return NotFound();
            }

            return recipeIngredients;
        }

        // PUT: api/RecipeIngredients/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRecipeIngredients(int id, RecipeIngredients recipeIngredients)
        {
            if (id != recipeIngredients.Id)
            {
                return BadRequest();
            }

            _context.Entry(recipeIngredients).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RecipeIngredientsExists(id))
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

        // POST: api/RecipeIngredients
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<RecipeIngredients>> PostRecipeIngredients(RecipeIngredients recipeIngredients)
        {
            _context.RecipeIngredients.Add(recipeIngredients);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetRecipeIngredients), new { id = recipeIngredients.Id }, recipeIngredients);
        }

        // DELETE: api/RecipeIngredients/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRecipeIngredients(int id)
        {
            var recipeIngredients = await _context.RecipeIngredients.FindAsync(id);
            if (recipeIngredients == null)
            {
                return NotFound();
            }

            _context.RecipeIngredients.Remove(recipeIngredients);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RecipeIngredientsExists(int id)
        {
            return _context.RecipeIngredients.Any(e => e.Id == id);
        }
    }
}
