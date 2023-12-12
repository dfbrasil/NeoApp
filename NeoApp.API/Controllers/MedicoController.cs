using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
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
            List<Medico> medicos = await _medicoRepositorie.BuscarTodosMedicos();
            return Ok(medicos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Medico>> BuscarPorId(int id)
        {
            Medico medico = await _medicoRepositorie.BuscarPorId(id);
            return Ok(medico);
        }

        [HttpPost]
        public async Task<ActionResult<Medico>> Cadastrar([FromBody] Medico medicoModel)
        {
            Medico medico = await _medicoRepositorie.AdicionarMedico(medicoModel);
            return Ok(medico);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Medico>> Atualizar([FromBody] Medico medicoModel, int id)
        {
            medicoModel.Id = id;
            Medico medico = await _medicoRepositorie.AtualizarMedico(medicoModel, id);
            return Ok(medico);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Medico>> Apagar(int id)
        {
            bool apagado= await _medicoRepositorie.DeletarMedico(id);
            return Ok(apagado);
        }
    }
}
