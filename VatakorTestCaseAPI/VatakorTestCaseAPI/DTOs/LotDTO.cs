namespace VitakorTestCaseAPI.DTOs
{
    public class LotDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int? StartBet { get; set; }
        public bool? Alive { get; set; }
    }
}
