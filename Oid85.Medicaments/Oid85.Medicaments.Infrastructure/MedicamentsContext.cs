using Microsoft.EntityFrameworkCore;
using Oid85.Medicaments.Common.KnownConstants;
using Oid85.Medicaments.Infrastructure.Entities;
using Oid85.Medicaments.Infrastructure.Schemas;

namespace Oid85.Medicaments.Infrastructure;

public class MedicamentsContext(DbContextOptions<MedicamentsContext> options) : DbContext(options)
{
    public DbSet<PillEntity> PillEntities { get; set; }
    public DbSet<PillIncrementEntity> PillIncrementEntities{ get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder
            .HasDefaultSchema(KnownDatabaseSchemas.Default)
            .ApplyConfigurationsFromAssembly(
                typeof(MedicamentsContext).Assembly,
                type => type
                    .GetInterface(typeof(IMedicamentsSchema).ToString()) != null)
            .UseIdentityAlwaysColumns();
    }    
}