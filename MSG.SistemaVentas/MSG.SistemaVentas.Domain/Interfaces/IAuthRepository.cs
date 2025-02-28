using MSG.SistemaVentas.Domain.Entities;

namespace MSG.SistemaVentas.Domain.Interfaces
{
    public interface IAuthRepository
    {
        Task<User?> AuthenticateAsync(string email, string password);
    }
}
