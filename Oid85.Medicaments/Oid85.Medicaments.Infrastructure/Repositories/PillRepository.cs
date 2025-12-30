using Microsoft.EntityFrameworkCore;
using Oid85.Medicaments.Application.Interfaces.Repositories;

namespace Oid85.Medicaments.Infrastructure.Repositories
{
    /// <inheritdoc />
    public class PillRepository(
        IDbContextFactory<MedicamentsContext> contextFactory
        ) : IPillRepository
    {

    }
}
