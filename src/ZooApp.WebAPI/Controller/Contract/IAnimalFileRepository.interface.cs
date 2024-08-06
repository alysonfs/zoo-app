using ZooApp.WebAPI.Domain;

namespace ZooApp.WebAPI.Controller.Contract
{
    public interface IAnimalFileRepository
    {
        public Task<List<Animal>> GetAnimals();
    }
}