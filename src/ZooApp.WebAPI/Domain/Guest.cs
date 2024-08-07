namespace ZooApp.WebAPI.Domain
{
    public class Guest
    {
        public int? ID { get; set; }
        public string? UUID { get; set; }
        public required string Name { get; set; }
        public int? Age { get; set; }
    }
}