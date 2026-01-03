using Oid85.Medicaments.Core.Requests;
using Oid85.Medicaments.Core.Responses;

namespace Oid85.Medicaments.Application.Interfaces.Services
{
    /// <summary>
    /// Сервис лекарств
    /// </summary>
    public interface IMedicamentService
    {
        /// <summary>
        /// Добавить запас лекарств
        /// </summary>
        Task<AddMedicamentResponse?> AddMedicamentAsync(AddMedicamentRequest request);
        
        /// <summary>
        /// Добавить лекарство
        /// </summary>
        Task<CreateMedicamentResponse?> CreateMedicamentAsync(CreateMedicamentRequest request);
        
        /// <summary>
        /// Удалить лекарство
        /// </summary>
        Task<DeleteMedicamentResponse?> DeleteMedicamentAsync(DeleteMedicamentRequest request);
        
        /// <summary>
        /// Редактировать лекарство
        /// </summary>
        Task<EditMedicamentResponse?> EditMedicamentAsync(EditMedicamentRequest request);
        
        /// <summary>
        /// Получить список лекарств
        /// </summary>
        Task<GetMedicamentListResponse?> GetMedicamentListAsync(GetMedicamentListRequest request);
    }
}
