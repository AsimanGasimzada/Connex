using Connex.DataAccess.Contexts;
using Connex.DataAccess.Repositories.Abstractions;

namespace Connex.DataAccess.Repositories.Implementations;

public class CertificateRepository : Repository<Certificate>, ICertificateRepository
{
    public CertificateRepository(AppDbContext context) : base(context)
    {
    }
}
