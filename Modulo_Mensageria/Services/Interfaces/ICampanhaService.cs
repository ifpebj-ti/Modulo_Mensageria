using Modulo_Mensageria.Domain;

namespace Modulo_Mensageria.Services.Interfaces
{
    public interface ICampanhaService
    {
        Task<List<Campanha>> getCampanhasDoDia();
    }
}
