using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NeoApp.API.Models;

namespace NeoApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConsultaController : ControllerBase
    {
        [HttpGet]
        public ActionResult <List<Medico>> BuscarTodasConsultas()
        {
            return Ok();
        }
    }
}
