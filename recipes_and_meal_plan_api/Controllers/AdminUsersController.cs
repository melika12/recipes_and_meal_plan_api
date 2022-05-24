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
    public class AdminUsersController : ControllerBase
    {
        private readonly AdminUsersContext _context;

        public AdminUsersController(AdminUsersContext context)
        {
            _context = context;
        }

        // GET: api/AdminUsers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AdminUsers>>> GetAdminUsers()
        {
            return await _context.AdminUsers.ToListAsync();
        }

        // GET: api/AdminUsers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AdminUsers>> GetAdminUsers(int id)
        {
            var adminUsers = await _context.AdminUsers.FindAsync(id);

            if (adminUsers == null)
            {
                return NotFound();
            }

            return adminUsers;
        }

        // PUT: api/AdminUsers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAdminUsers(int id, AdminUsers adminUsers)
        {
            if (id != adminUsers.Id)
            {
                return BadRequest();
            }

            _context.Entry(adminUsers).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AdminUsersExists(id))
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

        // POST: api/AdminUsers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AdminUsers>> PostAdminUsers(AdminUsers adminUsers)
        {
            _context.AdminUsers.Add(adminUsers);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetAdminUsers), new { id = adminUsers.Id }, adminUsers);
        }

        // DELETE: api/AdminUsers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAdminUsers(int id)
        {
            var adminUsers = await _context.AdminUsers.FindAsync(id);
            if (adminUsers == null)
            {
                return NotFound();
            }

            _context.AdminUsers.Remove(adminUsers);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AdminUsersExists(int id)
        {
            return _context.AdminUsers.Any(e => e.Id == id);
        }
    }
}
