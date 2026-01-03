namespace Oid85.Medicaments.Core.Responses
{
    public class GetMedicamentListResponse
    {
        public List<GetMedicamentListItemResponse> Medicaments { get; set; }
    }

    public class GetMedicamentListItemResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string? Shedule { get; set; }
        public int? Dose { get; set; }
        public int Reserve { get; set; }
    }
}
