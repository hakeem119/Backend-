using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ToDoMyApp.Models;
using ToDoMyApp.ViewModels;

namespace ToDoMyApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TagsController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly UserManager<AppUser> _userManager;

        public TagsController(AppDbContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // POST api/<Tags>
        [HttpPost]
        public async Task<IActionResult> CreateTag(CreateTagModel model)
        {
            var tag = new Tag { Name = model.Name };
            _context.Tags.Add(tag);
            await _context.SaveChangesAsync();
            return Ok(tag);
        }
        // PUT api/<Tags>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTag(int id, UpdateTagModel model)
        {
            var tag = await _context.Tags.FindAsync(id);
            if (tag == null)
            {
                return NotFound();
            }

            tag.Name = model.Name;
            _context.Tags.Update(tag);
            await _context.SaveChangesAsync();
            return Ok(tag);
        }
        // DELETE api/<Tags>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTag(int id)
        {
            var tag = await _context.Tags.FindAsync(id);
            if (tag == null)
            {
                return NotFound();
            }

            _context.Tags.Remove(tag);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
