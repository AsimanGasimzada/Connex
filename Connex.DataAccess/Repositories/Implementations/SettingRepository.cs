using Connex.DataAccess.Contexts;
using Connex.DataAccess.Repositories.Abstractions;

namespace Connex.DataAccess.Repositories.Implementations;

public class SettingRepository : Repository<Setting>, ISettingRepository
{
    public SettingRepository(AppDbContext context) : base(context)
    {
    }
}