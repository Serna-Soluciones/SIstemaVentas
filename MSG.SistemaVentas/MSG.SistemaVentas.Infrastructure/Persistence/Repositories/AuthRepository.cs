using Microsoft.EntityFrameworkCore;
using MSG.SistemaVentas.Domain.Entities;
using MSG.SistemaVentas.Domain.Interfaces;

namespace MSG.SistemaVentas.Infrastructure.Persistence.Repositories
{
    public class AuthRepository : IAuthRepository
    {
        private readonly VentasDbContext _dbContext;

        public AuthRepository(VentasDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<User?> AuthenticateAsync(string email, string password) => await _dbContext.Users.FirstOrDefaultAsync(u => u.Email == email);
    }
}
