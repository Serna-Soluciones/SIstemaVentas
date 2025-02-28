using MSG.SistemaVentas.Application.Interfaces;
using MSG.SistemaVentas.Domain.Entities;
using MSG.SistemaVentas.Domain.Interfaces;

namespace MSG.SistemaVentas.Application.Services
{
    public class VentaService : IVentaService
    {
        private readonly IRepository<Venta> _ventaRepository;

        public VentaService(IRepository<Venta> ventaRepository)
        {
                _ventaRepository = ventaRepository;
        }

        public async Task<Venta> CreateAsync(Venta venta) => await _ventaRepository.AddAsync(venta);

        public async Task<bool> DeleteAsync(int ventaId) => await _ventaRepository.DeleteAsync(ventaId);

        public async Task<IEnumerable<Venta>> GetAllAsync() => await _ventaRepository.GetAllAsync();

        public async Task<Venta> GetByIdAsync(int ventaId) => await _ventaRepository.GetByIdAsync(ventaId);

        public async Task<bool> UpdateAsync(Venta venta) => await _ventaRepository.UpdateAsync(venta);
    }
}
