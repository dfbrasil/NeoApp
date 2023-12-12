using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NeoApp.API.Models;
using NeoApp.API.Repositories.Interfaces;

namespace NeoApp.API.Controllers
{
    [Authorize(Roles = "Paciente")]
    [Route("[controller]")]
    [ApiController]
    public class PacienteController : ControllerBase
    {
        private readonly IPacienteRepositorie _pacienteRepositorie;

        public PacienteController(IPacienteRepositorie pacienteRepositorie)
        {
            _pacienteRepositorie = pacienteRepositorie;
        }

        [HttpGet]
        public async Task<ActionResult<List<Paciente>>> BuscaTodosPacientes()
        {
            List<Paciente> pacientes = await _pacienteRepositorie.BuscarTodosPacientes();
            return Ok(pacientes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Paciente>> BuscarPorId(int id)
        {
            if (id <= 0)
            {
                return BadRequest("ID inválido.");
            }

            Paciente paciente = await _pacienteRepositorie.BuscarPorId(id);

            if (paciente == null)
            {
                return NotFound("Paciente não encontrado.");
            }

            return Ok(paciente);
        }

        [HttpPost]
        public async Task<ActionResult<Paciente>> Cadastrar([FromBody] Paciente pacienteModel)
        {
            if (pacienteModel == null)
            {
                return BadRequest("Objeto Paciente não pode ser nulo.");
            }

            Paciente paciente = await _pacienteRepositorie.AdicionarPaciente(pacienteModel);
            return Ok(paciente);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Paciente>> Atualizar([FromBody] Paciente pacienteModel, int id)
        {
            if (pacienteModel == null || id <= 0 || id != pacienteModel.Id)
            {
                return BadRequest("ID na URL não corresponde ao ID no objeto Paciente.");
            }

            if (!await _pacienteRepositorie.VerificarExistenciaPaciente(id))
            {
                return NotFound("Paciente não encontrado.");
            }

            Paciente paciente = await _pacienteRepositorie.AtualizarPaciente(pacienteModel, id);
            return Ok(paciente);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Paciente>> Apagar(int id)
        {
            if (id <= 0)
            {
                return BadRequest("ID inválido.");
            }

            if (!await _pacienteRepositorie.VerificarExistenciaPaciente(id))
            {
                return NotFound("Paciente não encontrado.");
            }

            bool apagado = await _pacienteRepositorie.DeletarPaciente(id);
            return Ok(apagado);
        }
    }
}
