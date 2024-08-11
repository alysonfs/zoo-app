namespace ZooApp.WebAPI.Domain;

public class Animal
{
    public int? ID { get; set; }
    public string? UUID { get; set; }
    public required string Name { get; set; }
    public string? Species { get; set; }
    public DateTime? DateOfBirth { get; set; }
    public string? TypeSound { get; set; }
    public string? ImageUrl { get; set; }
    public string? SoundUrl { get; set; }
    public string? SoundFileName { get; set; }

    public Animal()
    {
        this.DateOfBirth = DateTime.Now;
    }
}
