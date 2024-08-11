using System.ComponentModel.DataAnnotations;
using ZooApp.WebAPI.Domain;

namespace ZooApp.WebAPI.Data.Model
{
    public class GuestModel : Guest 
    {
        [Key]
        public required new string UUID { get; set; }
        public required string ZooUUID { get; set; }
        public ZooModel? Zoo { get; set; }        
    }
}