using Microsoft.AspNetCore.Mvc;
using ZooApp.WebAPI.Controller.Contract;
using ZooApp.WebAPI.Controller.DTO;
using ZooApp.WebAPI.Domain;

namespace ZooApp.WebAPI.Controller
{
    [ApiController]
    [Route("[controller]")]
    public class AnimalController : ControllerBase
    {
        private readonly IAnimalFileRepository _animalFileRepository;
        private readonly IAnimalRepository _animalRepository;

        public AnimalController( IAnimalFileRepository animalFileRepository, IAnimalRepository animalRepository)
        {
            _animalFileRepository = animalFileRepository;
            _animalRepository = animalRepository;
        }
                
        [HttpGet("Predefined")]        
        public async Task<IEnumerable<Animal>> GetAnimalPredefined()
        {
            var animals = await _animalFileRepository.GetAnimals();
            return animals;
        }

        [HttpGet("List")]
        public async Task<IEnumerable<Animal>> GetAnimalListByZooId(string zooUUID)
        {
            var animals = await _animalRepository.GetAnimalsByZooUUID(zooUUID);
            return animals;
        }

        [HttpPost("Add")]
        public async Task<Animal> AddAnimal(AddAnimalPayload payload)
        {
            var animalAdded = await _animalRepository.AddAnimal(payload.ZooUUID, new Animal() {
                Name = payload.Name,
                Species = payload.Species,
                DateOfBirth = payload.DateOfBirth,
                TypeSound = payload.TypeSound
            });

            return animalAdded;
        }

        [HttpGet("{uuid}")]
        public async Task<ActionResult<Animal?>> GetAnimal(string uuid)
        {
            var animal = await _animalRepository.GetAnimalByUUID(uuid);
            return animal;
        }
    }
}