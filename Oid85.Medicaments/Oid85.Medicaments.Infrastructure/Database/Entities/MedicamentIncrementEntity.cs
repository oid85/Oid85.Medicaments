using Oid85.Medicaments.Infrastructure.Database.Entities.Base;

namespace Oid85.Medicaments.Infrastructure.Database.Entities
{
    /// <summary>
    /// Приход-расход лекарства
    /// </summary>
    public class MedicamentIncrementEntity : AuditableEntity
    {
        /// <summary>
        /// Дата
        /// </summary>
        public DateOnly Date { get; set; }

        /// <summary>
        /// Запас
        /// </summary>
        public int Reserve { get; set; }

        /// <summary>
        /// Изменение
        /// </summary>
        public int Value { get; set; }

        /// <summary>
        /// Лекарство
        /// </summary>
        public MedicamentEntity Medicament { get; set; }
    }
}
