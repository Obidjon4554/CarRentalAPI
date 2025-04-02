namespace CarRentalAPI.DataAccess.Entities
{
    public class Car
    {
        public int Id { get; set; }
        public string Make { get; set; } = default!;
        public string Model { get; set; } = default!;
        public int Year { get; set; }
        public decimal DailyRate { get; set; }
        public bool IsAvailable { get; set; }
    }
}
