using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NeoApp.API.Models;
using NeoApp.API.Repositories.Interfaces;

namespace NeoApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PacienteController : ControllerBase
    {
        private readonly IPacienteRepositorie _pacienteRepositorie;

        public PacienteController(IPacienteRepositorie pacienteRepositorie)
        {
            _pacienteRepositorie = pacienteRepositorie;
        }

        [Authorize(Roles = "Medico, Paciente")]
        [HttpGet]
        public async Task<ActionResult<List<Paciente>>> BuscaTodosPacientes()
        {
            try
            {
                List<Paciente> pacientes = await _pacienteRepositorie.BuscarTodosPacientes();
                return Ok(pacientes);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Erro interno do servidor: {ex.Message}");
            }
        }

        [Authorize(Roles = "Medico, Paciente")]
        [HttpGet("{id}")]
        public async Task<ActionResult<Paciente>> BuscarPorId(int id)
        {
            try
            {
                Paciente paciente = await _pacienteRepositorie.BuscarPorId(id);
                if (paciente == null)
                {
                    return NotFound($"Paciente com ID {id} não encontrado.");
                }
                return Ok(paciente);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Erro interno do servidor: {ex.Message}");
            }
        }

        [Authorize(Roles = "Medico")]
        [HttpPost]
        public async Task<ActionResult<Paciente>> Cadastrar([FromBody] Paciente pacienteModel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                Paciente paciente = await _pacienteRepositorie.AdicionarPaciente(pacienteModel);
                return Ok(paciente);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Erro interno do servidor: {ex.Message}");
            }
        }

        [Authorize(Roles = "Medico")]
        [HttpPut("{id}")]
        public async Task<ActionResult<Paciente>> Atualizar([FromBody] Paciente pacienteModel, int id)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                pacienteModel.Id = id;
                Paciente paciente = await _pacienteRepositorie.AtualizarPaciente(pacienteModel, id);
                if (paciente == null)
                {
                    return NotFound($"Paciente com ID {id} não encontrado.");
                }

                return Ok(paciente);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Erro interno do servidor: {ex.Message}");
            }
        }

        [Authorize(Roles = "Medico")]
        [HttpDelete("{id}")]
        public async Task<ActionResult<Paciente>> Apagar(int id)
        {
            try
            {
                Paciente pacientePorId = await _pacienteRepositorie.BuscarPorId(id);
                if (pacientePorId == null)
                {
                    return NotFound($"Paciente com ID {id} não encontrado.");
                }

                await _pacienteRepositorie.DeletarPaciente(id);
                return Ok(pacientePorId);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Erro interno do servidor: {ex.Message}");
            }
        }
    }
}
