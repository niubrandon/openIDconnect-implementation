using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Auth0ServerApi.Controllers
{
    [Route("api")]
    [ApiController]
    public class ApiController : ControllerBase
    {
        [HttpGet("public")]
        public IActionResult Public()
        {
            Console.WriteLine("receiving call from front");
            return Ok(new
            {
                Message = "Hello from a public endpoint! You don't need to be authenticated to see this."
            });
        }

        [HttpGet("private")]
        [Authorize]
        public IActionResult Private()
        {   
            Console.WriteLine("receiving call from front for private");
            return Ok(new
            {
                Message = "Hello from a private endpoint! You need to be authenticated to see this."
            });
        }

        [HttpGet("private-scoped")]
        [Authorize("read:actions")]
        public IActionResult Scoped()
        {
            Console.WriteLine("receiving call from front for private-scoped");
            return Ok(new
            {
                Action = "Hello from a private endpoint! You need to be authenticated and have a scope of read:messages to see this."
            });
        }

        // This is a helper action. It allows you to easily view all the claims of the token.
        [HttpGet("claims")]
        public IActionResult Claims()
        {
            return Ok(User.Claims.Select(c =>
                new
                {
                    c.Type,
                    c.Value
                }));
        }
    }
}

