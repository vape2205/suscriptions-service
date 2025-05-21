using Microsoft.EntityFrameworkCore;
using suscriptions_service.Entities;
using suscriptions_service.Interfaces.Repositories;
using suscriptions_service.Models;

namespace suscriptions_service.Infraestructure.Persistence.Repositories
{
    public class SuscripcionRepository : ISuscripcionRepository
    {
        private readonly AppDbContext _appDbContext;

        public SuscripcionRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<Suscripcion> FindById(Guid id)
        {
            return (await _appDbContext.Suscripciones.FindAsync(id));
        }

        public async Task<IEnumerable<Suscripcion>> FindByUserId(Guid id)
        {
            return await _appDbContext.Suscripciones.Where(x => x.UserId.Equals(id)).ToListAsync();
        }

        public async Task<Suscripcion> FindActivesByUser(Guid userId)
        {
            return (await _appDbContext.Suscripciones
                .FirstOrDefaultAsync(x => x.UserId.Equals(userId) && x.Estado.Equals(EstadoSuscripcion.Activo)));
        }

        public async Task<Suscripcion> Save(Suscripcion suscripcion)
        {
            var existing = await FindById(suscripcion.Id);
            if (existing != null)
            {
                _appDbContext.Entry(suscripcion).State = EntityState.Modified;
            }
            else
            {
                await _appDbContext.Suscripciones.AddAsync(suscripcion);
            }
            await _appDbContext.SaveChangesAsync();
            return suscripcion;
        }

        
    }
}
