using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NeoApp.API.Models;
using NeoApp.API.Repositories.Interfaces;

namespace NeoApp.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class MedicoController : ControllerBase
    {
        private readonly IMedicoRepositorie _medicoRepositorie;
        public MedicoController(IMedicoRepositorie medicoRepositorie)
        {
            _medicoRepositorie = medicoRepositorie;
        }

        [Authorize(Roles = "Medico, Paciente")]
        [HttpGet]
        public async Task<ActionResult<List<Medico>>> BuscarTodosMedicos()
        {
            List<Medico> medicos = await _medicoRepositorie.BuscarTodosMedicos();
            return Ok(medicos);
        }

        [Authorize(Roles = "Medico, Paciente")]
        [HttpGet("{id}")]
        public async Task<ActionResult<Medico>> BuscarPorId(int id)
        {
            Medico medico = await _medicoRepositorie.BuscarPorId(id);
            return Ok(medico);
        }

        [Authorize(Roles = "Medico")]
        [HttpPost]
        public async Task<ActionResult<Medico>> Cadastrar([FromBody] Medico medicoModel)
        {
            Medico medico = await _medicoRepositorie.AdicionarMedico(medicoModel);
            return Ok(medico);
        }

        [Authorize(Roles = "Medico")]
        [HttpPut("{id}")]
        public async Task<ActionResult<Medico>> Atualizar([FromBody] Medico medicoModel, int id)
        {
            medicoModel.Id = id;
            Medico medico = await _medicoRepositorie.AtualizarMedico(medicoModel, id);
            return Ok(medico);
        }

        [Authorize(Roles = "Medico")]
        [HttpDelete("{id}")]
        public async Task<ActionResult<Medico>> DeletarMedico(int id)
        {
            Medico medicoPorId = await _medicoRepositorie.BuscarPorId(id);
            if (medicoPorId == null)
            {
                throw new Exception($"Médico para o ID: {id} não foi encontrado no banco de dados.");
            }

            await _medicoRepositorie.DeletarMedico(id);
            return Ok(medicoPorId);
        }
    }
}
