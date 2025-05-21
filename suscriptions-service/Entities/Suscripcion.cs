using suscriptions_service.Models;

namespace suscriptions_service.Entities
{
    public class Suscripcion
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime? FechaInicio { get; set; }
        public DateTime? FechaFin { get; set; }
        public int PeriodoMeses { get; set; }
        public decimal PrecioPorMes { get; set; }
        public decimal Total { get; set; }
        public EstadoSuscripcion Estado { get; set; }

        public void Activar()
        {
            FechaInicio = DateTime.Now;
            FechaFin = FechaInicio.Value.AddMonths(PeriodoMeses);
            Estado = EstadoSuscripcion.Activo;
        }

        public void Cancelar()
        {
            FechaFin = DateTime.Now;
            Estado = EstadoSuscripcion.Cancelado;
        }
    }
}
