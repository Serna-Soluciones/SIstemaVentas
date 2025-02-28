using MSG.SistemaVentas.Domain.Entities;

namespace MSG.SistemaVentas.Application.Interfaces
{
    public interface IVentaService
    {
        Task<Venta> CreateAsync(Venta venta);
        Task<bool> UpdateAsync(Venta venta);
        Task<bool> DeleteAsync(int ventaId);
        Task<Venta> GetByIdAsync(int ventaId);
        Task<IEnumerable<Venta>> GetAllAsync();
    }
}
