
using Oid85.Medicaments.Core.Models;
using Oid85.Medicaments.Core.Requests;

namespace Oid85.Medicaments.Application.Interfaces.Repositories
{
    /// <summary>
    /// Репозиторий лекарств
    /// </summary>
    public interface IPillRepository
    {
        Task<Guid?> CreatePillAsync(Pill model);
        Task<Guid?> CreatePillIncrementAsync(Guid pillId, int number);
        Task<Guid?> DeletePillAsync(Guid id);
        Task<Guid?> EditPillAsync(Pill model);
        Task<int> GetPillReserveAsync(Guid id);
        Task<List<Pill>?> GetPillsAsync();
    }
}
