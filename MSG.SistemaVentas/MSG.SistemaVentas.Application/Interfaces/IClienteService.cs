using MSG.SistemaVentas.Domain.Entities;

namespace MSG.SistemaVentas.Application.Interfaces
{
    public interface IClienteService
    {
        Task<Cliente> CreateAsync(Cliente cliente);
        Task<bool> UpdateAsync(Cliente cliente);
        Task<bool> DeleteAsync(int clienteId);
        Task<Cliente?> GetByIdAsync(int clienteId);
        Task<IEnumerable<Cliente>> GetAllAsync();
    }
}
