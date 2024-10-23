using Connex.DataAccess.Contexts;
using Connex.DataAccess.Repositories.Abstractions;

namespace Connex.DataAccess.Repositories.Implementations;

public class FeatureRepository : Repository<Feature>, IFeatureRepository
{
    public FeatureRepository(AppDbContext context) : base(context)
    {
    }
}
