using Microsoft.AspNetCore.Identity;

namespace ToDoMyApp.Models
{
    public class AppUser : IdentityUser 
    {
        public string Name{ get;set;}
    }
}
