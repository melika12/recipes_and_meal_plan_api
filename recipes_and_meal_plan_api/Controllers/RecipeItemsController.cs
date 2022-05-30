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
    public class RecipeItemsController : ControllerBase
    {
        private readonly RecipeContext _context;

        public RecipeItemsController(RecipeContext context)
        {
            _context = context;
        }

        // GET: api/RecipeItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Recipe>>> GetTodoItems()
        {
            return await _context.Recipes.ToListAsync();
        }

        // GET: api/RecipeItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Recipe>> GetRecipeItem(long id)
        {
            var recipeItem = await _context.Recipes.FindAsync(id);

            if (recipeItem == null)
            {
                return NotFound();
            }

            return recipeItem;
        }

        // GET: api/RecipeItems/meal?name=name
        [HttpGet("meal")]
        public async Task<ActionResult<Recipe>> GetRecipeByName(string name) {
            var recipeName = await _context.Recipes.Where(n => n.Name == name).ToListAsync();

            if (recipeName.Count > 0) {
                return recipeName[0];
            } else {
                return null;
            }
        }

        // PUT: api/RecipeItems/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRecipeItem(long id, Recipe recipeItem)
        {
            if (id != recipeItem.Id)
            {
                return BadRequest();
            }

            _context.Entry(recipeItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RecipeItemExists(id))
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

        // POST: api/RecipeItems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Recipe>> PostRecipeItem(Recipe recipeItem)
        {
            _context.Recipes.Add(recipeItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetRecipeItem), new { id = recipeItem.Id }, recipeItem);
        }

        // DELETE: api/RecipeItems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRecipeItem(long id)
        {
            var recipeItem = await _context.Recipes.FindAsync(id);
            if (recipeItem == null)
            {
                return NotFound();
            }

            _context.Recipes.Remove(recipeItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RecipeItemExists(long id)
        {
            return _context.Recipes.Any(e => e.Id == id);
        }
    }
}
