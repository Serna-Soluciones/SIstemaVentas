using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using MSG.SistemaVentas.Domain.Entities;
using MSG.SistemaVentas.Domain.Interfaces;

namespace MSG.SistemaVentas.Infrastructure.Persistence.Repositories
{
    public class ProductoRepository : IRepository<Producto>
    {
        private readonly VentasDbContext _context;

        public ProductoRepository( VentasDbContext context)
        {
                _context = context;
        }
        public async Task<Producto> AddAsync(Producto entity)
        {
            try
            {
                _context.Productos.Add(entity);
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
                var producto = await _context.Productos.FindAsync(id);
                if (producto != null)
                {
                    _context.Productos.Remove(producto);
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

        public async Task<IEnumerable<Producto>> GetAllAsync() => await _context.Productos.ToListAsync();

        public async Task<Producto?> GetByIdAsync(int id) => await _context.Productos.FindAsync(id);

        public async Task<bool> UpdateAsync(Producto entity)
        {
            try
            {
                _context.Productos.Update(entity);
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
