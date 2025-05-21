namespace suscriptions_service.Models
{
    public class CrearSuscripcionDTO
    {
        public Guid UserId { get; set; }
        public int PeriodoMeses { get; set; }
        public decimal PrecioPorMes { get; set; }
        public decimal Total { get; set; }
    }
}
