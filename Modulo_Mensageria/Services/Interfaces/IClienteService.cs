using Modulo_Mensageria.Domain;

namespace Modulo_Mensageria.Services.Interfaces
{
    public interface IClienteService
    {
        Task<List<Cliente>> getTodosOsUsuarios();
    }
}
