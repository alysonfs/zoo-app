using System.ComponentModel.DataAnnotations;

namespace ZooApp.WebAPI.Controller.DTO
{
    public class AddAnimalInput()
    {
        [Required(ErrorMessage = "O nome do animal é obrigatório")]
        public required string Name { get; set; }
        [Required(ErrorMessage = "A espécie do animal é obrigatória")]
        public required string Species { get; set; }
        [Required(ErrorMessage = "A data de nascimento do animal é obrigatória")]
        public required DateTime DateOfBirth { get; set; }
        [Required(ErrorMessage = "O tipo de som do animal é obrigatório")]
        public string? TypeSound { get; set; }
        public string? ImageUrl { get; set; }
        public string? SoundUrl { get; set; }
        public string? SoundFileName { get; set; }
    }
}