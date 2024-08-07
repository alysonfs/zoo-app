using System.ComponentModel.DataAnnotations;
using ZooApp.WebAPI.Domain;

namespace ZooApp.WebAPI.Data.Model
{
    public class AnimalModel : Animal
    {
        [Key]
        public new int ID { get; set; }
    }
}