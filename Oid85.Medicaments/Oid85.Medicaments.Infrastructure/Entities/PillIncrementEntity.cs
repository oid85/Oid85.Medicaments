using Oid85.Medicaments.Infrastructure.Entities.Base;

namespace Oid85.Medicaments.Infrastructure.Entities
{
    /// <summary>
    /// Приход-расход лекарства
    /// </summary>
    public class PillIncrementEntity : AuditableEntity
    {
        /// <summary>
        /// Дата
        /// </summary>
        public DateOnly Date { get; set; }

        /// <summary>
        /// Изменение
        /// </summary>
        public int Delta { get; set; }

        /// <summary>
        /// Лекарство
        /// </summary>
        public PillEntity Pill { get; set; }
    }
}
