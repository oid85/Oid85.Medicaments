using Oid85.Medicaments.Core.Requests;
using Oid85.Medicaments.Core.Responses;

namespace Oid85.Medicaments.Application.Interfaces.Services
{
    /// <summary>
    /// Сервис лекарств
    /// </summary>
    public interface IPillService
    {
        Task<CreatePillResponse> CreatePillAsync(CreatePillRequest request);
        Task<DeletePillResponse> DeletePillAsync(DeletePillRequest request);
        Task<EditPillResponse> EditPillAsync(EditPillRequest request);
        Task<GetPillListResponse> GetPillListAsync(GetPillListRequest request);
    }
}
