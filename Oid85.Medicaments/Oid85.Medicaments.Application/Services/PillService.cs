using System.Reflection;
using Oid85.Medicaments.Application.Interfaces.Repositories;
using Oid85.Medicaments.Application.Interfaces.Services;
using Oid85.Medicaments.Core.Models;
using Oid85.Medicaments.Core.Requests;
using Oid85.Medicaments.Core.Responses;

namespace Oid85.Medicaments.Application.Services
{
    /// <inheritdoc />
    internal class PillService(
        IPillRepository pillRepository) 
        : IPillService
    {
        /// <inheritdoc />
        public async Task<AddPillResponse?> AddPillAsync(AddPillRequest request)
        {
            var id = await pillRepository.CreatePillIncrementAsync(request.PillId, request.Number);

            if (id is null)
                return null;

            var response = new AddPillResponse
            {
                Id = id.Value
            };

            return response;
        }

        /// <inheritdoc />
        public async Task<CreatePillResponse?> CreatePillAsync(CreatePillRequest request)
        {
            var model = new Pill
            {
                Name = request.Name,
                Shedule = request.Shedule,
                Dose = request.Dose
            };

            var id = await pillRepository.CreatePillAsync(model);

            if (id is null)
                return null;

            var response = new CreatePillResponse
            {
                Id = id.Value
            };

            return response;
        }

        /// <inheritdoc />
        public async Task<DeletePillResponse?> DeletePillAsync(DeletePillRequest request)
        {
            var id = await pillRepository.DeletePillAsync(request.Id);

            if (id is null)
                return null;

            var response = new DeletePillResponse
            {
                Id = id.Value
            };

            return response;
        }

        /// <inheritdoc />
        public async Task<EditPillResponse?> EditPillAsync(EditPillRequest request)
        {
            var model = new Pill
            {
                Name = request.Name,
                Shedule = request.Shedule,
                Dose = request.Dose
            };

            var id = await pillRepository.EditPillAsync(model);

            if (id is null)
                return null;

            var response = new EditPillResponse
            {
                Id = id.Value
            };

            return response;
        }

        /// <inheritdoc />
        public async Task<GetPillListResponse?> GetPillListAsync(GetPillListRequest request)
        {
            var pills = await pillRepository.GetPillsAsync();

            if (pills is null)
                return null;

            var response = new GetPillListResponse { Pills = [] };

            foreach ( var pill in pills )
            {
                var reserve = await pillRepository.GetPillReserveAsync(pill.Id);

                response.Pills.Add(
                    new GetPillListItemResponse
                    {
                        Id= pill.Id,
                        Name = pill.Name,
                        Shedule= pill.Shedule,
                        Dose = pill.Dose,
                        Reserve = reserve
                    });
            }

            return response;
        }        
    }
}
