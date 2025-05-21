using AutoMapper;
using suscriptions_service.Entities;
using suscriptions_service.Interfaces.Repositories;
using suscriptions_service.Interfaces.Services;
using suscriptions_service.Models;

namespace suscriptions_service.Services
{
    public class SuscripcionService : ISuscripcionService
    {
        private readonly ISuscripcionRepository _suscripcionRepository;
        private readonly IMapper _mapper;

        public SuscripcionService(ISuscripcionRepository suscripcionRepository,
            IMapper mapper)
        {
            _suscripcionRepository = suscripcionRepository;
            _mapper = mapper;
        }

        public async Task<SuscripcionDTO> GetById(Guid id)
        {
            var suscripcion = await _suscripcionRepository.FindById(id);
            return _mapper.Map<SuscripcionDTO>(suscripcion);
        }

        public async Task<IEnumerable<SuscripcionDTO>> FindByUserId(Guid userId)
        {
            var suscripcion = await _suscripcionRepository.FindByUserId(userId);
            return _mapper.Map<IEnumerable<SuscripcionDTO>>(suscripcion);
        }

        public async Task<SuscripcionDTO> Crear(CrearSuscripcionDTO dto)
        {
            Suscripcion suscripcion = _mapper.Map<Suscripcion>(dto);
            suscripcion.FechaCreacion = DateTime.Now;
            var savedEntity = await _suscripcionRepository.Save(suscripcion);
            return _mapper.Map<SuscripcionDTO>(savedEntity);
        }

        public async Task Activar(Guid id)
        {
            Suscripcion suscripcion = await _suscripcionRepository.FindById(id);
            if (suscripcion == null)
                throw new Exception();

            suscripcion.Activar();
            await _suscripcionRepository.Save(suscripcion);
        }

        public async Task Cancelar(Guid id)
        {
            Suscripcion suscripcion = await _suscripcionRepository.FindById(id);
            if (suscripcion == null)
                throw new Exception();

            suscripcion.Cancelar();
            await _suscripcionRepository.Save(suscripcion);
        }
    }
}
