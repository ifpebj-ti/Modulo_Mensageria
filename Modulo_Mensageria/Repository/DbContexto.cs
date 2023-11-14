using Microsoft.EntityFrameworkCore;
using Modulo_Mensageria.Domain;

namespace Modulo_Mensageria.Repository
{
    public class DbContexto : DbContext
    {
        public DbContexto(DbContextOptions<DbContexto> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Habilitar o Lazy Loading
            optionsBuilder.UseLazyLoadingProxies();
        }


        public DbSet<Campanha> Campanha { get; set; }
    }
}
