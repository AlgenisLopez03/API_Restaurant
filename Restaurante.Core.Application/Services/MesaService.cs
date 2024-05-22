using AutoMapper;
using Microsoft.AspNetCore.Http;
using RestaurantAPI.Core.Application.Helpers;
using Restaurante.Core.Application.Dtos.Account;
using Restaurante.Core.Application.Interfaces.Repositories;
using Restaurante.Core.Application.Interfaces.Services;
using Restaurante.Core.Application.ViewModels.Plato;
using Restaurante.Core.Application.ViewModels.Mesa;
using Restaurante.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurante.Core.Application.Services
{
    public class MesaService : GenericServices<SaveMesaViewModel, MesaViewModel, Mesa>, IMesaService
    {
        private readonly IMesaRepository _mesaRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IMapper _mapper;
        private readonly AuthenticationResponse userViewModel;

        public MesaService(IMesaRepository mesaRepository, IMapper mapper, IHttpContextAccessor httpContextAccessor) : base(mesaRepository, mapper)
        {
            _mesaRepository = mesaRepository;
            _httpContextAccessor = httpContextAccessor;
            _mapper = mapper;
            userViewModel = _httpContextAccessor.HttpContext.Session.Get<AuthenticationResponse>("user");
        }
        public async Task<List<MesaViewModel>> GetAllViewModelWithInclude()
        {

            var mesas = await _mesaRepository.GetAllAsync();

            var mesaViewModels = _mapper.Map<List<MesaViewModel>>(mesas);

            return mesaViewModels;

        }

    }
}