using Microsoft.EntityFrameworkCore;
using Oid85.Medicaments.Application.Interfaces.Repositories;
using Oid85.Medicaments.Core.Models;
using Oid85.Medicaments.Infrastructure.Entities;

namespace Oid85.Medicaments.Infrastructure.Repositories
{
    /// <inheritdoc />
    public class MedicamentRepository(
        IDbContextFactory<MedicamentsContext> contextFactory)
        : IMedicamentRepository
    {
        /// <inheritdoc />
        public async Task<Guid?> CreateMedicamentAsync(Medicament model)
        {
            await using var context = await contextFactory.CreateDbContextAsync();

            var entity = new MedicamentEntity
            {
                Id = Guid.NewGuid(),
                Name = model.Name,                
                Dose = model.Dose,
                Alias = model.Alias
            };

            await context.AddAsync(entity);
            await context.SaveChangesAsync();

            return entity.Id;
        }

        /// <inheritdoc />
        public async Task<Guid?> CreateMedicamentIncrementAsync(Guid medicamentId, DateOnly date, int value)
        {
            await using var context = await contextFactory.CreateDbContextAsync();

            var medicamentEntity = await context.MedicamentEntities.FirstOrDefaultAsync(x => x.Id == medicamentId);

            if (medicamentEntity is null)
                return null;

            var medicamentIncrementEntity = await context.MedicamentIncrementEntities
                .Include(x => x.Medicament)
                .Where(x => x.Medicament.Id == medicamentId)
                .OrderBy(x => x.CreatedAt)
                .LastOrDefaultAsync();

            var prevReserve = medicamentIncrementEntity is null ? 0 : medicamentIncrementEntity.Reserve;

            var entity = new MedicamentIncrementEntity
            {
                Id = Guid.NewGuid(),
                Date = date,
                Medicament = medicamentEntity,
                Reserve = prevReserve + value
            };

            await context.AddAsync(entity);
            await context.SaveChangesAsync();

            return entity.Id;
        }

        /// <inheritdoc />
        public async Task<Guid?> DeleteMedicamentAsync(Guid id)
        {
            await using var context = await contextFactory.CreateDbContextAsync();

            await context.MedicamentEntities.Where(x => x.Id == id).ExecuteDeleteAsync();
            await context.SaveChangesAsync();

            return id;
        }

        /// <inheritdoc />
        public async Task<Guid?> EditMedicamentAsync(Medicament model)
        {
            await using var context = await contextFactory.CreateDbContextAsync();

            await context.MedicamentEntities
                .Where(x => x.Id == model.Id)
                .ExecuteUpdateAsync(x => x
                        .SetProperty(entity => entity.Name, model.Name)
                        .SetProperty(entity => entity.Dose, model.Dose)
                        .SetProperty(entity => entity.Alias, model.Alias));

            await context.SaveChangesAsync();

            return model.Id;
        }

        public async Task<List<MedicamentIncrement>?> GetMedicamentIncrementByDateAsync(Guid medicamentId, DateOnly date)
        {
            await using var context = await contextFactory.CreateDbContextAsync();

            var entities = await context.MedicamentIncrementEntities
                .Include(x => x.Medicament)
                .Where(x => x.Medicament.Id == medicamentId)
                .Where(x => x.Date == date)
                .OrderBy(x => x.CreatedAt)
                .ToListAsync();

            if (entities is null)
                return null;

            var models = entities.Select(x => new MedicamentIncrement
            {
                Id = x.Id,
                Date = x.Date,
                Reserve = x.Reserve,
                Medicament = new Medicament
                {
                    Id = x.Medicament.Id,
                    Name = x.Medicament.Name,
                    Dose = x.Medicament.Dose,
                    Alias = x.Medicament.Alias

                }
            }).ToList();

            return models;
        }

        /// <inheritdoc />
        public async Task<List<MedicamentIncrement>?> GetMedicamentIncrementsAsync(Guid medicamentId)
        {
            await using var context = await contextFactory.CreateDbContextAsync();

            var entities = await context.MedicamentIncrementEntities
                .Include(x => x.Medicament)
                .Where(x => x.Medicament.Id == medicamentId)
                .OrderBy(x => x.CreatedAt)
                .ToListAsync();

            if (entities is null)
                return null;

            var models = entities.Select(x => new MedicamentIncrement
            {
                Id = x.Id,
                Date = x.Date,
                Reserve = x.Reserve,
                Medicament = new Medicament
                {
                    Id = x.Medicament.Id,
                    Name = x.Medicament.Name,
                    Dose = x.Medicament.Dose,
                    Alias = x.Medicament.Alias

                }
            }).ToList();

            return models;
        }

        /// <inheritdoc />
        public async Task<int> GetMedicamentReserveAsync(Guid id)
        {
            await using var context = await contextFactory.CreateDbContextAsync();

            var entity = await context.MedicamentIncrementEntities
                .Include(x => x.Medicament)
                .Where(x => x.Medicament.Id == id)
                .OrderBy(x => x.CreatedAt)
                .LastOrDefaultAsync();

            if (entity is not null)
                return entity.Reserve;

            return 0;
        }

        /// <inheritdoc />
        public async Task<List<Medicament>?> GetMedicamentsAsync()
        {
            await using var context = await contextFactory.CreateDbContextAsync();

            var entities = context.MedicamentEntities.AsQueryable();

            if (entities is null)
                return null;

            entities = entities.OrderBy(x => x.Name);

            var filteredEntities = await entities.AsNoTracking().ToListAsync();

            if (filteredEntities is null)
                return null;

            var result = entities
                .Select(x => new Medicament
                {
                    Id = x.Id,
                    Name = x.Name,                    
                    Dose = x.Dose,
                    Alias = x.Alias
                })
                .ToList();

            return result;
        }
    }
}
