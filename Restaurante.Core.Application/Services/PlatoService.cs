using AutoMapper;
using Microsoft.AspNetCore.Http;
using RestaurantAPI.Core.Application.Helpers;
using Restaurante.Core.Application.Dtos.Account;
using Restaurante.Core.Application.Interfaces.Repositories;
using Restaurante.Core.Application.Interfaces.Services;
using Restaurante.Core.Application.ViewModels.Plato;
using Restaurante.Core.Application.ViewModels.Ingredient;
using Restaurante.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurante.Core.Application.Services
{
    public class PlatoService : GenericServices<SavePlatoViewModel, PlatoViewModel, Plato>, IPlatoService
    {
        private readonly IPlatoRepository _platoRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IMapper _mapper;
        private readonly AuthenticationResponse userViewModel;

        public PlatoService(IPlatoRepository platoRepository, IMapper mapper, IHttpContextAccessor httpContextAccessor) : base(platoRepository, mapper)
        {
            _platoRepository = platoRepository;
            _httpContextAccessor = httpContextAccessor;
            _mapper = mapper;
            userViewModel = _httpContextAccessor.HttpContext.Session.Get<AuthenticationResponse>("user");
        }
        public async Task<List<PlatoViewModel>> GetAllViewModelWithInclude()
        {

            var PlatosLis = await _platoRepository.GetAllWithIncludeAsync(new List<string> { "Ingrediente" });


            return PlatosLis.Select(Plato => new PlatoViewModel
            {
                Nombre = Plato.Nombre,
                Precio = Plato.Precio,
                CantidadPersonas = Plato.CantidadPersonas,
                //Categoria = Plato.Categoria,
                NombreIngrediente = Plato.Ingrediente.Nombre,
                IngredienteID = Plato.Ingrediente.Id,

            }).ToList();
        }

    }
}
