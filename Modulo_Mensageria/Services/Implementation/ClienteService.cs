using Modulo_Mensageria.Domain;
using Modulo_Mensageria.Repository.Interfaces;
using Modulo_Mensageria.Services.Interfaces;

namespace Modulo_Mensageria.Services.Implementation
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteService(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public async Task<List<Cliente>> getTodosOsUsuarios()
        {
            try
            {
                var clientes = await _clienteRepository.getTodosOsUsuarios();

                return clientes;
            }
            catch (Exception)
            {
                throw;
            }
           
        }
    }
}
