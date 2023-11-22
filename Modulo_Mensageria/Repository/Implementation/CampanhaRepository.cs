using Microsoft.EntityFrameworkCore;
using Modulo_Mensageria.Domain;
using Modulo_Mensageria.Repository.Interfaces;

namespace Modulo_Mensageria.Repository.Implementation
{
    public class CampanhaRepository : ICampanhaRepository
    {
        private readonly DbContexto _dbContexto;

        public CampanhaRepository(DbContexto dbContexto) 
        {
            _dbContexto = dbContexto;
        }

        public async Task<List<Campanha>> getCampanhasDoDia()
        {
            try
            {
                var teste = await this._dbContexto.Campanha.ToListAsync();
                return teste;
            }

            catch (Exception ex)
            {

                throw;
            }
        } 
    }
}
