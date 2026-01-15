using Oid85.Medicaments.Application.Interfaces.Repositories;
using Oid85.Medicaments.Application.Interfaces.Services;
using Oid85.Medicaments.Core.Models;
using Oid85.Medicaments.Core.Requests;
using Oid85.Medicaments.Core.Responses;

namespace Oid85.Medicaments.Application.Services
{
    /// <inheritdoc />
    internal class MedicamentService(
        IMedicamentRepository medicamentRepository) 
        : IMedicamentService
    {
        /// <inheritdoc />
        public async Task<AddMedicamentResponse?> AddMedicamentAsync(AddMedicamentRequest request)
        {
            var id = await medicamentRepository.CreateMedicamentIncrementAsync(
                request.Id, DateOnly.FromDateTime(DateTime.Today), request.Value);

            if (id is null)
                return null;

            var response = new AddMedicamentResponse
            {
                Id = id.Value
            };

            return response;
        }

        /// <inheritdoc />
        public async Task<CreateMedicamentResponse?> CreateMedicamentAsync(CreateMedicamentRequest request)
        {
            var model = new Medicament
            {
                Name = request.Name,
                Dose = request.Dose,
                Alias = request.Alias,
            };

            var id = await medicamentRepository.CreateMedicamentAsync(model);

            if (id is null)
                return null;

            var response = new CreateMedicamentResponse
            {
                Id = id.Value
            };

            return response;
        }

        /// <inheritdoc />
        public async Task<DeleteMedicamentResponse?> DeleteMedicamentAsync(DeleteMedicamentRequest request)
        {
            var id = await medicamentRepository.DeleteMedicamentAsync(request.Id);

            if (id is null)
                return null;

            var response = new DeleteMedicamentResponse
            {
                Id = id.Value
            };

            return response;
        }

        /// <inheritdoc />
        public async Task<EditMedicamentResponse?> EditMedicamentAsync(EditMedicamentRequest request)
        {
            var model = new Medicament
            {
                Id = request.Id,
                Name = request.Name,
                Alias = request.Alias,
                Dose = request.Dose
            };

            var id = await medicamentRepository.EditMedicamentAsync(model);

            if (id is null)
                return null;

            var response = new EditMedicamentResponse
            {
                Id = id.Value
            };

            return response;
        }

        /// <inheritdoc />
        public async Task<GetMedicamentListResponse?> GetMedicamentListAsync(GetMedicamentListRequest request)
        {
            var medicaments = await medicamentRepository.GetMedicamentsAsync();

            if (medicaments is null)
                return null;

            var response = new GetMedicamentListResponse { Medicaments = [] };

            var medicamentItems = new List<GetMedicamentListItemResponse>();

            foreach ( var medicament in medicaments )
            {
                var reserve = await medicamentRepository.GetMedicamentReserveAsync(medicament.Id);

                medicamentItems.Add(
                    new GetMedicamentListItemResponse
                    {
                        Id= medicament.Id,
                        Name = medicament.Name,
                        Dose = medicament.Dose,
                        Alias = medicament.Alias,
                        Reserve = reserve
                    });
            }

            response.Medicaments = medicamentItems.OrderBy(x => x.Reserve).ToList();

            return response;
        }        
    }
}
