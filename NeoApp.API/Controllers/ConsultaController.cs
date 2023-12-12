using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NeoApp.API.Models;
using NeoApp.API.Repositories.Interfaces;

namespace NeoApp.API.Controllers
{
    [Authorize(Roles = "Paciente")]
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
        public async Task<ActionResult<List<Consulta>>> BuscaTodasConsultas()
        {
            try
            {
                List<Consulta> consultas = await _consultaRepositorie.BuscarTodasConsultas();
                return Ok(consultas);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Erro interno do servidor: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Consulta>> BuscarPorId(int id)
        {
            try
            {
                if (id <= 0)
                {
                    return BadRequest("ID inválido.");
                }

                Consulta consulta = await _consultaRepositorie.BuscarPorId(id);

                if (consulta == null)
                {
                    return NotFound("Consulta não encontrada.");
                }

                return Ok(consulta);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Erro interno do servidor: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<ActionResult<Consulta>> AdicionarConsulta([FromBody] Consulta consultaModel)
        {
            try
            {
                if (consultaModel == null)
                {
                    return BadRequest("Objeto Consulta não pode ser nulo.");
                }

                // Adicione mais validações conforme necessário, por exemplo, para campos obrigatórios.

                Consulta consulta = await _consultaRepositorie.AdicionarConsulta(consultaModel);
                return Ok(consulta);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Erro interno do servidor: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Consulta>> AtualizarConsulta([FromBody] Consulta consultaModel, int id)
        {
            try
            {
                if (consultaModel == null || id <= 0 || id != consultaModel.Id)
                {
                    return BadRequest("ID na URL não corresponde ao ID no objeto Consulta.");
                }

                // Verificar se a consulta existe antes de atualizar
                if (!await _consultaRepositorie.VerificarExistenciaConsulta(id))
                {
                    return NotFound("Consulta não encontrada.");
                }

                // Continue com a lógica de atualização
                Consulta consulta = await _consultaRepositorie.AtualizarConsulta(consultaModel, id);
                return Ok(consulta);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Erro interno do servidor: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> DeletarConsulta(int id)
        {
            try
            {
                if (id <= 0)
                {
                    return BadRequest("ID inválido.");
                }

                // Verificar se a consulta existe antes de apagar
                if (!await _consultaRepositorie.VerificarExistenciaConsulta(id))
                {
                    return NotFound("Consulta não encontrada.");
                }

                bool apagado = await _consultaRepositorie.DeletarConsulta(id);
                return Ok(apagado);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Erro interno do servidor: {ex.Message}");
            }
        }
    }
}
