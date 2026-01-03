using Oid85.Medicaments.Core.Models.Base;

namespace Oid85.Medicaments.Core.Models
{
    /// <summary>
    /// Лекарство
    /// </summary>
    public class Pill : AuditableModel
    {
        /// <summary>
        /// Наименование
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Расписание
        /// </summary>
        public string? Shedule { get; set; }

        /// <summary>
        /// Доза
        /// </summary>
        public int? Dose { get; set; }
    }
}
