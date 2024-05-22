using AutoMapper;
using Restaurante.Core.Application.ViewModels.Ingredient;
using Restaurante.Core.Application.ViewModels.Mesa;
using Restaurante.Core.Application.ViewModels.Plato ;
using Restaurante.Core.Application.ViewModels.Order;
using Restaurante.Core.Domain.Entities;
using AutoMapper;



namespace Restaurante.Core.Application.Mappings
{
    public class GeneralProfile:Profile
    {
        public GeneralProfile() 
        
        {
            #region Ingredient
            CreateMap<Ingrediente, IngredienteViwModel >()
               .ReverseMap()
               .ForMember(x => x.Created, opt => opt.Ignore())
                .ForMember(x => x.CreatedBy, opt => opt.Ignore())
                .ForMember(x => x.LastModified, opt => opt.Ignore())
                .ForMember(x => x.LastModifiedBy, opt => opt.Ignore());

            CreateMap<Ingrediente, SaveIngredienteViewModel>()
                .ReverseMap()
                .ForMember(x => x.Created, opt => opt.Ignore())
                .ForMember(x => x.CreatedBy, opt => opt.Ignore())
                .ForMember(x => x.LastModified, opt => opt.Ignore())
                .ForMember(x => x.LastModifiedBy, opt => opt.Ignore());

            #endregion

            #region Mesa
                  CreateMap<Mesa, MesaViewModel>()
                .ReverseMap()
                .ForMember(x => x.Created, opt => opt.Ignore())
                 .ForMember(x => x.CreatedBy, opt => opt.Ignore())
                 .ForMember(x => x.LastModified, opt => opt.Ignore())
                 .ForMember(x => x.LastModifiedBy, opt => opt.Ignore());

            CreateMap<Mesa, SaveMesaViewModel>()
                .ReverseMap()
                .ForMember(x => x.Created, opt => opt.Ignore())
                 .ForMember(x => x.CreatedBy, opt => opt.Ignore())
                 .ForMember(x => x.LastModified, opt => opt.Ignore())
                 .ForMember(x => x.LastModifiedBy, opt => opt.Ignore());
            #endregion

            #region Plato
            CreateMap<Plato, PlatoViewModel>()
                .ForMember(x => x.NombreIngrediente, opt => opt.Ignore())
                .ForMember(x => x.NombreMesa, opt => opt.Ignore())
                .ReverseMap()
                .ForMember(x => x.Created, opt => opt.Ignore())
                 .ForMember(x => x.CreatedBy, opt => opt.Ignore())
                 .ForMember(x => x.LastModified, opt => opt.Ignore())
                 .ForMember(x => x.LastModifiedBy, opt => opt.Ignore());

            CreateMap<Plato, SavePlatoViewModel>()
                .ReverseMap()
                .ForMember(x => x.Created, opt => opt.Ignore())
                 .ForMember(x => x.CreatedBy, opt => opt.Ignore())
                 .ForMember(x => x.LastModified, opt => opt.Ignore())
                 .ForMember(x => x.LastModifiedBy, opt => opt.Ignore());

            #endregion

            #region Order
            CreateMap<Orden, OrdenViewModel>()
                .ForMember(x => x.PlatoNombre, opt => opt.Ignore())
                .ForMember(x => x.MesaNombre, opt => opt.Ignore())

                .ReverseMap()
                .ForMember(x => x.Created, opt => opt.Ignore())
                 .ForMember(x => x.CreatedBy, opt => opt.Ignore())
                 .ForMember(x => x.LastModified, opt => opt.Ignore())
                 .ForMember(x => x.LastModifiedBy, opt => opt.Ignore());

            CreateMap<Orden, SavevOrderViewModel>()
                .ReverseMap()
                .ForMember(x => x.Created, opt => opt.Ignore())
                 .ForMember(x => x.CreatedBy, opt => opt.Ignore())
                 .ForMember(x => x.LastModified, opt => opt.Ignore())
                 .ForMember(x => x.LastModifiedBy, opt => opt.Ignore());
            #endregion
        }
    }
}
