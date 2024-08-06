using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZooApp.WebAPI.Domain;

public class Animal
{
    public int? ID { get; set; }
    public string? UUID { get; set; }
    public required string Name { get; set; }
    public string? Species { get; set; }
    public DateTime? DateOfBirth { get; set; }
    public string? TypeSound { get; set; }
    public Image? Image { get; set; }
    public Sound? Sound { get; set; }

    public Animal()
    {
        this.DateOfBirth = DateTime.Now;
    }

    public virtual string MakeSound()
    {
        return $"The {this.TypeSound} makes a sound";
    }
}
