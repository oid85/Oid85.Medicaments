using Oid85.Medicaments.Core.Models.Base;

namespace Oid85.Medicaments.Core.Models
{
    /// <summary>
    /// Приход-расход лекарства
    /// </summary>
    public class PillIncrement : AuditableModel
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
        /// Запас
        /// </summary>
        public int Reserve { get; set; }

        /// <summary>
        /// Лекарство
        /// </summary>
        public Pill Pill { get; set; }
    }
}
