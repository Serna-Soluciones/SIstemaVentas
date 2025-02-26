using Microsoft.AspNetCore.Mvc;
using MSG.SistemaVentas.Application.Interfaces;
using MSG.SistemaVentas.Domain.Entities;

namespace MSG.SistemaVentas.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductoController : ControllerBase
    {
        private readonly ILogger<ProductoController> _logger;
        private readonly IProductoService _productoService;

        public ProductoController(ILogger<ProductoController> logger, IProductoService productoService)
        {
            _logger = logger;
            _productoService = productoService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _productoService.GetAllAsync();
            return result != null ? Ok(result) : NoContent();
        }

        [HttpGet("{productoId:int}")]
        public async Task<IActionResult> GetById(int productoId)
        {
            var result = await _productoService.GetByIdAsync(productoId);
            return result != null ? Ok(result) : NoContent();
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Producto producto)
        {
             var result = _productoService.CreateAsync(producto);
            return CreatedAtAction(nameof(GetById), new { id = result.Id });
        }

        [HttpPut("{productoId:int}")]
        public async Task<IActionResult> Put(int productoId, [FromBody] Producto producto)
        {
            if (productoId == producto.Id)
            {
                var result = await _productoService.UpdateAsync(producto);
                return result ? Ok(result) : BadRequest();
            } else
            {
                return BadRequest();
            }
        }

        [HttpDelete("{productoId:int}")]
        public async Task<IActionResult> Delete(int productoId)
        {
            var result = await _productoService.DeleteAsync(productoId);
            return Ok(result);
        }
    }
}
