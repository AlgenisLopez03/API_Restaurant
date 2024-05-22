using Restaurante.Core.Application.Interfaces.Repositories;
using Restaurante.Core.Domain.Entities;
using Restaurante.Infrastructure.Persistence.Contexts;
using Restaurante.Infrastructure.Persistence.Repositories.GenericRepository;


namespace Restaurante.Infrastructure.Persistence.Repositories
{
    public class MesaRepository : GenericRepository<Mesa>, IMesaRepository
    {
        private readonly ApplicationContext _dbContext;

        public MesaRepository(ApplicationContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
