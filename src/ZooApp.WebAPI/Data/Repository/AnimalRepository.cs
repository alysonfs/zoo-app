using Microsoft.EntityFrameworkCore;
using ZooApp.WebAPI.Controller.Contract;
using ZooApp.WebAPI.Data;
using ZooApp.WebAPI.Data.Contract;
using ZooApp.WebAPI.Data.Model;
using ZooApp.WebAPI.Data.Repository;
using ZooApp.WebAPI.Domain;

namespace ZooApp.WebAPI.Repository
{
    public class AnimalRepository : RepositoryBase , IAnimalRepository
    {
        public AnimalRepository(ZooContext context, IUUIDGererator uuidGenerator): base(context, uuidGenerator) { }

        public async Task<IEnumerable<Animal>> GetAnimals()
        {
            var databaseAnimals = await _context.Animals.ToListAsync();
            return databaseAnimals;
        }

         public async Task<IEnumerable<Animal>> GetAnimalsByZooUUID(string zooUUID)
        {
            if(string.IsNullOrEmpty(zooUUID))
            {
                throw new ArgumentNullException(nameof(zooUUID));
            }

            var query = from animal in _context.Animals
                        join zoo in _context.Zoos on animal.ZooUUID equals zoo.UUID
                        where zoo.UUID == zooUUID
                        select animal;

            var databaseAnimals = await query.ToListAsync();
            return databaseAnimals;
        }

        public async Task<Animal?> GetAnimalByID(int id)
        {
            var databaseAnimal = await _context.Animals.FirstOrDefaultAsync(a => a.ID == id);
            return databaseAnimal;
        }

        public async Task<Animal?> GetAnimalByUUID(string uuid)
        {
            var databaseAnimal = await _context.Animals.FirstOrDefaultAsync(a => a.UUID == uuid);
            return databaseAnimal;
        }

        public async Task<Animal> AddAnimal(string zooUUID, Animal animal)
        {
            var uuidGenerator = _uuidGenerator.Generate();
            var newAnimal = new AnimalModel
            {
                Name = animal.Name,
                UUID = uuidGenerator,
                Species = animal.Species,
                DateOfBirth = animal.DateOfBirth,
                TypeSound = animal.TypeSound,
                ImageUrl = animal.ImageUrl,
                SoundUrl = animal.SoundUrl,
                SoundFileName = animal.SoundFileName,
                ZooUUID = zooUUID
            };

            await _context.Animals.AddAsync(newAnimal);

            await _context.SaveChangesAsync();

            return newAnimal;
        }
    }
}