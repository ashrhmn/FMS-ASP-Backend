namespace Web_API.DTOs
{
    public class TransportDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? MaximumSeat { get; set; }
        public int? CreatedBy { get; set; }
    }
}