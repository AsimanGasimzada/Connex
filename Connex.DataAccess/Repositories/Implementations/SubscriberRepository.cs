using Connex.DataAccess.Contexts;
using Connex.DataAccess.Repositories.Abstractions;

namespace Connex.DataAccess.Repositories.Implementations;

public class SubscriberRepository : Repository<Subscriber>, ISubscriberRepository
{
    public SubscriberRepository(AppDbContext context) : base(context)
    {
    }
}
