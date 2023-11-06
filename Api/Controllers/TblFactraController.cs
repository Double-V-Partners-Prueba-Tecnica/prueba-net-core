// Imports Framework
using Microsoft.AspNetCore.Mvc;
// Imports Project
using Api.Services.TblFacturaService;

namespace Api.Controllers
{
    [Route("Api/[controller]")]
    [ApiController]
    public class TblFacturaController : ControllerBase
    {
        private readonly ITblFacturaService _service;
        public TblFacturaController(ITblFacturaService service)
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