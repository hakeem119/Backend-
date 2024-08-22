using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToDoMyApp.Models;
using ToDoMyApp.ViewModels;

namespace ToDoMyApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoItemsController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly UserManager<AppUser> _userManager;

        public ToDoItemsController(AppDbContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: api/<ToDoItems>
        [HttpGet]
        public async Task<IActionResult> GetToDoItems()
        {
            var user = await _userManager.GetUserAsync(User);
            var items = await _context.ToDoItems.Where(t => t.UserId == user.Id).ToListAsync();
            return Ok(items);
        }

        // POST api/<ToDoItems>
        [HttpPost]
        public async Task<IActionResult> CreateToDoItem(CreateToDoItemModel model)
        {
            var user = await _userManager.GetUserAsync(User);
            var item = new ToDoItem { Title = model.Title, Description = model.Description, UserId = user.Id };
            _context.ToDoItems.Add(item);
            await _context.SaveChangesAsync();
            return Ok(item);
        }
        // PUT api/<ToDoItems>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateToDoItem(int id, UpdateToDoItemModel model)
        {
            var item = await _context.ToDoItems.FindAsync(id);
            if (item == null || item.UserId != (await _userManager.GetUserAsync(User)).Id)
            {
                return NotFound();
            }

            item.Title = model.Title;
            item.Description = model.Description;
            item.IsCompleted = model.IsCompleted;

            _context.ToDoItems.Update(item);
            await _context.SaveChangesAsync();
            return Ok(item);
        }
        // DELETE api/<ToDoItems>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteToDoItem(int id)
        {
            var item = await _context.ToDoItems.FindAsync(id);
            if (item == null || item.UserId != (await _userManager.GetUserAsync(User)).Id)
            {
                return NotFound();
            }

            _context.ToDoItems.Remove(item);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
