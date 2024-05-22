using Restaurante.Core.Application.ViewModels.Plato;
using Restaurante.Core.Application.ViewModels.Mesa;
using Restaurante.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurante.Core.Application.ViewModels.Order
{
	public class OrdenViewModel
	{
		public int Id { get; set; }
		public int Estado { get; set; }
		public double Subtotal { get; set; }


		public int PlatoId { get; set; }
		public string PlatoNombre { get; set; }
		public PlatoViewModel? Plato { get; set; }


		public int MesaId { get; set; }
		public string MesaNombre { get; set; }
		public MesaViewModel? Mesa { get; set; }

    }
}
