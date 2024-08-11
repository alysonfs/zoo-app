using ZooApp.WebAPI.Domain;

namespace ZooApp.WebAPI.Controller.Contract
{
    public interface IAnimalRepository
    {
        Task<IEnumerable<Animal>> GetAnimals();
        Task<IEnumerable<Animal>> GetAnimalsByZooUUID(string zooUUID);
        Task<Animal?> GetAnimalByID(int id);
        Task<Animal?> GetAnimalByUUID(string uuid);
        Task<Animal> AddAnimal(string zooUUID, Animal animal);
    }
}