using System.ComponentModel.DataAnnotations.Schema;

namespace Oid85.Medicaments.Infrastructure.Entities.Base;

public class AuditableEntity : BaseEntity
{
    [Column(TypeName = "timestamp with time zone")]
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    
    [Column(TypeName = "timestamp with time zone")]
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    
    [Column(TypeName = "timestamp with time zone")]
    public DateTime DeletedAt { get; set; } = DateTime.MinValue.ToUniversalTime();    
    
    public bool IsDeleted { get; set; } = false;
}