using AutoMapper;
using Microsoft.AspNetCore.Http;
using Restaurante.Core.Application.Dtos.Account;
using Restaurante.Core.Application.Interfaces.Repositories;
using Restaurante.Core.Application.Interfaces.Services;
using Restaurante.Core.Application.ViewModels.Order;
using Restaurante.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurante.Core.Application.Services
{
    public class OrdenService : GenericServices<SavevOrderViewModel, OrdenViewModel, Orden>, IOrdenService
    {
        private readonly IOrdenRepository _ordenRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IMapper _mapper;
        private readonly AuthenticationResponse userViewModel;

        public OrdenService(IOrdenRepository ordenRepository, IMapper mapper) : base(ordenRepository, mapper)
        {
            _ordenRepository = ordenRepository;
            _mapper = mapper;
        }
        public async Task<List<OrdenViewModel>> GetAllViewModelWithInclude()
        {

            var List = await _ordenRepository.GetAllAsync();

            return _mapper.Map<List<OrdenViewModel>>(List);

        }
        public async Task<OrdenViewModel> GetByIdWithInclude(int id)
        {
            var list = await _ordenRepository.GetAllAsync();

            var orderEntity = list.FirstOrDefault(x => x.Id == id);

            var orderViewModel = _mapper.Map<OrdenViewModel>(orderEntity);

            return orderViewModel;
        }


    }
}
