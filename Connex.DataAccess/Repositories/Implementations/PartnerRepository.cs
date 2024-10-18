using Connex.DataAccess.Contexts;
using Connex.DataAccess.Repositories.Abstractions;

namespace Connex.DataAccess.Repositories.Implementations;

public class PartnerRepository : Repository<Partner>, IPartnerRepository
{
    public PartnerRepository(AppDbContext context) : base(context)
    {
    }
}
