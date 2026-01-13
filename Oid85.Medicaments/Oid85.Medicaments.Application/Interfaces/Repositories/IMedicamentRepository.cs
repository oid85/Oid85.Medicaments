
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
        /// <param name="date">Дата</param>
        /// <param name="value">Кол-во</param>
        /// <returns></returns>
        Task<Guid?> CreateMedicamentIncrementAsync(Guid medicamentId, DateOnly date, int value);

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

        /// <summary>
        /// Получить изменения количества лекарств
        /// </summary>
        Task<List<MedicamentIncrement>?> GetMedicamentIncrementsAsync(Guid medicamentId);

        /// <summary>
        /// Получить изменения количества лекарств на дату
        /// </summary>
        Task<List<MedicamentIncrement>?> GetMedicamentIncrementByDateAsync(Guid medicamentId, DateOnly date);
    }
}
