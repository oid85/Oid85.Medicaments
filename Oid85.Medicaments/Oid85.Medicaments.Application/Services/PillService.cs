using Oid85.Medicaments.Application.Interfaces.Repositories;
using Oid85.Medicaments.Application.Interfaces.Services;

namespace Oid85.Medicaments.Application.Services
{
    /// <inheritdoc />
    internal class PillService(
        IPillRepository pillRepository) : IPillService
    {

    }
}
