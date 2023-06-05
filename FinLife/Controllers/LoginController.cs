using FinLife.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace FinLife.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {
        IConfiguration _config;
        FinLifeContext _context;
    public LoginController(IConfiguration config, FinLifeContext context)
    {
        _config = config;
        _context = context;
    } 
    

    [AllowAnonymous]
    [Route("Login")]
    [HttpPost]
    public IActionResult Login(User User)
    {   

        var Login = _context.Users.Where(u => u.EmailId == User.EmailId && u.Password == User.Password).FirstOrDefault();
        if (Login != null)
        {
            return Ok(Login);
        }
        return Ok("Failure");
    }

    
    }
}