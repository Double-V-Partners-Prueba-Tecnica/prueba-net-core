// Imports Framework
using Microsoft.AspNetCore.Mvc;
// Imports Project
using Api.Services.CatProductoService;


namespace Api.Controllers
{
    [Route("Api/[controller]")]
    [ApiController]
    public class CatProductoController : ControllerBase
    {
        private readonly ICatProductoService _service;
        public CatProductoController(ICatProductoService catProducto)
        {
            _service = catProducto;
        }
        [HttpGet]
        public IActionResult Get() => Ok(_service.Get());

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var catProducto = _service.Get(id);
            if (catProducto == null)
                return NotFound();

            return Ok(catProducto);
        }
    }
}