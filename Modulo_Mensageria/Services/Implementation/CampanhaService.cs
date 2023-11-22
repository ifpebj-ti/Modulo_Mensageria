using Modulo_Mensageria.Domain;
using Modulo_Mensageria.Repository.Interfaces;
using Modulo_Mensageria.Services.Interfaces;

namespace Modulo_Mensageria.Services.Implementation
{
    public class CampanhaService : ICampanhaService
    {
        private readonly ICampanhaRepository _campanhaRepository;

        public CampanhaService(ICampanhaRepository campanhaRepository)
        {
            _campanhaRepository = campanhaRepository;
        }

        public async Task<List<Campanha>> getCampanhasDoDia()
        {
            var teste = await _campanhaRepository.getCampanhasDoDia();
            return teste;
        }
    }
}
