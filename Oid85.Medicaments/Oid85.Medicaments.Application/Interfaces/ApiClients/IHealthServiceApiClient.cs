using Oid85.Medicaments.Core.Requests;
using Oid85.Medicaments.Core.Responses;

namespace Oid85.Medicaments.Application.Interfaces.ApiClients
{
    /// <summary>
    /// Клиент сервиса Health
    /// </summary>
    public interface IHealthServiceApiClient
    {
        /// <summary>
        /// Получить количество измерений глюкозы за дату
        /// </summary>
        Task<int> GetCountGlucoseAsync(DateOnly date);
    }
}
