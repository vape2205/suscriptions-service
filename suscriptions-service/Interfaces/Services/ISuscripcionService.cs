using suscriptions_service.Models;

namespace suscriptions_service.Interfaces.Services
{
    public interface ISuscripcionService
    {
        Task<SuscripcionDTO> GetById(Guid id);
        Task<IEnumerable<SuscripcionDTO>> FindByUserId(Guid userId);
        Task<SuscripcionDTO> Crear(CrearSuscripcionDTO dto);
        Task Activar(Guid id);
        Task Cancelar(Guid id);
    }
}
