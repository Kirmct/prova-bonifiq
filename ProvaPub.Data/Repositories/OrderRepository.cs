using ProvaPub.Domain.Repositories;
using ProvaPub.Infra.Data.Context;

namespace ProvaPub.Infra.Data.Repositories;
public class OrderRepository : Repository<Order>, IOrderRepository
{
    public OrderRepository(AppDbContext context) : base(context) { }

}
