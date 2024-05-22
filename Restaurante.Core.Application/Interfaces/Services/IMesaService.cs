using Restaurante.Core.Application.ViewModels.Mesa;
using Restaurante.Core.Application.ViewModels.Plato;
using Restaurante.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurante.Core.Application.Interfaces.Services
{
	public interface IMesaService : IGenericService<SaveMesaViewModel,MesaViewModel,Mesa>
	{

    }
}
