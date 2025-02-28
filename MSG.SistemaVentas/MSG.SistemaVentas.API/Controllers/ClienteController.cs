using Microsoft.AspNetCore.Mvc;
using MSG.SistemaVentas.Application.Interfaces;
using MSG.SistemaVentas.Domain.Entities;

namespace MSG.SistemaVentas.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClienteController : ControllerBase
    {
        private readonly ILogger<ClienteController> _logger;
        private readonly IClienteService _clienteService;

        public ClienteController(ILogger<ClienteController> logger, IClienteService clienteService)
        {
            _logger = logger;
            _clienteService = clienteService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _clienteService.GetAllAsync();
            return result != null ? Ok(result) : NoContent();
        }

        [HttpGet("{productoId:int}")]
        public async Task<IActionResult> GetById(int productoId)
        {
            var result = await _clienteService.GetByIdAsync(productoId);
            return result != null ? Ok(result) : NoContent();
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Cliente cliente)
        {
            var result = await _clienteService.CreateAsync(cliente);
            var nuevoCliente = await _clienteService.GetByIdAsync(result.Id);
            return nuevoCliente != null ? Ok(nuevoCliente) : NoContent();
        }

        [HttpPut("{clienteId:int}")]
        public async Task<IActionResult> Put(int clienteId, [FromBody] Cliente cliente)
        {
            if (clienteId == cliente.Id)
            {
                var result = await _clienteService.UpdateAsync(cliente);
                return result ? Ok(result) : BadRequest();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpDelete("{clienteId:int}")]
        public async Task<IActionResult> Delete(int clienteId)
        {
            var result = await _clienteService.DeleteAsync(clienteId);
            return Ok(result);
        }
    }
}
