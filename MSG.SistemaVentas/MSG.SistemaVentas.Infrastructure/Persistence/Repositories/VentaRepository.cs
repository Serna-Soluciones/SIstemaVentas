using Microsoft.EntityFrameworkCore;
using MSG.SistemaVentas.Domain.Entities;
using MSG.SistemaVentas.Domain.Interfaces;

namespace MSG.SistemaVentas.Infrastructure.Persistence.Repositories
{
    public class VentaRepository : IRepository<Venta>
    {
        private readonly VentasDbContext _context;

        public VentaRepository(VentasDbContext context)
        {
            _context = context;
        }
        public async Task<Venta> AddAsync(Venta entity)
        {
            try
            {
                _context.Ventas.Add(entity);
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
                var venta = await _context.Ventas.FindAsync(id);
                if (venta != null)
                {
                    _context.Ventas.Remove(venta);
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

        public async Task<IEnumerable<Venta>> GetAllAsync() => await _context.Ventas.ToListAsync();

        public async Task<Venta?> GetByIdAsync(int id) => await _context.Ventas.FindAsync(id);

        public async Task<bool> UpdateAsync(Venta entity)
        {
            try
            {
                _context.Ventas.Update(entity);
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
