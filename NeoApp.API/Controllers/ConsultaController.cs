using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NeoApp.API.Models;
using NeoApp.API.Repositories.Interfaces;

namespace NeoApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConsultaController : ControllerBase
    {
        private readonly IConsultaRepositorie _consultaRepositorie;
        public ConsultaController(IConsultaRepositorie consultaRepositorie)
        {
            _consultaRepositorie = consultaRepositorie;
        }
        [HttpGet]
        public async Task<ActionResult<List<Consulta>>> ListarTodas()
        {
            List<Consulta> consultas = await _consultaRepositorie.BuscarTodasConsultas();
            return Ok(consultas);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Consulta>> BuscarPorId(int id)
        {
            Consulta consulta = await _consultaRepositorie.BuscarPorId(id);
            return Ok(consulta);
        }

        [HttpPost]
        public async Task<ActionResult<Consulta>> Cadastrar([FromBody] Consulta consultaModel)
        {
            Consulta consulta = await _consultaRepositorie.AdicionarConsulta(consultaModel);
            return Ok(consulta);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Consulta>> Atualizar(Consulta consultaModel, int id)
        {
            consultaModel.Id = id;
            Consulta consulta = await _consultaRepositorie.AtualizarConsulta(consultaModel, id);
            return Ok(consulta);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Consulta>> Apagar(int id)
        {
            bool apagado = await _consultaRepositorie.DeletarConsulta(id);
            return Ok(apagado);
        }
    }
}
