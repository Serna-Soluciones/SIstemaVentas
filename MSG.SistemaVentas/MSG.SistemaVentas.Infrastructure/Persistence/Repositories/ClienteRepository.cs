using Microsoft.EntityFrameworkCore;
using MSG.SistemaVentas.Domain.Entities;
using MSG.SistemaVentas.Domain.Interfaces;

namespace MSG.SistemaVentas.Infrastructure.Persistence.Repositories
{
    public class ClienteRepository : IRepository<Cliente>
    {
        private readonly VentasDbContext _context;

        public ClienteRepository( VentasDbContext context)
        {
                _context = context;
        }
        public async Task<Cliente> AddAsync(Cliente entity)
        {
            try
            {
                _context.Clientes.Add(entity);
                await _context.SaveChangesAsync();
                return entity;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                var cliente = await _context.Clientes.FindAsync(id);
                if (cliente != null)
                {
                    _context.Clientes.Remove(cliente);
                    var result = await _context.SaveChangesAsync() > 0;
                    return result;
                }
                return false;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<Cliente>> GetAllAsync() => await _context.Clientes.ToListAsync();

        public async Task<Cliente?> GetByIdAsync(int id) => await _context.Clientes.FindAsync(id);

        public async Task<bool> UpdateAsync(Cliente entity)
        {
            try
            {
                _context.Clientes.Update(entity);
                var result = await _context.SaveChangesAsync() > 0;
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
