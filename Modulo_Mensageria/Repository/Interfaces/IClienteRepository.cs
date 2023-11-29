using Modulo_Mensageria.Domain;

namespace Modulo_Mensageria.Repository.Interfaces
{
    public interface IClienteRepository
    {
        Task<List<Cliente>> getTodosOsUsuarios();
    }
}
