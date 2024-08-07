using Microsoft.AspNetCore.Mvc;
using ZooApp.WebAPI.Controller.Contract;
using ZooApp.WebAPI.Controller.DTO;
using ZooApp.WebAPI.Domain;

namespace ZooApp.WebAPI.Controller
{
    [ApiController]
    [Route("[controller]")]
    public class GuestController : ControllerBase
    {
        private readonly IGuestRepository _guestRepository;

        public GuestController(IGuestRepository guestRepository)
        {
            _guestRepository = guestRepository;
        }
        
        [HttpPost("Add")]
        public async Task<Guest> AddGuest(AddGuestPayload payload)
        {
            var guestAdded = await _guestRepository.AddGuest(new Guest() {
                Name = payload.Name,
                Age = payload.Age
            });

            return guestAdded;
        }

        [HttpGet("{uuid}")]
        public async Task<ActionResult<Guest?>> GetGuest(string uuid)
        {
            var guest = await _guestRepository.GetGuestByUUID(uuid);
            return guest;
        }

        [HttpGet("List")]
        public async Task<IEnumerable<Guest>> GetGuests()
        {
            var guests = await _guestRepository.GetGuests();
            return guests;
        }
    }
}