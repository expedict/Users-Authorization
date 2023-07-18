using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Users.Models;
using UsersApi.Models;

namespace Users.Controllers
{
    [Route("api/UserLists")]
    [ApiController]
    public class UserListsController : ControllerBase
    {
        private readonly UsersContext _context;

        public UserListsController(UsersContext context)
        {
            _context = context;
        }

        // GET: api/UserLists
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserList>>> GetUsersItems()
        {
          if (_context.UsersItems == null)
          {
              return NotFound();
          }
            return await _context.UsersItems.ToListAsync();
        }

        // GET: api/UserLists/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserList>> GetUserList(long id)
        {
          if (_context.UsersItems == null)
          {
              return NotFound();
          }
            var userList = await _context.UsersItems.FindAsync(id);

            if (userList == null)
            {
                return NotFound();
            }

            return userList;
        }

        // PUT: api/UserLists/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserList(long id, UserList userList)
        {
            if (id != userList.Id)
            {
                return BadRequest();
            }

            _context.Entry(userList).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserListExists(id))
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

        // POST: api/UserLists
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<UserList>> PostUserList(UserList userList)
        {
          if (_context.UsersItems == null)
          {
              return Problem("Entity set 'UsersContext.UsersItems'  is null.");
          }
            _context.UsersItems.Add(userList);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetUserList), new { id = userList.Id }, userList);
        }

        // DELETE: api/UserLists/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserList(long id)
        {
            if (_context.UsersItems == null)
            {
                return NotFound();
            }
            var userList = await _context.UsersItems.FindAsync(id);
            if (userList == null)
            {
                return NotFound();
            }

            _context.UsersItems.Remove(userList);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserListExists(long id)
        {
            return (_context.UsersItems?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
