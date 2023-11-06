// Imports Framework
using Microsoft.AspNetCore.Mvc;
// Imports Project
using Api.Services.TblClienteService;

namespace Api.Controllers
{
    [Route("Api/[controller]")]
    [ApiController]
    public class TblClienteClinteController : ControllerBase
    {
        private readonly ITblClienteService _service;
        public TblClienteClinteController(ITblClienteService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult Get() => Ok(_service.Get());

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var catTipoCliente = _service.Get(id);
            if (catTipoCliente == null)
                return NotFound();

            return Ok(catTipoCliente);
        }
    }
}