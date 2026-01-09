using System.ComponentModel.DataAnnotations;
using Oid85.Medicaments.Infrastructure.Entities.Base;

namespace Oid85.Medicaments.Infrastructure.Entities
{
    /// <summary>
    /// Лекарство
    /// </summary>
    public class MedicamentEntity : AuditableEntity
    {
        /// <summary>
        /// Наименование
        /// </summary>
        [MaxLength(500)]
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Доза
        /// </summary>
        public int? Dose { get; set; }

        /// <summary>
        /// Псевдоним
        /// </summary>
        [MaxLength(100)]
        public string? Alias { get; set; }
    }
}
