using Microsoft.AspNetCore.Mvc;
using NeoApp.API.Models;
using NeoApp.API.Services;

namespace NeoApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        
            [HttpPost]
            public IActionResult Auth(string username, string password)
            {
                if (username == "neoapp" && password == "senha123")
                {
                    var paciente = new Paciente();
                    var token = TokenService.GenerateToken(paciente);
                    return Ok(token);
                }

                return BadRequest("username or password invalid");
            }
    }
}
