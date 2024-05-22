using Restaurante.Core.Domain.Common;

namespace Restaurante.Core.Domain.Entities
{
    public class Orden : AuditableBaseEntity
    {
        public int Id { get; set; }
        public int Estado { get; set; }
        public double Subtotal { get; set; }

        // Relación con Plato
        public int PlatoId { get; set; }
        public Plato? Plato { get; set; }

        // Relación con Mesa
        public int MesaId { get; set; }
        public Mesa? Mesa { get; set; }

        // Relación con Usuario
        //public int? UsuarioId { get; set; }
    }
}
