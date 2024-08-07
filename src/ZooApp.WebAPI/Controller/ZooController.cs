using Microsoft.AspNetCore.Mvc;
using ZooApp.WebAPI.Controller.Contract;
using ZooApp.WebAPI.Domain;
using static ZooApp.WebAPI.Controller.DTO.ZooController;

namespace ZooApp.WebAPI.Controller
{
    [ApiController]
    [Route("[controller]")]
    public class ZooController : ControllerBase
    {
        private readonly IZooRepository _zooRepository;

        public ZooController(IZooRepository zooRepository)
        {
            _zooRepository = zooRepository;
        }

        [HttpGet("List")]
        public async Task<IEnumerable<Zoo>> GetZoos()
        {
            var zoos = await _zooRepository.GetZoos();
            return zoos;
        }

        [HttpPost("Add")]
        public async Task<Zoo> AddZoo(AddZooPayload payload)
        {
            var zooAdded = await _zooRepository.AddZoo(new Zoo() {
                Name = payload.Name,
                Address = payload.Address
            });

            return zooAdded;
        }   
        
        [HttpGet("{uuid}")]
        public async Task<ActionResult<Zoo?>> GetZoo(string uuid)
        {
            var zoo = await _zooRepository.GetZooByUUID(uuid);
            return zoo;
        }

    }
}