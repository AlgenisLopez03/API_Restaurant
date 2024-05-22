using Restaurante.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurante.Core.Application.ViewModels.Order
{
	public class SavevOrderViewModel
	{
		public int Id { get; set; }
		public string Estado { get; set; }
		public decimal Subtotal { get; set; }
		public int PlatoId { get; set; }

		public int MesaId { get; set; }
	}
}
