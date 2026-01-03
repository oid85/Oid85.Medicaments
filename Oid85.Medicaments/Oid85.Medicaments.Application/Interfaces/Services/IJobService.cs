
namespace Oid85.Medicaments.Application.Interfaces.Services
{
    /// <summary>
    /// Сервис задач Hangfire
    /// </summary>
    public interface IJobService
    {
        /// <summary>
        /// Обновить запасы лекарств
        /// </summary>
        Task UpdateReserveAsync();
    }
}
