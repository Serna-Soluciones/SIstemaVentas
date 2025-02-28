using Microsoft.IdentityModel.Tokens;
using MSG.SistemaVentas.Application.Interfaces;
using MSG.SistemaVentas.Domain.Entities;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks.Dataflow;

namespace MSG.SistemaVentas.API.Middlewares
{
    public class JWTMiddleware
    {
        private readonly RequestDelegate _next;

        public JWTMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
            if (token == null)
            {
                try
                {
                    var tokenHandler = new JwtSecurityTokenHandler();
                    var key = Encoding.UTF8.GetBytes("Clave secreta");
                    tokenHandler.ValidateToken(token, new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(key),
                        ValidateIssuer = false,
                        ValidateAudience = false
                    }, out SecurityToken validatedToken);

                    context.Items["User"] = validatedToken;
                }
                catch (Exception)
                {

                    throw;
                }
            }
            await _next(context);
        }
    }
}
