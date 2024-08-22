using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;
using ToDoMyApp.Models;
using ToDoMyApp.ViewModels;

namespace ToDoMyApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly ILogger<UserController> _logger;
       


        public UserController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, ILogger<UserController> logger)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
        }

       
     
        [HttpPost("Login")]
        public async Task<ActionResult> UserLogin(SignInVM loginModel)
        {
            AppUser user;
            
            user = await _userManager.FindByEmailAsync(loginModel.UsernameOrEmail);
           
            if (user == null)
            {
                return Ok("failed");
            }
            var result = await _signInManager.CheckPasswordSignInAsync(user, loginModel.Password, true);
            if (result.Succeeded)
            {
                return Ok(loginModel);
            }
            else
            {
                return BadRequest("failed process");
            }
        }



        [HttpPost("Register")]
        public async Task<ActionResult> Register(RegisterVM register)
        {
            if (!ModelState.IsValid) return Ok("wrong Model");
            AppUser newUser = new AppUser
            {
                Email = register.Email,
                UserName = register.Username,
                Name=register.Username
            };
            IdentityResult result = await _userManager.CreateAsync(newUser, register.Password);
            if (!result.Succeeded)
            {
                return BadRequest("failed");
            }
            return Ok(register);
        }

    }
}
