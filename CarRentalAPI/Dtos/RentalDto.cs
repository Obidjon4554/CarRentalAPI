namespace CarRentalAPI.Dtos
{
    public class RentalDto
    {
        public int Id { get; set; }
        public string CarInfo { get; set; } = default!;
        public string CustomerName { get; set; } = default!;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
