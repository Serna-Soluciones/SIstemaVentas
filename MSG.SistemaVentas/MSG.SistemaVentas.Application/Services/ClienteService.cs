using MSG.SistemaVentas.Application.Interfaces;
using MSG.SistemaVentas.Domain.Entities;
using MSG.SistemaVentas.Domain.Interfaces;

namespace MSG.SistemaVentas.Application.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IRepository<Cliente> _clienteRepository;

        public ClienteService(IRepository<Cliente> clienteRepository)
        {
                _clienteRepository = clienteRepository;
        }

        public async Task<Cliente> CreateAsync(Cliente cliente) => await _clienteRepository.AddAsync(cliente);

        public async Task<bool> DeleteAsync(int clienteId) => await _clienteRepository.DeleteAsync(clienteId);

        public async Task<IEnumerable<Cliente>> GetAllAsync() => await _clienteRepository.GetAllAsync();

        public async Task<Cliente?> GetByIdAsync(int clienteId) => await _clienteRepository.GetByIdAsync(clienteId);

        public async Task<bool> UpdateAsync(Cliente cliente) => await _clienteRepository.UpdateAsync(cliente);
    }
}
