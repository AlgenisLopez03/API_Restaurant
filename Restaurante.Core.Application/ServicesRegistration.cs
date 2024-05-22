using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Restaurante.Core.Application.Interfaces.Services;
using Restaurante.Core.Application.Services;
using System.Reflection;

namespace Restaurante.Core.Application
{
    public static class ServicesRegistration
    {
        public static void AddApplicationLayer(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            #region Services
            services.AddTransient(typeof(IGenericService<,,>), typeof(GenericServices<,,>));
            services.AddTransient<IPlatoService, PlatoService>();
            services.AddTransient<IIngredienteService, IngredienteService>();
            services.AddTransient<IOrdenService, OrdenService>();
            services.AddTransient<IMesaService, MesaService>();
            #endregion
        }
    }
}

