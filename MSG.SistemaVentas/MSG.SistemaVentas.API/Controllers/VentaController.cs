using Microsoft.AspNetCore.Mvc;
using MSG.SistemaVentas.Application.Interfaces;
using MSG.SistemaVentas.Domain.Entities;

namespace MSG.SistemaVentas.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VentaController : ControllerBase
    {
        private readonly ILogger<ProductoController> _logger;
        private readonly IVentaService _ventaService;

        public VentaController(ILogger<ProductoController> logger, IVentaService ventaService)
        {
            _logger = logger;
            _ventaService = ventaService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _ventaService.GetAllAsync();
            return result != null ? Ok(result) : NoContent();
        }

        [HttpGet("{ventaId:int}")]
        public async Task<IActionResult> GetById(int ventaId)
        {
            var result = await _ventaService.GetByIdAsync(ventaId);
            return result != null ? Ok(result) : NoContent();
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Venta venta)
        {
            var result = await _ventaService.CreateAsync(venta);
            var nuevoProducto = await _ventaService.GetByIdAsync(result.Id);
            return nuevoProducto != null ? Ok(nuevoProducto) : NoContent();
        }

        [HttpPut("{ventaId:int}")]
        public async Task<IActionResult> Put(int ventaId, [FromBody] Venta venta)
        {
            if (ventaId == venta.Id)
            {
                var result = await _ventaService.UpdateAsync(venta);
                return result ? Ok(result) : BadRequest();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpDelete("{ventaId:int}")]
        public async Task<IActionResult> Delete(int ventaId)
        {
            var result = await _ventaService.DeleteAsync(ventaId);
            return Ok(result);
        }
    }
}
