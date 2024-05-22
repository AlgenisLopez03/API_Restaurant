using Restaurante.Core.Application.Interfaces.Repositories;
using Restaurante.Core.Domain.Entities;
using Restaurante.Infrastructure.Persistence.Contexts;
using Restaurante.Infrastructure.Persistence.Repositories.GenericRepository;


namespace Restaurante.Infrastructure.Persistence.Repositories
{
    public class IngredienteRepository : GenericRepository<Ingrediente>, IIngredienteRepository
    {
        private readonly ApplicationContext _dbContext;

        public IngredienteRepository(ApplicationContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
