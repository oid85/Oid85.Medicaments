
using Oid85.Medicaments.Core.Models;

namespace Oid85.Medicaments.Application.Interfaces.Repositories
{
    /// <summary>
    /// Репозиторий лекарств
    /// </summary>
    public interface IMedicamentRepository
    {
        /// <summary>
        /// Добавить лекарство
        /// </summary>
        Task<Guid?> CreateMedicamentAsync(Medicament model);

        /// <summary>
        /// Пополнить запас лекарства
        /// </summary>
        /// <param name="medicamentId">Идентификатор лекарства</param>
        /// <param name="number">Кол-во</param>
        /// <returns></returns>
        Task<Guid?> CreateMedicamentIncrementAsync(Guid medicamentId, int number);

        /// <summary>
        /// Удалить лекарство
        /// </summary>
        Task<Guid?> DeleteMedicamentAsync(Guid id);

        /// <summary>
        /// Редктировать лекарство
        /// </summary>
        Task<Guid?> EditMedicamentAsync(Medicament model);

        /// <summary>
        /// Получить остаток лекарства
        /// </summary>
        /// <param name="id">Идентификатор лекарства</param>        
        Task<int> GetMedicamentReserveAsync(Guid id);

        /// <summary>
        /// Получить список лекарств
        /// </summary>
        Task<List<Medicament>?> GetMedicamentsAsync();
    }
}
