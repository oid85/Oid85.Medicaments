using Oid85.Medicaments.Application.Interfaces.ApiClients;
using Oid85.Medicaments.Application.Interfaces.Repositories;
using Oid85.Medicaments.Application.Interfaces.Services;
using Oid85.Medicaments.Common.Helpers;
using Oid85.Medicaments.Common.KnownConstants;
using Oid85.Medicaments.Core.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Oid85.Medicaments.Application.Services
{
    /// <inheritdoc />
    public class JobService(
        IMedicamentRepository medicamentRepository,
        IHealthServiceApiClient healthServiceApiClient)
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
                switch (medicament.Alias)
                {
                    case KnownAliases.Canephron:
                        await ProcessCanephron(medicament);
                        break;

                    case KnownAliases.BloodGlucoseTestStrips:
                        await ProcessBloodGlucoseTestStrips(medicament);
                        break;

                    default:
                        await ProcessMedicament(medicament);
                        break;
                }
            }
        }

        /// <summary>
        /// Обработка инкремента медикамента Канефрон (прием с 1 по 10 число каждого месяца)
        /// </summary>
        private async Task ProcessCanephron(Medicament medicament)
        {
            var today = DateOnly.FromDateTime(DateTime.Today);

            var increments = (await medicamentRepository.GetMedicamentIncrementsAsync(medicament.Id))?
                .Where(x => x.Value < 0).ToList();

            if (increments is null || increments.Count == 0)
            {
                if (today.Day >= 1 && today.Day <= 10)
                    if (medicament.Dose.HasValue)                    
                        await medicamentRepository.CreateMedicamentIncrementAsync(
                            medicament.Id, today, -1 * medicament.Dose.Value);
            }

            else
            {
                var dates = DateHelper.GetDates(increments.Last().Date, today)
                    .Where(x => x.Day >=1 && x.Day <= 10).ToList();

                foreach (var date in dates)
                {
                    var incrementsByDate = 
                        (await medicamentRepository.GetMedicamentIncrementByDateAsync(medicament.Id, date))?
                        .Where(x => x.Value < 0).ToList();

                    if (incrementsByDate is null || incrementsByDate is [])
                        if (medicament.Dose.HasValue)
                            await medicamentRepository.CreateMedicamentIncrementAsync(
                                medicament.Id, date, -1 * medicament.Dose.Value);
                }
            }
        }

        /// <summary>
        /// Обработка инкремента тестовых полосок для измерения глюкозы
        /// </summary>
        private async Task ProcessBloodGlucoseTestStrips(Medicament medicament)
        {
            if (DateTime.Now.Hour <= 6)
                return;

            var today = DateOnly.FromDateTime(DateTime.Today);

            var increments = (await medicamentRepository.GetMedicamentIncrementsAsync(medicament.Id))?
                .Where(x => x.Value < 0).ToList();

            if (increments is null || increments.Count == 0)
            {
                var count = await healthServiceApiClient.GetCountGlucoseAsync(today.AddDays(-1));
                await medicamentRepository.CreateMedicamentIncrementAsync(medicament.Id, today, -1 * count);
            }

            else
            {
                var dates = DateHelper.GetDates(increments.Last().Date, today);

                foreach (var date in dates)
                {
                    var incrementsByDate = (await medicamentRepository.GetMedicamentIncrementByDateAsync(medicament.Id, date))?
                        .Where(x => x.Value < 0).ToList();

                    if (incrementsByDate is null || incrementsByDate is [])
                    {
                        var count = await healthServiceApiClient.GetCountGlucoseAsync(date.AddDays(-1));
                        await medicamentRepository.CreateMedicamentIncrementAsync(medicament.Id, date, -1 * count);
                    }
                }
            }
        }

        /// <summary>
        /// Обработка инкремента медикамента
        /// </summary>
        private async Task ProcessMedicament(Medicament medicament)
        {
            var today = DateOnly.FromDateTime(DateTime.Today);

            var increments = (await medicamentRepository.GetMedicamentIncrementsAsync(medicament.Id))?
                .Where(x => x.Value < 0).ToList();
            
            if (increments is null || increments.Count == 0)
            {
                if (medicament.Dose.HasValue)
                    await medicamentRepository.CreateMedicamentIncrementAsync(medicament.Id, today, -1 * medicament.Dose.Value);
            }

            else
            {
                var dates = DateHelper.GetDates(increments.Last().Date, today);

                foreach (var date in dates)
                {
                    var incrementsByDate = (await medicamentRepository.GetMedicamentIncrementByDateAsync(medicament.Id, date))?
                        .Where(x => x.Value < 0).ToList();

                    if (incrementsByDate is null || incrementsByDate is [])
                        if (medicament.Dose.HasValue)
                            await medicamentRepository.CreateMedicamentIncrementAsync(medicament.Id, date, -1 * medicament.Dose.Value);
                }
            }
        }
    }
}
