using System.ComponentModel.DataAnnotations;

namespace Oid85.Medicaments.Infrastructure.Database.Entities.Base;

public class BaseEntity
{
    [Key]
    public Guid Id { get; set; }
}