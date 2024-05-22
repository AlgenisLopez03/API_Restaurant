using Restaurante.Core.Application.Interfaces.Repositories;
using Restaurante.Core.Domain.Entities;
using Restaurante.Infrastructure.Persistence.Contexts;
using Restaurante.Infrastructure.Persistence.Repositories.GenericRepository;

namespace Restaurante.Infrastructure.Persistence.Repositories
{
    public class PlatoRepository : GenericRepository<Plato>, IPlatoRepository
    {
        private readonly ApplicationContext _dbContext;

        public PlatoRepository(ApplicationContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }

}
