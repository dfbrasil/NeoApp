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
    public class ConsultaController : ControllerBase
    {
        private readonly IConsultaRepositorie _consultaRepositorie;

        public ConsultaController(IConsultaRepositorie consultaRepositorie)
        {
            _consultaRepositorie = consultaRepositorie;
        }

        [Authorize(Roles = "Medico, Paciente")]
        [HttpGet]
        public async Task<ActionResult<List<Consulta>>> ListarTodas()
        {
            List<Consulta> consultas = await _consultaRepositorie.BuscarTodasConsultas();
            return Ok(consultas);
        }

        [Authorize(Roles = "Medico, Paciente")]
        [HttpGet("{id}")]
        public async Task<ActionResult<Consulta>> BuscarPorId(int id)
        {
            Consulta consulta = await _consultaRepositorie.BuscarPorId(id);
            return Ok(consulta);
        }

        [Authorize(Roles = "Medico")]
        [HttpPost]
        public async Task<ActionResult<Consulta>> Cadastrar([FromBody] Consulta consultaModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Consulta consulta = await _consultaRepositorie.AdicionarConsulta(consultaModel);
            return Ok(consulta);
        }

        [Authorize(Roles = "Medico")]
        [HttpPut("{id}")]
        public async Task<ActionResult<Consulta>> Atualizar(Consulta consultaModel, int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            consultaModel.Id = id;
            Consulta consulta = await _consultaRepositorie.AtualizarConsulta(consultaModel, id);
            return Ok(consulta);
        }

        [Authorize(Roles = "Medico")]
        [HttpDelete("{id}")]
        public async Task<ActionResult<Consulta>> Apagar(int id)
        {
            bool apagado = await _consultaRepositorie.DeletarConsulta(id);
            return Ok(apagado);
        }
    }
}
