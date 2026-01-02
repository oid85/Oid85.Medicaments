using Oid85.Medicaments.Application.Interfaces.Repositories;
using Oid85.Medicaments.Application.Interfaces.Services;
using Oid85.Medicaments.Core.Requests;
using Oid85.Medicaments.Core.Responses;

namespace Oid85.Medicaments.Application.Services
{
    /// <inheritdoc />
    internal class PillService(
        IPillRepository pillRepository) : IPillService
    {
        public Task<AddPillResponse> AddPillAsync(AddPillRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<CreatePillResponse> CreatePillAsync(CreatePillRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<DeletePillResponse> DeletePillAsync(DeletePillRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<EditPillResponse> EditPillAsync(EditPillRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<GetPillListResponse> GetPillListAsync(GetPillListRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
