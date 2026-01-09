namespace Oid85.Medicaments.Core.Requests
{
    public class EditMedicamentRequest
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int? Dose { get; set; }
        public string? Alias { get; set; }
    }
}
