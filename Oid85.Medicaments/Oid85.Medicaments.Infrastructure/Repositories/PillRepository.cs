using Microsoft.EntityFrameworkCore;
using Oid85.Medicaments.Application.Interfaces.Repositories;
using Oid85.Medicaments.Core.Models;
using Oid85.Medicaments.Core.Requests;
using Oid85.Medicaments.Infrastructure.Entities;

namespace Oid85.Medicaments.Infrastructure.Repositories
{
    /// <inheritdoc />
    public class PillRepository(
        IDbContextFactory<MedicamentsContext> contextFactory)
        : IPillRepository
    {
        /// <inheritdoc />
        public async Task<Guid?> CreatePillAsync(Pill model)
        {
            await using var context = await contextFactory.CreateDbContextAsync();

            var entity = new PillEntity
            {
                Id = Guid.NewGuid(),
                Name = model.Name,
                Shedule = model.Shedule,
                Dose = model.Dose
            };

            await context.AddAsync(entity);
            await context.SaveChangesAsync();

            return entity.Id;
        }

        /// <inheritdoc />
        public async Task<Guid?> CreatePillIncrementAsync(Guid pillId, int number)
        {
            await using var context = await contextFactory.CreateDbContextAsync();

            var pillEntity = await context.PillEntities.FirstOrDefaultAsync(x => x.Id == pillId);

            if (pillEntity is null)
                return null;

            var pillIncrementEntity = await context.PillIncrementEntities
                .Include(x => x.Pill)
                .Where(x => x.Pill.Id == pillId)
                .OrderBy(x => x.Date)
                .LastOrDefaultAsync();

            var prevReserve = pillIncrementEntity is null ? 0 : pillIncrementEntity.Reserve;

            var entity = new PillIncrementEntity
            {
                Id = Guid.NewGuid(),
                Pill = pillEntity,
                Reserve = prevReserve + number
            };

            await context.AddAsync(entity);
            await context.SaveChangesAsync();

            return entity.Id;
        }

        /// <inheritdoc />
        public async Task<Guid?> DeletePillAsync(Guid id)
        {
            await using var context = await contextFactory.CreateDbContextAsync();

            await context.PillEntities.Where(x => x.Id == id).ExecuteDeleteAsync();
            await context.SaveChangesAsync();

            return id;
        }

        /// <inheritdoc />
        public async Task<Guid?> EditPillAsync(Pill model)
        {
            await using var context = await contextFactory.CreateDbContextAsync();

            await context.PillEntities
                .Where(x => x.Id == model.Id)
                .ExecuteUpdateAsync(x => x
                        .SetProperty(entity => entity.Name, model.Name)
                        .SetProperty(entity => entity.Shedule, model.Shedule)
                        .SetProperty(entity => entity.Dose, model.Dose));

            await context.SaveChangesAsync();

            return model.Id;
        }

        /// <inheritdoc />
        public async Task<int> GetPillReserveAsync(Guid id)
        {
            await using var context = await contextFactory.CreateDbContextAsync();

            var entity = await context.PillIncrementEntities
                .Include(x => x.Pill)
                .Where(x => x.Pill.Id == id)
                .OrderBy(x => x.Date)
                .LastOrDefaultAsync();

            if (entity is not null)
                return entity.Reserve;

            return 0;
        }

        /// <inheritdoc />
        public async Task<List<Pill>?> GetPillsAsync()
        {
            await using var context = await contextFactory.CreateDbContextAsync();

            var entities = context.PillEntities.AsQueryable();

            if (entities is null)
                return null;

            entities = entities.OrderBy(x => x.Name);

            var filteredEntities = await entities.AsNoTracking().ToListAsync();

            if (filteredEntities is null)
                return null;

            var result = entities
                .Select(x => new Pill
                {
                    Id = x.Id,
                    Name = x.Name,
                    Shedule = x.Shedule,
                    Dose = x.Dose
                })
                .ToList();

            return result;
        }
    }
}
