using Restaurante.Core.Domain.Common;

namespace Restaurante.Core.Domain.Entities
{
    public class Plato : AuditableBaseEntity
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public double Precio { get; set; }
        public int CantidadPersonas { get; set; }
        public int  Categoria { get; set; }

        // Relación con Mesa
        public int IngredienteID { get; set; }
        public Ingrediente? Ingrediente { get; set; }
        //public int MesaId { get; set; }
        //public Mesa? Mesa { get; set; }

        //Relacion con orden
        public ICollection<Orden>? Ordenes { get; set; }

    }
}
