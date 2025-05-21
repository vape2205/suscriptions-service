using Microsoft.EntityFrameworkCore;
using suscriptions_service.Entities;

namespace suscriptions_service.Infraestructure.Persistence
{
    public class AppDbContext : DbContext
    {
        public DbSet<Suscripcion> Suscripciones { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }


    }
}
