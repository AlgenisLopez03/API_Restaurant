using Restaurante.Core.Domain.Common;
namespace Restaurante.Core.Domain.Entities
{
    public class Ingrediente : AuditableBaseEntity
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        // Relación con platos
        public ICollection<Plato>? Platos { get; set; }

    }
}
