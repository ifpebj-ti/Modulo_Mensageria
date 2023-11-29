using Microsoft.EntityFrameworkCore;
using Modulo_Mensageria.Domain;
using Modulo_Mensageria.Repository.Interfaces;

namespace Modulo_Mensageria.Repository.Implementation
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly UnifiedContext _unifiedContext;
        public ClienteRepository(UnifiedContext unifiedContext) {
            _unifiedContext = unifiedContext;
        }

        public async Task<List<Cliente>> getTodosOsUsuarios()
        {
            try
            {
                var clientes = await _unifiedContext.Cliente.ToListAsync();
                return clientes;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
