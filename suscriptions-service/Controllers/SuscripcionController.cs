using Microsoft.AspNetCore.Mvc;
using suscriptions_service.Interfaces.Services;
using suscriptions_service.Models;

namespace suscriptions_service.Controllers
{
    [ApiController]
    [Route("api/suscripciones")]
    public class SuscripcionController : ControllerBase
    {
        private readonly ISuscripcionService _suscripcionService;

        public SuscripcionController(ISuscripcionService suscripcionService)
        {
            _suscripcionService = suscripcionService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObtenerPorId(Guid id)
        {
            var suscripcion = await _suscripcionService.GetById(id);
            return Ok(suscripcion);
        }

        [HttpGet("user/{id}")]
        public async Task<IActionResult> GetByUser(Guid id)
        {
            var suscripcion = await _suscripcionService.FindByUserId(id);
            return Ok(suscripcion);
        }

        [HttpPost]
        public async Task<IActionResult> Crear([FromBody] CrearSuscripcionDTO request)
        {
            var creado = await _suscripcionService.Crear(request);
            return Ok(creado);
        }

        [HttpPost("{id}/activar")]
        public async Task<IActionResult> Activar(Guid id)
        {
            await _suscripcionService.Activar(id);
            return NoContent();
        }

        [HttpPost("{id}/cancelar")]
        public async Task<IActionResult> Cancelar(Guid id)
        {
            await _suscripcionService.Cancelar(id);
            return NoContent();
        }
    }
}
