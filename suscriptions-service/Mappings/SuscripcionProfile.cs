using AutoMapper;
using suscriptions_service.Entities;
using suscriptions_service.Models;

namespace suscriptions_service.Mappings
{
    public class SuscripcionProfile : Profile
    {
        public SuscripcionProfile()
        {
            CreateMap<SuscripcionDTO, Suscripcion>();
            CreateMap<CrearSuscripcionDTO, Suscripcion>();
            CreateMap<Suscripcion, SuscripcionDTO>();
        }
    }
}
