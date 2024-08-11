using System.ComponentModel.DataAnnotations;

namespace ZooApp.WebAPI.Controller.DTO
{
    public class AddGuestPayload()
    {
        [Required(ErrorMessage = "O nome do visitante é obrigatório")]
        public required string Name { get; set; }
        [Required(ErrorMessage = "A idade do visitante é obrigatória")]
        public required int Age { get; set; }
        [Required(ErrorMessage = "O email do visitante é obrigatório")]
        public required string Email { get; set; }
        [Required(ErrorMessage = "O UUID do zoológico é obrigatório")]
        public required string ZooUUID { get; set; }
    }
}