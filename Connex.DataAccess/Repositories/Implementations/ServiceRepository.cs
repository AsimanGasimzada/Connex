using Connex.DataAccess.Contexts;
using Connex.DataAccess.Repositories.Abstractions;

namespace Connex.DataAccess.Repositories.Implementations;

public class ServiceRepository : Repository<Service>, IServiceRepository
{
    public ServiceRepository(AppDbContext context) : base(context)
    {
    }
}
