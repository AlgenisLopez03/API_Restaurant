using AutoMapper;
using Restaurante.Core.Application.Interfaces.Repositories;
using Restaurante.Core.Application.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurante.Core.Application.Services
{
    public class GenericServices<SaveViewModel, ViewModel, Model> : IGenericService<SaveViewModel, ViewModel, Model>
        where SaveViewModel : class
        where ViewModel : class
        where Model : class
    {
        private readonly IGenericRepository<Model> _repository;
        private readonly IMapper _mapper;
        public GenericServices(IGenericRepository<Model> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public virtual async Task Update(SaveViewModel vm, int Id)
        {
            Model Model = _mapper.Map<Model>(vm);

            await _repository.UpdateAsync(Model, Id);
        }

        public virtual async Task<SaveViewModel> Add(SaveViewModel vm)
        {
            Model Model = _mapper.Map<Model>(vm);

            Model = await _repository.AddAsync(Model);

            SaveViewModel Savevm = _mapper.Map<SaveViewModel>(Model);

            return Savevm;
        }

        public virtual async Task Delete(int id)
        {
            Model Model = await _repository.GetByIdAsync(id);
            await _repository.DeleteAsync(Model);
        }

        public virtual async Task<SaveViewModel> GetByIdSaveViewModel(int id)
        {
            Model Model = await _repository.GetByIdAsync(id);

            SaveViewModel vm = _mapper.Map<SaveViewModel>(Model);

            return vm;
        }

        public virtual async Task<List<ViewModel>> GetAllViewModel()
        {
            var ModelList = await _repository.GetAllAsync();

            return _mapper.Map<List<ViewModel>>(ModelList);

        }

    }

}
