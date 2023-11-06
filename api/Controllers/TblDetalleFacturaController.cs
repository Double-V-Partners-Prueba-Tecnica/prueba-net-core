// Imports Framework
using Microsoft.AspNetCore.Mvc;
// Imports Project
using Api.Services.TblDetalleFacturaService;

namespace Api.Controllers
{
    [Route("Api/[controller]")]
    [ApiController]
    public class TblDetalleFacturaController : ControllerBase
    {
        private readonly ITblDetalleFacturaService _service;
        public TblDetalleFacturaController(ITblDetalleFacturaService service)
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