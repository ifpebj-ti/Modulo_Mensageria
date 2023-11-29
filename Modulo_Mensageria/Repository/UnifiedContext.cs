using Microsoft.EntityFrameworkCore;
using Modulo_Mensageria.Domain;

namespace Modulo_Mensageria.Repository
{
    public class UnifiedContext : DbContext
    {
        public UnifiedContext(DbContextOptions<UnifiedContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Habilitar o Lazy Loading
            optionsBuilder.UseLazyLoadingProxies();
        }

        public DbSet<Cliente> Cliente { get; set; }
    }
}
