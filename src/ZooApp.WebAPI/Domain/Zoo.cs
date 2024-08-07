namespace ZooApp.WebAPI.Domain
{
    public class Zoo
    {
        public required string Name { get; set; }

        public List<Animal>? Animals { get; set; }
        public List<Guest>? Guests { get; set; }
    }
}