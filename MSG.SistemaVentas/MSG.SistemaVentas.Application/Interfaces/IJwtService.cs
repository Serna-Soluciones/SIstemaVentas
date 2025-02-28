using MSG.SistemaVentas.Domain.Entities;

namespace MSG.SistemaVentas.Application.Interfaces
{
    public interface IJwtService
    {
        string GenerateToken(User user);
    }
}
