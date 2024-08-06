using System.ComponentModel.DataAnnotations.Schema;
using ZooApp.WebAPI.Domain;

namespace ZooApp.WebAPI.Data.Model
{
    public class AnimalModel : Animal
    {
        [NotMapped]
        public new Image? Image { get; set; }
        [NotMapped]
        public new Sound? Sound { get; set; }
        
        public string? ImageUrl { get; set; }
        public string? SoundUrl { get; set; }
        public string? SoundFileName { get; set; }
    }
}