using Oid85.Medicaments.Core.Models.Base;

namespace Oid85.Medicaments.Core.Models
{
    /// <summary>
    /// Лекарство
    /// </summary>
    public class Medicament : AuditableModel
    {
        /// <summary>
        /// Наименование
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Доза
        /// </summary>
        public int? Dose { get; set; }

        /// <summary>
        /// Псевдоним
        /// </summary>
        public string? Alias { get; set; }
    }
}
