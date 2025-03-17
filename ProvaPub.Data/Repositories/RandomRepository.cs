using ProvaPub.Domain.Models;
using ProvaPub.Domain.Repositories;
using ProvaPub.Infra.Data.Context;

namespace ProvaPub.Infra.Data.Repositories
{
    public class RandomRepository : Repository<RandomNumber>, IRandomRepository
    {
        public RandomRepository(AppDbContext context) : base(context) { }
    }
}

