using Connex.DataAccess.Contexts;
using Connex.DataAccess.Repositories.Abstractions;

namespace Connex.DataAccess.Repositories.Implementations;

public class AboutRepository : Repository<About>, IAboutRepository
{
    public AboutRepository(AppDbContext context) : base(context)
    {
    }
}
