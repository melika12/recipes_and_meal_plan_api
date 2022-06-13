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
    public class IngredientsController : ControllerBase
    {
        private readonly IngredientsContext _context;

        public IngredientsController(IngredientsContext context)
        {
            _context = context;
        }

        // GET: api/Ingredients
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Ingredients>>> GetIngredients()
        {
            return await _context.Ingredients.Where(n => n.Request == 0).ToListAsync();
        }

        // GET: api/Ingredients/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Ingredients>> GetIngredients(int id)
        {
            var ingredients = await _context.Ingredients.FindAsync(id);

            if (ingredients == null)
            {
                return NotFound();
            }

            return ingredients;
        }

        // GET: api/Ingredients/Requests
        [HttpGet("requests")]
        public async Task<ActionResult<List<Ingredients>>> GetIngredientsByRequest()
        {
            var ingredients = await _context.Ingredients.Where(n => n.Request == 1).ToListAsync();

            if (ingredients.Count > 0)
            {
                return ingredients;
            }
            else
            {
                return null;
            }
        }

        // GET: api/Ingredients/name?ingredientname=ingredientname
        [HttpGet("name")]
        public async Task<ActionResult<List<Ingredients>>> GetIngredientByName(string ingredientname)
        {
            var ingredient = await _context.Ingredients.Where(n => n.Name.Contains(ingredientname)).ToListAsync();

            if (ingredient.Count > 0)
            {
                return ingredient;
            }
            else
            {
                return null;
            }
        }

        // PUT: api/Ingredients/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutIngredients(int id, Ingredients ingredients)
        {
            if (id != ingredients.Id)
            {
                return BadRequest();
            }

            _context.Entry(ingredients).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IngredientsExists(id))
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

        // POST: api/Ingredients
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Ingredients>> PostIngredients(Ingredients ingredients)
        {
            _context.Ingredients.Add(ingredients);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetIngredients), new { id = ingredients.Id }, ingredients);
        }

        // PATCH: api/Ingredients/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPatch("{id}")]
        public async Task<ActionResult<Ingredients>> PatchIngredients(int id)
        {
            var ingredient = await _context.Ingredients.Where(n => n.Id == id).FirstOrDefaultAsync();

            ingredient.Request = 0;

            _context.Entry(ingredient).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IngredientsExists(id))
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

        // DELETE: api/Ingredients/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteIngredients(int id)
        {
            var ingredients = await _context.Ingredients.FindAsync(id);
            if (ingredients == null)
            {
                return NotFound();
            }

            _context.Ingredients.Remove(ingredients);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool IngredientsExists(int id)
        {
            return _context.Ingredients.Any(e => e.Id == id);
        }
    }
}
