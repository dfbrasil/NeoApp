using Microsoft.AspNetCore.Mvc;
using NeoApp.API.Models;
using NeoApp.API.Services;
using System.Numerics;

namespace NeoApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        [HttpPost]
        public IActionResult Auth(string username, string password, string userType)
        {
            if (userType == "Paciente" && username == "paciente" && password == "paciente123")
            {
                var paciente = new Paciente();
                var token = TokenService.GenerateToken(paciente.Id, "Paciente");
                return Ok(token);
            }
            else if (userType == "Medico" && username == "medico" && password == "medico123")
            {
                var doctor = new Medico();
                var token = TokenService.GenerateToken(doctor.Id, "Medico");
                return Ok(token);
            }

            return BadRequest("username or password invalid");
        }
    }
}
