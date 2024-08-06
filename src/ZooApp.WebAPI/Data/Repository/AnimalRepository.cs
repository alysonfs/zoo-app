using Microsoft.EntityFrameworkCore;
using ZooApp.WebAPI.Controller.Contract;
using ZooApp.WebAPI.Data;
using ZooApp.WebAPI.Data.Contract;
using ZooApp.WebAPI.Data.Model;
using ZooApp.WebAPI.Domain;

namespace ZooApp.WebAPI.Repository
{
    public class AnimalRepository : IAnimalRepository
    {
        private readonly ILogger<AnimalRepository> _logger;
        private readonly ZooContext _context;
        private readonly IUUIDGererator _uuidGenerator;

        public AnimalRepository(ILogger<AnimalRepository> logger, ZooContext context, IUUIDGererator uuidGenerator)
        {
            _logger = logger;
            _context = context;
            _uuidGenerator = uuidGenerator;
        }

        public async Task<IEnumerable<Animal>> GetAnimals()
        {
            var databaseAnimals = await _context.Animals.ToListAsync();
            List<Animal> animals = [];
            databaseAnimals.ForEach(a =>
            {
                var animal = (Animal) a;
                animal.Image = new Image() { 
                    Url = a.ImageUrl ?? string.Empty
                };

                animal.Sound = new Sound() { 
                    Url = a.SoundUrl ?? string.Empty, 
                    FileName = a.SoundFileName ?? string.Empty
                };

                animals.Add(animal);
            });
            
            return animals;
        }

        public async Task<Animal?> GetAnimalByID(int id)
        {
            var databaseAnimal = await _context.Animals.FirstOrDefaultAsync(a => a.ID == id);
            if (databaseAnimal != null)
            {
                var animalResult = (Animal) databaseAnimal;
                animalResult.Image = new Image() { 
                    Url = databaseAnimal.ImageUrl ?? string.Empty
                };

                animalResult.Sound = new Sound() { 
                    Url = databaseAnimal.SoundUrl ?? string.Empty, 
                    FileName = databaseAnimal.SoundFileName ?? string.Empty
                };
                return animalResult;
            }

            return null;
        }

        public async Task<Animal?> GetAnimalByUUID(string uuid)
        {
            var databaseAnimal = await _context.Animals.FirstOrDefaultAsync(a => a.UUID == uuid);
            if (databaseAnimal != null)
            {
                var animalResult = (Animal) databaseAnimal;
                animalResult.Image = new Image() { 
                    Url = databaseAnimal.ImageUrl ?? string.Empty
                };

                animalResult.Sound = new Sound() { 
                    Url = databaseAnimal.SoundUrl ?? string.Empty, 
                    FileName = databaseAnimal.SoundFileName ?? string.Empty
                };
                return animalResult;
            }

            return null;
        }

        public async Task<Animal> AddAnimal(Animal animal)
        {
            var uuidGenerator = _uuidGenerator.Generate();
            var newAnimal = new AnimalModel
            {
                Name = animal.Name,
                UUID = uuidGenerator,
                Species = animal.Species,
                DateOfBirth = animal.DateOfBirth,
                TypeSound = animal.TypeSound,
                ImageUrl = animal.Image?.Url ?? string.Empty,
                SoundUrl = animal.Sound?.Url ?? string.Empty,
                SoundFileName = animal.Sound?.FileName ?? string.Empty
            };

            await _context.Animals.AddAsync(newAnimal);

            await _context.SaveChangesAsync();

            return newAnimal;
        }
    }
}