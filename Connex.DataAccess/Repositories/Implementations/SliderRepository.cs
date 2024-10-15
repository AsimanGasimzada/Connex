using Connex.DataAccess.Contexts;
using Connex.DataAccess.Repositories.Abstractions;

namespace Connex.DataAccess.Repositories.Implementations;

public class SliderRepository : Repository<Slider>, ISliderRepository
{
    public SliderRepository(AppDbContext context) : base(context)
    {
    }
}
