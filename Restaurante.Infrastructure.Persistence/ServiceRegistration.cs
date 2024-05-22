using Restaurante.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Restaurante.Core.Application.Interfaces.Repositories;
using Restaurante.Infrastructure.Persistence.Repositories.GenericRepository;
using Restaurante.Infrastructure.Persistence.Contexts;


namespace Restaurante.Infrastructure.Persistence
{

    //Extension Method - Decorator
    public static class ServiceRegistration
    {
        public static void AddPersistenceInfrastructure(this IServiceCollection services,IConfiguration configuration)
        {
            #region Contexts
            if (configuration.GetValue<bool>("UseInMemoryDatabase"))
            {
                services.AddDbContext<ApplicationContext>(options => options.UseInMemoryDatabase("ApplicationDb"));
            }
            else
            {
                services.AddDbContext<ApplicationContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                m=> m.MigrationsAssembly(typeof(ApplicationContext).Assembly.FullName)));
            }
            #endregion

            #region Repositories
            services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddTransient<IIngredienteRepository, IngredienteRepository>();
            services.AddTransient<IMesaRepository, MesaRepository>();
            services.AddTransient<IOrdenRepository, OrdenRepository>();
            services.AddTransient<IPlatoRepository, PlatoRepository>();
            #endregion
        }
    }
}
