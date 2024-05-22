using Restaurante.Core.Domain.Common;
namespace Restaurante.Core.Domain.Entities
{
    public class Mesa : AuditableBaseEntity
    {
        public int Id { get; set; }
        public int CantidadPersonas { get; set; }
        public string Descripcion { get; set; }
        public int Estado { get; set; }

        // Relación con órdenes
        public ICollection<Orden>? Ordenes { get; set; }
    }
}
