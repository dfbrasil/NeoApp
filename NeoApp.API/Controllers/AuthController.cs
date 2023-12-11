using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using NeoApp.API.Models;
using NeoApp.API.Repositories.Interfaces;
using NeoApp.API.Repositories;

namespace NeoApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IPacienteRepositorie _pacienteRepositorie;
        private readonly IMedicoRepositorie _medicoRepositorie;

        public AuthController(IConfiguration configuration, IPacienteRepositorie pacienteRepositorie, IMedicoRepositorie medicoRepositorie)
        {
            _configuration = configuration;
            _pacienteRepositorie = pacienteRepositorie;
            _medicoRepositorie = medicoRepositorie;
        }

        [HttpPost("login")]
        public async Task<ActionResult<string>> Login([FromBody] LoginRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Paciente paciente = await _pacienteRepositorie.VerificarCredenciaisPaciente(request.UserName, request.Password);
            Medico medico = await _medicoRepositorie.VerificarCredenciaisMedico(request.UserName, request.Password);

            if (paciente != null)
            {
                var pacientePorId = await _pacienteRepositorie.BuscarPorId(paciente.Id);
                var token = GenerateJwtTokenForPaciente(pacientePorId);
                return Ok(new { Token = token });
            }
            else if (medico != null)
            {
                var medicoPorId = await _medicoRepositorie.BuscarPorId(medico.Id);
                var token = GenerateJwtTokenForMedico(medicoPorId);
                return Ok(new { Token = token });
            }

            return Unauthorized();
        }

        private string GenerateJwtTokenForMedico(Medico medico)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>
        {
        new Claim(ClaimTypes.Name, medico.NomeMedico),
        new Claim(ClaimTypes.Role, "Medico"),
        };

            var token = new JwtSecurityToken(
                _configuration["Jwt:Issuer"],
                _configuration["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddMinutes(Convert.ToDouble(_configuration["Jwt:ExpirationInMinutes"])),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private string GenerateJwtTokenForPaciente(Paciente paciente)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>
    {
        new Claim(ClaimTypes.Name, paciente.NomePaciente),
        new Claim(ClaimTypes.Role, "Paciente"),
    };

            var token = new JwtSecurityToken(
                _configuration["Jwt:Issuer"],
                _configuration["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddMinutes(1000),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
