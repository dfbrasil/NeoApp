using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NeoApp.API.Models;
using NeoApp.API.Repositories.Interfaces;

namespace NeoApp.API.Controllers
{
    [Authorize(Roles = "Medico")]
    [Route("api/[controller]")]
    [ApiController]
    public class MedicoController : ControllerBase
    {
        private readonly IMedicoRepositorie _medicoRepositorie;

        public MedicoController(IMedicoRepositorie medicoRepositorie)
        {
            _medicoRepositorie = medicoRepositorie;
        }

        [HttpGet]
        public async Task<ActionResult<List<Medico>>> BuscarTodosMedicos()
        {
            try
            {
                List<Medico> medicos = await _medicoRepositorie.BuscarTodosMedicos();
                return Ok(medicos);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Erro interno do servidor: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Medico>> BuscarPorId(int id)
        {
            try
            {
                if (id <= 0)
                {
                    return BadRequest("O ID do médico deve ser maior que zero.");
                }

                // Verificar se o médico existe antes de atualizar
                if (!await _medicoRepositorie.VerificarExistenciaMedico(id))
                {
                    return NotFound("Médico não encontrado.");
                }

                Medico medico = await _medicoRepositorie.BuscarPorId(id);

                if (medico == null)
                {
                    return NotFound($"Médico com ID {id} não encontrado.");
                }

                return Ok(medico);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Erro interno do servidor: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<ActionResult<Medico>> Cadastrar([FromBody] Medico medicoModel)
        {
            try
            {
                if (medicoModel == null)
                {
                    return BadRequest("Os dados do médico não podem ser nulos.");
                }

                // Adicione outras regras de validação conforme necessário.

                Medico medico = await _medicoRepositorie.AdicionarMedico(medicoModel);
                return Ok(medico);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Erro interno do servidor: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Medico>> Atualizar([FromBody] Medico medicoModel, int id)
        {
            if (medicoModel == null || id != medicoModel.Id)
            {
                return BadRequest("ID na URL não corresponde ao ID no objeto Médico.");
            }

            // Verificar se o médico existe antes de atualizar
            if (!await _medicoRepositorie.VerificarExistenciaMedico(id))
            {
                return NotFound("Médico não encontrado.");
            }

            // Continue com a lógica de atualização
            Medico medico = await _medicoRepositorie.AtualizarMedico(medicoModel, id);
            return Ok(medico);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Apagar(int id)
        {
            try
            {
                if (id <= 0)
                {
                    return BadRequest("O ID do médico deve ser maior que zero.");
                }

                // Verificar se o médico existe antes de atualizar
                if (!await _medicoRepositorie.VerificarExistenciaMedico(id))
                {
                    return NotFound("Médico não encontrado.");
                }

                bool apagado = await _medicoRepositorie.DeletarMedico(id);
                return Ok(apagado);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Erro interno do servidor: {ex.Message}");
            }
        }
    }
}
