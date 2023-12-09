using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NeoApp.API.Models;

namespace NeoApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicoController : ControllerBase
    {
        [HttpGet]

        public ActionResult <List<Medico>> BuscaTodosPacientes()
            {
                return Ok();
            }
    }
}
