using System.ComponentModel.DataAnnotations;

namespace ZooApp.WebAPI.Controller.DTO
{
    public class ZooController
    {
        public class AddZooPayload
        {
            [Required(ErrorMessage = "O nome do zoológico é obrigatório")]
            public required string Name { get; set; }
            public string? Address { get; set; }
        }
    }
}