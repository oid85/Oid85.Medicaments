namespace Oid85.Medicaments.Core.Models.Base;

public class AuditableModel : BaseModel
{
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

    public DateTime DeletedAt { get; set; } = DateTime.MinValue.ToUniversalTime();

    public bool IsDeleted { get; set; } = false;
}