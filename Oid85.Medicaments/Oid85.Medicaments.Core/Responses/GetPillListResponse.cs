namespace Oid85.Medicaments.Core.Responses
{
    public class GetPillListResponse
    {
        public List<GetPillListItemResponse> Pills { get; set; }
    }

    public class GetPillListItemResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Shedule { get; set; }
        public int Dose { get; set; }
        public int Reserve { get; set; }
    }
}
