using Oid85.Medicaments.Core.Requests;
using Oid85.Medicaments.Core.Responses;

namespace Oid85.Medicaments.Application.Interfaces.Services
{
    /// <summary>
    /// Сервис лекарств
    /// </summary>
    public interface IPillService
    {
        /// <summary>
        /// Добавить запас лекарств
        /// </summary>
        Task<AddPillResponse?> AddPillAsync(AddPillRequest request);
        
        /// <summary>
        /// Добавить лекарство
        /// </summary>
        Task<CreatePillResponse?> CreatePillAsync(CreatePillRequest request);
        
        /// <summary>
        /// Удалить лекарство
        /// </summary>
        Task<DeletePillResponse?> DeletePillAsync(DeletePillRequest request);
        
        /// <summary>
        /// Редактировать лекарство
        /// </summary>
        Task<EditPillResponse?> EditPillAsync(EditPillRequest request);
        
        /// <summary>
        /// Получить список лекарств
        /// </summary>
        Task<GetPillListResponse?> GetPillListAsync(GetPillListRequest request);
    }
}
