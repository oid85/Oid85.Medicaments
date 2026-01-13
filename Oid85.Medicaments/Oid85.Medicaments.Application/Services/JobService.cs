using Oid85.Medicaments.Application.Interfaces.Repositories;
using Oid85.Medicaments.Application.Interfaces.Services;
using Oid85.Medicaments.Common.Helpers;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Oid85.Medicaments.Application.Services
{
    /// <inheritdoc />
    public class JobService(
        IMedicamentRepository medicamentRepository)
        : IJobService
    {
        /// <inheritdoc />
        public async Task UpdateReserveAsync()
        {
            var medicaments = await medicamentRepository.GetMedicamentsAsync();

            if (medicaments is null) 
                return;

            foreach (var medicament in medicaments)
            {
                var increments = (await medicamentRepository.GetMedicamentIncrementsAsync(medicament.Id))?
                    .Where(x => x.Value < 0).ToList();

                var today = DateOnly.FromDateTime(DateTime.Today);

                if (increments is null || increments.Count == 0)
                {
                    if (medicament.Dose.HasValue)
                        await medicamentRepository.CreateMedicamentIncrementAsync(
                            medicament.Id, today, -1 * medicament.Dose.Value);  
                }

                else
                {
                    var lastIncrement = increments.Last();
                    var lastDate = lastIncrement.Date;

                    var dates = DateHelper.GetDates(lastDate, today);

                    foreach (var date in dates)
                    {
                        var incrementsByDate = (await medicamentRepository.GetMedicamentIncrementByDateAsync(medicament.Id, date))?
                            .Where(x => x.Value < 0).ToList();

                        if (incrementsByDate is null || incrementsByDate is [])
                            if (medicament.Dose.HasValue)
                                await medicamentRepository.CreateMedicamentIncrementAsync(
                                    medicament.Id, date, -1 * medicament.Dose.Value);
                    }
                }
            }
        }
    }
}
