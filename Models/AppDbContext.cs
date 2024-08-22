using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ToDoMyApp.Models
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
             public DbSet<ToDoItem> ToDoItems { get; set; }
        public DbSet<Tag> Tags { get; set; }
    }
          
}
