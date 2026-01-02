
using Oid85.Medicaments.Core.Models;
using Oid85.Medicaments.Core.Requests;

namespace Oid85.Medicaments.Application.Interfaces.Repositories
{
    /// <summary>
    /// Репозиторий лекарств
    /// </summary>
    public interface IPillRepository
    {
        /// <summary>
        /// Добавить лекарство
        /// </summary>
        Task<Guid?> CreatePillAsync(Pill model);

        /// <summary>
        /// Пополнить запас лекарства
        /// </summary>
        /// <param name="pillId">Идентификатор лекарства</param>
        /// <param name="number">Кол-во</param>
        /// <returns></returns>
        Task<Guid?> CreatePillIncrementAsync(Guid pillId, int number);

        /// <summary>
        /// Удалить лекарство
        /// </summary>
        Task<Guid?> DeletePillAsync(Guid id);

        /// <summary>
        /// Редктировать лекарство
        /// </summary>
        Task<Guid?> EditPillAsync(Pill model);

        /// <summary>
        /// Получить остаток лекарства
        /// </summary>
        /// <param name="id">Идентификатор лекарства</param>        
        Task<int> GetPillReserveAsync(Guid id);

        /// <summary>
        /// Получить список лекарств
        /// </summary>
        Task<List<Pill>?> GetPillsAsync();
    }
}
