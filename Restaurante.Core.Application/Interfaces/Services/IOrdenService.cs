using Restaurante.Core.Application.ViewModels.Order;
using Restaurante.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurante.Core.Application.Interfaces.Services
{
	public interface IOrdenService : IGenericService<SavevOrderViewModel,OrdenViewModel,Orden>
	{

    }
}
