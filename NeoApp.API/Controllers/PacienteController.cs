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
            List<Paciente> pacientes = await _pacienteRepositorie.BuscarTodosPacientes();
            return Ok(pacientes);
        }

        [Authorize(Roles = "Medico, Paciente")]
        [HttpGet("{id}")]
        public async Task<ActionResult<Paciente>> BuscarPorId(int id)
        {
            Paciente paciente = await _pacienteRepositorie.BuscarPorId(id);
            return Ok(paciente);
        }

        [Authorize(Roles = "Medico")]
        [HttpPost]
        public async Task<ActionResult<Paciente>> Cadastrar([FromBody] Paciente pacienteModel)
        {
            Paciente paciente = await _pacienteRepositorie.AdicionarPaciente(pacienteModel);
            return Ok(paciente);
        }

        [Authorize(Roles = "Medico")]
        [HttpPut("{id}")]
        public async Task<ActionResult<Paciente>> Atualizar([FromBody] Paciente pacienteModel, int id)
        {
            pacienteModel.Id = id;
            Paciente paciente = await _pacienteRepositorie.AtualizarPaciente(pacienteModel, id);
            return Ok(paciente);
        }

        [Authorize(Roles = "Medico")]
        [HttpDelete("{id}")]
        public async Task<ActionResult<Paciente>> Apagar(int id)
        {
            Paciente pacientePorId = await _pacienteRepositorie.BuscarPorId(id);
            if (pacientePorId == null)
            {
                throw new Exception($"Paciente para o ID: {id} não foi encontrado no banco de dados.");
            }

            await _pacienteRepositorie.DeletarPaciente(id);
            return Ok(pacientePorId);
        }
    }
}
