using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurante.Core.Application.ViewModels.Mesa
{
	public class MesaViewModel
	{
        public int Id { get; set; }
        public int CantidadPersonas { get; set; }
        public string Descripcion { get; set; }
        public int Estado { get; set; }
    }
}
