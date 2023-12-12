using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NeoApp.API.Models;
using NeoApp.API.Repositories.Interfaces;

namespace NeoApp.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
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
            Paciente paciente = await _pacienteRepositorie.BuscarPorId(id);
            return Ok(paciente);
        }
        [HttpPost]
        public async Task<ActionResult<Paciente>> Cadastrar([FromBody] Paciente pacienteModel)
        {
            Paciente paciente = await _pacienteRepositorie.AdicionarPaciente(pacienteModel);
            return Ok(paciente);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Paciente>> Atualizar([FromBody] Paciente pacienteModel, int id)
        {
            pacienteModel.Id = id;
            Paciente paciente = await _pacienteRepositorie.AtualizarPaciente(pacienteModel, id);
            return Ok(paciente);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Paciente>> Apagar(int id)
        {
            bool apagado= await _pacienteRepositorie.DeletarPaciente(id);
            return Ok(apagado);
        }
    }
}
