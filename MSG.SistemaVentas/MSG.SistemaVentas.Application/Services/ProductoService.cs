using MSG.SistemaVentas.Application.Interfaces;
using MSG.SistemaVentas.Domain.Entities;
using MSG.SistemaVentas.Domain.Interfaces;
using MSG.SistemaVentas.Infrastructure.Persistence.Repositories;

namespace MSG.SistemaVentas.Application.Services
{
    public class ProductoService : IProductoService
    {
        private readonly IRepository<Producto> _productoRepository;

        public ProductoService(IRepository<Producto> productoRepository)
        {
                _productoRepository = productoRepository;
        }

        public async Task<Producto> CreateAsync(Producto producto) => await _productoRepository.AddAsync(producto);

        public async Task<bool> DeleteAsync(int productoId) => await _productoRepository.DeleteAsync(productoId);

        public async Task<IEnumerable<Producto>> GetAllAsync() => await _productoRepository.GetAllAsync();

        public async Task<Producto> GetByIdAsync(int productoId) => await _productoRepository.GetByIdAsync(productoId);

        public async Task<bool> UpdateAsync(Producto producto) => await _productoRepository.UpdateAsync(producto);
    }
}
