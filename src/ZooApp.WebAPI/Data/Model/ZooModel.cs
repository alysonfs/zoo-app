using System.ComponentModel.DataAnnotations;
using ZooApp.WebAPI.Domain;

namespace ZooApp.WebAPI.Data.Model
{
    public class ZooModel : Zoo
    {
        [Key]
        public required new string UUID { get; set; }
        public List<AnimalModel>? Animals { get; set; }
        public List<GuestModel>? Guests { get; set; }    
    }
}