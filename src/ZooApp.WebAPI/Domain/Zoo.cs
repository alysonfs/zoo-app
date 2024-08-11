namespace ZooApp.WebAPI.Domain
{
    public class Zoo
    {
        public int? ID { get; set; }
        public string? UUID { get; set; }
        public required string Name { get; set; }
        public string? Address { get; set; }
        public int? AnimalCount { get; set; }
        public int? GuestCount { get; set; }
    }
}