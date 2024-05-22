using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurante.Core.Application.Interfaces.Services
{
	public interface IGenericService<SaveViewModel, ViewModel, Model>
		where SaveViewModel : class
		where ViewModel : class
		where Model : class
	{
		Task Update(SaveViewModel vm, int Id);

		Task<SaveViewModel> Add(SaveViewModel vm);

		Task Delete(int Id);

		Task<SaveViewModel> GetByIdSaveViewModel(int Id);

		Task<List<ViewModel>> GetAllViewModel();
	}

}
