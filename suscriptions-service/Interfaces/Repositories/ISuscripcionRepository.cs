using suscriptions_service.Entities;
using suscriptions_service.Models;

namespace suscriptions_service.Interfaces.Repositories
{
    public interface ISuscripcionRepository
    {
        Task<Suscripcion> FindById(Guid id);
        Task<IEnumerable<Suscripcion>> FindByUserId(Guid id);
        Task<Suscripcion> FindActivesByUser(Guid userId);
        Task<Suscripcion> Save(Suscripcion suscripcion);
    }
}
