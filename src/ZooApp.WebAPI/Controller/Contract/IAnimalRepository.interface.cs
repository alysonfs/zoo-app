using ZooApp.WebAPI.Domain;

namespace ZooApp.WebAPI.Controller.Contract
{
    public interface IAnimalRepository
    {
        Task<IEnumerable<Animal>> GetAnimals();
        Task<Animal?> GetAnimalByID(int id);
        Task<Animal?> GetAnimalByUUID(string uuid);
        Task<Animal> AddAnimal(Animal animal);
    }
}