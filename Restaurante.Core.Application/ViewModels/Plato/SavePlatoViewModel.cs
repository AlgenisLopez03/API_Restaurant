using Restaurante.Core.Application.ViewModels.Ingredient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurante.Core.Application.ViewModels.Plato
{
	public class SavePlatoViewModel
	{
		public int Id { get; set; }
		public string Nombre { get; set; }
		public double Precio { get; set; }
		public int CantidadPersonas { get; set; }
		public int Categoria { get; set; }


		public int IngredienteID { get; set; }
	


	}
}
