using AutoMapper;
using Microsoft.AspNetCore.Http;
using RestaurantAPI.Core.Application.Helpers;
using Restaurante.Core.Application.Dtos.Account;
using Restaurante.Core.Application.Interfaces.Repositories;
using Restaurante.Core.Application.Interfaces.Services;
using Restaurante.Core.Application.ViewModels.Ingredient;
using Restaurante.Core.Application.ViewModels.Mesa;
using Restaurante.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurante.Core.Application.Services
{
    public class IngredienteService : GenericServices<SaveIngredienteViewModel, IngredienteViwModel, Ingrediente>, IIngredienteService
    {
        private readonly IIngredienteRepository _ingredienteRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IMapper _mapper;
        private readonly AuthenticationResponse userViewModel;

        public IngredienteService(IIngredienteRepository ingredientRepository, IMapper mapper, IHttpContextAccessor httpContextAccessor) : base(ingredientRepository, mapper)
        {
            _ingredienteRepository = ingredientRepository;
            _httpContextAccessor = httpContextAccessor;
            _mapper = mapper;
            userViewModel = _httpContextAccessor.HttpContext.Session.Get<AuthenticationResponse>("user");
        }
        public async Task<List<IngredienteViwModel>> GetAllViewModelWithInclude()
        {

            var ingrediente = await _ingredienteRepository.GetAllAsync();

            var IngredienteViwModel = _mapper.Map<List<IngredienteViwModel>>(ingrediente);

            return IngredienteViwModel;

        }
    }
}