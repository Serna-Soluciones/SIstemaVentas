using MSG.SistemaVentas.Domain.Entities;

namespace MSG.SistemaVentas.Application.Interfaces
{
    public interface IProductoService
    {
        Task<Producto> CreateAsync(Producto producto);
        Task<bool> UpdateAsync(Producto producto);
        Task<bool> DeleteAsync(int productoId);
        Task<Producto> GetByIdAsync(int productoId);
        Task<IEnumerable<Producto>> GetAllAsync();
    }
}
