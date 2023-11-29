using Modulo_Mensageria.Domain;

namespace Modulo_Mensageria.Repository.Interfaces
{
    public interface ICampanhaRepository
    {
        Task<List<Campanha>> getCampanhasDoDia();
    }
}
