using Microsoft.AspNetCore.Mvc;
using MSG.SistemaVentas.API.Dtos;
using MSG.SistemaVentas.Application.Interfaces;
using MSG.SistemaVentas.Domain.Entities;
using MSG.SistemaVentas.Domain.Interfaces;

namespace MSG.SistemaVentas.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly ILogger<ProductoController> _logger;
        private readonly IAuthRepository _authRepository;
        private readonly IJwtService _jwtService;

        public AuthController(ILogger<ProductoController> logger, IAuthRepository authRepository, IJwtService jwtService)
        {
            _logger = logger;
            _authRepository = authRepository;
            _jwtService = jwtService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Post([FromBody] UserLoginDto userDto)
        {
            var result = await _authRepository.AuthenticateAsync(userDto.Email, string.Empty);
            if (result == null)
            {
                return Unauthorized("Usuario y contraseña incorrectos");
            }
            var token = _jwtService.GenerateToken(result);
            return Ok(new { token });
        }
    }
}
