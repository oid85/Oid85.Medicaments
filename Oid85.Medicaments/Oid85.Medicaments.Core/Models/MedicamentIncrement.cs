using Oid85.Medicaments.Core.Models.Base;

namespace Oid85.Medicaments.Core.Models
{
    /// <summary>
    /// Приход-расход лекарства
    /// </summary>
    public class MedicamentIncrement : AuditableModel
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
        public Medicament Medicament { get; set; }
    }
}
